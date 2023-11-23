using Emgu.CV;
using Emgu.CV.DnnSuperres;
using OpenCV_Vision_Pro.Interface;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace OpenCV_Vision_Pro.Tools.ImageProcess.ProcessTool
{
    public class SuperResolutionParams : IParams
    {
        public string SuperResolutionMode { get; set; } = "Bicubic";
        public Size resizeSize { get; set; } = new Size();
        public int upscale { get; set; } = 1;
        public bool maintainRatio { get; set; } = true;
    }

    public class SuperResolutionTool : IBaseTool
    {
        public IUserControlBase m_toolControl { get; set; }
        public IParams parameter { get; set; } = new SuperResolutionParams();
        public IToolResult toolResult { get; set; }
        public SuperResolutionResult SuperResolutionResult { get { return (SuperResolutionResult)toolResult; } set { toolResult = value; } }

        public void Dispose()
        {
            m_toolControl?.Dispose();
        }

        public void getGUI()
        {
            m_toolControl = new SuperResolutionToolControl(parameter) { Dock = DockStyle.Fill };
        }

        public void Run(Mat image, Rectangle region)
        {   
            Cursor.Current = Cursors.WaitCursor;
            SuperResolutionResult?.Dispose();
            SuperResolutionResult = new SuperResolutionResult();
            string mode = ((SuperResolutionParams)parameter).SuperResolutionMode.ToLower();
            SuperResolutionResult.resultImage = new Mat();
            switch (mode)
            {
                case "bicubic":
                    CvInvoke.Resize(image, SuperResolutionResult.resultImage, ((SuperResolutionParams)parameter).resizeSize, interpolation: Emgu.CV.CvEnum.Inter.Cubic);
                    break;
                case "edsr":
                case "espcn":
                case "fsrcnn":
                case "lapsrn":
                    if (((SuperResolutionParams)parameter).upscale < 2)
                    {
                        MessageBox.Show("Cannot upscale to <= 1, remain the same.");
                        ((SuperResolutionParams)parameter).upscale = 1;
                        SuperResolutionResult.resultImage = image.Clone();
                        break;
                    }
                    DnnSuperResImpl dnnSuperRes = new DnnSuperResImpl();
                    if (mode == "lapsrn")
                    {
                        if (((SuperResolutionParams)parameter).upscale == 3)
                        {
                            MessageBox.Show("LapSRN Cannot upscale to 3, change to 2.");
                            ((SuperResolutionParams)parameter).upscale = 2;
                        }
                        else if (((SuperResolutionParams)parameter).upscale > 4 && ((SuperResolutionParams)parameter).upscale < 8)
                        {
                            MessageBox.Show("LapSRN Cannot upscale to 5-7, change to 4.");
                            ((SuperResolutionParams)parameter).upscale = 4;
                        }
                        else if (((SuperResolutionParams)parameter).upscale > 8)
                        {
                            MessageBox.Show("LapSRN Cannot upscale to > 8, change to 8.");
                            ((SuperResolutionParams)parameter).upscale = 8;
                        }
                    }
                    else if (((SuperResolutionParams)parameter).upscale > 4)
                    {
                        MessageBox.Show("Cannot upscale to > 4, change to 4.");
                        ((SuperResolutionParams)parameter).upscale = 4;
                    }
                    dnnSuperRes.ReadModel("C:\\Users\\T0571\\source\\repos\\OpenCV_Vision_Pro\\OpenCV_Vision_Pro\\SuperResolutionModel\\" + mode + "\\" + mode + "x" + ((SuperResolutionParams)parameter).upscale + ".pb");
                    dnnSuperRes.SetModel(mode.ToLower(), ((SuperResolutionParams)parameter).upscale);
                    dnnSuperRes.Upsample(image, SuperResolutionResult.resultImage);
                    break;
            }
            Cursor.Current = Cursors.Default;
            image?.Dispose();
        }
    }

    public class SuperResolutionResult : IToolResult, IDisposable
    { }
}
