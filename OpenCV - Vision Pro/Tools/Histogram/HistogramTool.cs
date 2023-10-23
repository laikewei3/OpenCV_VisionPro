using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Emgu.CV;
using Emgu.CV.Reg;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using OpenCV_Vision_Pro.Interface;
using OpenCV_Vision_Pro.Properties;
using Shared.ComponentModel.SortableBindingList;

namespace OpenCV_Vision_Pro
{

    public class HistorgramParams: IParams
    {
        public ROI m_roi { get; set; } = new ROI(); 
        public bool m_boolHasROI { get; set; } = false;
    }

    public class HistogramResult : IDisposable, IToolResult
    {
        public int Minimum { get; set; }
        public int Maximum { get; set; }
        public int Median { get; set; }
        public int Mode { get; set; }
        public double Mean { get; set; }
        public double StandardDeviation { get; set; }
        public double Variance { get; set; }
        public long NumberOfSample { get; set; }
        public Mat resultImage { get; set; }

        public void Dispose()
        {
            resultImage?.Dispose();
        }
    }

    // Declare Variable
    public partial class HistogramTool : IToolBase
    {
        private class HistogramData
        {
            public HistogramData(int Grey_Level, float Count, double Cumulative)
            {
                this.Count = Count;
                this.Grey_Level = Grey_Level;
                this.Cumulative = Cumulative;
            }

            public int Grey_Level { get; set; }
            public float Count { get; set; }
            public double Cumulative { get; set; }
        }

        public  Bitmap toolIcon { get; } = Resources.histogram;
        public  string ToolName { get; set; }
        public  AutoDisposeDict<string, Mat> m_bitmapList { get; set; }
        public  UserControlBase m_toolControl { get; set; }
        public  BindingList<string> m_DisplaySelection { get; set; } = new BindingList<string>();
        public  BindingSource resultSource { get; set; }
        public  Rectangle m_rectROI { get; set; }
        public  IParams parameter { get; set; } = new HistorgramParams();

        public  IToolResult toolResult { get; set; }
        public HistogramResult m_histogramResult { get { return (HistogramResult)toolResult; } set { toolResult = value; } }

        private SortableBindingList<HistogramData> resultList;
    }

    // Methods
    public partial class HistogramTool : IToolBase
    {
        public HistogramTool(string toolName) { ToolName = toolName; }

        public  void getGUI()
        {
            if(m_rectROI != null && !m_rectROI.IsEmpty)
            {
                parameter.m_roi.location = new Point(m_rectROI.X, m_rectROI.Y);
                parameter.m_roi.ROI_Width = m_rectROI.Width;
                parameter.m_roi.ROI_Height = m_rectROI.Height;
            }
            m_toolControl = new HistogramToolControl(parameter) { Dock = DockStyle.Fill };
        }

        public  void Run(Mat img, Rectangle region)
        {
            Mat gray = HelperClass.getROIImage(img, region, parameter.m_roi.points);

            m_histogramResult = new HistogramResult();
            //=============================================== Declare Variable =============================================
            List<float> cummulative_list = new List<float>();
            bool getMin = false;
            int maxCount = 0;
            Mat m_matHist = new Mat();
            VectorOfMat m_vomat = new VectorOfMat();
            //==============================================================================================================

            //=============================================== Calculate Result =============================================
            m_vomat.Push(gray);
            CvInvoke.CalcHist(m_vomat, new int[] { 0 }, null, m_matHist, new int[] { 256 }, new float[] { 0, 256 }, false);
            //==============================================================================================================
            m_vomat.Dispose();

            //================================= Calculate Statistics/ Prepare Chart Data ===================================
            float[] histogramData = new float[m_matHist.Rows];
            double calMean = 0;
            for (int i = 0; i < m_matHist.Rows; i++)
            {
                float count = (float)m_matHist.GetData().GetValue(new int[] { i, 0 }); // get the pixel count from Mat
                histogramData[i] = count;
                calMean += i * count;

                if (count > 0)
                {
                    if (!getMin)
                    {
                        getMin = true;
                        m_histogramResult.Minimum = i;
                    }

                    if (i > m_histogramResult.Maximum)
                        m_histogramResult.Maximum = i;
                    if (i > 0)
                    {
                        if (count > histogramData[maxCount])
                            maxCount = i;
                        cummulative_list.Add(cummulative_list[i - 1] + count);
                    }
                    else
                        cummulative_list.Add(count);
                }
                else
                {
                    if (i > 0)
                        cummulative_list.Add(cummulative_list[i - 1] + count);
                    else
                        cummulative_list.Add(count);
                }
            }
            m_histogramResult.Mode = maxCount;
            m_histogramResult.NumberOfSample = (long)cummulative_list[histogramData.Length - 1];
            m_histogramResult.Mean = Math.Round(calMean / m_histogramResult.NumberOfSample,4);
            m_matHist.Dispose();

            double m_doubleHalf = m_histogramResult.NumberOfSample / 2;
            for (int i = 0; i < cummulative_list.Count; i++)
            {
                if (cummulative_list[i] > m_doubleHalf)
                {
                    m_histogramResult.Median = i;
                    break;
                }
            }
            
            double m_doubleCumulativePercent = 0;
            double variance = 0;
            resultList = new SortableBindingList<HistogramData>();
            for (int i = 0; i < histogramData.Length; i++)
            {
                m_doubleCumulativePercent += (histogramData[i] * 100.0) / m_histogramResult.NumberOfSample;
                resultList.Add(new HistogramData(i, histogramData[i], Math.Round(m_doubleCumulativePercent, 2)));
                double temp = Math.Pow((i - m_histogramResult.Mean), 2) * histogramData[i];
                variance += temp;
            }
            variance /= m_histogramResult.NumberOfSample;
            m_histogramResult.Variance = Math.Round(variance,4);
            m_histogramResult.StandardDeviation = Math.Round(Math.Sqrt(variance),4);
            //==============================================================================================================

            //================================================ Plot the Chart ==============================================
            Chart histogramChart = new Chart
            {
                Size = new Size(800, 500),
                BackColor = Color.Navy
            };

            ChartArea chartArea = new ChartArea
            {
                BackColor = Color.Transparent
            };
            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisY.MajorGrid.Enabled = false;
            chartArea.AxisX.LabelStyle.ForeColor = Color.White;
            chartArea.AxisY.LabelStyle.ForeColor = Color.White;

            histogramChart.ChartAreas.Add(chartArea);

            Series series = new Series
            {
                ChartType = SeriesChartType.Column // Use a vertical column chart.
            };
            series.Points.DataBindY(histogramData);
            series.Color = Color.Yellow;

            StripLine meanLine = new StripLine
            {
                StripWidth = 1,
                BackColor = Color.White,
                IntervalOffset = m_histogramResult.Mean,
                Interval = 0,
                Text = Math.Round(m_histogramResult.Mean, 4).ToString(),
                ForeColor = Color.White
            };

            chartArea.AxisX.StripLines.Add(meanLine);
            histogramChart.Series.Add(series);

            Bitmap chartBitmap = new Bitmap(histogramChart.Width, histogramChart.Height);
            histogramChart.DrawToBitmap(chartBitmap, new Rectangle(0, 0, histogramChart.Width, histogramChart.Height));
            m_histogramResult.resultImage = chartBitmap.ToMat();
            chartBitmap.Dispose();
            histogramChart.Dispose();
            chartArea.Dispose();
            meanLine.Dispose();
            series.Dispose();
            
            //==============================================================================================================
        }

        public  void Dispose()
        {
            m_bitmapList?.Dispose();
            m_toolControl?.Dispose();
            m_histogramResult.Dispose();
            resultSource?.Dispose();
        }

        public  object showResult()
        {
            ArrayList arrayList = new ArrayList();
            resultSource?.Dispose();
            resultSource = new BindingSource();
            arrayList.Add(resultSource);
            arrayList.Add(m_histogramResult);
            if (m_histogramResult == null)
                return arrayList;
            if (m_toolControl == null)
                return arrayList;
            resultSource.DataSource = resultList;
            return arrayList;
        }

        public  void showResultImages()
        {
            if (Form1.m_bitmapList.ContainsKey("LastRun." + ToolName + ".Histogram"))
            {
                Form1.m_bitmapList["LastRun." + ToolName + ".Histogram"]?.Dispose();
                Form1.m_bitmapList["LastRun." + ToolName + ".Histogram"] = m_histogramResult.resultImage.Clone();
            }
            else
            {
                Form1.m_bitmapList.Add("LastRun." + ToolName + ".Histogram", m_histogramResult.resultImage.Clone());
                if (!Form1.m_form1DisplaySelection.Contains("LastRun." + ToolName + ".Histogram"))
                    Form1.m_form1DisplaySelection.Add("LastRun." + ToolName + ".Histogram");
            }


            if (m_bitmapList.ContainsKey("LastRun." + ToolName + ".Histogram"))
            {
                m_bitmapList["LastRun." + ToolName + ".Histogram"]?.Dispose();
                m_bitmapList["LastRun." + ToolName + ".Histogram"] = m_histogramResult.resultImage.Clone();
            }
            else
            {
                m_bitmapList.Add("LastRun." + ToolName + ".Histogram", m_histogramResult.resultImage.Clone());
                if (!m_DisplaySelection.Contains("LastRun." + ToolName + ".Histogram"))
                    m_DisplaySelection.Add("LastRun." + ToolName + ".Histogram");
            }
        }
    }
}
