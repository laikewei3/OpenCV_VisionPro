using OpenCV_Vision_Pro.Interface;
using System;
using System.Windows.Forms;

namespace OpenCV_Vision_Pro.Tools.ImageProcess.ProcessTool
{
    public partial class PaintToolControl : UserControl, IUserControlBase
    {
        public ROI m_roi { get { return PaintParams.m_roi; } }
        public IParams parameter { get; set; }
        public PaintParams PaintParams { get; private set; }

        public PaintToolControl(IParams RotateParams)
        {
            InitializeComponent(); 
            parameter = RotateParams;
            this.PaintParams = (PaintParams)parameter;
        }
        
        private void m_nudPaintSize_ValueChanged(object sender, EventArgs e)
        {
            PaintParams.paintSize = (int)m_nudPaintSize.Value;
        }

        private void PaintToolControl_Load(object sender, EventArgs e)
        {
            m_nudPaintSize.Value = PaintParams.paintSize;
        }
    }
}
