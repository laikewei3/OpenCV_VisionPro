using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using OpenCV_Vision_Pro.Interface;
using OpenCV_Vision_Pro.Properties;
using OpenCV_Vision_Pro.Tools.ColorMatcher;
using OpenCV_Vision_Pro.Tools.ImageSegmentor;
using Shared.ComponentModel.SortableBindingList;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenCV_Vision_Pro
{
    public class ColorExtractorParams : IParams
    {
        public ROI m_roi { get; set; } = new ROI();
        public bool m_boolHasROI { get; set; } = false;
        public SortableBindingList<ColorData> colorDatas { get; set; } = new SortableBindingList<ColorData>();
    }
    public class ColorExtractorResults : IDisposable, IToolResult
    {
        public Mat resultImage { get; set; }
        public Mat grayImage { get; set; }

        public void Dispose()
        {
            resultImage?.Dispose();
            grayImage?.Dispose();
        }
    }

    public partial class ColorExtractorTool:IToolBase
    {
        public Bitmap toolIcon { get; } = Resources.segmentor;
        public string ToolName { get; set; }
        public UserControlBase m_toolControl { get; set; }
        public AutoDisposeDict<string, Mat> m_bitmapList { get; set; }
        public BindingList<string> m_DisplaySelection { get; set; } = new BindingList<string>();
        public BindingSource resultSource { get; set; }
        public Rectangle m_rectROI { get; set; }
        public IParams parameter { get; set; } = new ColorExtractorParams();
        public IToolResult toolResult { get; set; }
        public ColorExtractorResults extractorResults
        {
            get { return (ColorExtractorResults)toolResult; }
            set { toolResult = value; }
        }

        public ColorExtractorTool(string toolName) { this.ToolName = toolName; }

        public  void getGUI()
        {
            if (m_rectROI != null && !m_rectROI.IsEmpty)
            {
                parameter.m_roi.location = new Point(m_rectROI.X, m_rectROI.Y);
                parameter.m_roi.ROI_Width = m_rectROI.Width;
                parameter.m_roi.ROI_Height = m_rectROI.Height;
            }
            m_toolControl = new ColorExtractorToolControl(parameter) { Dock = DockStyle.Fill };
        }
        
        public  void Run(Mat img, Rectangle region)
        {
            Mat image = HelperClass.getROIImage(img, region, parameter.m_roi.points);

            extractorResults?.Dispose();
            extractorResults = new ColorExtractorResults();

            if(((ColorExtractorToolControl)m_toolControl) != null)
                parameter = ((ColorExtractorToolControl)m_toolControl).ColorExtractorParams;
            else
                parameter = new ColorExtractorParams();


            Mat grayOutput = null;
            foreach (ColorData cd in ((ColorExtractorParams)parameter).colorDatas)
            {
                Mat colorMask = new Mat();
                foreach (MCvScalar color in cd.colorPalette)
                {
                    ScalarArray minColor = new ScalarArray(new MCvScalar(color.V0 - 10, color.V1 - 10, color.V2 - 10));
                    ScalarArray maxColor = new ScalarArray(new MCvScalar(color.V0 + 10, color.V1 + 10, color.V2 + 10));
                    CvInvoke.InRange(image, minColor, maxColor, colorMask);

                    if (grayOutput == null)
                        grayOutput = Mat.Zeros(colorMask.Rows, colorMask.Cols, colorMask.Depth, colorMask.NumberOfChannels);

                    CvInvoke.BitwiseOr(colorMask, grayOutput, grayOutput);
                    minColor.Dispose();
                    maxColor.Dispose();
                }
                colorMask.Dispose();
            }

            //Gray Scale Image
            extractorResults.grayImage = grayOutput != null ? grayOutput.Clone() : Mat.Zeros(image.Rows, image.Cols, DepthType.Cv8U, 1);

            Mat colorOutput = Mat.Zeros(image.Rows, image.Cols, DepthType.Cv8U, 1);
            Mat tempMask = new Mat();
            CvInvoke.CvtColor(extractorResults.grayImage, tempMask, ColorConversion.Gray2Bgr);
            CvInvoke.BitwiseAnd(tempMask, image, colorOutput);
            extractorResults.resultImage = colorOutput.Clone();

            tempMask.Dispose();
            colorOutput.Dispose();
            grayOutput?.Dispose();
            image.Dispose();
        }

        public  object showResult()
        {
            return null;
        }

        public  void showResultImages()
        {
            if (Form1.m_bitmapList.ContainsKey("LastRun." + ToolName + ".OverallColorImage"))
            {
                Form1.m_bitmapList["LastRun." + ToolName + ".OverallColorImage"]?.Dispose();
                Form1.m_bitmapList["LastRun." + ToolName + ".GrayScaleImage"]?.Dispose();
                Form1.m_bitmapList["LastRun." + ToolName + ".OverallColorImage"] = extractorResults.resultImage.Clone();
                Form1.m_bitmapList["LastRun." + ToolName + ".GrayScaleImage"] = extractorResults.grayImage.Clone();
            }
            else
            {
                Form1.m_bitmapList.Add("LastRun." + ToolName + ".OverallColorImage", extractorResults.resultImage.Clone());
                Form1.m_bitmapList.Add("LastRun." + ToolName + ".GrayScaleImage", extractorResults.grayImage.Clone());
                if (!Form1.m_form1DisplaySelection.Contains("LastRun." + ToolName + ".OverallColorImage"))
                {
                    Form1.m_form1DisplaySelection.Add("LastRun." + ToolName + ".OverallColorImage");
                    Form1.m_form1DisplaySelection.Add("LastRun." + ToolName + ".GrayScaleImage");
                }
            }

            if (m_bitmapList.ContainsKey("LastRun." + ToolName + ".OverallColorImage"))
            {
                m_bitmapList["LastRun." + ToolName + ".OverallColorImage"]?.Dispose();
                m_bitmapList["LastRun." + ToolName + ".GrayScaleImage"]?.Dispose();
                m_bitmapList["LastRun." + ToolName + ".OverallColorImage"] = extractorResults.resultImage.Clone();
                m_bitmapList["LastRun." + ToolName + ".GrayScaleImage"] = extractorResults.grayImage.Clone();
            }
            else
            {
                m_bitmapList.Add("LastRun." + ToolName + ".OverallColorImage", extractorResults.resultImage.Clone());
                m_bitmapList.Add("LastRun." + ToolName + ".GrayScaleImage", extractorResults.grayImage.Clone());
                if (!m_DisplaySelection.Contains("LastRun." + ToolName + ".OverallColorImage"))
                {
                    m_DisplaySelection.Add("LastRun." + ToolName + ".OverallColorImage");
                    m_DisplaySelection.Add("LastRun." + ToolName + ".GrayScaleImage");
                }
                    
            }
        }

        public  void Dispose()
        {
            extractorResults?.Dispose();
            m_toolControl?.Dispose();
            m_bitmapList?.Dispose();
            resultSource?.Dispose();
        }
    }
    
}