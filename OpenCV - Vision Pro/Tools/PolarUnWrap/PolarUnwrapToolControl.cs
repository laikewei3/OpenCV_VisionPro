using OpenCV_Vision_Pro.Interface;
using OpenCV_Vision_Pro.LineSegment;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenCV_Vision_Pro.Tools.PolarUnWrap
{
    public partial class PolarUnwrapToolControl : UserControl, UserControlBase
    {
        public DataGridView resultDataGrid { get; set; }
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

        public void SetDataSource(object bs)
        {
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
