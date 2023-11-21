using OpenCV_Vision_Pro.Interface;
using System;
using System.Windows.Forms;

namespace OpenCV_Vision_Pro.Tools.ImageSegmentor
{
    public partial class ColorSegmentorToolControl : UserControl, IColorUserControlBase
    {
        public DataGridView resultDataGrid { get; set; }
        public ROI m_roi { get { return ColorSegmentorParams.m_roi; } }
        public IParams parameter { get; set; }
        public ColorSegmentorParams ColorSegmentorParams { get; set; }

        public ColorTools m_colorTools { get; set; }

        public ColorSegmentorToolControl(IParams parameter)
        {
            InitializeComponent();
            this.parameter = parameter;
            ColorSegmentorParams = (ColorSegmentorParams)parameter;
            m_colorTools = new ColorTools(ColorSegmentorParams.colorDatas) { Dock = DockStyle.Top };
            this.Controls.Add(m_colorTools); 
            ColorSegmentorParams.m_roi.Dock = DockStyle.Top;
            this.Controls.Add(ColorSegmentorParams.m_roi);
        }

        public void SetDataSource(object bs)
        {
        }

        private void ColorSegmentorToolControl_Load(object sender, EventArgs e)
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
