using Emgu.CV;
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

namespace OpenCV_Vision_Pro.Tools.ImageProcess.ProcessTool
{
    public partial class RotateFlip : UserControl, UserControlBase
    {
        public DataGridView resultDataGrid { get; set; }
        public ROI m_roi { get { return RotateParams.m_roi; } }
        public IParams parameter { get; set; }
        public RotateParams RotateParams { get; private set; }

        public RotateFlip(IParams RotateParams)
        {
            InitializeComponent(); 
            parameter = RotateParams;
            this.RotateParams = (RotateParams)parameter;
        }
        
        public void SetDataSource(object bs)
        {
        }

        private void m_rbX_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
                RotateParams.rotateFlipMode = ((RadioButton)sender).Text;
        }

        private void RotateFlip_Load(object sender, EventArgs e)
        {
            switch (RotateParams.rotateFlipMode)
            {
                case "No Rotation/Flip":
                    m_rbNoRotateFlip.Checked = true;
                    break;
                case "Rotate 90 degree Clockwise":
                    m_rb90Clock.Checked = true;
                    break;
                case "Rotate 90 degree Counter Clockwise":
                    m_rb90CounterClock.Checked = true;
                    break;
                case "Rotate 180 degree":
                    m_rb180.Checked = true;
                    break;
                case "Flip Horizontal":
                    m_rbFlipHorizontal.Checked = true;
                    break;
                case "Flip Vertical":
                    m_rbFlipVertical.Checked = true;
                    break;
                case "Flip Both Vertical and Horizontal":
                    m_rbFlipBoth.Checked = true;
                    break;
            }
        }
    }
}
