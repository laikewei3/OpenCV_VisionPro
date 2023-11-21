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
        public string operation { get; set; } = "Focus";
        public SortableBindingList<string> selectedImage { get; set; } = new SortableBindingList<string>();
        public VectorOfMat vom { get; set; } = new VectorOfMat();
        public VectorOfFloat times { get; set; } = new VectorOfFloat();
        public IToneMappingParameter toneMapParameter { get; set; } = new DragoParams();
    }

    public class ImageStackingResults : IToolResult
    {

    }

    public class ImageStackingTool : ITool
    {
        public string ToolName { get; set; }
        public AutoDisposeDict<string, Mat> m_bitmapList { get; set; }
        public BindingList<string> m_DisplaySelection { get; set; } = new BindingList<string>();
        public BindingSource resultSource { get; set; }
        public IUserControlBase m_toolControl { get; set; }
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

        private Mat laplacian(Mat image)
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
            ((ImageStackingParams)parameter).vom = HelperClass.alignImages(((ImageStackingParams)parameter).vom);

            AlignMTB alignMTB = new AlignMTB(5, 6, true);
            alignMTB.Process(((ImageStackingParams)parameter).vom, ((ImageStackingParams)parameter).vom, new VectorOfFloat(), new Mat());
            alignMTB.Dispose();
            Mat[] laps = new Mat[((ImageStackingParams)parameter).vom.Size];

            for (int i = 0; i < ((ImageStackingParams)parameter).vom.Size; i++)
            {
                laps[i] = laplacian(((ImageStackingParams)parameter).vom[i]);
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
            maxima.Dispose();
            Mat output = new Mat(laps[0].Rows, laps[0].Cols, ((ImageStackingParams)parameter).vom[0].Depth, ((ImageStackingParams)parameter).vom[0].NumberOfChannels);
            for (int i = 0; i < ((ImageStackingParams)parameter).vom.Size; i++)
            {
                CvInvoke.BitwiseNot(((ImageStackingParams)parameter).vom[i], output, masks[i]);
                //CvInvoke.Imshow("Output", output);
                // CvInvoke.WaitKey(250);
                laps[i].Dispose();
                masks[i].Dispose();
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
                case "DurandParams":/*
                    toneMap = new Emgu.CV.XPhoto.TonemapDurand
                    {
                        Gamma = ((DurandParams)tempParams).gamma,
                        Contrast = ((DurandParams)tempParams).contrast,
                        Saturation = ((DurandParams)tempParams).saturation,
                        SigmaSpace = ((DurandParams)tempParams).sigma_space,
                        SigmaColor = ((DurandParams)tempParams).sigma_color
                    };*/
                    toneMap = new Tonemap
                    {
                        Gamma = ((DurandParams)tempParams).gamma
                    };
                    MessageBox.Show("Error on TonemapDurand, change to Tonemap.");
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
            AlignMTB alignMTB = new AlignMTB(5, 6, cut: false);
            alignMTB.Process(((ImageStackingParams)parameter).vom, ((ImageStackingParams)parameter).vom, new VectorOfFloat(), new Mat());
            alignMTB.Dispose();

            Mat mergeMat = new Mat();
            MergeMertens mergeMertens = new MergeMertens(1, 2, 2);
            mergeMertens.Process(((ImageStackingParams)parameter).vom, mergeMat);
            mergeMertens.Dispose();
            return mergeMat;
        }

        public void showResultImages()
        {
            HelperClass.showResultImagesStatic(m_bitmapList, m_DisplaySelection, ImageStackingResult.resultImage, ToolName, "StackImage");
        }

    }
}
