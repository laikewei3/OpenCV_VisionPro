using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using OpenCV_Vision_Pro.Interface;
using OpenCV_Vision_Pro.Properties;
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
    public class ColorSegmentorParams : IParams
    {
        public ROI m_roi { get; set; } = new ROI();
        public bool m_boolHasROI { get; set; } = false;
        public SortableBindingList<ColorData> colorDatas { get; set; } = new SortableBindingList<ColorData>();
    }
    public class ColorSegmentorResults : IDisposable, IToolResult
    {
        public Mat resultImage { get; set; }

        public void Dispose()
        {
            resultImage?.Dispose();
        }
    }

    public partial class ColorSegmentorTool:IToolBase
    {
        public Bitmap toolIcon { get; } = Resources.segmentor;
        public string ToolName { get; set; }
        public UserControlBase m_toolControl { get; set; }
        public AutoDisposeDict<string, Mat> m_bitmapList { get; set; }
        public BindingList<string> m_DisplaySelection { get; set; } = new BindingList<string>();
        public BindingSource resultSource { get; set; }
        public Rectangle m_rectROI { get; set; }
        public IParams parameter { get; set; } = new ColorSegmentorParams();
        public IToolResult toolResult { get; set; }
        public ColorSegmentorResults segmentorResults
        {
            get { return (ColorSegmentorResults)toolResult; }
            set { toolResult = value; }
        }

        public ColorSegmentorTool(string toolName) { this.ToolName = toolName; }

        public  void getGUI()
        {
            if (m_rectROI != null && !m_rectROI.IsEmpty)
            {
                parameter.m_roi.location = new Point(m_rectROI.X, m_rectROI.Y);
                parameter.m_roi.ROI_Width = m_rectROI.Width;
                parameter.m_roi.ROI_Height = m_rectROI.Height;
            }
            m_toolControl = new ColorSegmentorToolControl(parameter) { Dock = DockStyle.Fill };
        }
        
        public  void Run(Mat img, Rectangle region)
        {
            Mat image;
            if (region.IsEmpty)
                image = img.Clone();
            else if(((ColorSegmentorToolControl)m_toolControl).m_roi.points == null)
                image = new Mat(img,region);
            else
            {
                Mat mask = Mat.Zeros(img.Rows, img.Cols, img.Depth, img.NumberOfChannels);
                CvInvoke.FillPoly(mask, new VectorOfPoint(((ColorSegmentorToolControl)m_toolControl).m_roi.points), new MCvScalar(255, 255, 255));

                Mat bitImage = new Mat();
                CvInvoke.BitwiseAnd(img, mask, bitImage);
                image = new Mat(bitImage, region);
                bitImage?.Dispose();
                mask?.Dispose();
            }

            segmentorResults?.Dispose();
            segmentorResults = new ColorSegmentorResults();

            if(((ColorSegmentorToolControl)m_toolControl) != null)
                parameter = ((ColorSegmentorToolControl)m_toolControl).ColorSegmentorParams;
            else
                parameter = new ColorSegmentorParams();

            Mat tempOut = null;
            foreach (ColorData cd in ((ColorSegmentorParams)parameter).colorDatas)
            {
                Mat colorMask = new Mat();
                ScalarArray minColor = new ScalarArray(new MCvScalar(cd.ColorCode.V0 - 10, cd.ColorCode.V1 - 10, cd.ColorCode.V2 - 10));
                ScalarArray maxColor = new ScalarArray(new MCvScalar(cd.ColorCode.V0 + 10, cd.ColorCode.V1 + 10, cd.ColorCode.V2 + 10));
                CvInvoke.InRange(image,minColor,maxColor,colorMask);

                if(tempOut == null)
                    tempOut = Mat.Zeros(colorMask.Rows, colorMask.Cols, colorMask.Depth, colorMask.NumberOfChannels);
                
                CvInvoke.BitwiseOr(colorMask, tempOut, tempOut);

                colorMask.Dispose();
                minColor.Dispose(); 
                maxColor.Dispose();
            }
            segmentorResults.resultImage = tempOut != null ? tempOut.Clone() : Mat.Zeros(image.Rows, image.Cols, DepthType.Cv8U, 1);
            tempOut?.Dispose();
            image.Dispose();
        }

        public  object showResult()
        {
            return null;
        }

        public  void showResultImages()
        {
            if (Form1.m_bitmapList.ContainsKey("LastRun." + ToolName + ".SegmentImage"))
            {
                Form1.m_bitmapList["LastRun." + ToolName + ".SegmentImage"]?.Dispose();
                Form1.m_bitmapList["LastRun." + ToolName + ".SegmentImage"] = segmentorResults.resultImage.Clone();
            }
            else
            {
                Form1.m_bitmapList.Add("LastRun." + ToolName + ".SegmentImage", segmentorResults.resultImage.Clone());
                if (!Form1.m_form1DisplaySelection.Contains("LastRun." + ToolName + ".SegmentImage"))
                    Form1.m_form1DisplaySelection.Add("LastRun." + ToolName + ".SegmentImage");
            }

            if (m_bitmapList.ContainsKey("LastRun." + ToolName + ".SegmentImage"))
            {
                m_bitmapList["LastRun." + ToolName + ".SegmentImage"]?.Dispose();
                m_bitmapList["LastRun." + ToolName + ".SegmentImage"] = segmentorResults.resultImage.Clone();
            }
            else
            {
                m_bitmapList.Add("LastRun." + ToolName + ".SegmentImage", segmentorResults.resultImage.Clone());
                if (!m_DisplaySelection.Contains("LastRun." + ToolName + ".SegmentImage"))
                    m_DisplaySelection.Add("LastRun." + ToolName + ".SegmentImage");
            }
        }

        public  void Dispose()
        {
            segmentorResults?.Dispose();
            m_toolControl?.Dispose();
            m_bitmapList?.Dispose();
            resultSource?.Dispose();
        }
    }
    
}