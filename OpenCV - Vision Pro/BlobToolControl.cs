using Emgu.CV.Structure;
using Emgu.CV;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace OpenCV_Vision_Pro
{
    public partial class BlobToolControl : UserControl
    {
        public BlobTool blobTool { get; set; } = new BlobTool();
        public Mat resultSelectedImage { get; set; }
        public ROI m_roi { get; set; } = new ROI();
        public Dictionary<string, Bitmap> m_bitmapList { get; set; } = new Dictionary<string, Bitmap>();

        public BlobToolControl()
        {
            InitializeComponent();
            Panel panel = new Panel();
            Panel tempPanel = new Panel();
            panel = new Panel();
            panel.Height = 65;
            
            this.Controls.Add(panel);
            panel.Controls.Add(tempPanel);
            tempPanel.Controls.Add(m_roi);
            m_roi.Dock = DockStyle.Fill;
            panel.Dock = DockStyle.Top;
            tempPanel.Dock = DockStyle.Top;

            for (int i = 0; i < 3; i++)
            {
                m_cbBlobProperties.SelectedIndex = 0;
                m_cbBlobProperties.SelectedIndex = -1;
            }

            m_cbSegMode.SelectedIndex = 2;
            m_cbSegPolarity.SelectedIndex = 0;
            m_cbConnectMode.SelectedIndex = 0;
            m_cbConnectClean.SelectedIndex = 2;

            m_NumSegmentation1.Value = 128;
        }

        public DataGridView showBlobResult(List<Blob> m_listResults)
        {
            m_dgvBlobResults.Columns.Clear();
            m_dgvBlobResults.Rows.Clear();
            m_dgvBlobResults.Refresh();

            int i = 2;
            List<string> m_listData = new List<string>();
            m_dgvBlobResults.Columns.Add("m_measure0", "N");
            m_dgvBlobResults.Columns.Add("m_measure1", "ID");
            m_dgvBlobResults.Columns[0].Frozen = true;
            m_dgvBlobResults.Columns[0].ReadOnly = true;
            m_dgvBlobResults.Columns[1].Frozen = true;
            m_dgvBlobResults.Columns[1].ReadOnly = true;
            m_dgvBlobResults.Columns[0].Width = 50;
            m_dgvBlobResults.Columns[1].Width = 50;
            m_listData.Add("ID");

            foreach (DataGridViewRow r in m_BlobMeasurementTable.Rows)
            {
                int index = m_dgvBlobResults.Columns.Add("m_measure" + i++, r.Cells[0].Value.ToString());
                m_dgvBlobResults.Columns[index].ReadOnly = true;
                m_listData.Add(r.Cells[0].Value.ToString());
            }
            int j = 0;
            foreach (Blob r in m_listResults)
            {
                i = 1;
                string[] m_listTemp = new string[m_listData.Count + 1];
                m_listTemp[0] = (j++).ToString();
                foreach (string name in m_listData)
                {
                    PropertyInfo propInfo = typeof(Blob).GetProperty(name);
                    if (propInfo != null)
                    {
                        object value = propInfo.GetValue(r);
                        m_listTemp[i++] = (value.ToString());
                    }
                }
                m_dgvBlobResults.Rows.Add(m_listTemp);
            }

            return m_dgvBlobResults;
        }

        private void m_cbBlobProperties_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox m_comboBox = (ComboBox)sender;
            if (m_comboBox.SelectedIndex == -1)
                return;
            string m_strName = m_comboBox.SelectedItem.ToString();
            if (m_strName == "<ADD ALL>")
            {
                m_comboBox.Items.RemoveAt(m_comboBox.Items.Count - 1);
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
            m_comboBox.Items.RemoveAt(m_cbBlobProperties.SelectedIndex);
        }

        private void m_cbSegPolarity_SelectedIndexChanged(object sender, EventArgs e)
        {
            blobTool.polarity = m_cbSegPolarity.SelectedItem.ToString();
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
                    if (blobTool.MeasurementProperties.ContainsKey(m_strName))
                        blobTool.MeasurementProperties.Remove(m_strName);
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
                    blobTool.MeasurementProperties.Add(m_strName, new ArrayList()
                    {
                        "Exclude",0,0
                    });
                }
                return;
            }
            if (!blobTool.MeasurementProperties.ContainsKey(m_strName))
                return;
            if (m_intColumn == 2)
            {
                if (m_dgvCell.Value.ToString() == "Include")
                    blobTool.MeasurementProperties[m_strName][0] = "Include";
                else if (m_dgvCell.Value.ToString() == "Exclude")
                    blobTool.MeasurementProperties[m_strName][0] = "Exclude";
            }
            else if (m_intColumn == 3)
            {
                if (m_dgvCell.Value == null)
                    return;
                blobTool.MeasurementProperties[m_strName][1] = m_dgvCell.Value.ToString();
            }
            else if (m_intColumn == 4)
            {
                if (m_dgvCell.Value == null)
                    return;
                blobTool.MeasurementProperties[m_strName][2] = m_dgvCell.Value.ToString();
            }
        }

        private void m_BlobMeasurementTable_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            m_BlobMeasurementTable.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void m_NumSegmentation1_ValueChanged(object sender, EventArgs e)
        {
            blobTool.threshold = (double)m_NumSegmentation1.Value;
        }

        private void m_NumConnectionMin_ValueChanged(object sender, EventArgs e)
        {
            blobTool.minArea = (int)m_NumConnectionMin.Value;
        }

        private void m_btnDeleteProperties_Click(object sender, EventArgs e)
        {
            if (m_BlobMeasurementTable.SelectedRows == null)
                return;
            foreach (DataGridViewRow row in m_BlobMeasurementTable.SelectedRows)
            {
                string m_strName = row.Cells[0].Value.ToString();
                m_cbBlobProperties.Items.Add(m_strName);
                m_BlobMeasurementTable.Rows.Remove(row);
            }
        }

        private void m_cbBlobOperation_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_dgvBlobOperation.Rows.Add(new string[] { m_cbBlobOperation.SelectedItem.ToString() });
            blobTool.morphologyOperation.Add(m_cbBlobOperation.SelectedItem.ToString());
        }

        private void m_BtnDeleteOperation_Click(object sender, EventArgs e)
        {
            if (m_dgvBlobOperation.SelectedRows == null)
                return;

            foreach (DataGridViewRow row in m_dgvBlobOperation.SelectedRows)
            {
                blobTool.morphologyOperation.RemoveAt(row.Index);
                m_dgvBlobOperation.Rows.RemoveAt(row.Index);
            }
        }

        private void m_dgvBlobResults_SelectionChanged(object sender, EventArgs e)
        {
            if (m_dgvBlobResults.Rows.Count == 0) { return; }
            if (m_dgvBlobResults.SelectedRows.Count == 0) { return; }
            try
            {
                int m_intNum = m_dgvBlobResults.SelectedRows[0].Index;
                int N = int.Parse(m_dgvBlobResults.SelectedRows[0].Cells[0].Value.ToString());
                Mat tempMat = blobTool.BlobImage.ToMat();
                CvInvoke.Polylines(tempMat, blobTool.contourByRow[N], true, new MCvScalar(100, 150), 2);
                resultSelectedImage = tempMat;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
    }
}
