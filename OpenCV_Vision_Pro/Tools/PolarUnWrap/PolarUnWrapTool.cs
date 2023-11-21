using Emgu.CV;
using Emgu.CV.CvEnum;
using OpenCV_Vision_Pro.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace OpenCV_Vision_Pro.Tools.PolarUnWrap
{
    public class PolarUnWrapParams : IParams
    {
        public int lineheight { get; set; } = 50;

        public string rotation { get; set; } = "No Rotation";
    }

    public class PolarUnWrapResult : IToolResult
    {
    }

    public class PolarUnWrapTool : ITool
    {
        public string ToolName { get; set; }
        public AutoDisposeDict<string, Mat> m_bitmapList { get; set; }
        public BindingList<string> m_DisplaySelection { get; set; } = new BindingList<string>();
        public IUserControlBase m_toolControl { get; set; }
        public IParams parameter { get; set; } = new PolarUnWrapParams();
        public BindingSource resultSource { get; set; }
        public IToolResult toolResult { get; set; }
        private PolarUnWrapResult PolarUnWrapResult { get { return (PolarUnWrapResult)toolResult; } set { toolResult = value; } }

        public void Dispose()
        {
            m_bitmapList?.Dispose();
            m_toolControl?.Dispose();
            resultSource?.Dispose();
        }

        public void getGUI()
        {
            m_toolControl = new PolarUnwrapToolControl(parameter) { Dock = DockStyle.Fill };
        }

        public PolarUnWrapTool(string toolName)
        {
            ToolName = toolName;
        }

        public void Run(Mat img, Rectangle region)
        {
            if (((PolarUnwrapToolControl)m_toolControl) != null)
                parameter = ((PolarUnwrapToolControl)m_toolControl).PolarUnWrapParams;
            else
                parameter = new PolarUnWrapParams();

            //=============================================== Delete Previous Results =============================================
            PolarUnWrapResult?.Dispose();
            PolarUnWrapResult = new PolarUnWrapResult();
            //=====================================================================================================================

            parameter.m_roi.ROIRectangle = HelperClass.getROIImage(img, region, parameter.m_roi.points, out Mat image);
            
            int radius = Math.Min(image.Width, image.Height)/2;

            OpenCvSharp.Point2f center = new OpenCvSharp.Point2f(radius, radius);
            int maxRadius = (int)Math.Min(center.X, center.Y);

            byte[] byteArr = CvInvoke.Imencode(".png", image, new KeyValuePair<ImwriteFlags, int>());

            OpenCvSharp.Mat cvSharpMat = OpenCvSharp.Cv2.ImDecode(byteArr, OpenCvSharp.ImreadModes.AnyColor);
            OpenCvSharp.InterpolationFlags flags = OpenCvSharp.InterpolationFlags.WarpFillOutliers | OpenCvSharp.InterpolationFlags.Linear;
            OpenCvSharp.Mat outputImage = new OpenCvSharp.Mat();
            OpenCvSharp.Cv2.WarpPolar(cvSharpMat, outputImage, new OpenCvSharp.Size(), center, maxRadius, flags, OpenCvSharp.WarpPolarMode.Linear);

            OpenCvSharp.Cv2.Rotate(outputImage, outputImage, OpenCvSharp.RotateFlags.Rotate90Counterclockwise);

            outputImage = new OpenCvSharp.Mat(outputImage, new OpenCvSharp.Rect(0, 0, outputImage.Width, ((PolarUnWrapParams)parameter).lineheight > maxRadius ? maxRadius : ((PolarUnWrapParams)parameter).lineheight));

            if(Enum.TryParse(((PolarUnWrapParams)parameter).rotation, out OpenCvSharp.RotateFlags rotateFlag))
                OpenCvSharp.Cv2.Rotate(outputImage, outputImage, rotateFlag);

            Mat emguMat = new Mat();
            CvInvoke.Imdecode(outputImage.ToBytes(), ImreadModes.AnyColor, emguMat);
            PolarUnWrapResult.resultImage = emguMat.Clone();
            emguMat.Dispose();
            cvSharpMat.Dispose();
            outputImage.Dispose();
            image.Dispose();
        }


        public void showResultImages()
        {
            HelperClass.showResultImagesStatic(m_bitmapList, m_DisplaySelection, PolarUnWrapResult.resultImage, ToolName, "PolarUnwrapImage");
        }
    }
}
