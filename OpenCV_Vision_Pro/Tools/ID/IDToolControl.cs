using Emgu.CV;
using OpenCV_Vision_Pro.Interface;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace OpenCV_Vision_Pro.Tools.ID
{
    public partial class IDToolControl : UserControl, IUserDataControl
    {
        public Mat resultSelectedImage { get; set; }
        public IDParams IDParams { get; private set; }
        public DataGridView resultDataGrid { get; set; }
        public ROI m_roi { get { return IDParams.m_roi; } }
        public IParams parameter { get; set; }

        public IDToolControl(IParams IDParams)
        {
            InitializeComponent();
            resultDataGrid = m_dgvIDResults;
            parameter = IDParams;
            this.IDParams = (IDParams)parameter;
            this.IDParams.m_roi.Dock = DockStyle.Top;
            m_IDInput.Controls.Add(IDParams.m_roi);
        }

        private void m_dgvIDResults_SelectionChanged(object sender, EventArgs e)
        {
            if (m_dgvIDResults.Rows.Count == 0) { return; }
            if (m_dgvIDResults.SelectedRows.Count == 0) { return; }
            ToolWindow m_toolWindow = (ToolWindow)this.ParentForm;
            if (m_toolWindow.m_displayControl.m_bitmapList == null) { return; }
            if (!m_toolWindow.m_displayControl.m_cbImages.SelectedItem.ToString().EndsWith(".ID")) { return; }
            try
            {
                Bitmap tempBitamp = m_toolWindow.m_displayControl.m_bitmapList["LastRun." + m_toolWindow.m_toolBase.ToolName + ".ID"].ToBitmap();
                using (Pen pen = new Pen(Color.Yellow, 4))
                using (Graphics graphics = Graphics.FromImage(tempBitamp))
                {
                    Point[] points = ((IDResult)m_toolWindow.m_toolBase.toolResult).idList[m_dgvIDResults.SelectedRows[0].Index].m_rect;
                    if (IDParams.mode == "BarCode")
                        graphics.DrawPolygon(pen, points);
                    else
                        graphics.DrawRectangle(pen, new Rectangle(points[0], new Size(points[1].X, points[1].Y)));
                    
                    pen.Dispose();
                    graphics.Dispose();
                }
                resultSelectedImage = tempBitamp.ToMat();
                m_toolWindow.m_displayControl.m_display.Image = resultSelectedImage;
                tempBitamp?.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }


        private void m_dgvIDbResults_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView gridView = sender as DataGridView;
            if (null != gridView)
            {
                foreach (DataGridViewRow r in gridView.Rows)
                {
                    gridView.Rows[r.Index].HeaderCell.Value = r.Index.ToString();
                }
            }
        }

        private void m_dgvIDResults_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            e.PaintCells(e.ClipBounds, DataGridViewPaintParts.All);
            e.PaintHeader(DataGridViewPaintParts.Background
                | DataGridViewPaintParts.Border
                | DataGridViewPaintParts.Focus
                | DataGridViewPaintParts.SelectionBackground
                | DataGridViewPaintParts.ContentForeground);
            e.Handled = true;
        }

        public void SetDataSource(object bs)
        {
            if (bs == null)
                return;
            resultDataGrid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            resultDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            resultDataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            resultDataGrid.DataSource = bs;
        }

        private void IDToolControl_Load(object sender, EventArgs e)
        {
            if (parameter.m_boolHasROI)
            {
                if (parameter.m_roi.points != null)
                    parameter.m_roi.m_comboBoxROI.SelectedIndex = 2;
                else
                    parameter.m_roi.m_comboBoxROI.SelectedIndex = 1;
            }
            m_cbMode.SelectedItem = IDParams.mode;
        }

        private void m_cbMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            IDParams.mode = m_cbMode.SelectedItem.ToString();
        }
    }
}
