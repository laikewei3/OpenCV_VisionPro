using Emgu.CV.Structure;
using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using OpenCV_Vision_Pro.Interface;

namespace OpenCV_Vision_Pro
{
    public partial class CaliperToolControl : UserControlBase
    {
        public Mat resultSelectedImage { get; set; } = new Mat();
        public CaliperParams CaliperParams { get; set;}
        public override DataGridView resultDataGrid { get; set; }
        public override ROI m_roi { get { return CaliperParams.m_roi; } }
        public override IParams parameter { get; set; }

        public CaliperToolControl(IParams caliperParams)
        {
            InitializeComponent();
            resultDataGrid = m_CaliperRes;
            parameter = caliperParams;
            CaliperParams = (CaliperParams)parameter;

            Panel panel = new Panel
            {
                Height = 65,
                Dock = DockStyle.Top
            };
            Panel tempPanel = new Panel
            {
                Dock = DockStyle.Top
            };
            tempPanel.Controls.Add(CaliperParams.m_roi);
            CaliperParams.m_roi.Dock = DockStyle.Fill;
            panel.Controls.Add(tempPanel);
            m_CaliperInput.Controls.Add(panel);
        }

        private void CaliperToolControl_Load(object sender, EventArgs e)
        {
            if (parameter.m_boolHasROI)
            {
                parameter.m_roi.m_comboBoxROI.SelectedIndex = 1;
            }
            if(CaliperParams.EdgeMode == m_radioPair.Text)
                m_radioPair.Checked = true;
            else
                m_radioSingle.Checked = true;

            if (CaliperParams.polarity1 == m_DL1.Text)
                m_DL1.Checked = true;
            else if (CaliperParams.polarity1 == m_LD1.Text)
                m_LD1.Checked = true;
            else
                m_Any1.Checked = true;

            if (CaliperParams.polarity0 == m_DL0.Text)
                m_DL0.Checked = true;
            else if (CaliperParams.polarity0 == m_LD0.Text)
                m_LD0.Checked = true;
            else
                m_Any0.Checked = true;

            m_NumEdgePairWidth.Value = (decimal)CaliperParams.estimatedWidth;
            m_NumResult.Value = CaliperParams.maxResult;
            m_NumContrastThreshold.Value = CaliperParams.contrastThreshold;
        }

        private void m_CaliperRes_SelectionChanged(object sender, EventArgs e)
        {
            if (m_CaliperRes.Rows.Count == 0) { return; } // 什么row都没有
            if (m_CaliperRes.SelectedRows.Count == 0) { return; } // 目前没有row被selected
            ToolWindow m_toolWindow = (ToolWindow)this.ParentForm;
            if (m_toolWindow.m_displayControl.m_bitmapList == null) { return; }
            if (!m_toolWindow.m_displayControl.m_cbImages.SelectedItem.ToString().EndsWith("CaliperImage")) { return; }
            try
            {
                Bitmap tempBitmap = m_toolWindow.m_displayControl.m_bitmapList["LastRun." + m_toolWindow.m_toolBase.ToolName + ".CaliperImage"].ToBitmap();
                using (Pen pen = new Pen(Color.DeepSkyBlue, 2))
                using (Graphics graphics = Graphics.FromImage(tempBitmap))
                {
                    int edge0 = int.Parse(m_CaliperRes.SelectedRows[0].Cells[1].Value.ToString());
                    List<int> points = ((CaliperTool)m_toolWindow.m_toolBase).caliperPoints[edge0]; // 提取edge0资料

                    int edge1 = 0;
                    List<int> points1 = new List<int>();
                    if (CaliperParams.EdgeMode == "Edge Pair") // 提取edge1资料（如果有）
                    {
                        edge1 = int.Parse(m_CaliperRes.SelectedRows[0].Cells[2].Value.ToString());
                        points1 = ((CaliperTool)m_toolWindow.m_toolBase).caliperPoints[edge1];
                    }

                    if (!CaliperParams.ROIBool) // 如果没有ROI
                    {
                        if (CaliperParams.EdgeMode == "Edge Pair") // 如果有edge1才画
                            graphics.DrawLine(pen, new Point(points1[0], points1[1]), new Point(points1[2], points1[3]));
                        graphics.DrawLine(pen, new Point(points[0], points[1]), new Point(points[2], points[3]));
                    }
                    else // 如果有ROI
                    {
                        if (CaliperParams.EdgeMode == "Edge Pair") // 如果有edge1才画
                            graphics.DrawLine(pen, new Point(points1[0] + m_roi.X, m_roi.Y), new Point(points1[2] + m_roi.X, m_roi.Y + m_roi.ROI_Height));
                        graphics.DrawLine(pen, new Point(points[0] + m_roi.X, m_roi.Y), new Point(points[2] + m_roi.X, m_roi.Y + m_roi.ROI_Height));
                    }
                    resultSelectedImage = tempBitmap.ToMat();
                    m_toolWindow.m_displayControl.m_display.Image = resultSelectedImage;
                    tempBitmap?.Dispose();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
        
        private void m_radioPair_CheckedChanged(object sender, EventArgs e)
        {
            if (m_radioPair.Checked)
            {
                m_gbEdge1Polarity.Enabled = true;
                m_NumEdgePairWidth.Enabled = true;
                CaliperParams.EdgeMode = m_radioPair.Text;
            }
            else
            {
                m_gbEdge1Polarity.Enabled = false;
                m_NumEdgePairWidth.Enabled = false;
                CaliperParams.EdgeMode = m_radioSingle.Text;
            }
        }
        
        private void edge0_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
                CaliperParams.polarity0 = ((RadioButton)sender).Text;
        }

        private void edge1_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
                CaliperParams.polarity1 = ((RadioButton)sender).Text;
        }

        private void m_NumEdgePairWidth_ValueChanged(object sender, EventArgs e)
        {
            CaliperParams.estimatedWidth = (double)m_NumEdgePairWidth.Value;
        }
        
        void m_NumContrastThreshold_ValueChanged(object sender, EventArgs e)
        {
            CaliperParams.contrastThreshold = (int)m_NumContrastThreshold.Value;
        }
        
        private void m_NumResult_ValueChanged(object sender, EventArgs e)
        {
            CaliperParams.maxResult = (int)m_NumResult.Value;
        }

    }
}
