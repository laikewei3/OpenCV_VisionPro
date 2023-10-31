using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using OpenCV_Vision_Pro.Interface;
using OpenCV_Vision_Pro.Properties;
using OpenCV_Vision_Pro.Tools.ColorMatcher;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenCV_Vision_Pro
{
    public class ConvertParams : IParams
    {
        public ROI m_roi { get; set; } = new ROI();
        public bool m_boolHasROI { get; set; } = false;

        public string runMode { get; set; } = "Intensity";
    }
    public class ImageConvertTool : IToolBase
    {
        public string ToolName { get; set; }
        public AutoDisposeDict<string, Mat> m_bitmapList { get; set; }
        public BindingList<string> m_DisplaySelection { get; set; } = new BindingList<string>();
        public UserControlBase m_toolControl { get; set; }
        public Rectangle m_rectROI { get; set; }
        public IParams parameter { get; set; } = new ConvertParams();
        public BindingSource resultSource { get; set; }

        public IToolResult toolResult { get; set; }
        private ConvertResults convertResults { get { return (ConvertResults)toolResult; } set { toolResult = value; } }

        public ImageConvertTool(string toolName) { this.ToolName = toolName; }

        public void Dispose()
        {
            m_bitmapList?.Dispose();
            m_toolControl?.Dispose();
            resultSource?.Dispose();
        }

        public void getGUI()
        {
            if (m_rectROI != null && !m_rectROI.IsEmpty)
            {
                parameter.m_roi.location = new Point(m_rectROI.X, m_rectROI.Y);
                parameter.m_roi.ROI_Width = m_rectROI.Width;
                parameter.m_roi.ROI_Height = m_rectROI.Height;
            }
            m_toolControl = new ImageConvertToolControl(parameter) { Dock = DockStyle.Fill };
        }

        public void Run(Mat img, Rectangle region)
        {
            parameter.m_roi.ROIRectangle = HelperClass.getROIImage(img, region, parameter.m_roi.points, out Mat image);
            convertResults?.Dispose();
            convertResults = new ConvertResults();

            string m_strSelectedMode = ((ConvertParams)parameter).runMode;
            RunByMode(m_strSelectedMode, image);
        }

        private void RunByMode(string m_strSelectedMode, Mat image)
        {
            try
            {
                convertResults.resultImage = new Mat();
                switch (m_strSelectedMode)
                {
                    case "Intensity":
                        if (image.NumberOfChannels == 1)
                        {
                            convertResults.resultImage?.Dispose();
                            convertResults.resultImage = image.Clone();
                        }
                        else
                            CvInvoke.CvtColor(image, convertResults.resultImage, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);
                        break;
                    case "HSV":
                        CvInvoke.CvtColor(image, convertResults.resultImage, Emgu.CV.CvEnum.ColorConversion.Bgr2Hsv);
                        break;
                    case "HSV to BGR":
                        CvInvoke.CvtColor(image, convertResults.resultImage, Emgu.CV.CvEnum.ColorConversion.Hsv2Bgr);
                        break;
                    case "YUV to BGR":
                        CvInvoke.CvtColor(image, convertResults.resultImage, Emgu.CV.CvEnum.ColorConversion.Yuv2Bgr);
                        break;
                    case "Red":
                    case "Blue":
                    case "Green":
                        VectorOfMat vectorOfMat = new VectorOfMat();
                        CvInvoke.Split(image, vectorOfMat);
                        convertResults.resultImage?.Dispose();
                        if (String.Compare(m_strSelectedMode, "Red") == 0)
                            convertResults.resultImage = vectorOfMat[2].Clone();
                        else if (String.Compare(m_strSelectedMode, "Blue") == 0)
                            convertResults.resultImage = vectorOfMat[0].Clone();
                        else if (String.Compare(m_strSelectedMode, "Green") == 0)
                            convertResults.resultImage = vectorOfMat[1].Clone();
                        vectorOfMat.Dispose();
                        break;
                    case "YUV":
                        CvInvoke.CvtColor(image, convertResults.resultImage, Emgu.CV.CvEnum.ColorConversion.Bgr2Yuv);
                        break;
                }
                image.Dispose();
            }
            catch (Exception)
            {
                convertResults.resultImage = image.Clone();
            }

        }

        public object showResult()
        {
            return null;
        }

        public void showResultImages()
        {
            if (Form1.m_bitmapList.ContainsKey("LastRun." + ToolName + ".ConvertImage"))
            {
                Form1.m_bitmapList["LastRun." + ToolName + ".ConvertImage"]?.Dispose();
                Form1.m_bitmapList["LastRun." + ToolName + ".ConvertImage"] = convertResults.resultImage.Clone();
            }
            else
            {
                Form1.m_bitmapList.Add("LastRun." + ToolName + ".ConvertImage", convertResults.resultImage.Clone());
                if (!Form1.m_form1DisplaySelection.Contains("LastRun." + ToolName + ".ConvertImage"))
                    Form1.m_form1DisplaySelection.Add("LastRun." + ToolName + ".ConvertImage");
            }

            if (m_bitmapList.ContainsKey("LastRun." + ToolName + ".ConvertImage"))
            {
                m_bitmapList["LastRun." + ToolName + ".ConvertImage"]?.Dispose();
                m_bitmapList["LastRun." + ToolName + ".ConvertImage"] = convertResults.resultImage.Clone();
            }
            else
            {
                m_bitmapList.Add("LastRun." + ToolName + ".ConvertImage", convertResults.resultImage.Clone());
                if (!m_DisplaySelection.Contains("LastRun." + ToolName + ".ConvertImage"))
                    m_DisplaySelection.Add("LastRun." + ToolName + ".ConvertImage");
            }
        }

        private class ConvertResults : IDisposable, IToolResult
        {
            public Mat resultImage { get; set; }

            public void Dispose()
            {
                resultImage?.Dispose();
            }
        }

    }
}
