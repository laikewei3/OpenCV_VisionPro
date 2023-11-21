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
    public class PaintParams : IParams
    {
        public List<Point> InPaintPoints { get; set; } = new List<Point>();
        public int paintSize { get; set; } = 5;
    }

    public class PaintTool : ITool
    {
        public IUserControlBase m_toolControl { get; set; }
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
            resultSource?.Dispose();
            toolResult?.Dispose();
            m_bitmapList?.Dispose();
        }

        public void getGUI()
        {
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

        public void showResultImages()
        {
            HelperClass.showResultImagesStatic(m_bitmapList, m_DisplaySelection, PaintResult.resultImage, ToolName, "PaintImage");
        }
    }

    public class PaintResult : IToolResult
    {
    }
}
