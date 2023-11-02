using OpenCV_Vision_Pro.Interface;
using System.Collections;
using System;
using System.Windows.Forms;

namespace OpenCV_Vision_Pro
{
    public partial class TextRecognitionToolControl : UserControl, UserControlBase
    {
        public DataGridView resultDataGrid { get; set; }
        public ROI m_roi { get { return TextRecognitionParams.m_roi; } }
        public IParams parameter { get; set; }

        TextRecognitionParams TextRecognitionParams;

        public TextRecognitionToolControl(IParams TextRecognitionParams)
        {
            InitializeComponent();
            parameter = TextRecognitionParams;
            this.TextRecognitionParams = (TextRecognitionParams)parameter;
            TextRecognitionParams.m_roi.Dock = DockStyle.Fill;
            m_TextRecognitionInput.Controls.Add(TextRecognitionParams.m_roi);
        }

        private void TextRecognitionToolControl_Load(object sender, EventArgs e)
        {
            if (parameter.m_boolHasROI)
            {
                parameter.m_roi.m_comboBoxROI.SelectedIndex = 1;
            }
            m_cbLanguage.SelectedItem = TextRecognitionParams.language;
            m_cbMode.SelectedItem = TextRecognitionParams.mode;
        }

        public void SetDataSource(object bs) {
            m_tbResultText.Text = (string)bs;
        }

        private void m_cbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextRecognitionParams.language = m_cbLanguage.SelectedItem.ToString();
        }

        private void m_cbMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextRecognitionParams.mode = m_cbMode.SelectedItem.ToString();
        }
    }
}
