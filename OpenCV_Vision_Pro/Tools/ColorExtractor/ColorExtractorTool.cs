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
    public class ColorExtractorParams : IParams
    {
        public SortableBindingList<ColorData> colorDatas { get; set; } = new SortableBindingList<ColorData>();
    }
    public class ColorExtractorResults : IToolResult
    {
        public Mat grayImage { get; set; }

        public new void Dispose()
        {
            resultImage?.Dispose();
            grayImage?.Dispose();
        }
    }

    public partial class ColorExtractorTool : IToolData
    {
        public string ToolName { get; set; }
        public IUserControlBase m_toolControl { get; set; }
        public AutoDisposeDict<string, Mat> m_bitmapList { get; set; }
        public BindingList<string> m_DisplaySelection { get; set; } = new BindingList<string>();
        public BindingSource resultSource { get; set; }
        public IParams parameter { get; set; } = new ColorExtractorParams();
        public IToolResult toolResult { get; set; }
        public ColorExtractorResults extractorResults
        {
            get { return (ColorExtractorResults)toolResult; }
            set { toolResult = value; }
        }

        public ColorExtractorTool(string toolName) { this.ToolName = toolName; }

        public void getGUI()
        {
            m_toolControl = new ColorExtractorToolControl(parameter) { Dock = DockStyle.Fill };
        }

        public void Run(Mat img, Rectangle region)
        {
            parameter.m_roi.ROIRectangle = HelperClass.getROIImage(img, region, parameter.m_roi.points, out Mat image);

            extractorResults?.Dispose();
            extractorResults = new ColorExtractorResults();

            if (((ColorExtractorToolControl)m_toolControl) != null)
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

        public void showResultImages()
        {
            HelperClass.showResultImagesStatic(m_bitmapList, m_DisplaySelection, extractorResults.resultImage, ToolName, "OverallColorImage");
            HelperClass.showResultImagesStatic(m_bitmapList, m_DisplaySelection, extractorResults.grayImage, ToolName, "GrayScaleImage");
        }

        public void Dispose()
        {
            extractorResults?.Dispose();
            m_toolControl?.Dispose();
            m_bitmapList?.Dispose();
            resultSource?.Dispose();
        }

        public object showResult()
        {
            return null;
        }
    }

}