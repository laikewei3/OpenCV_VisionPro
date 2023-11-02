using Emgu.CV.Structure;
using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using OpenCV_Vision_Pro.Interface;
using System.Collections;

namespace OpenCV_Vision_Pro.LineSegment
{
    public partial class LineSegmentToolControl : UserControl, UserControlBase
    {
        public Mat resultSelectedImage { get; set; } = new Mat();
        public LineSegmentParams LineSegmentParams { get; set; }
        public DataGridView resultDataGrid { get; set; }
        public ROI m_roi { get { return LineSegmentParams.m_roi; } }
        public IParams parameter { get; set; }

        public LineSegmentToolControl(IParams LineSegmentParams)
        {
            InitializeComponent();
            resultDataGrid = m_LineSegmentRes;
            parameter = LineSegmentParams;
            this.LineSegmentParams = (LineSegmentParams)parameter;
            this.LineSegmentParams.m_roi.Dock = DockStyle.Top;
            m_LineSegmentInput.Controls.Add(LineSegmentParams.m_roi);
        }

        private void LineSegmentToolControl_Load(object sender, EventArgs e)
        {
            if (parameter.m_boolHasROI)
            {
                parameter.m_roi.m_comboBoxROI.SelectedIndex = 1;
            }
            
            m_NumResult.Value = LineSegmentParams.maxResult;
            m_NumContrastThreshold.Value = LineSegmentParams.contrastThreshold;
            m_minLineLength.Value = (decimal)(LineSegmentParams.minLineLength);
            m_maxLineGap.Value = (decimal)LineSegmentParams.maxLineGap;
            m_minSlope.Value = (decimal)LineSegmentParams.minSlope;
            m_maxSlope.Value = (decimal)LineSegmentParams.maxSlope;
        }

        private void m_LineSegmentRes_SelectionChanged(object sender, EventArgs e)
        {
            if (m_LineSegmentRes.Rows.Count == 0) { return; } // 什么row都没有
            if (m_LineSegmentRes.SelectedRows.Count == 0) { return; } // 目前没有row被selected
            ToolWindow m_toolWindow = (ToolWindow)this.ParentForm;
            if (m_toolWindow.m_displayControl.m_bitmapList == null) { return; }
            if (!m_toolWindow.m_displayControl.m_cbImages.SelectedItem.ToString().EndsWith("LineSegmentImage")) { return; }
            try
            {
                Bitmap tempBitmap = m_toolWindow.m_displayControl.m_bitmapList["LastRun." + m_toolWindow.m_toolBase.ToolName + ".LineSegmentImage"].ToBitmap();
                using (Pen pen = new Pen(Color.DeepSkyBlue, 2))
                using (Graphics graphics = Graphics.FromImage(tempBitmap))
                {
                    int edge0 = int.Parse(m_LineSegmentRes.SelectedRows[0].Cells[1].Value.ToString());
                    List<int> points = ((LineSegmentTool)m_toolWindow.m_toolBase).LineSegmentPoints[edge0]; // 提取edge0资料

                    if (!LineSegmentParams.ROIBool) // 如果没有ROI
                    {
                        graphics.DrawLine(pen, new Point(points[0], points[1]), new Point(points[2], points[3]));
                    }
                    else // 如果有ROI
                    { 
                        graphics.DrawLine(pen, new Point(points[0] + m_roi.X, m_roi.Y), new Point(points[2] + m_roi.X, m_roi.Y + m_roi.ROI_Height));
                    }

                    resultSelectedImage = tempBitmap.ToMat();
                    m_toolWindow.m_displayControl.m_display.Image = resultSelectedImage;
                    pen.Dispose();
                    graphics.Dispose();
                    tempBitmap?.Dispose();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
        
        void m_NumContrastThreshold_ValueChanged(object sender, EventArgs e)
        {
            LineSegmentParams.contrastThreshold = (int)m_NumContrastThreshold.Value;
        }
        
        private void m_NumResult_ValueChanged(object sender, EventArgs e)
        {
            LineSegmentParams.maxResult = (int)m_NumResult.Value;
        }

        public void SetDataSource(object bs)
        {
            resultDataGrid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            resultDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            resultDataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            resultDataGrid.DataSource = bs;
        }

        private void m_minLineLength_ValueChanged(object sender, EventArgs e)
        {
            LineSegmentParams.minLineLength = (double)m_minLineLength.Value;
        }

        private void m_maxLineGap_ValueChanged(object sender, EventArgs e)
        {
            LineSegmentParams.maxLineGap = (double)m_maxLineGap.Value;
        }

        private void m_minSlope_ValueChanged(object sender, EventArgs e)
        {
            LineSegmentParams.minSlope = (double)m_minSlope.Value;
        }

        private void m_maxSlope_ValueChanged(object sender, EventArgs e)
        {
            LineSegmentParams.maxSlope = (double)m_maxSlope.Value;
        }
    }
}
