using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.CV.XPhoto;
using OpenCV_Vision_Pro.Interface;
using Shared.ComponentModel.SortableBindingList;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Emgu.CV.Features2D;
using System.Collections.Generic;
using System.Threading;
using Google.Protobuf.WellKnownTypes;

namespace OpenCV_Vision_Pro.Tools.ImageStacking
{
    public abstract class IToneMappingParameter
    {
        public float gamma = 1.0f;
    }

    public class DragoParams : IToneMappingParameter
    {
        public float saturation { get; set; }
        public float bias { get; set; }
        public DragoParams(float gamma = 1.0f, float saturation = 0.8f, float bias = 0.9f)
        {
            this.gamma = gamma;
            this.saturation = saturation;
            this.bias = bias;
        }
    }

    public class DurandParams : IToneMappingParameter
    {
        public float contrast { get; set; }
        public float saturation { get; set; }
        public float sigma_space { get; set; }
        public float sigma_color { get; set; }
        public DurandParams(float gamma = 1.0f, float contrast = 4.0f, float saturation = 1.0f, float sigma_space = 2.0f, float sigma_color = 2.0f)
        {
            this.gamma = gamma;
            this.contrast = contrast;
            this.saturation = saturation;
            this.sigma_space = sigma_space;
            this.sigma_color = sigma_color;
        }
    }

    public class ReinhardParams : IToneMappingParameter
    {
        public float intensity { get; set; }
        public float light_adapt { get; set; }
        public float color_adapt { get; set; }
        public ReinhardParams(float gamma = 1.0f, float intensity = 0.0f, float light_adapt = 1.0f, float color_adapt = 0.0f)
        {
            this.gamma = gamma;
            this.intensity = intensity;
            this.light_adapt = light_adapt;
            this.color_adapt = color_adapt;
        }
    }

    public class MantiukParams : IToneMappingParameter
    {
        public float saturation { get; set; }
        public float scale { get; set; }
        public MantiukParams(float gamma = 1.0f, float saturation = 1.0f, float scale = 0.7f)
        {
            this.gamma = gamma;
            this.saturation = saturation;
            this.scale = scale;
        }
    }

    public class ImageStackingParams : IParams
    {
        public ROI m_roi { get; set; } = new ROI();
        public bool m_boolHasROI { get; set; } = false;
        public string operation { get; set; } = "Focus";
        public SortableBindingList<string> selectedImage { get; set; } = new SortableBindingList<string>();
        public VectorOfMat vom { get; set; } = new VectorOfMat();
        public VectorOfFloat times { get; set; } = new VectorOfFloat();
        public IToneMappingParameter toneMapParameter { get; set; } = new DragoParams();
    }

    public class ImageStackingResults : IToolResult, IDisposable
    {
        public Mat resultImage { get; set; }

        public void Dispose()
        {
            resultImage?.Dispose();
        }
    }

    public class ImageStackingTool : IToolBase
    {
        public Rectangle m_rectROI { get; set; }
        public string ToolName { get; set; }
        public AutoDisposeDict<string, Mat> m_bitmapList { get; set; }
        public BindingList<string> m_DisplaySelection { get; set; } = new BindingList<string>();
        public BindingSource resultSource { get; set; }
        public UserControlBase m_toolControl { get; set; }
        public IParams parameter { get; set; } = new ImageStackingParams();
        public IToolResult toolResult { get; set; }
        private ImageStackingResults ImageStackingResult { get { return (ImageStackingResults)toolResult; } set { toolResult = value; } }
        
        public ImageStackingTool(string toolName)
        {
            this.ToolName = toolName;
        }

        public void Dispose()
        {
            m_bitmapList?.Dispose();
            resultSource?.Dispose();
            m_toolControl?.Dispose();
        }

        public void getGUI()
        {
            if (m_rectROI != null && !m_rectROI.IsEmpty)
            {
                parameter.m_roi.location = new Point(m_rectROI.X, m_rectROI.Y);
                parameter.m_roi.ROI_Width = m_rectROI.Width;
                parameter.m_roi.ROI_Height = m_rectROI.Height;
            }
            m_toolControl = new ImageStackingToolControl(parameter) { Dock = DockStyle.Top };
        }

        public void Run(Mat img, Rectangle region)
        {
            ImageStackingResult?.Dispose();
            ImageStackingResult = new ImageStackingResults();

            int inputCnt = ((ImageStackingParams)parameter).selectedImage.Count;
            if (inputCnt < 2)
            {
                MessageBox.Show("Please input AT LEAST 2 images for the operation.");
                ImageStackingResult.resultImage = new Mat();
                return;
            }
            ImageStackingResult.resultImage?.Dispose();

            if (String.Compare(((ImageStackingParams)parameter).operation, "Focus") == 0)
                ImageStackingResult.resultImage = FocusOperation();
            else if (String.Compare(((ImageStackingParams)parameter).operation, "Exposure - Fusion") == 0)
                ImageStackingResult.resultImage = FusionOperation();
            else if (String.Compare(((ImageStackingParams)parameter).operation, "Exposure - HDR") == 0)
            {
                if (inputCnt != ((ImageStackingParams)parameter).times.Size)
                {
                    MessageBox.Show("The number of the images MUST BE same with the number of the times array.");
                    ImageStackingResult.resultImage = new Mat();
                    return;
                }
                ImageStackingResult.resultImage = HDROperation();
            }
            showResultImages();
        }

        private Mat laplacien(Mat image)
        {
            int kernel_size = 5;
            int blur_size = 5;

            Mat gray = new Mat();
            CvInvoke.CvtColor(image, gray, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);
            
            Mat gauss = new Mat();
            CvInvoke.GaussianBlur(gray, gauss, new Size(blur_size, blur_size), 0);

            Mat laplace = new Mat();
            CvInvoke.Laplacian(gauss, laplace, DepthType.Cv64F, kernel_size);

            Mat temp = Mat.Zeros(laplace.Rows, laplace.Cols, laplace.Depth, laplace.NumberOfChannels);
            Mat absolute = new Mat();
           // Mat absolute2 = new Mat();
           // Mat absolute = new Mat();
            CvInvoke.AbsDiff(laplace, temp, absolute);
           // CvInvoke.AbsDiff(temp, laplace, absolute2);
           // CvInvoke.BitwiseOr(absolute1, absolute2, absolute);
            //MessageBox.Show(laplace.GetValueRange().Max + ",," + laplace.GetValueRange().Min+"\n"+absolute.GetValueRange().Max + ",," + absolute.GetValueRange().Min);
            gray.Dispose();
            gauss.Dispose();
            //laplace.Dispose();
            //return absolute;
            return absolute;
        }

        /*
         * it 's called "focus stacking".
         * the algorithm, quoting straight from here goes like this:
         * Align the images. Changing the focus on a lens, even if the camera remains fixed, causes a mild zooming on the images. 
         * We need to correct the images so they line up perfectly on top of each other.
         * 
         * Perform a gaussian blur on all images
         * 
         * Compute the laplacian on the blurred image to generate a gradient map
         * 
         * Create a blank output image with the same size as the original input images
         * 
         * For each pixel [x,y] in the output image, copy the pixel [x,y] from the input image which has the largest gradient [x,y]
         */
        private Mat FocusOperation()
        {
            ((ImageStackingParams)parameter).vom = alignImages(((ImageStackingParams)parameter).vom);
            Mat[] laps = new Mat[((ImageStackingParams)parameter).vom.Size];

            for (int i = 0; i < ((ImageStackingParams)parameter).vom.Size; i++)
            {
                CvInvoke.Imshow("((ImageStackingParams)parameter).vom[i]", ((ImageStackingParams)parameter).vom[i]);
                CvInvoke.WaitKey(1000);
                laps[i] = laplacien(((ImageStackingParams)parameter).vom[i]);
                CvInvoke.Imshow("laps[i]", laps[i]);
            }

            Mat maxima = Mat.Zeros(laps[0].Rows, laps[0].Cols, laps[0].Depth, laps[0].NumberOfChannels);
            for (int i = 0; i < laps.Length; i++)
            {
                CvInvoke.Max(maxima, laps[i], maxima);
            }
            Mat[] masks = new Mat[laps.Length];
            for (int i = 0; i < laps.Length; i++)
            {
                Mat mask = Mat.Zeros(laps[i].Rows, laps[i].Cols, laps[i].Depth, laps[i].NumberOfChannels);
                CvInvoke.Compare(laps[i], maxima, mask, CmpType.Equal);
                masks[i] = mask;
            }
            Mat output = new Mat(laps[0].Rows, laps[0].Cols, ((ImageStackingParams)parameter).vom[0].Depth, ((ImageStackingParams)parameter).vom[0].NumberOfChannels);
            for (int i = 0; i < ((ImageStackingParams)parameter).vom.Size; i++)
            {
                CvInvoke.BitwiseNot(((ImageStackingParams)parameter).vom[i], output, masks[i]);
                CvInvoke.Imshow("Output", output);
                CvInvoke.WaitKey(1000);
            }

            return 255 - output;
        }

        private Mat HDROperation()
        {
            Mat responseDebevec = new Mat();
            CalibrateDebevec debevec = new CalibrateDebevec();
            debevec.Process(((ImageStackingParams)parameter).vom, responseDebevec, ((ImageStackingParams)parameter).times);
            debevec.Dispose();

            AlignMTB alignMTB = new AlignMTB(5, 6, true);
            alignMTB.Process(((ImageStackingParams)parameter).vom, ((ImageStackingParams)parameter).vom, new VectorOfFloat(), new Mat());
            alignMTB.Dispose();

            Mat mergeMat = new Mat();
            MergeDebevec mergeDebevec = new MergeDebevec();
            mergeDebevec.Process(((ImageStackingParams)parameter).vom, mergeMat, ((ImageStackingParams)parameter).times, responseDebevec);

            responseDebevec.Dispose();
            mergeDebevec.Dispose();

            Mat img = new Mat();
            Tonemap toneMap;
            IToneMappingParameter tempParams = ((ImageStackingParams)parameter).toneMapParameter;

            switch (tempParams.GetType().Name)
            {
                case "DragoParams":
                    toneMap = new TonemapDrago
                    {
                        Gamma = ((DragoParams)tempParams).gamma,
                        Saturation = ((DragoParams)tempParams).saturation,
                        Bias = ((DragoParams)tempParams).bias
                    };
                    break;
                case "DurandParams":
                    toneMap = new TonemapDurand
                    {
                        Gamma = ((DurandParams)tempParams).gamma,
                        Contrast = ((DurandParams)tempParams).contrast,
                        Saturation = ((DurandParams)tempParams).saturation,
                        SigmaSpace = ((DurandParams)tempParams).sigma_space,
                        SigmaColor = ((DurandParams)tempParams).sigma_color
                    };
                    break;
                case "ReinhardParams":
                    toneMap = new TonemapReinhard
                    {
                        Gamma = ((ReinhardParams)tempParams).gamma,
                        Intensity = ((ReinhardParams)tempParams).intensity,
                        LightAdaptation = ((ReinhardParams)tempParams).light_adapt,
                        ColorAdaptation = ((ReinhardParams)tempParams).color_adapt
                    };
                    break;
                case "MantiukParams":
                    toneMap = new TonemapMantiuk
                    {
                        Gamma = ((MantiukParams)tempParams).gamma,
                        Scale = ((MantiukParams)tempParams).scale,
                        Saturation = ((MantiukParams)tempParams).saturation
                    };
                    break;
                default:
                    MessageBox.Show("Wrong Tone Map Parameter Input!");
                    return mergeMat;
            }

            toneMap.Process(mergeMat, img);
            img *= 3;
            mergeMat.Dispose();
            toneMap.Dispose();

            img.ConvertTo(img, DepthType.Cv8U, 255);
            return img;
        }

        private Mat FusionOperation()
        {
            return null;
        }

        public object showResult()
        {
            return null;
        }

        public void showResultImages()
        {
            if (m_bitmapList == null)
                m_bitmapList = new AutoDisposeDict<string, Mat>();
            if (Form1.m_bitmapList == null)
                Form1.m_bitmapList = new AutoDisposeDict<string, Mat>();
            if (Form1.m_bitmapList.ContainsKey("LastRun." + ToolName + ".StackImage"))
            {
                Form1.m_bitmapList["LastRun." + ToolName + ".StackImage"]?.Dispose();
                Form1.m_bitmapList["LastRun." + ToolName + ".StackImage"] = ImageStackingResult.resultImage.Clone();
            }
            else
            {
                Form1.m_bitmapList.Add("LastRun." + ToolName + ".StackImage", ImageStackingResult.resultImage.Clone());
                if (!Form1.m_form1DisplaySelection.Contains("LastRun." + ToolName + ".StackImage"))
                    Form1.m_form1DisplaySelection.Add("LastRun." + ToolName + ".StackImage");
            }

            if (m_bitmapList.ContainsKey("LastRun." + ToolName + ".StackImage"))
            {
                m_bitmapList["LastRun." + ToolName + ".StackImage"]?.Dispose();
                m_bitmapList["LastRun." + ToolName + ".StackImage"] = ImageStackingResult.resultImage.Clone();
            }
            else
            {
                m_bitmapList.Add("LastRun." + ToolName + ".StackImage", ImageStackingResult.resultImage.Clone());
                if (!m_DisplaySelection.Contains("LastRun." + ToolName + ".StackImage"))
                    m_DisplaySelection.Add("LastRun." + ToolName + ".StackImage");
            }
        }

        private VectorOfMat alignImages(VectorOfMat mats)
        {
            VectorOfMat alignImages = new VectorOfMat();
            SIFT sift = new SIFT();

            //Add base image, other align with it
            alignImages.Push(mats[0]);

            Mat gray = new Mat();
            CvInvoke.CvtColor(mats[0], gray, ColorConversion.Bgr2Gray);
            VectorOfKeyPoint keyPoint = new VectorOfKeyPoint();
            Mat descriptors = new Mat();
            sift.DetectAndCompute(gray, null, keyPoint, descriptors, false);

            for (int i = 1; i < mats.Size; i++)
            {
                VectorOfKeyPoint keyPointi = new VectorOfKeyPoint();
                Mat descriptorsi = new Mat();
                sift.DetectAndCompute(mats[i], null, keyPointi, descriptorsi, false);

                VectorOfVectorOfDMatch dMatch = new VectorOfVectorOfDMatch();
                BFMatcher bf = new BFMatcher(DistanceType.L2);
                bf.KnnMatch(descriptorsi,descriptors, dMatch, 2); //This returns the top two matches for each feature point (list of list)

                List<MDMatch> rawMatches = new List<MDMatch>();
                for (int m = 0; m < dMatch.Size; m++)
                {
                    if (dMatch[m][0].Distance < 0.7* dMatch[m][1].Distance)
                        rawMatches.Add(dMatch[m][0]);
                }
                List<MDMatch> sortMatches = rawMatches.OrderBy(m => m.Distance).Take(rawMatches.Count > 128 ? 128 : rawMatches.Count).ToList();
                
                Mat homography = findHomography(keyPointi, keyPoint,sortMatches);
                Mat output = new Mat();
                if (homography.Size.IsEmpty)
                    continue;
                CvInvoke.WarpPerspective(mats[i], output, homography, mats[i].Size);

                alignImages.Push(output);    
            }


            return alignImages;
        }

        private Mat findHomography(VectorOfKeyPoint keyPointi, VectorOfKeyPoint keyPoint, List<MDMatch> sortMatches)
        {
            Matrix<float> image1Points = new Matrix<float>(sortMatches.Count,2);
            Matrix<float> image2Points = new Matrix<float>(sortMatches.Count,2);

            for (int i = 0; i < sortMatches.Count; i++)
            {
                /*
                If you look at matrixa.Data, this will be a float[,] with the first dimension corresponding 
                to rows and the second being the columns and channels merged into one dimension. 
                If the number of channels is N, the current channel is n and 
                the current column is m, the index j of the second dimension is
                j = m*N + n
                */
                int index1 = sortMatches[i].QueryIdx;
                int index2 = sortMatches[i].TrainIdx;
                image1Points[i, 0] = keyPointi[index1].Point.X;
                image1Points[i, 1] = keyPointi[index1].Point.Y;
                image2Points[i, 0] = keyPoint[index2].Point.X;
                image2Points[i, 1] = keyPoint[index2].Point.Y;
            }
            if (sortMatches.Count < 4)
                return new Mat();
            return CvInvoke.FindHomography(image1Points,image2Points,RobustEstimationAlgorithm.Ransac,2.0);
        }

        private Rectangle getSharpestPart(Mat image)
        {
            Mat transpose = new Mat();
            CvInvoke.Transpose(image, transpose);
            VectorOfPoint points = new VectorOfPoint();
            CvInvoke.FindNonZero(transpose, points);
            int min_col = points[0].Y;
            int max_col = points[points.Size - 1].Y;
            Point[] pt = points.ToArray().OrderBy(p => p.X).ToArray();
            int min_row = pt[0].X;
            int max_row = pt[pt.Length - 1].X;
            
            MessageBox.Show(min_row+","+min_col+"::::"+max_row+","+max_col);
            Size rectSize = new Size(max_row - min_row, max_col - min_col);
            Size rectSizeThresh = new Size((int)(rectSize.Width * 0.95), (int)(rectSize.Height * 0.95));
            //Point top_left = new Point((min_row + (int)((rectSize.Width - rectSizeThresh.Width) / 2)), min_col + (int)((rectSize.Height - rectSizeThresh.Height) / 2));
            //Point bottom_right = new Point(top_left.X + rectSizeThresh.Width, top_left.Y + rectSizeThresh.Height);
            return new Rectangle(points[0], rectSize);
            /*
             * 
def get_bounding_box(image,thresh=0.95):
    nonzero_indices = np.nonzero(image.T)
    min_row, max_row = np.min(nonzero_indices[0]), np.max(nonzero_indices[0])
    min_col, max_col = np.min(nonzero_indices[1]), np.max(nonzero_indices[1])
    box_size = max_row - min_row + 1, max_col - min_col + 1
    box_size_thresh = (int(box_size[0] * thresh), int(box_size[1] * thresh))
    #box_size_thresh = (int(box_size[0]), int(box_size[1]))
    #coordinates of the box that contains 95% of the highest pixel values
    top_left = (min_row + int((box_size[0] - box_size_thresh[0]) / 2), min_col + int((box_size[1] - box_size_thresh[1]) / 2))
    bottom_right = (top_left[0] + box_size_thresh[0], top_left[1] + box_size_thresh[1])
    return (top_left[0], top_left[1]), (bottom_right[0], bottom_right[1])
            */
        }
    }
}
