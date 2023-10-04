using Emgu.CV.Structure;
using Emgu.CV;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.ComponentModel;
using System.Reflection.Metadata;
using OpenCV_Vision_Pro.Interface;
using Emgu.CV.CvEnum;

namespace OpenCV_Vision_Pro
{
    public partial class BlobToolControl : UserControlBase
    {
        public Mat resultSelectedImage { get; set; }
        public BlobParams BlobParams { get; private set; }
        public BindingList<string> m_measurementList { get; set; } = new BindingList<string>()
        {
            "Area","CenterMassX","CenterMassY","ConnectivityLabel","Angle","BoundaryPixelLength","Perimeter","NumChildren","InertiaX","InertiaY",
            "InertiaMin","InertiaMax","Elongation","Acircularity","AcircularityRms","ImageBoundCenterX","ImageBoundCenterY","ImageBoundMinX","ImageBoundMaxX",
            "ImageBoundMinY","ImageBoundMaxY","ImageBoundWidth","ImageBoundHeight","ImageBoundAspect","MedianX","MedianY","BoundCenterX","BoundCenterY",
            "BoundMinX","BoundMaxX","BoundMinY","BoundMaxY","BoundWidth","BoundHeight","BoundAspect","BoundPrincipalMinX","BoundPrincipalMaxX","BoundPrincipalMinY",
            "BoundPrincipalMaxY","BoundPrincipalWidth","BoundPrincipalHeight","BoundPrincipalAspect","NotClipped","<ADD ALL>"
        };
        public override DataGridView resultDataGrid { get; set; }
        public override ROI m_roi { get { return BlobParams.m_roi; } }
        public override IParams parameter { get; set; }

        public BlobToolControl(IParams blobParams)
        {
            InitializeComponent();
            resultDataGrid = m_dgvBlobResults;
            resultDataGrid.RowPrePaint += m_dgvBlobResults_RowPrePaint;
            parameter = blobParams;
            BlobParams = (BlobParams)parameter;
            BindingSource bindingSource = new BindingSource() { DataSource = m_measurementList };
            m_cbBlobProperties.DataSource = bindingSource;
            Panel panel = new Panel
            {
                Height = 65,
                Dock = DockStyle.Top
            };
            Panel tempPanel = new Panel
            {
                Dock = DockStyle.Top
            };

            tempPanel.Controls.Add(BlobParams.m_roi);
            BlobParams.m_roi.Dock = DockStyle.Fill;
            panel.Controls.Add(tempPanel);
            m_BlobInput.Controls.Add(panel); 
        }

        private void BlobToolControl_Load(object sender, EventArgs e)
        {
            if (parameter.m_boolHasROI)
            {
                parameter.m_roi.m_comboBoxROI.SelectedIndex = 1;
            }

            if (BlobParams.MeasurementProperties.Count <= 0)
            {
                for (int i = 0; i < 4; i++)
                {
                    m_cbBlobProperties.SelectedIndex = 0;
                    m_cbBlobProperties.SelectedIndex = -1;
                }
            }
            else
            {
                foreach(KeyValuePair<string,ArrayList> kvp in BlobParams.MeasurementProperties)
                {
                    m_BlobMeasurementTable.Rows.Add(new object[] { kvp.Key, "Filter", kvp.Value[0].ToString(), kvp.Value[1].ToString(), kvp.Value[2].ToString() }); 
                    m_measurementList.Remove(kvp.Key);
                }
            }

            if(BlobParams.morphologyOperation.Count > 0)
            {
                for(int i = 0; i <BlobParams.morphologyOperation.Count; i++)
                {
                    m_dgvBlobOperation.Rows.Add(new string[] { BlobParams.morphologyOperation[i].ToString() });
                }
            }

            m_cbSegMode.SelectedItem = BlobParams.thresholdMode;
            m_cbSegPolarity.SelectedItem = BlobParams.polarity;
            m_cbConnectMode.SelectedIndex = 0;
            m_cbConnectClean.SelectedIndex = 2;
            m_NumConnectionMin.Value = BlobParams.minArea;
            m_NumSegmentation1.Value = (decimal)BlobParams.threshold;
        }

        private void m_dgvBlobResults_SelectionChanged(object sender, EventArgs e)
        {
            if (m_dgvBlobResults.Rows.Count == 0) { return; }
            if (m_dgvBlobResults.SelectedRows.Count == 0) { return; }
            ToolWindow m_toolWindow = (ToolWindow)this.ParentForm;
            if(m_toolWindow.m_displayControl.m_bitmapList == null) { return; }
            if (!m_toolWindow.m_displayControl.m_cbImages.SelectedItem.ToString().EndsWith("BlobImage")) { return; }
            try
            {
                int N = int.Parse(m_dgvBlobResults.SelectedRows[0].Cells[0].Value.ToString());
                Bitmap tempBitamp = m_toolWindow.m_displayControl.m_bitmapList["LastRun."+m_toolWindow.m_toolBase.ToolName+".BlobImage"].ToBitmap();
                using(Pen pen = new Pen(Color.DeepSkyBlue,2))
                using (Graphics graphics = Graphics.FromImage(tempBitamp))
                {
                    graphics.DrawPolygon(pen, ((BlobTool)m_toolWindow.m_toolBase).contourByRow[N]);
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

        private void m_cbBlobProperties_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox m_comboBox = (ComboBox)sender;
            if (m_comboBox.SelectedIndex == -1)
                return;
            string m_strName = m_comboBox.SelectedItem.ToString();
            if (m_strName == "<ADD ALL>")
            {
                m_measurementList.RemoveAt(m_measurementList.Count-1);
                for (int i = 0; i < m_comboBox.Items.Count;)
                {
                    m_comboBox.SelectedIndex = 0;
                    m_comboBox.SelectedIndex = -1;
                }
                return;
            }
            int index = m_BlobMeasurementTable.Rows.Add();
            m_BlobMeasurementTable.Rows[index].Cells[0].Value = m_strName;
            ((DataGridViewComboBoxCell)m_BlobMeasurementTable.Rows[index].Cells[1]).Value = "Runtime";
            m_measurementList.RemoveAt(m_cbBlobProperties.SelectedIndex);
        }

        private void m_cbSegPolarity_SelectedIndexChanged(object sender, EventArgs e)
        {
            BlobParams.polarity = m_cbSegPolarity.SelectedItem.ToString();
        }

        private void m_NumSegmentation1_ValueChanged(object sender, EventArgs e)
        {
            BlobParams.threshold = (double)m_NumSegmentation1.Value;
        }

        private void m_NumConnectionMin_ValueChanged(object sender, EventArgs e)
        {
            BlobParams.minArea = (int)m_NumConnectionMin.Value;
        }

        private void m_BlobMeasurementTable_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            DataGridView m_dataGridView = (DataGridView)sender;
            int m_intRow = e.RowIndex;
            int m_intColumn = e.ColumnIndex;
            DataGridViewRow m_dgvRow = m_dataGridView.Rows[m_intRow];
            DataGridViewCell m_dgvCell = m_dgvRow.Cells[m_intColumn];

            if (m_intColumn == 3)
            {
                if (m_dgvCell.Value == null)
                    m_dgvCell.Value = "0";
                if (m_dgvRow.Cells[4].Value == null)
                    m_dgvRow.Cells[4].Value = "0";
                try
                {
                    double low = double.Parse(m_dgvRow.Cells[3].Value.ToString());
                    double high = double.Parse(m_dgvRow.Cells[4].Value.ToString());
                    if (low > high)
                        m_dgvRow.Cells[4].Value = low.ToString();
                }
                catch (Exception)
                {
                    m_dgvCell.Value = "0";
                }

            }
            else if (m_intColumn == 4)
            {
                if (m_dgvCell.Value == null)
                    m_dgvCell.Value = "0";
                if (m_dgvRow.Cells[4].Value == null)
                    m_dgvRow.Cells[4].Value = "0";
                try
                {
                    double low = double.Parse(m_dgvRow.Cells[3].Value.ToString());
                    double high = double.Parse(m_dgvRow.Cells[4].Value.ToString());
                    if (high < low)
                        m_dgvRow.Cells[3].Value = high.ToString();
                }
                catch (Exception)
                {
                    m_dgvCell.Value = "0";
                }
            }
        }

        private void m_BlobMeasurementTable_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            DataGridView m_dataGridView = (DataGridView)sender;
            int m_intRow = e.RowIndex;
            int m_intColumn = e.ColumnIndex;
            DataGridViewRow m_dgvRow = m_dataGridView.Rows[m_intRow];
            DataGridViewCell m_dgvCell = m_dgvRow.Cells[m_intColumn];
            string m_strName = m_dgvRow.Cells[0].Value.ToString();

            if (m_intColumn == 1)
            {
                if (m_dgvCell.Value.ToString() != "Filter")
                {
                    if (BlobParams.MeasurementProperties.ContainsKey(m_strName))
                        BlobParams.MeasurementProperties.Remove(m_strName);
                    m_dgvRow.Cells[2].Value = "";
                    m_dgvRow.Cells[3].Value = "";
                    m_dgvRow.Cells[4].Value = "";
                    m_dgvRow.Cells[2].ReadOnly = true;
                    m_dgvRow.Cells[3].ReadOnly = true;
                    m_dgvRow.Cells[4].ReadOnly = true;
                }
                else
                {
                    m_dgvRow.Cells[2].Value = "Exclude";
                    m_dgvRow.Cells[3].Value = "0";
                    m_dgvRow.Cells[4].Value = "0";
                    m_dgvRow.Cells[2].ReadOnly = false;
                    m_dgvRow.Cells[3].ReadOnly = false;
                    m_dgvRow.Cells[4].ReadOnly = false;
                    BlobParams.MeasurementProperties.Add(m_strName, new ArrayList()
                    {
                        "Exclude","0","0"
                    });
                }
                return;
            }
            if (!BlobParams.MeasurementProperties.ContainsKey(m_strName))
                return;
            if (m_intColumn == 2)
            {
                if (m_dgvCell.Value.ToString() == "Include")
                    BlobParams.MeasurementProperties[m_strName][0] = "Include";
                else if (m_dgvCell.Value.ToString() == "Exclude")
                    BlobParams.MeasurementProperties[m_strName][0] = "Exclude";
            }
            else if (m_intColumn == 3)
            {
                if (m_dgvCell.Value == null)
                    return;
                BlobParams.MeasurementProperties[m_strName][1] = m_dgvCell.Value.ToString();
            }
            else if (m_intColumn == 4)
            {
                if (m_dgvCell.Value == null)
                    return;
                BlobParams.MeasurementProperties[m_strName][2] = m_dgvCell.Value.ToString();
            }
        }

        private void m_BlobMeasurementTable_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            m_BlobMeasurementTable.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void m_btnDeleteProperties_Click(object sender, EventArgs e)
        {
            if (m_BlobMeasurementTable.SelectedRows == null)
                return;
            foreach (DataGridViewRow row in m_BlobMeasurementTable.SelectedRows)
            {
                string m_strName = row.Cells[0].Value.ToString();
                m_measurementList.Add(m_strName);
                m_BlobMeasurementTable.Rows.Remove(row);
            }
        }

        private void m_cbBlobOperation_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_dgvBlobOperation.Rows.Add(new string[] { m_cbBlobOperation.SelectedItem.ToString() });
            BlobParams.morphologyOperation.Add(m_cbBlobOperation.SelectedItem.ToString());
        }

        private void m_BtnDeleteOperation_Click(object sender, EventArgs e)
        {
            if (m_dgvBlobOperation.SelectedRows == null)
                return;

            foreach (DataGridViewRow row in m_dgvBlobOperation.SelectedRows)
            {
                BlobParams.morphologyOperation.RemoveAt(row.Index);
                m_dgvBlobOperation.Rows.RemoveAt(row.Index);
            }
        }

        private void m_dgvBlobResults_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
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

        private void m_dgvBlobResults_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            DataGridViewColumn newColumn = e.Column;
            if (m_measurementList.Contains(newColumn.Name))
                newColumn.Visible = false;
            else
                newColumn.Visible = true;
        }

        private void m_dgvBlobResults_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            e.PaintCells(e.ClipBounds, DataGridViewPaintParts.All);
            e.PaintHeader(DataGridViewPaintParts.Background
                | DataGridViewPaintParts.Border
                | DataGridViewPaintParts.Focus
                | DataGridViewPaintParts.SelectionBackground
                | DataGridViewPaintParts.ContentForeground);
            e.Handled = true;
        }

        private void m_cbSegMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            BlobParams.thresholdMode = m_cbSegMode.SelectedItem.ToString();
            switch (((BlobParams)parameter).thresholdMode)
            {
                case "Global (Triangle)":
                    m_labelSeg1.Visible = false;
                    m_NumSegmentation1.Visible = false;
                    m_labelSeg2.Visible = false;
                    m_NumSegmentation2.Visible = false; 
                    m_labelSeg3.Visible = false;
                    m_NumSegmentation3.Visible = false;
                    break;
                case "Global (Manual)":
                    m_labelSeg1.Visible = true;
                    m_NumSegmentation1.Visible = true;
                    m_labelSeg2.Visible = false;
                    m_NumSegmentation2.Visible = false;
                    m_labelSeg3.Visible = false;
                    m_NumSegmentation3.Visible = false;
                    break;
                case "Global (Otsu)":
                    m_labelSeg1.Visible = false;
                    m_NumSegmentation1.Visible = false;
                    m_labelSeg2.Visible = false;
                    m_NumSegmentation2.Visible = false;
                    m_labelSeg3.Visible = false;
                    m_NumSegmentation3.Visible = false;
                    break;
                case "Local (MeanC)":
                    m_labelSeg1.Visible = false;
                    m_NumSegmentation1.Visible = false;
                    m_labelSeg2.Visible = true;
                    m_NumSegmentation2.Visible = true;
                    m_labelSeg3.Visible = true;
                    m_NumSegmentation3.Visible = true;
                    break;
                case "Local (GaussianC)":
                    m_labelSeg1.Visible = false;
                    m_NumSegmentation1.Visible = false; 
                    m_labelSeg2.Visible = true;
                    m_NumSegmentation2.Visible = true;
                    m_labelSeg3.Visible = true;
                    m_NumSegmentation3.Visible = true;
                    break;
                default:
                    return;
            }
        }

        private void m_NumSegmentation2_ValueChanged(object sender, EventArgs e)
        {
            BlobParams.blockSize = (int)m_NumSegmentation2.Value;
        }

        private void m_NumSegmentation3_ValueChanged(object sender, EventArgs e)
        {
            BlobParams.param1 = (int)m_NumSegmentation3.Value;
        }
    }
}