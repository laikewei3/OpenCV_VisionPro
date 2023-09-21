using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenCV_Vision_Pro
{
    public partial class HistogramToolControl : UserControl
    {
        public ROI m_roi { get; } = new ROI();
        public List<Dictionary<string, Bitmap>> m_bitmapList { get; set; }

        public HistogramToolControl()
        {
            InitializeComponent();
            
            Panel panel = new Panel
            {
                Height = 65,
                Dock = DockStyle.Top
            };
            Panel tempPanel = new Panel
            {
                Dock = DockStyle.Top
            };
            tempPanel.Controls.Add(m_roi);
            m_roi.Dock = DockStyle.Fill;
            panel.Controls.Add(tempPanel);
            m_HistogramInput.Controls.Add(panel);
        }

        public void showResult(HistogramTool histogramTool)
        {
            m_tbMin.Text = histogramTool.HistogramResult.Minimum.ToString();
            m_tbMax.Text = histogramTool.HistogramResult.Maximum.ToString();
            m_tbMedian.Text = histogramTool.HistogramResult.Median.ToString();
            m_tbMode.Text = histogramTool.HistogramResult.Mode.ToString();
            m_tbMean.Text = Math.Round(histogramTool.HistogramResult.Mean, 4).ToString();
            m_tbSD.Text = Math.Round(histogramTool.HistogramResult.StandardDeviation, 4).ToString();
            m_tbVariance.Text = Math.Round(histogramTool.HistogramResult.Variance, 4).ToString();
            m_tbSample.Text = histogramTool.HistogramResult.NumberOfSample.ToString();
            m_dgvHisData.DataSource = histogramTool.HistogramResult.histData;
        }
    }
}
