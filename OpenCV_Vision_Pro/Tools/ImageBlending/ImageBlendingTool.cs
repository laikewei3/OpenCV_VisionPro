using Emgu.CV;
using Emgu.CV.Util;
using OpenCV_Vision_Pro.Interface;
using Shared.ComponentModel.SortableBindingList;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace OpenCV_Vision_Pro.Tools.ImageBlending
{
    public class ImageBlendingParams : IParams
    {
        public string colorMode { get; set; } = "LAB";
        public SortableBindingList<string> selectedImage { get; set; } = new SortableBindingList<string>();
        public VectorOfMat vom { get; set; } = new VectorOfMat();
        public string weight { get; set; } = "";
    }

    public class ImageBlendingResults : IToolResult
    {

    }

    public class ImageBlendingTool : ITool
    {
        public string ToolName { get; set; }
        public AutoDisposeDict<string, Mat> m_bitmapList { get; set; }
        public BindingList<string> m_DisplaySelection { get; set; } = new BindingList<string>();
        public BindingSource resultSource { get; set; }
        public IUserControlBase m_toolControl { get; set; }
        public IParams parameter { get; set; } = new ImageBlendingParams();
        public IToolResult toolResult { get; set; }
        private ImageBlendingResults ImageBlendingResult { get { return (ImageBlendingResults)toolResult; } set { toolResult = value; } }

        public ImageBlendingTool(string toolName)
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
            m_toolControl = new ImageBlendingToolControl(parameter) { Dock = DockStyle.Top };
        }

        public void Run(Mat img, Rectangle region)
        {
            ImageBlendingResult?.Dispose();
            ImageBlendingResult = new ImageBlendingResults();

            int inputCnt = ((ImageBlendingParams)parameter).selectedImage.Count;
            if (inputCnt < 2)
            {
                MessageBox.Show("Please input AT LEAST 2 images for the operation.");
                ImageBlendingResult.resultImage = new Mat();
                return;
            }
            ImageBlendingResult.resultImage?.Dispose();
            double[] w;
            try
            {
                w = Array.ConvertAll(((ImageBlendingParams)parameter).weight.Split(','), Double.Parse);
                if (w.Length != inputCnt)
                {
                    MessageBox.Show("Weight Length != inputCnt. Default weight will be used for operation.");
                    w = new double[inputCnt];
                    for (int i = 0; i < w.Length; i++)
                    {
                        w[i] = 1.0 / inputCnt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Input Error. Default weight will be used for operation.\n" + ex.ToString());
                w = new double[inputCnt];
                for (int i = 0; i < w.Length; i++)
                {
                    w[i] = 1.0 / inputCnt;
                }
            }
            try
            {
                Mat output = new Mat();
                if (((ImageBlendingParams)parameter).colorMode == "LAB")
                {
                    Mat blend = Mat.Zeros(((ImageBlendingParams)parameter).vom[0].Rows,
                        ((ImageBlendingParams)parameter).vom[0].Cols,
                        ((ImageBlendingParams)parameter).vom[0].Depth,
                        ((ImageBlendingParams)parameter).vom[0].NumberOfChannels);
                    for (int i = 0; i < inputCnt; i++)
                    {
                        Mat labImg = new Mat();
                        CvInvoke.CvtColor(((ImageBlendingParams)parameter).vom[i], labImg, Emgu.CV.CvEnum.ColorConversion.Bgr2Lab);
                        blend += w[i] * labImg;
                        labImg.Dispose();
                    }
                    CvInvoke.CvtColor(blend, output, Emgu.CV.CvEnum.ColorConversion.Lab2Bgr);
                    blend.Dispose();
                }
                else
                {
                    for (int i = 0; i < inputCnt; i++)
                    {
                        output += w[i] * ((ImageBlendingParams)parameter).vom[i];
                    }
                }
                ImageBlendingResult.resultImage = output;
            }
            catch (CvException ex)
            {
                MessageBox.Show("Emgu CV Exception.\n"+ex.Message);
                ImageBlendingResult.resultImage = new Mat();
            }
            showResultImages();
        }

        public void showResultImages()
        {
            HelperClass.showResultImagesStatic(m_bitmapList, m_DisplaySelection, ImageBlendingResult.resultImage, ToolName, "BlendImage");
        }

    }
}
