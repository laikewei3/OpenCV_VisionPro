using OpenCV_Vision_Pro.Interface;
using System;
using System.Windows.Forms;

namespace OpenCV_Vision_Pro
{
    public partial class PerspectiveTransformToolControl : UserControl, IUserControlBase
    {
        public ROI m_roi { get { return PerspectiveTransformParams.m_roi; } }
        public IParams parameter { get; set; }

        PerspectiveTransformParams PerspectiveTransformParams;

        public PerspectiveTransformToolControl(IParams PerspectiveTransformParams)
        {
            InitializeComponent();
            parameter = PerspectiveTransformParams;
            this.PerspectiveTransformParams = (PerspectiveTransformParams)parameter;
            PerspectiveTransformParams.m_roi.Dock = DockStyle.Fill;
            m_PerspectiveTransformInput.Controls.Add(PerspectiveTransformParams.m_roi);
            m_roi.m_comboBoxROI.Items.RemoveAt(1);
            m_roi.m_comboBoxROI.Items.RemoveAt(0);
            m_roi.flowLayoutPanel3.Enabled = false;
        }

        private void PerspectiveTransformToolControl_Load(object sender, EventArgs e)
        {
            if (parameter.m_boolHasROI)
            {
                parameter.m_roi.m_comboBoxROI.SelectedIndex = -1;
                parameter.m_roi.m_comboBoxROI.SelectedIndex = 0;
            }
        }
    }
}
