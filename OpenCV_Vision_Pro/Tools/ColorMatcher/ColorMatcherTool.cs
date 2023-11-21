using Emgu.CV;
using Emgu.CV.Structure;
using OpenCV_Vision_Pro.Interface;
using Shared.ComponentModel.SortableBindingList;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace OpenCV_Vision_Pro.Tools.ColorMatcher
{
    public class ColorMatcherParams : IParams
    {
        public SortableBindingList<ColorData> colorDatas { get; set; } = new SortableBindingList<ColorData>();
    }

    public class ColorMatcherResults : IToolResult
    {
        public SortableBindingList<ColorData> resultColorDatas { get; set; }
        public ColorData bestMatch { get; set; }
        public MCvScalar observedColor { get; set; }
        public double confidence { get; set; }
    }

    public class ColorMatcherTool : IToolData
    {
        public string ToolName { get; set; }
        public AutoDisposeDict<string, Mat> m_bitmapList { get; set; }
        public BindingList<string> m_DisplaySelection { get; set; } = new BindingList<string>();
        public IUserControlBase m_toolControl { get; set; }
        public IParams parameter { get; set; } = new ColorMatcherParams();
        public BindingSource resultSource { get; set; }
        public IToolResult toolResult { get; set; }
        public ColorMatcherResults matcherResults
        {
            get { return (ColorMatcherResults)toolResult; }
            set { toolResult = value; }
        }

        public ColorMatcherTool(string toolName) { ToolName = toolName; }

        public void Dispose()
        {
            m_bitmapList?.Dispose();
            m_toolControl?.Dispose();
            resultSource?.Dispose();
        }

        public void getGUI()
        {
            m_toolControl = new ColorMatchToolControl(parameter) { Dock = DockStyle.Fill };
        }

        public void Run(Mat img, Rectangle region)
        {
            parameter.m_roi.ROIRectangle = HelperClass.getROIImage(img, region, parameter.m_roi.points, out Mat image);

            matcherResults?.Dispose();
            matcherResults = new ColorMatcherResults();

            if (((ColorMatchToolControl)m_toolControl) != null)
                parameter = ((ColorMatchToolControl)m_toolControl).ColorMatcherParams;
            else
                parameter = new ColorMatcherParams();

            matcherResults.observedColor = CvInvoke.Mean(image);
            double maxColordistance = Math.Sqrt(Math.Pow(255, 2) * 3);

            matcherResults.resultColorDatas = new SortableBindingList<ColorData>(((ColorMatcherParams)parameter).colorDatas);

            int i = 0;
            foreach (ColorData cd in ((ColorMatcherParams)parameter).colorDatas)
            {
                MCvScalar testColor = cd.ColorCode;
                double colordistance = Math.Sqrt(Math.Pow(matcherResults.observedColor.V0 - testColor.V0, 2) + Math.Pow(matcherResults.observedColor.V1 - testColor.V1, 2) + Math.Pow(matcherResults.observedColor.V2 - testColor.V2, 2));
                double score = 1 - (colordistance / maxColordistance);
                matcherResults.resultColorDatas[i++].Score = Math.Round(score, 5);
            }
            matcherResults.resultColorDatas = new SortableBindingList<ColorData>(matcherResults.resultColorDatas.OrderByDescending(x => x.Score));
            matcherResults.bestMatch = matcherResults.resultColorDatas[0];
            double secondBestScore = matcherResults.resultColorDatas.Count >= 2 ? matcherResults.resultColorDatas[1].Score : 0;
            matcherResults.confidence = (matcherResults.bestMatch.Score - secondBestScore) / (matcherResults.bestMatch.Score + secondBestScore);

            image.Dispose();
        }

        public object showResult()
        {
            resultSource?.Dispose();
            resultSource = new BindingSource();

            ArrayList result = new ArrayList();
            if (matcherResults == null)
                return result;
            if (m_toolControl == null)
                return result;

            resultSource.DataSource = matcherResults.resultColorDatas;

            result.Add(resultSource);
            result.Add(matcherResults.bestMatch);
            result.Add(matcherResults.observedColor);
            result.Add(Math.Round(matcherResults.confidence, 5));
            return result;
        }

        public void showResultImages() { }
    }
}
