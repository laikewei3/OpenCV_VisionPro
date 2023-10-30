using OpenCV_Vision_Pro.Interface;
using System;
using System.Windows.Forms;

namespace OpenCV_Vision_Pro.Tools.ImageProcess.ProcessTool
{
    public partial class ArithmeticToolControl : UserControl, UserControlBase
    {
        public DataGridView resultDataGrid { get; set; }
        public ROI m_roi { get { return ArithmeticParams.m_roi; } }
        public IParams parameter { get; set; }
        public ArithmeticParams ArithmeticParams { get; private set; }

        public ArithmeticToolControl(IParams ArithmeticParams)
        {
            InitializeComponent(); 
            parameter = ArithmeticParams;
            this.ArithmeticParams = (ArithmeticParams)parameter;
        }
        
        public void SetDataSource(object bs)
        {
        }

        private void Arithmetic_Load(object sender, EventArgs e)
        {
            m_cbMode.SelectedItem = ArithmeticParams.ArithmeticMode;
            m_cbOverflow.SelectedItem = ArithmeticParams.overflow;
            m_nudP1.Value = (decimal)ArithmeticParams.P1;
            m_nudP2.Value = (decimal)ArithmeticParams.P2;
            m_nudP3.Value = (decimal)ArithmeticParams.P3;
        }

        private void m_cbMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            ArithmeticParams.ArithmeticMode = m_cbMode.SelectedItem.ToString();
        }

        private void m_cbOverflow_SelectedIndexChanged(object sender, EventArgs e)
        {
            ArithmeticParams.overflow = m_cbOverflow.SelectedItem.ToString();
        }

        private void m_nudP1_ValueChanged(object sender, EventArgs e)
        {
            ArithmeticParams.P1 = (int)m_nudP1.Value;
        }

        private void m_nudP2_ValueChanged(object sender, EventArgs e)
        {
            ArithmeticParams.P2 = (int)m_nudP2.Value;
        }

        private void m_nudP3_ValueChanged(object sender, EventArgs e)
        {
            ArithmeticParams.P3 = (int)m_nudP3.Value;
        }
    }
}
