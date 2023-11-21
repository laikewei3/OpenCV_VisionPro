using OpenCV_Vision_Pro.Interface;
using System.Collections;
using System;
using System.Windows.Forms;

namespace OpenCV_Vision_Pro
{
    public partial class HistogramToolControl : UserControl, IUserDataControl
    {
        public DataGridView resultDataGrid { get; set; }
        public ROI m_roi { get { return historgramParams.m_roi; } }
        public IParams parameter { get; set; }

        HistorgramParams historgramParams;
        public HistogramToolControl(IParams historgramParams)
        {
            InitializeComponent();
            resultDataGrid = m_dgvHisData;
            
            parameter = historgramParams;
            this.historgramParams = (HistorgramParams)parameter;
            historgramParams.m_roi.Dock = DockStyle.Fill;
            m_HistogramInput.Controls.Add(historgramParams.m_roi);

            m_HistogramOutput.HorizontalScroll.Maximum = 0;
            m_HistogramOutput.AutoScroll = false;
            m_HistogramOutput.VerticalScroll.Visible = false;
            m_HistogramOutput.AutoScroll = true;
        }

        private void HistogramToolControl_Load(object sender, System.EventArgs e)
        {
            if (parameter.m_boolHasROI)
                parameter.m_roi.m_comboBoxROI.SelectedIndex = 1;
        }

        public void SetDataSource(object bs)
        {
            resultDataGrid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            resultDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            resultDataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;


            resultDataGrid.DataSource = ((ArrayList)bs)[0];

            HistogramResult m_histogramResult = (HistogramResult)((ArrayList)bs)[1];
            if (m_histogramResult != null)
            {
                m_tbMin.Text = m_histogramResult.Minimum.ToString();
                m_tbMax.Text = m_histogramResult.Maximum.ToString();
                m_tbMean.Text = m_histogramResult.Mean.ToString();
                m_tbMedian.Text = m_histogramResult.Median.ToString();
                m_tbMode.Text = m_histogramResult.Mode.ToString();
                m_tbSample.Text = m_histogramResult.NumberOfSample.ToString();
                m_tbSD.Text = m_histogramResult.StandardDeviation.ToString();
                m_tbVariance.Text = m_histogramResult.Variance.ToString();
            }
        }
    }
}
