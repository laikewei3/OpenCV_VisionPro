using OpenCV_Vision_Pro.Interface;
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
    public partial class ImageSharpenerToolControl : UserControl,UserControlBase
    {
        public DataGridView resultDataGrid { get; set; }

        public ROI m_roi { get { return SharpenerParams.m_roi; } }

        public IParams parameter { get; set; }

        public SharpenerParams SharpenerParams { get; private set; }

        public ImageSharpenerToolControl(IParams SharpenerParams)
        {
            InitializeComponent(); 
            parameter = SharpenerParams;
            this.SharpenerParams = (SharpenerParams)parameter;
            this.SharpenerParams.m_roi.Dock = DockStyle.Top;
            this.Controls.Add(SharpenerParams.m_roi);
        }

        public void SetDataSource(object bs) {
            m_scoreVariance.Text = ((double)bs).ToString();
        }

        private void m_comboBoxColorMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            SharpenerParams.runMode = m_comboBoxColorMode.SelectedItem.ToString();
        }

        private void ImageSharpenerToolControl_Load(object sender, EventArgs e)
        {
            if (parameter.m_boolHasROI)
            {
                if (parameter.m_roi.points != null)
                    parameter.m_roi.m_comboBoxROI.SelectedIndex = 2;
                else
                    parameter.m_roi.m_comboBoxROI.SelectedIndex = 1;
            }

            m_comboBoxColorMode.SelectedItem = SharpenerParams.runMode;
        }
    }
}
