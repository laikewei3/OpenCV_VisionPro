using OpenCV_Vision_Pro.Interface;
using System;
using System.Windows.Forms;

namespace OpenCV_Vision_Pro.Tools.Retina
{
    public partial class RetinaToolControl : UserControl, IUserControlBase
    {
        public RetinaParams RetinaParams { get; set; }
        public ROI m_roi { get { return RetinaParams.m_roi; } }

        public IParams parameter { get; set; }

        public RetinaToolControl(IParams RetinaParams)
        {
            InitializeComponent();
            parameter = RetinaParams;
            this.RetinaParams = (RetinaParams)parameter;
            this.RetinaParams.m_roi.Dock = DockStyle.Top;
            this.Controls.Add(RetinaParams.m_roi);
        }

        private void RetinaToolControl_Load(object sender, EventArgs e)
        {
            if (parameter.m_boolHasROI)
            {
                parameter.m_roi.m_comboBoxROI.SelectedIndex = 1;
            }
            if(RetinaParams.colorMode)
                colorMode_cb.Checked = true;
            else
                colorMode_cb.Checked = false;
            if (RetinaParams.normaliseOutput)
                normaliseOutput_cb.Checked = true;
            else
                normaliseOutput_cb.Checked = false;
            photoreceptorsLocalAdaptationSensitivity_nud.Value = (decimal)RetinaParams.photoreceptorsLocalAdaptationSensitivity;
            photoreceptorsTemporalConstant_nud.Value = (decimal)RetinaParams.photoreceptorsTemporalConstant;
            photoreceptorsSpatialConstant_nud.Value = (decimal)RetinaParams.photoreceptorsSpatialConstant;
            horizontalCellsGain_nud.Value = (decimal)RetinaParams.horizontalCellsGain;
            hcellsTemporalConstant_nud.Value = (decimal)RetinaParams.HcellsTemporalConstant;
            hcellsSpatialConstant_nud.Value = (decimal)RetinaParams.HcellsSpatialConstant;
            ganglionCellsSensitivity_nud.Value = (decimal)RetinaParams.ganglionCellsSensitivity;
            runIteration_nud.Value = (decimal)RetinaParams.iteration;
        }

        private void colorMode_cb_CheckedChanged(object sender, EventArgs e)
        {
            RetinaParams.colorMode = colorMode_cb.Checked;
        }

        private void normaliseOutput_cb_CheckedChanged(object sender, EventArgs e)
        {
            RetinaParams.normaliseOutput = normaliseOutput_cb.Checked;
        }

        private void photoreceptorsLocalAdaptationSensitivity_nud_ValueChanged(object sender, EventArgs e)
        {
            RetinaParams.photoreceptorsLocalAdaptationSensitivity = (float)photoreceptorsLocalAdaptationSensitivity_nud.Value;
        }

        private void photoreceptorsTemporalConstant_nud_ValueChanged(object sender, EventArgs e)
        {
            RetinaParams.photoreceptorsTemporalConstant = (float)photoreceptorsTemporalConstant_nud.Value;
        }

        private void photoreceptorsSpatialConstant_nud_ValueChanged(object sender, EventArgs e)
        {
            RetinaParams.photoreceptorsSpatialConstant = (float)photoreceptorsSpatialConstant_nud.Value;
        }

        private void horizontalCellsGain_nud_ValueChanged(object sender, EventArgs e)
        {
            RetinaParams.horizontalCellsGain = (float)horizontalCellsGain_nud.Value;
        }

        private void hcellsTemporalConstant_nud_ValueChanged(object sender, EventArgs e)
        {
            RetinaParams.HcellsTemporalConstant = (float)hcellsTemporalConstant_nud.Value;
        }

        private void hcellsSpatialConstant_nud_ValueChanged(object sender, EventArgs e)
        {
            RetinaParams.HcellsSpatialConstant = (float)hcellsSpatialConstant_nud.Value;
        }

        private void ganglionCellsSensitivity_nud_ValueChanged(object sender, EventArgs e)
        {
            RetinaParams.ganglionCellsSensitivity = (float)ganglionCellsSensitivity_nud.Value;
        }

        private void runIteration_nud_ValueChanged(object sender, EventArgs e)
        {
            RetinaParams.iteration = (int)runIteration_nud.Value;
        }
    }
}
