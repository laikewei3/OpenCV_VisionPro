using OpenCV_Vision_Pro.Interface;
using System.Windows.Forms;

namespace OpenCV_Vision_Pro
{
    public partial class HistogramToolControl : UserControlBase
    {
        public override DataGridView resultDataGrid { get; set; }
        public override ROI m_roi { get { return historgramParams.m_roi; } set { } }
        public override IParams parameter { get; set; }

        HistorgramParams historgramParams;
        public HistogramToolControl(IParams historgramParams)
        {
            InitializeComponent();
            resultDataGrid = m_dgvHisData;
            Panel panel = new Panel
            {
                Height = 65,
                Dock = DockStyle.Top
            };
            Panel tempPanel = new Panel
            {
                Dock = DockStyle.Top
            };
            parameter = historgramParams;
            this.historgramParams = (HistorgramParams)parameter;
            tempPanel.Controls.Add(historgramParams.m_roi);
            historgramParams.m_roi.Dock = DockStyle.Fill;
            panel.Controls.Add(tempPanel);
            m_HistogramInput.Controls.Add(panel);
        }

        private void HistogramToolControl_Load(object sender, System.EventArgs e)
        {
            if(parameter.m_boolHasROI)
            {
                parameter.m_roi.m_comboBoxROI.SelectedIndex = 1;
            }
        }
    }
}
