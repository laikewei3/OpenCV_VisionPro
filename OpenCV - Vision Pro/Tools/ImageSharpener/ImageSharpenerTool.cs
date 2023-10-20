using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using OpenCV_Vision_Pro.Interface;
using OpenCV_Vision_Pro.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenCV_Vision_Pro
{
    public class SharpenerParams : IParams
    {
        public ROI m_roi { get; set; } = new ROI();
        public bool m_boolHasROI { get; set; } = false;
        public string runMode { get; set; } = "Sharper";
        public double gamma { get; set; } = 1.0;
    }
    public class ImageSharpenerTool : IToolBase
    {
        public  Bitmap toolIcon { get; } = Resources.play;
        public  string ToolName { get; set; }
        public  AutoDisposeDict<string, Mat> m_bitmapList { get; set; }
        public  BindingList<string> m_DisplaySelection { get; set; } = new BindingList<string>();
        public  UserControlBase m_toolControl { get; set; }
        public  Rectangle m_rectROI { get; set; }
        public  IParams parameter { get; set; } = new SharpenerParams();
        public  BindingSource resultSource { get; set; }

        public  IToolResult toolResult { get; set; }
        private SharpenerResults SharpenerResult { get { return (SharpenerResults)toolResult; } set { toolResult = value; } }

        public ImageSharpenerTool(string toolName) { this.ToolName = toolName; }

        public  void Dispose()
        {
            toolIcon?.Dispose();
            m_bitmapList?.Dispose();
            m_toolControl?.Dispose();
            resultSource?.Dispose();
        }

        public  void getGUI()
        {
            if (m_rectROI != null && !m_rectROI.IsEmpty)
            {
                parameter.m_roi.location = new Point(m_rectROI.X, m_rectROI.Y);
                parameter.m_roi.ROI_Width = m_rectROI.Width;
                parameter.m_roi.ROI_Height = m_rectROI.Height;
            }
            m_toolControl = new ImageSharpenerToolControl(parameter) { Dock = DockStyle.Fill };
        }

        public  void Run(Mat img, Rectangle region)
        {
            Mat image;
            if (region.IsEmpty)
                image = img.Clone();
            else if (((ImageSharpenerToolControl)m_toolControl).m_roi.points == null)
                image = new Mat(img, region);
            else
            {
                Mat mask = Mat.Zeros(img.Rows, img.Cols, img.Depth, img.NumberOfChannels);
                CvInvoke.FillPoly(mask, new VectorOfPoint(((ImageSharpenerToolControl)m_toolControl).m_roi.points), new MCvScalar(255, 255, 255));

                Mat bitImage = new Mat();
                CvInvoke.BitwiseAnd(img, mask, bitImage);
                image = new Mat(bitImage, region);
                bitImage?.Dispose();
                mask?.Dispose();
            }

            SharpenerResult?.Dispose();
            SharpenerResult = new SharpenerResults();

            RunByMode(image,((SharpenerParams)parameter).runMode);

            Mat sharpScore = new Mat();
            CvInvoke.Laplacian(SharpenerResult.resultImage, sharpScore, DepthType.Cv64F);
            MCvScalar mean = new MCvScalar(), stdDev = new MCvScalar();
            CvInvoke.MeanStdDev(sharpScore, ref mean, ref stdDev);
            SharpenerResult.scoreVariance = stdDev.V0 * stdDev.V0;
            sharpScore.Dispose();

            image?.Dispose();
        }

        private void RunByMode(Mat image, string mode)
        {
            switch (mode)
            {
                case "Sharper":
                    int[,,] data = new int[,,] { { { 0 }, { -1 }, { 0 } }, { { -1 }, { 5 }, { -1 } }, { { 0 }, { -1 }, { 0 } } };
                    Image<Gray, int> kernel = new Image<Gray, int>(data);
                    SharpenerResult.resultImage = image.Clone();
                    CvInvoke.Filter2D(image, SharpenerResult.resultImage, kernel, new Point(-1, -1));
                    break;
                case "Expose":
                    Matrix<double> matrixLUT = new Matrix<double>(1,256);
                    for(int i = 0; i < 256; i++)
                    {
                        double invGamma = 1.0 / ((SharpenerParams)parameter).gamma;
                        matrixLUT.Data[0, i] = (Math.Pow(i / 255.0, invGamma)*255);
                    }
                    Mat tempLut = new Mat();
                    SharpenerResult.resultImage = new Mat();
                    CvInvoke.LUT(image,matrixLUT, tempLut);
                    tempLut.ConvertTo(SharpenerResult.resultImage, DepthType.Cv8U);
                    tempLut.Dispose();
                    break;
                case "Equalise(Fixed)":
                    SharpenerResult.resultImage = new Mat();
                    if (image.NumberOfChannels == 1)
                        CvInvoke.EqualizeHist(image, SharpenerResult.resultImage);
                    else
                    {
                        CvInvoke.CvtColor(image,image,ColorConversion.Bgr2YCrCb);
                        VectorOfMat channel = new VectorOfMat();
                        CvInvoke.Split(image,channel);

                        CvInvoke.EqualizeHist(channel[0], channel[0]);
                        CvInvoke.Merge(channel, image);
                        CvInvoke.CvtColor(image, SharpenerResult.resultImage, ColorConversion.YCrCb2Bgr);
                    }
                    break;
                case "Equalise(Adaptive)":
                    SharpenerResult.resultImage = new Mat();
                    if (image.NumberOfChannels == 1) 
                        CvInvoke.CLAHE(image, 2.0, new Size(8, 8), SharpenerResult.resultImage);
                    else
                    {
                        CvInvoke.CvtColor(image, image, ColorConversion.Bgr2YCrCb);
                        VectorOfMat channel = new VectorOfMat();
                        CvInvoke.Split(image, channel);

                        CvInvoke.CLAHE(channel[0],2.0,new Size(8,8), channel[0]);

                        CvInvoke.Merge(channel, image);
                        CvInvoke.CvtColor(image, SharpenerResult.resultImage, ColorConversion.YCrCb2Bgr);
                    }
                    break;
                default:
                    SharpenerResult.resultImage = new Mat();
                    break;
            }
        }

        public  object showResult()
        {
            if(SharpenerResult != null)
                return SharpenerResult.scoreVariance;
            return null;
        }

        public  void showResultImages()
        {
            if (Form1.m_bitmapList.ContainsKey("LastRun." + ToolName + ".SharpenerImage"))
            {
                Form1.m_bitmapList["LastRun." + ToolName + ".SharpenerImage"]?.Dispose();
                Form1.m_bitmapList["LastRun." + ToolName + ".SharpenerImage"] = SharpenerResult.resultImage.Clone();
            }
            else
            {
                Form1.m_bitmapList.Add("LastRun." + ToolName + ".SharpenerImage", SharpenerResult.resultImage.Clone());
                if (!Form1.m_form1DisplaySelection.Contains("LastRun." + ToolName + ".SharpenerImage"))
                    Form1.m_form1DisplaySelection.Add("LastRun." + ToolName + ".SharpenerImage");
            }

            if (m_bitmapList.ContainsKey("LastRun." + ToolName + ".SharpenerImage"))
            {
                m_bitmapList["LastRun." + ToolName + ".SharpenerImage"]?.Dispose();
                m_bitmapList["LastRun." + ToolName + ".SharpenerImage"] = SharpenerResult.resultImage.Clone();
            }
            else
            {
                m_bitmapList.Add("LastRun." + ToolName + ".SharpenerImage", SharpenerResult.resultImage.Clone());
                if (!m_DisplaySelection.Contains("LastRun." + ToolName + ".SharpenerImage"))
                    m_DisplaySelection.Add("LastRun." + ToolName + ".SharpenerImage");
            }
        }

        private class SharpenerResults : IDisposable, IToolResult
        {
            public Mat resultImage { get; set; }
            public double scoreVariance { get; set; }

            public void Dispose()
            {
                resultImage?.Dispose();
            }
        }

    }
}
