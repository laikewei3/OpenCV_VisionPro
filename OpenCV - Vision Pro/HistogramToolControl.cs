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
        public Dictionary<string, Bitmap> m_bitmapList { get; set; } = new Dictionary<string, Bitmap>();
        public HistogramToolControl()
        {
            InitializeComponent();
            Panel panel = new Panel();
            Panel tempPanel = new Panel();
            panel = new Panel();
            panel.Height = 65;

            m_HistogramInput.Controls.Add(panel);
            panel.Controls.Add(tempPanel);
            tempPanel.Controls.Add(m_roi);
            m_roi.Dock = DockStyle.Fill;
            panel.Dock = DockStyle.Top;
            tempPanel.Dock = DockStyle.Top;
        }
        public void showResult(HistogramTool histogramTool)
        {
            m_tbMin.Text = histogramTool.Minimum.ToString();
            m_tbMax.Text = histogramTool.Maximum.ToString();
            m_tbMedian.Text = histogramTool.Median.ToString();
            m_tbMode.Text = histogramTool.Mode.ToString();
            m_tbMean.Text = Math.Round(histogramTool.Mean, 4).ToString();
            m_tbSD.Text = Math.Round(histogramTool.StandardDeviation, 4).ToString();
            m_tbVariance.Text = Math.Round(histogramTool.Variance, 4).ToString();
            m_tbSample.Text = histogramTool.NumberOfSample.ToString();
            m_dgvHisData.DataSource = histogramTool.histData;
        }
    }
}
