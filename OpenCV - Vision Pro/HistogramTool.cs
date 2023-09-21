using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;

namespace OpenCV_Vision_Pro
{
    public class HistogramResult
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
    }

    public class HistogramTool
    {
        public HistogramResult HistogramResult { get; set; } = new HistogramResult();
        private void calcHist(Mat gray)
        {
            //=============================================== Declare Variable =============================================
            List<float> cummulative_list = new List<float>();
            bool getMin = false;
            int maxCount = 0;
            Mat m_matHist = new Mat();
            VectorOfMat m_vomat = new VectorOfMat();
            HistogramResult.histData = new DataTable();
            HistogramResult.histData.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("Grey Level"),
                new DataColumn("Count"),
                new DataColumn("Cumulative %")
            });
            //==============================================================================================================

            //=============================================== Calculate Result =============================================
            m_vomat.Push(gray);
            CvInvoke.CalcHist(m_vomat, new int[] { 0 }, null, m_matHist, new int[] { 256 }, new float[] { 0, 256 }, false);
            //==============================================================================================================
            m_vomat.Dispose();
            gray.Dispose();

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
                        HistogramResult.Minimum = i;
                    }

                    if (i > HistogramResult.Maximum)
                        HistogramResult.Maximum = i;
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
            HistogramResult.Mode = maxCount;
            HistogramResult.NumberOfSample = (long)cummulative_list[histogramData.Length - 1];
            HistogramResult.Mean = calMean / HistogramResult.NumberOfSample;
            m_matHist.Dispose();

            double m_doubleHalf = HistogramResult.NumberOfSample / 2;
            for (int i = 0; i < cummulative_list.Count; i++)
            {
                if (cummulative_list[i] > m_doubleHalf)
                {
                    HistogramResult.Median = i;
                    break;
                }
            }
            
            double m_doubleCumulativePercent = 0;
            double variance = 0;
            for (int i = 0; i < histogramData.Length; i++)
            {
                m_doubleCumulativePercent += (histogramData[i] * 100.0) / HistogramResult.NumberOfSample;
                HistogramResult.histData.Rows.Add(i, histogramData[i], Math.Round(m_doubleCumulativePercent, 2));
                double temp = Math.Pow((i - HistogramResult.Mean), 2) * histogramData[i];
                variance += temp;
            }
            variance /= HistogramResult.NumberOfSample;
            HistogramResult.Variance = variance;
            HistogramResult.StandardDeviation = Math.Sqrt(variance);
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
                IntervalOffset = HistogramResult.Mean,
                Interval = 0,
                Text = Math.Round(HistogramResult.Mean, 4).ToString(),
                ForeColor = Color.White
            };

            chartArea.AxisX.StripLines.Add(meanLine);
            histogramChart.Series.Add(series);

            Bitmap chartBitmap = new Bitmap(histogramChart.Width, histogramChart.Height);
            histogramChart.DrawToBitmap(chartBitmap, new Rectangle(0, 0, histogramChart.Width, histogramChart.Height));
            HistogramResult.histogram = chartBitmap;
            //==============================================================================================================
        }

        public HistogramTool(Bitmap image) // Whole Image
        {
            Mat gray = new Mat();
            Image<Bgr, byte> m_grayImage = image.ToImage<Bgr, byte>();
            CvInvoke.CvtColor(m_grayImage, gray, ColorConversion.Bgr2Gray);
            calcHist(gray);
            gray.Dispose();
        }

        public HistogramTool(Mat image) // ROI Image
        {
            Mat gray = new Mat();
            CvInvoke.CvtColor(image, gray, ColorConversion.Bgr2Gray);
            calcHist(gray);
            gray.Dispose();
        }
    }
}
