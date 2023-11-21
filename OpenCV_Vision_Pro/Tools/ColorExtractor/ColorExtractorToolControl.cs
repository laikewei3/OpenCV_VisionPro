using OpenCV_Vision_Pro.Interface;
using System;
using System.Windows.Forms;

namespace OpenCV_Vision_Pro.Tools.ImageSegmentor
{
    public partial class ColorExtractorToolControl : UserControl, IColorUserControlBase
    {
        public DataGridView resultDataGrid { get; set; }

        public ROI m_roi { get { return ColorExtractorParams.m_roi; } }
        public IParams parameter { get; set; }
        public ColorExtractorParams ColorExtractorParams { get; set; }

        public ColorTools m_colorTools { get; set; }

        public ColorExtractorToolControl(IParams parameter)
        {
            InitializeComponent();
            this.parameter = parameter;
            ColorExtractorParams = (ColorExtractorParams)parameter;
            m_colorTools = new ColorTools(ColorExtractorParams.colorDatas) { Dock = DockStyle.Top };
            this.Controls.Add(m_colorTools); 
            ColorExtractorParams.m_roi.Dock = DockStyle.Top;
            this.Controls.Add(ColorExtractorParams.m_roi);
            m_colorTools.labelB.Visible = false;
            m_colorTools.labelR.Visible = false;
            m_colorTools.labelG.Visible = false;
            m_colorTools.labelSpace.Visible = false;
            m_colorTools.m_cbColorSpace.Visible = false;
            m_colorTools.m_nudRed.Visible = false;
            m_colorTools.m_nudBlue.Visible = false;
            m_colorTools.m_nudGreen.Visible = false;
        }

        public void SetDataSource(object bs)
        {}

        private void ColorExtractorToolControl_Load(object sender, EventArgs e)
        {
            if (parameter.m_boolHasROI)
            {
                if (parameter.m_roi.points != null)
                    parameter.m_roi.m_comboBoxROI.SelectedIndex = 2;
                else
                    parameter.m_roi.m_comboBoxROI.SelectedIndex = 1;
            }
        }
    }
}
