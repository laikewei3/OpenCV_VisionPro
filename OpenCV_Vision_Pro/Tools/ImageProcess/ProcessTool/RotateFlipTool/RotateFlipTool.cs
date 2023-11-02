using Emgu.CV;
using OpenCV_Vision_Pro.Interface;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace OpenCV_Vision_Pro.Tools.ImageProcess.ProcessTool
{
    public class RotateFlipParams:IParams
    {
        public string rotateFlipMode { get; set; } = "No Rotation/Flip";
        public ROI m_roi { get; set; } = new ROI();
        public bool m_boolHasROI { get; set; } = false;
    }

    public class RotateFlipTool : ISimpleToolBase
    {
        public UserControlBase m_toolControl { get; set; }
        public IParams parameter { get; set; } = new RotateFlipParams();
        public IToolResult toolResult { get; set; }
        public RotateFlipResult RotateFlipResult { get { return (RotateFlipResult)toolResult; } set { toolResult = value; } }

        public void Dispose()
        {
            m_toolControl?.Dispose();
        }

        public void getGUI()
        {
            m_toolControl = new RotateFlipToolControl(parameter) { Dock = DockStyle.Fill };
        }

        public void Run(Mat image, Rectangle region)
        {
            RotateFlipResult?.Dispose();
            RotateFlipResult = new RotateFlipResult();
            string mode = ((RotateFlipParams)parameter).rotateFlipMode;
            Mat processedImage = new Mat();
            switch (mode)
            {
                case "No Rotation/Flip":
                    RotateFlipResult.resultImage = image.Clone();
                    break;
                case "Rotate 90 degree Clockwise":
                    CvInvoke.Rotate(image,processedImage,Emgu.CV.CvEnum.RotateFlags.Rotate90Clockwise);
                    RotateFlipResult.resultImage = processedImage.Clone();
                    break;
                case "Rotate 90 degree Counter Clockwise":
                    CvInvoke.Rotate(image, processedImage, Emgu.CV.CvEnum.RotateFlags.Rotate90CounterClockwise);
                    RotateFlipResult.resultImage = processedImage.Clone();
                    break;
                case "Rotate 180 degree":
                    CvInvoke.Rotate(image, processedImage, Emgu.CV.CvEnum.RotateFlags.Rotate180);
                    RotateFlipResult.resultImage = processedImage.Clone();
                    break;
                case "Flip Horizontal":
                    CvInvoke.Flip(image, processedImage, Emgu.CV.CvEnum.FlipType.Horizontal);
                    RotateFlipResult.resultImage = processedImage.Clone();
                    break;
                case "Flip Vertical":
                    CvInvoke.Flip(image, processedImage, Emgu.CV.CvEnum.FlipType.Vertical);
                    RotateFlipResult.resultImage = processedImage.Clone();
                    break;
                case "Flip Both Vertical and Horizontal":
                    CvInvoke.Flip(image, processedImage, Emgu.CV.CvEnum.FlipType.Both);
                    RotateFlipResult.resultImage = processedImage.Clone();
                    break;
            }
            processedImage.Dispose();
            image?.Dispose();
        }
    }

    public class RotateFlipResult : IToolResult, IDisposable
    {
        public Mat resultImage { get; set;}

        public void Dispose()
        {
            resultImage?.Dispose();
        }
    }
}
