using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;

namespace OpenCV_Vision_Pro
{
    public class HistogramTool
    {
        public int Minimum { get; set; }
        public int Maximum { get; set; }
        public int Median { get; set; }
        public int Mode { get; set; }
        public double Mean { get; set; }
        public double StandardDeviation { get; set; }
        public double Variance { get; set; }
        public long NumberOfSample { get; set; }
        public Bitmap histogram { get; set; }
        public DataTable histData { get; set; }

        private bool getMin = false;
        private int maxCount = 0;
        private List<float> cummulative_list = new List<float>(); 

        private void calcHist(Mat gray)
        {
            Mat m_matHist = new Mat();
            VectorOfMat m_vomat = new VectorOfMat();
            m_vomat.Push(gray);
            CvInvoke.CalcHist(m_vomat, new int[] { 0 }, null, m_matHist, new int[] { 256 }, new float[] { 0, 256 }, false);


            float[] histogramData = new float[m_matHist.Rows];
            double calMean = 0;
            for (int i = 0; i < m_matHist.Rows; i++)
            {
                float count = (float)m_matHist.GetData().GetValue(new int[] { i, 0 });
                histogramData[i] = count;
                calMean += i * count;

                if (count > 0)
                {
                    if (!getMin)
                    {
                        getMin = true;
                        this.Minimum = i;
                    }
                    if (i > Maximum)
                        this.Maximum = i;
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
                    cummulative_list.Add(count);
            }
            this.Mode = maxCount;
            this.NumberOfSample = (long)cummulative_list[histogramData.Length - 1];
            this.Mean = calMean / this.NumberOfSample;

            double m_doubleHalf = this.NumberOfSample / 2;
            for (int i = 0; i < cummulative_list.Count; i++)
            {
                if (cummulative_list[i] > m_doubleHalf)
                {
                    this.Median = i;
                    break;
                }
            }

            this.histData = new DataTable();
            this.histData.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("Grey Level"),
                new DataColumn("Count"),
                new DataColumn("Cumulative %")
            });
            double m_doubleCumulativePercent = 0;
            double variance = 0;
            for (int i = 1; i <= histogramData.Length; i++)
            {
                m_doubleCumulativePercent += (histogramData[i - 1] * 100.0) / this.NumberOfSample;
                this.histData.Rows.Add(i, histogramData[i - 1], Math.Round(m_doubleCumulativePercent, 2));
                double temp = Math.Pow((i - this.Mean), 2) * histogramData[i - 1];
                variance += temp;
            }
            variance /= this.NumberOfSample;
            this.Variance = variance;
            this.StandardDeviation = Math.Sqrt(variance);

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
                IntervalOffset = this.Mean,
                Interval = 0,
                Text = Math.Round(this.Mean, 4).ToString(),
                ForeColor = Color.White
            };

            chartArea.AxisX.StripLines.Add(meanLine);
            histogramChart.Series.Add(series);

            Bitmap chartBitmap = new Bitmap(histogramChart.Width, histogramChart.Height);
            histogramChart.DrawToBitmap(chartBitmap, new Rectangle(0, 0, histogramChart.Width, histogramChart.Height));
            this.histogram = chartBitmap;
        }

        public HistogramTool(Bitmap image)
        {
            Image<Bgr, byte> m_grayImage = image.ToImage<Bgr, byte>();

            Mat gray = new Mat();
            CvInvoke.CvtColor(m_grayImage, gray, ColorConversion.Bgr2Gray);

            calcHist(gray);
        }

        public HistogramTool(Mat image)
        {
            Mat gray = new Mat();
            CvInvoke.CvtColor(image, gray, ColorConversion.Bgr2Gray);

            calcHist(gray);
        }
    }
}
