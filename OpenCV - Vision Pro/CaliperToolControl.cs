using Emgu.CV.Structure;
using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace OpenCV_Vision_Pro
{
    public partial class CaliperToolControl : UserControl
    {
        public Mat resultSelectedImage { get; set; } = new Mat();
        public CaliperTool caliperTool { get; set; } = new CaliperTool();
        public ROI m_roi { get; } = new ROI();
        public List<Dictionary<string, Bitmap>> m_bitmapList { get; set; }
        public CaliperToolControl()
        {
            InitializeComponent();
            Panel panel = new Panel
            {
                Height = 65,
                Dock = DockStyle.Top
            };
            Panel tempPanel = new Panel
            {
                Dock = DockStyle.Top
            };
            tempPanel.Controls.Add(m_roi);
            m_roi.Dock = DockStyle.Fill;
            panel.Controls.Add(tempPanel);
            this.Controls.Add(panel);
        }

        private void m_CaliperRes_SelectionChanged(object sender, EventArgs e)
        {
            if (m_CaliperRes.Rows.Count == 0) { return; } // 什么row都没有
            if (m_CaliperRes.SelectedRows.Count == 0) { return; } // 目前没有row被selected
            try
            {
                Mat tempMat = caliperTool.caliperImage.ToMat(); // for future reference

                int edge0 = int.Parse(m_CaliperRes.SelectedRows[0].Cells[2].Value.ToString());
                List<int> points = caliperTool.caliperPoints[edge0]; // 提取edge0资料

                int edge1 = 0;
                List<int> points1 = new List<int>();
                if (caliperTool.caliperParams.EdgeMode == "Edge Pair") // 提取edge1资料（如果有）
                {
                    edge1 = int.Parse(m_CaliperRes.SelectedRows[0].Cells[3].Value.ToString());
                    points1 = caliperTool.caliperPoints[edge1];
                }

                if (!caliperTool.caliperParams.ROIBool) // 如果没有ROI
                {
                    if (caliperTool.caliperParams.EdgeMode == "Edge Pair") // 如果有edge1才画
                        CvInvoke.Line(tempMat, new Point(points1[0], points1[1]), new Point(points1[2], points1[3]), new MCvScalar(150), 1);
                    CvInvoke.Line(tempMat, new Point(points[0], points[1]), new Point(points[2], points[3]), new MCvScalar(150), 1);
                }
                else // 如果有ROI
                {
                    if (caliperTool.caliperParams.EdgeMode == "Edge Pair") // 如果有edge1才画
                        CvInvoke.Line(tempMat, new Point(points1[0] + m_roi.X, m_roi.Y), new Point(points1[2] + m_roi.X, m_roi.Y + m_roi.ROI_Height), new MCvScalar(150), 1);
                    CvInvoke.Line(tempMat, new Point(points[0] + m_roi.X, m_roi.Y), new Point(points[2] + m_roi.X, m_roi.Y + m_roi.ROI_Height), new MCvScalar(150), 1);
                }
                resultSelectedImage = tempMat;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        
        private void m_radioPair_CheckedChanged(object sender, EventArgs e)
        {
            if (m_radioPair.Checked)
            {
                m_gbEdge1Polarity.Enabled = true;
                m_NumEdgePairWidth.Enabled = true;
                caliperTool.caliperParams.EdgeMode = m_radioPair.Text;
            }
            else
            {
                m_gbEdge1Polarity.Enabled = false;
                m_NumEdgePairWidth.Enabled = false;
                caliperTool.caliperParams.EdgeMode = m_radioSingle.Text;
            }
        }
        
        private void edge0_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
                caliperTool.caliperParams.polarity0 = ((RadioButton)sender).Text;
        }

        private void edge1_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
                caliperTool.caliperParams.polarity1 = ((RadioButton)sender).Text;
        }

        private void m_NumEdgePairWidth_ValueChanged(object sender, EventArgs e)
        {
            caliperTool.caliperParams.estimatedWidth = (double)m_NumEdgePairWidth.Value;
        }
        
        void m_NumContrastThreshold_ValueChanged(object sender, EventArgs e)
        {
            caliperTool.caliperParams.contrastThreshold = (int)m_NumContrastThreshold.Value;
        }
        
        private void m_NumResult_ValueChanged(object sender, EventArgs e)
        {
            caliperTool.caliperParams.maxResult = (int)m_NumResult.Value;
        }
    }
}
