using Emgu.CV;
using Emgu.CV.Structure;
using OpenCV_Vision_Pro.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace OpenCV_Vision_Pro.Tools.ImageProcess.ProcessTool
{
    public class PaintParams:IParams
    {
        public string PaintMode { get; set; } = "No Rotation/Flip";
        public ROI m_roi { get; set; } = new ROI();
        public bool m_boolHasROI { get; set; } = false;
        public List<Point> InPaintPoints { get; set; } = new List<Point>();
        public int paintSize { get; set; } = 5;
    }

    public class PaintTool : IToolBase
    {
        public UserControlBase m_toolControl { get; set; }
        public Rectangle m_rectROI { get; set; }
        public IParams parameter { get; set; } = new PaintParams();
        public IToolResult toolResult { get; set; }
        public PaintResult PaintResult { get { return (PaintResult)toolResult; } set { toolResult = value; } }
        public string ToolName { get; set; }
        public AutoDisposeDict<string, Mat> m_bitmapList { get; set; }
        public BindingList<string> m_DisplaySelection { get; set; } = new BindingList<string>();
        public BindingSource resultSource { get; set; }

        public PaintTool(string toolName)
        {
            ToolName = toolName;
        }

        public void Dispose()
        {
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
            m_toolControl = new PaintToolControl(parameter) { Dock = DockStyle.Fill };
        }

        public void Run(Mat image, Rectangle region)
        {
            PaintResult?.Dispose();
            PaintResult = new PaintResult();
            
            if (((PaintParams)parameter).InPaintPoints.Count > 0)
            {
                if (image.NumberOfChannels > 3)
                    CvInvoke.CvtColor(image, image, Emgu.CV.CvEnum.ColorConversion.Bgra2Bgr);
                Mat mask = Mat.Zeros(image.Rows, image.Cols, image.Depth, 1);
                CvInvoke.Polylines(mask, ((PaintParams)parameter).InPaintPoints.ToArray(), false, new MCvScalar(255), 5);
                Mat processedImage = Mat.Zeros(image.Rows, image.Cols, image.Depth, image.NumberOfChannels);
                CvInvoke.Inpaint(image, mask, processedImage, 3, Emgu.CV.CvEnum.InpaintType.NS);
                PaintResult.resultImage = processedImage.Clone();
                mask.Dispose();
                processedImage.Dispose();
            }
            else
            {
                PaintResult.resultImage = image.Clone();
            }
        }

        public object showResult()
        {
            return null;
        }

        public void showResultImages()
        {
            if (Form1.m_bitmapList.ContainsKey("LastRun." + ToolName + ".PaintImage"))
            {
                Form1.m_bitmapList["LastRun." + ToolName + ".PaintImage"]?.Dispose();
                Form1.m_bitmapList["LastRun." + ToolName + ".PaintImage"] = PaintResult.resultImage.Clone();
            }
            else
            {
                Form1.m_bitmapList.Add("LastRun." + ToolName + ".PaintImage", PaintResult.resultImage.Clone());
                if (!Form1.m_form1DisplaySelection.Contains("LastRun." + ToolName + ".PaintImage"))
                    Form1.m_form1DisplaySelection.Add("LastRun." + ToolName + ".PaintImage");
            }

            if (m_bitmapList.ContainsKey("LastRun." + ToolName + ".PaintImage"))
            {
                m_bitmapList["LastRun." + ToolName + ".PaintImage"]?.Dispose();
                m_bitmapList["LastRun." + ToolName + ".PaintImage"] = PaintResult.resultImage.Clone();
            }
            else
            {
                m_bitmapList.Add("LastRun." + ToolName + ".PaintImage", PaintResult.resultImage.Clone());
                if (!m_DisplaySelection.Contains("LastRun." + ToolName + ".PaintImage"))
                    m_DisplaySelection.Add("LastRun." + ToolName + ".PaintImage");
            }
        }
    }

    public class PaintResult : IToolResult, IDisposable
    {
        public Mat resultImage { get; set;}

        public void Dispose()
        {
            resultImage?.Dispose();
        }
    }
}
