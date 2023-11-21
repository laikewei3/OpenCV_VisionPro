using OpenCV_Vision_Pro.Interface;
using System;
using System.Windows.Forms;

namespace OpenCV_Vision_Pro.Tools.PolarUnWrap
{
    public partial class PolarUnwrapToolControl : UserControl, IUserControlBase
    {
        public PolarUnWrapParams PolarUnWrapParams { get; set; }
        public ROI m_roi { get { return PolarUnWrapParams.m_roi; } }

        public IParams parameter { get; set; }

        public PolarUnwrapToolControl(IParams PolarUnWrapParams)
        {
            InitializeComponent();
            parameter = PolarUnWrapParams;
            this.PolarUnWrapParams = (PolarUnWrapParams)parameter;
            this.PolarUnWrapParams.m_roi.Dock = DockStyle.Top;
            this.Controls.Add(PolarUnWrapParams.m_roi);
        }

        private void PolarUnwrapToolControl_Load(object sender, EventArgs e)
        {
            if (parameter.m_boolHasROI)
            {
                parameter.m_roi.m_comboBoxROI.SelectedIndex = 1;
            }
            m_nudWidth.Value = PolarUnWrapParams.lineheight;
            m_cbRotation.SelectedItem = PolarUnWrapParams.rotation;
        }

        private void m_nudWidth_ValueChanged(object sender, EventArgs e)
        {
            PolarUnWrapParams.lineheight = (int)m_nudWidth.Value;
        }

        private void m_cbRotation_SelectedIndexChanged(object sender, EventArgs e)
        {
            PolarUnWrapParams.rotation = m_cbRotation.SelectedItem.ToString();
        }
    }
}
