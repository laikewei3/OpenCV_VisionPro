using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using OpenCV_Vision_Pro.Interface;
using OpenCV_Vision_Pro.Tools.ImageSegmentor;
using Shared.ComponentModel.SortableBindingList;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace OpenCV_Vision_Pro
{
    public class ColorSegmentorParams : IParams
    {
        public SortableBindingList<ColorData> colorDatas { get; set; } = new SortableBindingList<ColorData>();
    }

    public class ColorSegmentorResults : IToolResult
    { }

    public partial class ColorSegmentorTool : IToolData
    {
        public string ToolName { get; set; }
        public IUserControlBase m_toolControl { get; set; }
        public AutoDisposeDict<string, Mat> m_bitmapList { get; set; }
        public BindingList<string> m_DisplaySelection { get; set; } = new BindingList<string>();
        public BindingSource resultSource { get; set; }
        public IParams parameter { get; set; } = new ColorSegmentorParams();
        public IToolResult toolResult { get; set; }
        public ColorSegmentorResults segmentorResults
        {
            get { return (ColorSegmentorResults)toolResult; }
            set { toolResult = value; }
        }

        public ColorSegmentorTool(string toolName) { this.ToolName = toolName; }

        public void getGUI()
        {
            m_toolControl = new ColorSegmentorToolControl(parameter) { Dock = DockStyle.Fill };
        }

        public void Run(Mat img, Rectangle region)
        {
            parameter.m_roi.ROIRectangle = HelperClass.getROIImage(img, region, parameter.m_roi.points, out Mat image);

            segmentorResults?.Dispose();
            segmentorResults = new ColorSegmentorResults();

            if (((ColorSegmentorToolControl)m_toolControl) != null)
                parameter = ((ColorSegmentorToolControl)m_toolControl).ColorSegmentorParams;
            else
                parameter = new ColorSegmentorParams();

            Mat tempOut = null;
            foreach (ColorData cd in ((ColorSegmentorParams)parameter).colorDatas)
            {
                Mat colorMask = new Mat();
                ScalarArray minColor = new ScalarArray(new MCvScalar(cd.ColorCode.V0 - 10, cd.ColorCode.V1 - 10, cd.ColorCode.V2 - 10));
                ScalarArray maxColor = new ScalarArray(new MCvScalar(cd.ColorCode.V0 + 10, cd.ColorCode.V1 + 10, cd.ColorCode.V2 + 10));
                CvInvoke.InRange(image, minColor, maxColor, colorMask);

                if (tempOut == null)
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

        public object showResult()
        {
            return null;
        }

        public void showResultImages()
        {
            HelperClass.showResultImagesStatic(m_bitmapList, m_DisplaySelection, segmentorResults.resultImage, ToolName, "SegmentImage");
        }

        public void Dispose()
        {
            segmentorResults?.Dispose();
            m_toolControl?.Dispose();
            m_bitmapList?.Dispose();
            resultSource?.Dispose();
        }
    }

}