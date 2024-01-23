using Emgu.CV;
using Emgu.CV.Cuda;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Microsoft.WindowsAPICodePack.Dialogs;
using OneOf.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Windows.Forms;
using Tensorflow.Gradients;

namespace OpenCV_Vision_Pro
{
    public partial class LoopStitch : Form
    {   
        private BindingSource bindingSource = new BindingSource();
        private BindingList<string> list = new BindingList<string>();
        private CudaClahe clahe_illuminance = new CudaClahe(2,new Size(8,8));
        private CudaClahe clahe = new CudaClahe(40, new Size(8,8));
        private List<Dictionary<string,int>> PoseDictList = new List<Dictionary<string,int>>();

        public LoopStitch()
        {
            InitializeComponent();
            bindingSource.DataSource = list;
            inputList.DataSource = bindingSource;
        }

        /* Stitch and Blend images column by column
         * |            :                   |
         * |   img1     :       img2        |
         * |            :                   |
         * |____________:___________________|
         *              ^
         *              |__ x
         */
        private CudaImage<Gray, float> AlphaBlendHorizontal(CudaImage<Gray, float> img1, CudaImage<Gray, float> img2, int x, int width, object[] movementY, Dictionary<string,int> PoseDict)
        {
            Console.WriteLine("Blending X.");

            int width_to_blend = (int)(width * 0.1);
            // Ignore the part added manually for alignment to prevent color errors caused by blending
            int U, D;
            if (((string)movementY[0]).Equals("Up"))
            {
                U = (int)movementY[1] + PoseDict["Down"];
                D = img2.Size.Height - PoseDict["Up"];
            }
            else
            {
                U = PoseDict["Down"];
                D = img2.Size.Height - (int)movementY[1];
            }

            // To makesure the width to blend the alpha will not exceed the image width
            if (x + width_to_blend >= img2.Size.Width)
                width_to_blend = img2.Size.Width - x;
            Console.WriteLine("Blending X..");

            CudaImage<Gray, float> src = img2.RowRange(U, D).ColRange(x, x + width_to_blend);
            Size src_shape = src.Size;
            CudaImage<Gray, float> target = img1.RowRange(U, D).ColRange(0, src_shape.Width);
            Console.WriteLine("Blending X...");

            // Create the masks and blend images overlap's part
            create2GradientMask(src_shape, 0, 1, out CudaImage<Gray, float> mask1, out CudaImage<Gray, float> mask2);

            CudaImage<Gray, float> final = new CudaImage<Gray, float>();
            CudaInvoke.BlendLinear(src, target, mask2, mask1, final); //final = src * mask1 + target * mask2
            Console.WriteLine("Blending X....");

            CudaImage<Gray, float> output = new CudaImage<Gray, float>(img2.Size.Height,x+img1.Size.Width);
            img2.ColRange(0,x).CopyTo(output.GetSubRect(new Rectangle(new Point(0,0), img2.ColRange(0, x).Size)));
            img1.CopyTo(output.GetSubRect(new Rectangle(new Point(x, 0), img1.Size)));
            final.CopyTo(output.GetSubRect(new Rectangle(new Point(x,U), final.Size)));
            Console.WriteLine("Blending X.....");

            src.Dispose();
            target.Dispose();
            final.Dispose();
            mask1.Dispose();
            mask2.Dispose();

            return output;
        }

        /* Stitch and Blend images row by row
         * |                        |
         * |          img1          |
         * |........................| <- y
         * |                        |
         * |          img2          |
         * |                        |
         * |________________________|
         */
        private CudaImage<Gray, float> AlphaBlendVertical(CudaImage<Gray, float> img1, CudaImage<Gray, float> img2, int y, int height, object[] movementX, Dictionary<string, int> PoseDict)
        {
            Console.WriteLine("Blending Y.");

            int height_to_blend = (int)(height * 0.1);
            int ignoreCurr = Math.Max(PoseDict["Down"], PoseDict["Up"]);

            // Ignore the part added manually for alignment to prevent color errors caused by blending
            int L, R;
            if (((string)movementX[0]).Equals("Left"))
            {
                L = (int)movementX[1] + PoseDict["Right"];
                R = img2.Size.Width - PoseDict["Left"];
            }
            else
            {
                L = PoseDict["Right"];
                R = img2.Size.Width - (int)movementX[1];
            }

            // To makesure the height to blend the alpha will not exceed the image height
            if (y + height_to_blend >= img2.Size.Height)
                height_to_blend = img2.Size.Height - y;

            Console.WriteLine("Blending Y..");

            CudaImage<Gray, float> src = img2.RowRange(y - height_to_blend, y + height_to_blend).ColRange(L, R);
            Size src_shape = src.Size;
            CudaImage<Gray, float> target = img1.RowRange(0, src_shape.Height - height_to_blend).ColRange(L, R);

            create2GradientMask(new Size(src_shape.Width, src_shape.Height - height_to_blend - ignoreCurr), 0, 1, out CudaImage<Gray, float> mask1, out CudaImage<Gray, float> mask2, false);
            Console.WriteLine("Blending Y...");

            mask1 = ResizeImageAddRowCol(mask1, new Size(src_shape.Width, src_shape.Height), new Point(0, height_to_blend + ignoreCurr));
            mask2 = ResizeImageAddRowCol(mask2, new Size(src_shape.Width, src_shape.Height), new Point(0, height_to_blend + ignoreCurr),1);
            mask1.RowRange(0, height_to_blend + ignoreCurr).SetTo(new MCvScalar(0));
            target = ResizeImageAddRowCol(target, new Size(src_shape.Width, src_shape.Height), new Point(0, height_to_blend));
            Console.WriteLine("Blending Y....");

            CudaImage<Gray, float> final = new CudaImage<Gray, float>();
            CudaInvoke.BlendLinear(src, target, mask2, mask1, final);
            Console.WriteLine("Blending Y.....");

            CudaImage<Gray, float> output = new CudaImage<Gray, float>(y+img1.Size.Height, img2.Size.Width);
            img2.RowRange(0, y).CopyTo(output.GetSubRect(new Rectangle(new Point(0, 0), img2.RowRange(0, y).Size)));
            img1.CopyTo(output.GetSubRect(new Rectangle(new Point(0, y), img1.Size)));
            final.CopyTo(output.GetSubRect(new Rectangle(new Point(L,y-height_to_blend), final.Size)));
            Console.WriteLine("Blending Y......");

            src.Dispose();
            target.Dispose();
            final.Dispose();
            mask1.Dispose();
            mask2.Dispose();

            return output;
        }

        private void Run(object sender, DoWorkEventArgs e)
        {
            if (!CudaInvoke.HasCuda)
            {
                MessageBox.Show("NO CUDA DETECTED");
                return;
            }
            if (list.Count == 0)
                return;
            int width = -1;
            int height = -1;
            CudaImage<Gray, float> PrevOutput = null;
            for (int row = 0; row < rowNud.Value; row++)
            {
                Mat outTemp = CvInvoke.Imread(list[(int)colNud.Value * row], 0);
                CudaImage<Gray, float> outputGpu = new CudaImage<Gray, float>(outTemp);
                outTemp.Dispose();
                CudaImage<Gray, float> output = equaliseInputImage(outputGpu);
                outputGpu.Dispose();

                Dictionary<string, int> PoseDict = new Dictionary<string, int>()
                {
                    { "Up", 0 },
                    { "Down", 0 },
                    { "Left", 0 },
                    { "Right", 0 }
                };
                
                for (int col = 1; col < colNud.Value; col++)
                {
                    Mat img1TEMP = CvInvoke.Imread(list[(int)colNud.Value * row + col], 0);
                    CudaImage<Gray, float> img1Gpu = new CudaImage<Gray, float>(img1TEMP);
                    img1TEMP.Dispose();
                    CudaImage<Gray, float> img1 = equaliseInputImage(img1Gpu);
                    img1Gpu.Dispose();

                    Size img1Size = img1.Size;
                    CudaImage<Gray, float> img1_processed = ResizeImageAddRowCol(img1, new Size(img1Size.Width, img1Size.Height + PoseDict["Up"] + PoseDict["Down"]), new Point(0, PoseDict["Up"]));

                    img1.Dispose();

                    width = img1_processed.Size.Width;
                    height = img1_processed.Size.Height;

                    int out_w = output.Size.Width;
                    int out_h = output.Size.Height;
                    int Hdiff = Math.Abs(out_h - height);

                    if (height > out_h)
                        output = ResizeImageAddRowCol(output, new Size(out_w, Hdiff + out_h), new Point(0, 0));
                    else
                        img1_processed = ResizeImageAddRowCol(img1_processed, new Size(width, Hdiff + height), new Point(0, 0));

                    //img1_left_pixel = number of pixel to loop to check for overlap
                    //overlapXNud.Value = Approximate Of Overlap Percentage(Normally around 0.1-0.3)
                    //value = number of pixel for the overlap area(approximate)
                    //out_right_cnt =  if value too small, the use out_w(width) as overlap
                    //out_right_index = overlap starting index(approximate)
                    int img1_left_pixel = (int)(width * (overlapXNud.Value / 5));
                    int value = (int)(width * overlapXNud.Value);
                    int out_right_cnt = out_w - img1_left_pixel >= value ? value : out_w;
                    int out_right_index = out_w - out_right_cnt;

                    /* checkYAlignmentCnt = number of pixel to check for alignment Y axis
                     *                    _____________________ 
                     *                   |>>>>>>>>>>>>>>>>>>>>>|} checkYAlignmentCnt
                     *                   |>>>>>>>>>>>>>>>>>>>>>|} ________|
                     * |-----------------:                     |
                     * |                 :                     |
                     * |      img1       :         img2        |
                     * |                 :                     |
                     * |                 :                     |
                     */
                    int checkYAlignmentCnt = (int)(height * AlignYNud.Value);
                    checkYAlignmentCnt = checkYAlignmentCnt == 0 ? 1 : checkYAlignmentCnt;

                    findHOverlapNotAlignIndex(output, img1_processed, img1_left_pixel, out_right_cnt, checkYAlignmentCnt, out_right_index, PoseDict,
                        out int xIndex, out CudaImage<Gray, float> align_img1, out CudaImage<Gray, float> align_output, out object[] movementY);
                    output = AlphaBlendHorizontal(align_img1, align_output, xIndex, width, movementY, PoseDict);
                    
                    img1_processed.Dispose();
                    align_img1.Dispose();
                    align_output.Dispose();
                }

                if (row > 0)
                {
                    CudaImage<Gray, float> output_processed = ResizeImageAddRowCol(output,
                        new Size(output.Size.Width + PoseDictList[row - 1]["Left"] + PoseDictList[row - 1]["Right"], output.Size.Height),
                        new Point(PoseDictList[row - 1]["Right"], 0));

                    int PrevOutput_w = PrevOutput.Size.Width;
                    int PrevOutput_h = PrevOutput.Size.Height;
                    int outprocessed_w = output_processed.Size.Width;
                    int outprocessed_h = output_processed.Size.Height;

                    int Wdiff = Math.Abs((outprocessed_w - PrevOutput_w));
                    if (PrevOutput_w > outprocessed_w)
                    {
                        output_processed = ResizeImageAddRowCol(output_processed,
                            new Size(outprocessed_w + Wdiff, outprocessed_h),
                            new Point(0, 0));
                    }
                    else
                    {
                        PrevOutput = ResizeImageAddRowCol(PrevOutput,
                            new Size(PrevOutput_w + Wdiff, PrevOutput_h),
                            new Point(0, 0));
                    }

                    //img1_top_pixel = number of pixel to loop to check for overlap
                    //overlapYNud.Value = Approximate Of Overlap Percentage(Normally around 0.1-0.3)
                    //value = number of pixel for the overlap area(approximate)
                    //img0_bottom_cnt  =  if value too small, the use out_w(width) as overlap
                    //img0_bottom_index = overlap starting index(approximate)
                    int img1_top_pixel = (int)(output_processed.Size.Height * overlapYNud.Value / 5);
                    int value = (int)(output_processed.Size.Height * overlapYNud.Value);
                    int img0_bottom_cnt = PrevOutput.Size.Height - img1_top_pixel >= value ? value : PrevOutput.Size.Height;
                    int img0_bottom_index = PrevOutput.Size.Height - img0_bottom_cnt;

                    /* checkXAlignmentCnt = number of pixel to check for alignment X axis
                     * |                            |
                     * |                            |
                     * |           img1             |
                     * |                            |
                     * |............................|____
                     * ^^^^^|                            |
                     * ^^^^^|                            |
                     * ^^^^^|                            |
                     * ^^^^^|           img2             |
                     * ^^^^^|                            |
                     * ^^^^^|                            |
                     * ^^^^^|____________________________|
                     *   |
                     * checkXAlignmentCnt
                     */
                    width = width < 0 ? output_processed.Size.Width : width;
                    int checkXAlignmentCnt = (int)(width * AlignXNud.Value);
                    checkXAlignmentCnt = checkXAlignmentCnt == 0 ? 1 : checkXAlignmentCnt;

                    findVOverlapNotAlignIndex(PrevOutput, output_processed, img1_top_pixel, img0_bottom_cnt, checkXAlignmentCnt, img0_bottom_index, PoseDict,
                        out int yIndex, out CudaImage<Gray, float> align_img1, out CudaImage<Gray, float> align_output, out object[] movementX);

                    output_processed.Dispose();
                    output = AlphaBlendVertical(align_img1, align_output, yIndex, outprocessed_h, movementX, PoseDict);
                    align_img1.Dispose();
                    align_output.Dispose();
                }
                
                PrevOutput?.Dispose();
                PrevOutput = output;
                PoseDictList.Add(PoseDict);
            }

            CudaImage<Gray, byte> gray = PrevOutput.Convert<Gray, byte>();
            Mat temp = new Mat(gray.Size, gray.Depth, gray.NumberOfChannels);
            gray.Download(temp);
            OutImageBox.Image = temp;
            gray.Dispose();
        }

        /*
         * 
         * |          :             |
         * |    img   :     img     |
         * |     1    :      2      |
         * |          :             |
         *  ------------------------
         *            ^
         *            |___ find this index
         */
        private int findHOverlapIndex(CudaImage<Gray, float> output_right, CudaImage<Gray, float> img1_left,
            int img1_left_pixel, int out_right_cnt, int min_overlap_count = 0)
        {
            // Initialise an empty arr to record the sum of squared difference at each position
            GpuMat sqdif_arr = new GpuMat(1, out_right_cnt - img1_left_pixel - min_overlap_count, Emgu.CV.CvEnum.DepthType.Cv64F, 1);
            Console.WriteLine("Finding X Overlap using Cuda......");

            CudaImage<Gray, float> diff = new CudaImage<Gray, float>(img1_left.Size);
            CudaImage<Gray, float> img = new CudaImage<Gray, float>();
            MCvScalar sum_sqdif;
            Size size = new Size(img1_left_pixel, output_right.Size.Height);
            for (int x = min_overlap_count; x < out_right_cnt - img1_left_pixel; x++)
            {
                img = output_right.GetSubRect(new Rectangle(new Point(x, 0), size));
                //Get sum of squared differences
                CudaInvoke.Subtract(img, img1_left, diff);
                sum_sqdif = CudaInvoke.SqrSum(diff);
                sqdif_arr.Col(x - min_overlap_count).SetTo(sum_sqdif);
            }

            double minVal = 0, maxVal = 0;
            Point minLoc = new Point(0, 0), maxLoc = new Point(0, 0);
            CudaInvoke.MinMaxLoc(sqdif_arr, ref minVal, ref maxVal, ref minLoc, ref maxLoc);
            sqdif_arr.Dispose();
            diff.Dispose();
            img.Dispose();
            return minLoc.X + min_overlap_count;
        }
        
        private void findHOverlapNotAlignIndex(CudaImage<Gray, float> output, CudaImage<Gray, float> img1_processed,
            int img1_left_pixel, int out_right_cnt, int checkYAlignmentCnt, int out_right_index, Dictionary<string, int> PoseDict,
            out int xIndex, out CudaImage<Gray, float> align_img1, out CudaImage<Gray, float> align_output, out object[] movementY)
        {
            // Ignore part above PoseDict["Down"] & part below PoseDict["Up"] as they are area added for alignment purpose
            CudaImage<Gray, float> output_right = output.RowRange(PoseDict["Down"], output.Size.Height - PoseDict["Up"]).ColRange(out_right_index, output.Size.Width);
            CudaImage<Gray, float> img1_left = img1_processed.RowRange(PoseDict["Down"], img1_processed.Size.Height - PoseDict["Up"]).ColRange(0, img1_left_pixel);

            Console.WriteLine("Start Check Align using Cuda");

            /* Initialise an empty arr to record the sum of squared difference at each position
             * check_y_align_pixel_cnt*2 => at index [0,check_y_align_pixel_cnt) store the sum of squared difference when the img1 move DOWN (index) pixel
             * # index 0 => img1 not moving
             * index 1 => img1 move down 1 pixel
             * index 2 => img2 move down 2 pixels
             * 
             * check_y_align_pixel_cnt*2 => at index [check_y_align_pixel_cnt,check_y_align_pixel_cnt*2) store the sum of squared difference when the img1 move UP (check_y_align_pixel_cnt*2-index) pixel
             * index check_y_align_pixel_cnt => img1 not moving
             * index check_y_align_pixel_cnt+1 => img1 move up 1 pixel
             * index check_y_align_pixel_cnt+2 => img2 move down 2 pixels
             * 
             * [y diff value, x -> the best overlap x position when in this y value]
             * */
            CudaImage<Gray, float> sqdif_arr = new CudaImage<Gray, float>(checkYAlignmentCnt * 2, 2);

            int h = img1_left.Size.Height;
            
            CudaImage<Gray, float> img1DOWN, img1UP, output_right_TOP, img1DOWN_TOP, output_right_BOTTOM, img1UP_BOTTOM, output_right_BOTTOM_diffDOWN, output_right_BOTTOM_diffUP, diffDOWN, diffUP;
            img1DOWN = img1UP = output_right_TOP = img1DOWN_TOP = output_right_BOTTOM = img1UP_BOTTOM = output_right_BOTTOM_diffDOWN = output_right_BOTTOM_diffUP = diffDOWN = diffUP = new CudaImage<Gray, float>();
            MCvScalar sum_sqdifDOWN, sum_sqdifUP;
            for (int j = 0; j < checkYAlignmentCnt; j++)
            {
                Console.WriteLine("Checking Align using Cuda");

                // Preprocess img1
                img1DOWN = img1_left.RowRange(0,h-j); //cut down part (add black row at top) -> move down
                img1UP = img1_left.RowRange(j, h); //cut up part (add black row at bottom) -> move up
                
                if (j > 0)
                {
                    img1DOWN = ResizeImageAddRowCol(img1DOWN, new Size(img1_left_pixel, h), new Point(0, j));
                    img1UP = ResizeImageAddRowCol(img1UP, new Size(img1_left_pixel, h), new Point(0,0));
                }

                // Calculate the best X overlap index when img1 move DOWN
                output_right_TOP = output_right.RowRange(j, output_right.Size.Height);
                img1DOWN_TOP = img1DOWN.RowRange(j, img1DOWN.Size.Height);
                int xDOWN = findHOverlapIndex(output_right_TOP, img1DOWN_TOP, img1_left_pixel, out_right_cnt, (int)(img1_processed.Size.Width * minOverlapNud.Value)) + out_right_index;
                
                // Calculate the best X overlap index when img1 move UP
                output_right_BOTTOM = output_right.RowRange(0, h-j);
                img1UP_BOTTOM = img1UP.RowRange(0, h - j);
                int xUP = findHOverlapIndex(output_right_BOTTOM, img1UP_BOTTOM, img1_left_pixel, out_right_cnt, (int)(img1_processed.Size.Width * minOverlapNud.Value)) + out_right_index;
               
                // Calculate the sum of squared difference
                output_right_BOTTOM_diffDOWN = output_right_TOP.ColRange(xDOWN - out_right_index, xDOWN - out_right_index + img1_left_pixel);
                output_right_BOTTOM_diffUP = output_right_BOTTOM.ColRange(xUP - out_right_index, xUP - out_right_index + img1_left_pixel);

                //Get sum of squared differences
                CudaInvoke.Subtract(output_right_BOTTOM_diffDOWN, img1DOWN_TOP, diffDOWN);
                CudaInvoke.Subtract(output_right_BOTTOM_diffUP, img1UP_BOTTOM, diffUP);

                sum_sqdifDOWN = CudaInvoke.SqrSum(diffDOWN);
                sum_sqdifUP = CudaInvoke.SqrSum(diffUP);

                sqdif_arr.Row(j).Col(0).SetTo(sum_sqdifDOWN);
                sqdif_arr.Row(j).Col(1).SetTo(new MCvScalar(xDOWN));

                sqdif_arr.Row(j + checkYAlignmentCnt).Col(0).SetTo(sum_sqdifUP);
                sqdif_arr.Row(j + checkYAlignmentCnt).Col(1).SetTo(new MCvScalar(xUP));
            }
            img1DOWN.Dispose();
            img1UP.Dispose();
            output_right_TOP.Dispose();
            output_right_BOTTOM_diffDOWN.Dispose();
            output_right_BOTTOM_diffUP.Dispose();
            output_right_BOTTOM.Dispose();
            img1DOWN_TOP.Dispose();
            img1UP_BOTTOM.Dispose();
            diffDOWN.Dispose();
            diffUP.Dispose();
            img1_left.Dispose();
            output_right.Dispose();

            double minVal = 0, maxVal = 0;
            Point minLoc = new Point(0, 0), maxLoc = new Point(0, 0);
            CudaInvoke.MinMaxLoc(sqdif_arr.Col(0), ref minVal, ref maxVal, ref minLoc, ref maxLoc);
            int index = minLoc.Y;
            object Xvalue = sqdif_arr.GetData().GetValue(index, 1);
            xIndex = Convert.ToInt32(Xvalue);
            sqdif_arr.Dispose();

            // Align the output images and img1 by stack the images with rectangle
            movementY = new object[2];
            if (index >= checkYAlignmentCnt)
            {
                int v = index - checkYAlignmentCnt;
                align_img1 = ResizeImageAddRowCol(img1_processed, new Size(img1_processed.Size.Width, img1_processed.Size.Height+v), new Point(0,0));
                align_output = ResizeImageAddRowCol(output, new Size(output.Size.Width, output.Size.Height + v), new Point(0, v));
                PoseDict["Up"] += v;
                movementY[0] = "Up";
                movementY[1] = v;
            }
            else
            {
                align_img1 = ResizeImageAddRowCol(img1_processed, new Size(img1_processed.Size.Width, img1_processed.Size.Height + index), new Point(0, index));
                align_output = ResizeImageAddRowCol(output, new Size(output.Size.Width, output.Size.Height + index), new Point(0, 0));
                PoseDict["Down"] += index;
                movementY[0] = "Down";
                movementY[1] = index;
            }
        }

        private int findVOverlapIndex(CudaImage<Gray, float> output_bottom, CudaImage<Gray, float> img1_top,
            int img1_top_pixel, int out_bottom_cnt, int min_overlap_count = 0)
        {
            // Initialise an empty arr to record the sum of squared difference at each position
            GpuMat sqdif_arr = new GpuMat(1, out_bottom_cnt - img1_top_pixel, DepthType.Cv64F, 1);
            Console.WriteLine("Finding Y Overlap using Cuda......");

            CudaImage<Gray, float> diff = new CudaImage<Gray, float>();
            CudaImage<Gray, float> img = new CudaImage<Gray, float>();
            MCvScalar sum_sqdif;
            Size size = img1_top.Size;
            for (int y = min_overlap_count; y < out_bottom_cnt - img1_top_pixel; y++)
            {
                img = output_bottom.GetSubRect(new Rectangle(new Point(0, y), size));
                //Get sum of squared differences
                CudaInvoke.Subtract(img, img1_top, diff);
                sum_sqdif = CudaInvoke.SqrSum(diff);
                sqdif_arr.Col(y - min_overlap_count).SetTo(sum_sqdif);
            }

            double minVal = 0, maxVal = 0;
            Point minLoc = new Point(0, 0), maxLoc = new Point(0, 0);
            CudaInvoke.MinMaxLoc(sqdif_arr, ref minVal, ref maxVal, ref minLoc, ref maxLoc);
            sqdif_arr.Dispose();
            diff.Dispose();
            img.Dispose();
            return minLoc.X + min_overlap_count;
        }

        private void findVOverlapNotAlignIndex(CudaImage<Gray, float> PrevOutput, CudaImage<Gray, float> output_processed, 
            int img1_top_pixel, int out_bottom_cnt, int checkXAlignmentCnt, int out_bottom_index, Dictionary<string,int> PoseDict,
            out int yIndex, out CudaImage<Gray, float> align_img1, out CudaImage<Gray, float> align_output, out object[] movementX)
        {
            //  Ignore part at the left PoseDict["Right"] & part at the right PoseDict["Left"] as they are area added for alignment purpose
            CudaImage<Gray, float> output_bottom = equaliseInputImageFindOverlap(PrevOutput.RowRange(out_bottom_index, PrevOutput.Size.Height).ColRange(PoseDict["Right"], PrevOutput.Size.Width - PoseDict["Left"]));
            CudaImage<Gray, float> img1_top = equaliseInputImageFindOverlap(output_processed.RowRange(0, img1_top_pixel).ColRange(PoseDict["Right"], output_processed.Size.Width - PoseDict["Left"]));
            
            Console.WriteLine("Start Check Y Align using Cuda");
            /* Initialise an empty arr to record the sum of squared difference at each position
             * check_x_align_pixel_cnt*2 => at index [0,check_x_align_pixel_cnt) store the sum of squared difference when the img1 move RIGHT (index) pixel
             * index 0 => img1 not moving
             * index 1 => img1 move RIGHT 1 pixel
             * index 2 =>  img2 move RIGHT 2 pixels
             * 
             * check_x_align_pixel_cnt*2 => at index [check_x_align_pixel_cnt,check_x_align_pixel_cnt*2) store the sum of squared difference when the img1 move LEFT (check_y_align_pixel_cnt*2-index) pixel
             * index check_x_align_pixel_cnt => img1 not moving
             * index check_x_align_pixel_cnt+1 => img1 move LEFT 1 pixel
             * index check_x_align_pixel_cnt+2 => img2 move LEFT 2 pixels
             * 
             * [x diff value, y -> the best overlap y position when in this x value]
             * */
            CudaImage<Gray, float> sqdif_arr = new CudaImage<Gray, float>(checkXAlignmentCnt * 2, 2);

            int w = img1_top.Size.Width;

            CudaImage<Gray, float> img1RIGHT, img1LEFT, output_bottom_LEFT, img1RIGHT_LEFT, output_bottom_RIGHT, img1LEFT_RIGHT, output_bottom_LEFT_diffRIGHT, output_bottom_RIGHT_diffLEFT, diffRIGHT, diffLEFT;
            img1RIGHT = img1LEFT = output_bottom_LEFT = img1RIGHT_LEFT = output_bottom_RIGHT = img1LEFT_RIGHT = output_bottom_LEFT_diffRIGHT = output_bottom_RIGHT_diffLEFT = diffRIGHT = diffLEFT = new CudaImage<Gray, float>();
            MCvScalar sum_sqdifRIGHT, sum_sqdifLEFT;
            
            for (int j = 0; j < checkXAlignmentCnt; j++)
            {
                Console.WriteLine("Checking Y Align using Cuda");

                // Preprocess img1
                img1RIGHT = img1_top.ColRange(0, w - j); //cut right part (add black row at left) -> move right
                img1LEFT = img1_top.ColRange(j, w); //# cut left part (add black row at right) -> move left

                if (j > 0) 
                {
                    img1RIGHT = ResizeImageAddRowCol(img1RIGHT, new Size(w, img1_top_pixel), new Point(j,0));
                    img1LEFT = ResizeImageAddRowCol(img1LEFT, new Size(w, img1_top_pixel), new Point(0, 0));
                }

                // Calculate the best Y overlap index when img1 move RIGHT
                output_bottom_LEFT = output_bottom.ColRange(j, output_bottom.Size.Width);
                img1RIGHT_LEFT = img1RIGHT.ColRange(j, img1RIGHT.Size.Width);
                int yRIGHT = findVOverlapIndex(output_bottom_LEFT, img1RIGHT_LEFT, img1_top_pixel, out_bottom_cnt) + out_bottom_index;

                // Calculate the best Y overlap index when img1 move UP
                output_bottom_RIGHT = output_bottom.ColRange(0, w - j);
                img1LEFT_RIGHT = img1LEFT.ColRange(0, w - j);
                int yLEFT = findVOverlapIndex(output_bottom_RIGHT, img1LEFT_RIGHT, img1_top_pixel, out_bottom_cnt) + out_bottom_index;

                // Calculate the sum of squared difference
                output_bottom_LEFT_diffRIGHT = output_bottom_LEFT.RowRange(yRIGHT - out_bottom_index, yRIGHT - out_bottom_index + img1_top_pixel);
                output_bottom_RIGHT_diffLEFT = output_bottom_RIGHT.RowRange(yLEFT - out_bottom_index, yLEFT - out_bottom_index + img1_top_pixel);
                
                //Get sum of squared differences
                CudaInvoke.Subtract(output_bottom_LEFT_diffRIGHT, img1RIGHT_LEFT, diffRIGHT);
                CudaInvoke.Subtract(output_bottom_RIGHT_diffLEFT, img1LEFT_RIGHT, diffLEFT);

                sum_sqdifRIGHT = CudaInvoke.SqrSum(diffRIGHT);
                sum_sqdifLEFT = CudaInvoke.SqrSum(diffLEFT);

                sqdif_arr.Row(j).Col(0).SetTo(sum_sqdifRIGHT);
                sqdif_arr.Row(j).Col(1).SetTo(new MCvScalar(yRIGHT));

                sqdif_arr.Row(j + checkXAlignmentCnt).Col(0).SetTo(sum_sqdifLEFT);
                sqdif_arr.Row(j + checkXAlignmentCnt).Col(1).SetTo(new MCvScalar(yLEFT));
            }

            img1RIGHT.Dispose();
            img1LEFT.Dispose();
            output_bottom_LEFT.Dispose();
            img1RIGHT_LEFT.Dispose();
            output_bottom_RIGHT.Dispose();
            img1LEFT_RIGHT.Dispose();
            output_bottom_LEFT_diffRIGHT.Dispose();
            output_bottom_RIGHT_diffLEFT.Dispose();
            diffRIGHT.Dispose();
            diffLEFT.Dispose();
            output_bottom.Dispose();
            img1_top.Dispose();

            double minVal = 0, maxVal = 0;
            Point minLoc = new Point(0, 0), maxLoc = new Point(0, 0);
            CudaInvoke.MinMaxLoc(sqdif_arr.Col(0), ref minVal, ref maxVal, ref minLoc, ref maxLoc);
            int index = minLoc.Y;
            object Yvalue = sqdif_arr.GetData().GetValue(index, 1);
            yIndex = Convert.ToInt32(Yvalue);
            sqdif_arr.Dispose();
            // Align by adding black pixel at left/right
            movementX = new object[2];
            if (index >= checkXAlignmentCnt)
            {
                int v = index - checkXAlignmentCnt;
                align_img1 = ResizeImageAddRowCol(output_processed, new Size(output_processed.Size.Width+v, output_processed.Size.Height), new Point(0, 0));
                align_output = ResizeImageAddRowCol(PrevOutput, new Size(PrevOutput.Size.Width + v, PrevOutput.Size.Height), new Point(v, 0));
                PoseDict["Left"] += v;
                movementX[0] = "Left";
                movementX[1] = v;
            }
            else
            {
                align_img1 = ResizeImageAddRowCol(output_processed, new Size(output_processed.Size.Width + index, output_processed.Size.Height), new Point(0, 0));
                align_output = ResizeImageAddRowCol(PrevOutput, new Size(PrevOutput.Size.Width + index, PrevOutput.Size.Height), new Point(index, 0));
                PoseDict["Right"] += index;
                movementX[0] = "Right";
                movementX[1] = index;
            }
        }

        private CudaImage<Gray, float> equaliseInputImage(CudaImage<Gray, float> image_gray)
        {
            CudaImage<Gray, float> output = new CudaImage<Gray, float>();
            clahe_illuminance.Apply(image_gray, output);
            output.ConvertTo(output, DepthType.Cv32F);
            return output;
        }

        private CudaImage<Gray, float> equaliseInputImageFindOverlap(CudaImage<Gray, float> image_gray)
        {
            CudaImage<Gray, float> output = new CudaImage<Gray, float>();
            image_gray.ConvertTo(image_gray, DepthType.Cv8U);
            clahe.Apply(image_gray, output);
            output.ConvertTo(output, DepthType.Cv32F);
            return output;
        }

        private void create2GradientMask(Size size, int startValue, int endValue, out CudaImage<Gray, float> mask, out CudaImage<Gray, float> maskReverse, bool Horizontal = true)
        {
            int width = size.Width;
            int height = size.Height;
            mask = new CudaImage<Gray, float>(height, width);
            maskReverse = new CudaImage<Gray, float>(height, width);

            float step;
            float v = startValue;
            if (Horizontal)
            {
                step = (float)(endValue - startValue) / (float)(width - 1);
                for (int j = width - 1, i = 0; j >= 0; j--, i++)
                {
                    mask.Col(i).SetTo(new MCvScalar(v));
                    maskReverse.Col(j).SetTo(new MCvScalar(v));
                    v += step;
                }
            }
            else
            {
                step = (float)(endValue - startValue) / (float)(height - 1);
                for (int j = height - 1, i = 0; j >= 0; j--, i++)
                {
                    mask.Row(i).SetTo(new MCvScalar(v));
                    maskReverse.Row(j).SetTo(new MCvScalar(v));
                    v += step;
                }
            }
        }

        private CudaImage<Gray, float> ResizeImageAddRowCol(CudaImage<Gray, float> img, Size desiredSize, Point StartPoint, int pixelValue = 0)
        {
            CudaImage<Gray, float> img_processed = new CudaImage<Gray, float>(desiredSize);
            img_processed.SetTo(new MCvScalar(pixelValue));
            img.CopyTo(img_processed.GetSubRect(new Rectangle(StartPoint, img.Size)));
            img.Dispose();
            return img_processed;
        }

        private void OpenFolderBtn_Click(object sender, EventArgs e)
        {
            using (CommonOpenFileDialog openFileDialog = new CommonOpenFileDialog())
            {
                openFileDialog.IsFolderPicker = true;
                if (openFileDialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    list.Clear();
                    string[] files = Directory.GetFiles(openFileDialog.FileName);
                    foreach(string file in files)
                    {
                        if(file.EndsWith(".png") || file.EndsWith(".jpg")||file.EndsWith(".bmp"))
                            list.Add(file);
                    }
                }
                openFileDialog.Dispose();
            }
        }

        private void inputList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (inputList.SelectedItem == null)
                return;
            InputImageBox.Image?.Dispose();
            Mat mat = CvInvoke.Imread(inputList.SelectedItem.ToString(), 0);
            Size outSize = HelperClass.resize(mat.Width, mat.Height, InputImageBox.Width, InputImageBox.Height);
            Mat matResize = new Mat();
            CvInvoke.Resize(mat, matResize, outSize);
            mat.Dispose();
            InputImageBox.Image = matResize;
        }

        private void RunBtn_Click(object sender, EventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerSupportsCancellation = false;
            worker.WorkerReportsProgress = false;
            worker.DoWork += Run;
            worker.RunWorkerCompleted += RunCompleted;
            worker.RunWorkerAsync();
            RunBtn.Enabled = false;
        }

        private void RunCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            RunBtn.Enabled = true;
            Console.WriteLine("Completed");
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (OutImageBox.Image == null)
            {
                MessageBox.Show("No Image(s) to Save");
                return;
            }

            SaveFileDialog saveFileDialog1 = new SaveFileDialog
            {
                Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Png Image|*.png",
                Title = "Save an Image File"
            };

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog1.FileName != "")
                    CvInvoke.Imwrite(saveFileDialog1.FileName, OutImageBox.Image, new KeyValuePair<ImwriteFlags, int>(ImwriteFlags.PngCompression, 9));
            }
            saveFileDialog1.Dispose();
        }

        private void LoopStitch_FormClosing(object sender, FormClosingEventArgs e)
        {
            bindingSource.Dispose();
            clahe_illuminance.Dispose();
            clahe.Dispose();
            Form form = Application.OpenForms["Form1"];
            form?.Show();
        }

        private void OpenImagesBtn_Click(object sender, EventArgs e)
        {
            using (CommonOpenFileDialog openFileDialog = new CommonOpenFileDialog())
            {
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    list.Clear();
                    foreach (string file in openFileDialog.FileNames)
                    {
                        if (file.EndsWith(".png") || file.EndsWith(".jpg") || file.EndsWith(".bmp"))
                            list.Add(file);
                    }
                }
                openFileDialog.Dispose();
            }
        }
    }
}
