using OpenCV_Vision_Pro.Interface;
using System;
using System.Windows.Forms;

namespace OpenCV_Vision_Pro
{
    public partial class ImageConvertToolControl : UserControl,IUserControlBase
    {

        public ROI m_roi { get { return ConvertParams.m_roi; } }

        public IParams parameter { get; set; }

        public ConvertParams ConvertParams { get; private set; }

        public ImageConvertToolControl(IParams convertParams)
        {
            InitializeComponent(); 
            parameter = convertParams;
            ConvertParams = (ConvertParams)parameter;
            ConvertParams.m_roi.Dock = DockStyle.Top;
            this.Controls.Add(ConvertParams.m_roi);
        }

        private void m_comboBoxColorMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConvertParams.runMode = m_comboBoxColorMode.SelectedItem.ToString();
        }

        private void ImageConvertToolControl_Load(object sender, EventArgs e)
        {
            if (parameter.m_boolHasROI)
            {
                if (parameter.m_roi.points != null)
                    parameter.m_roi.m_comboBoxROI.SelectedIndex = 2;
                else
                    parameter.m_roi.m_comboBoxROI.SelectedIndex = 1;
            }

            m_comboBoxColorMode.SelectedItem = ConvertParams.runMode;
        }
    }
}
