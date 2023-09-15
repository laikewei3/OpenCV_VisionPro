using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Features2D;
using Emgu.CV.Util;
using Emgu.CV.CvEnum;
using System.Reflection;
using System.Collections;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms.VisualStyles;
using System.Reflection.Metadata;

namespace OpenCV_Vision_Pro
{
    public partial class Form1 : Form
    {
        
        
        CaliperTool caliperTool = new CaliperTool();
        DisplayControl m_displayControl;
        public Form1()
        {
            InitializeComponent();
            m_displayControl = new DisplayControl();
            m_displayControl.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(m_displayControl);
            /*

            blobTool.MeasurementProperties = new Dictionary<string, ArrayList>();

            //m_display.Paint += ROI_Paint;
            m_roi.m_comboBoxROI.SelectedIndexChanged += m_comboBoxROI_SelectedIndexChanged;

            */
        }
        
        private void m_OpenBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All File (*.*) | *.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Bitmap m_image = new Bitmap(openFileDialog.FileName);
                m_displayControl.m_display.Width = m_image.Width;
                m_displayControl.m_display.Height = m_image.Height;

                m_displayControl.m_cbImages.Items.Clear();
                m_displayControl.m_bitmapList.Clear();
                m_displayControl.m_bitmapList.Add("LastRun.OutputImage", m_image);

                m_displayControl.m_display.Image = m_displayControl.m_bitmapList["LastRun.OutputImage"];
                m_displayControl.m_cbImages.Items.Add("LastRun.OutputImage");
                m_displayControl.m_cbImages.SelectedIndex = 0;
            }
        }

        private void m_BtnAddTool_Click(object sender, EventArgs e)
        {
            m_AddToolList.Show(m_BtnAddTool, new Point(0, m_BtnAddTool.Height));
        }

        private void blobToolMenuItem_Click(object sender, EventArgs e)
        {
            BlobTool blobTool = new BlobTool();
            
        }
        /*
private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
{
if (((TabControl)sender).SelectedIndex == 0) //Histogram
{
if (!m_roi.m_comboBoxROI.Items.Contains("CogRectangle"))
  m_roi.m_comboBoxROI.Items.Insert(1, "CogRectangle");
m_HistogramInput.Controls.Add(panel);
}
else if (((TabControl)sender).SelectedIndex == 1) //Blob
{
if (!m_roi.m_comboBoxROI.Items.Contains("CogRectangle"))
  m_roi.m_comboBoxROI.Items.Insert(1, "CogRectangle");
m_BlobInput.Controls.Add(panel);
}
else if (((TabControl)sender).SelectedIndex == 2) //Caliper
{
if (m_roi.m_comboBoxROI.SelectedIndex != 0 && m_roi.m_comboBoxROI.SelectedIndex != 2)
  m_roi.m_comboBoxROI.SelectedIndex = 2;
m_roi.m_comboBoxROI.Items.Remove("CogRectangle"); //Remove CogRectangle
m_CaliperInput.Controls.Add(panel);
}
}*/
        /*
        private void m_RunToolBtn_Click(object sender, EventArgs e)
        {
            if (m_display.Image == null)
            {
                MessageBox.Show("No Image Selected");
                return;
            }
            if (tabControl1.SelectedTab.Name == "m_HistogramTab")
                runHistogram();
            else if (tabControl1.SelectedTab.Name == "m_BlobTab")
                runBlob();
            else if (tabControl1.SelectedTab.Name == "m_CaliperTab")
                runCaliper();
            int index = m_cbImages.SelectedIndex;
            m_cbImages.SelectedIndex = 0;
            m_cbImages.SelectedIndex = index;
        }*/
        /*
        private void runHistogram()
        {
            HistogramTool histogramTool;
            if (m_roi.m_comboBoxROI.SelectedIndex != 0)
            {
                Bitmap bitmap = new Bitmap(m_display.Image);
                histogramTool = new HistogramTool(getRegion());
            }
            else
                histogramTool = new HistogramTool(bitmapList["LastRun.OutputImage"]);
            //bitmapList.Add("LastRun.Histogram.InputImage", new Bitmap(m_display.Image));
            //m_cbImages.Items.Add("LastRun.Histogram.InputImage");

            m_tbMin.Text = histogramTool.Minimum.ToString();
            m_tbMax.Text = histogramTool.Maximum.ToString();
            m_tbMedian.Text = histogramTool.Median.ToString();
            m_tbMode.Text = histogramTool.Mode.ToString();
            m_tbMean.Text = Math.Round(histogramTool.Mean, 4).ToString();
            m_tbSD.Text = Math.Round(histogramTool.StandardDeviation, 4).ToString();
            m_tbVariance.Text = Math.Round(histogramTool.Variance, 4).ToString();

            m_tbSample.Text = histogramTool.NumberOfSample.ToString();
            m_dgvHisData.DataSource = histogramTool.histData;
            if (bitmapList.ContainsKey("LastRun.Histogram"))
                bitmapList["LastRun.Histogram"] = histogramTool.histogram;
            else
            {
                bitmapList.Add("LastRun.Histogram", histogramTool.histogram);
                m_cbImages.Items.Add("LastRun.Histogram");
            }
        }

        private void runBlob()
        {
            m_dgvBlobResults.Columns.Clear();
            m_dgvBlobResults.Rows.Clear();
            m_dgvBlobResults.Refresh();
            if (m_roi.m_comboBoxROI.SelectedIndex != 0)
                blobTool.Run(getRegion());
            else
                blobTool.Run(bitmapList["LastRun.OutputImage"].ToMat());

            List<Blob> m_blobResult = blobTool.blobs;
            showBlobResult(m_BlobMeasurementTable.Rows, m_blobResult);
            if (bitmapList.ContainsKey("LastRun.BlobImage"))
                bitmapList["LastRun.BlobImage"] = blobTool.BlobImage;
            else
            {
                bitmapList.Add("LastRun.BlobImage", blobTool.BlobImage);
                m_cbImages.Items.Add("LastRun.BlobImage");
            }
        }

        private void showBlobResult(DataGridViewRowCollection rows, List<Blob> m_listResults)
        {
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

            foreach (DataGridViewRow r in rows)
            {
                int index = m_dgvBlobResults.Columns.Add("m_measure" + i++, r.Cells[0].Value.ToString());
                m_dgvBlobResults.Columns[index].ReadOnly = true;
                m_listData.Add(r.Cells[0].Value.ToString());
            }
            int j = 0;
            foreach (Blob r in m_listResults)
            {
                i = 1;
                string[] m_listTemp = new string[m_listData.Count+1];
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


        }

        private void runCaliper()
        {
            m_CaliperRes.Columns.Clear();
            m_CaliperRes.DataSource = null;
            m_CaliperRes.Refresh();

            if (m_roi.m_comboBoxROI.SelectedIndex != 0)
                caliperTool.Run(bitmapList["LastRun.OutputImage"].ToMat(), getRegionRect());
            else
                caliperTool.Run(bitmapList["LastRun.OutputImage"].ToMat(), new Rectangle());

            m_CaliperRes.DataSource = caliperTool.caliperResult;
            m_CaliperRes.Columns[0].Frozen = true;
            if (bitmapList.ContainsKey("LastRun.Caliper"))
                bitmapList["LastRun.Caliper"] = caliperTool.caliperImage;
            else
            {
                bitmapList.Add("LastRun.Caliper", caliperTool.caliperImage);
                m_cbImages.Items.Add("LastRun.Caliper");
            }
        }*/



        /*
        private void ROI_Paint(object sender, PaintEventArgs e)
        {
            if(m_display.Controls.Count <= 0)
                return;
            e.Graphics.ExcludeClip(m_display.Controls[0].Bounds);
            using (var b = new SolidBrush(Color.FromArgb(100, Color.Black)))
                e.Graphics.FillRectangle(b, m_display.ClientRectangle);
            
        }*/

        /*
        private void m_comboBoxROI_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_roi.m_comboBoxROI.SelectedIndex == 0)
            {
                m_display.Controls.Clear();
                return;
            }

            m_display.Controls.Add(m_roi.FrameControl);
            if (m_cbImages.SelectedItem.ToString() == "LastRun.OutputImage")
                m_roi.FrameControl.Visible = true;
            else
                m_roi.FrameControl.Visible = false;
        }

        private void m_cbBlobProperties_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox m_comboBox = (ComboBox)sender;
            if (m_comboBox.SelectedIndex == -1)
                return;
            String m_strName = m_comboBox.SelectedItem.ToString();
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

        private void m_dgvBlobResults_SelectionChanged(object sender, EventArgs e)
        {
            if (m_dgvBlobResults.Rows.Count == 0) { return; }
            if (m_dgvBlobResults.SelectedRows.Count == 0) { return; }
            if (m_cbImages.SelectedItem.ToString() != "LastRun.BlobImage") { return; }
            try
            {
                int m_intNum = m_dgvBlobResults.SelectedRows[0].Index;
                int N = int.Parse(m_dgvBlobResults.SelectedRows[0].Cells[0].Value.ToString());
                Mat tempMat = bitmapList["LastRun.BlobImage"].ToMat();
                CvInvoke.Polylines(tempMat, blobTool.contourByRow[N], true, new MCvScalar(100, 150), 2);
                Console.Write(N + ":"+ "DRAW" + "\n");
                m_display.Image = tempMat.ToBitmap();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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
                catch (Exception ex)
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
                catch (Exception ex)
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
            String m_strName = m_dgvRow.Cells[0].Value.ToString();

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

        private Mat getRegion()
        {
            Mat m = ResizeImage(m_display.Image, m_display.Width, m_display.Height).ToMat();
            return new Mat(m, getRegionRect());
        }*/
        /*
        private Rectangle getRegionRect()
        {
            int width, height;
            int X = 0;
            int Y = 0;

            if (m_roi.X < 0)
                width = m_roi.ROI_Width + m_roi.X;
            else if (m_roi.X + m_roi.ROI_Width > m_display.Width)
            {
                X = m_roi.X;
                width = m_display.Width - m_roi.X;
            }
            else
            {
                X = m_roi.X;
                width = m_roi.ROI_Width;
            }

            if (m_roi.Y < 0)
                height = m_roi.ROI_Height + m_roi.Y;
            else if (m_roi.Y + m_roi.ROI_Height > m_display.Height)
            {
                Y = m_roi.Y;
                height = m_display.Height - m_roi.Y;
            }
            else
            {
                Y = m_roi.Y;
                height = m_roi.ROI_Height;
            }

            return new Rectangle(X, Y, width, height);
        }*/
        /*
        private void m_RunBtn_Click(object sender, EventArgs e)
        {
            if (m_display.Image == null)
            {
                MessageBox.Show("No Image Selected");
                return;
            }
            if (tabControl1.SelectedTab.Name == "m_HistogramTab")
                runHistogram();
            else if (tabControl1.SelectedTab.Name == "m_BlobTab")
                runBlob();
            else if (tabControl1.SelectedTab.Name == "m_CaliperTab")
                runCaliper();
            int index = m_cbImages.SelectedIndex;
            m_cbImages.SelectedIndex = 0;
            m_cbImages.SelectedIndex = index;
        }
        */


        /*
        private void m_CaliperRes_SelectionChanged(object sender, EventArgs e)
        {
            if (m_CaliperRes.Rows.Count == 0) { return; }
            if (m_CaliperRes.SelectedRows.Count == 0) { return; }
            if (m_cbImages.SelectedItem.ToString() != "LastRun.Caliper") { return; }
            try
            {
                int m_intNum = m_CaliperRes.SelectedRows[0].Index;
                int edge0 = int.Parse(m_CaliperRes.SelectedRows[0].Cells[2].Value.ToString());
                Mat tempMat = bitmapList["LastRun.Caliper"].ToMat();
                List<int> points = caliperTool.caliperPoints[edge0];

                int edge1 = 0;
                List<int> points1 = new List<int>();
                if (caliperTool.caliperParams.EdgeMode == "Edge Pair")
                {
                    edge1 = int.Parse(m_CaliperRes.SelectedRows[0].Cells[3].Value.ToString());
                    points1 = caliperTool.caliperPoints[edge1];
                }

                if (!caliperTool.caliperParams.ROIBool)
                {
                    if (caliperTool.caliperParams.EdgeMode == "Edge Pair")
                        CvInvoke.Line(tempMat, new Point(points1[0], points1[1]), new Point(points1[2], points1[3]), new MCvScalar(150), 1);

                    CvInvoke.Line(tempMat, new Point(points[0], points[1]), new Point(points[2], points[3]), new MCvScalar(150), 1);
                }
                else
                {
                    Point p1 = new Point(points[0] + m_roi.X, m_roi.Y);
                    Point p2 = new Point(points[2] + m_roi.X, m_roi.Y + m_roi.ROI_Height);
                    Point p3 = new Point(points1[0] + m_roi.X, m_roi.Y);
                    Point p4 = new Point(points1[2] + m_roi.X, m_roi.Y + m_roi.ROI_Height);

                    if (caliperTool.caliperParams.EdgeMode == "Edge Pair")
                        CvInvoke.Line(tempMat, p3, p4, new MCvScalar(150), 1);
                    CvInvoke.Line(tempMat, p1, p2, new MCvScalar(150), 1);
                }
                m_display.Image = tempMat.ToBitmap();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void m_NumSegmentation1_ValueChanged(object sender, EventArgs e)
        {
            blobTool.threshold = (double)m_NumSegmentation1.Value;
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

        private void m_NumEdgePairWidth_ValueChanged(object sender, EventArgs e)
        {
            caliperTool.caliperParams.estimatedWidth = (double)m_NumEdgePairWidth.Value;
        }

        private void m_NumResult_ValueChanged(object sender, EventArgs e)
        {
            caliperTool.caliperParams.maxResult = (int)m_NumResult.Value;
        }

        private void m_NumContrastThreshold_ValueChanged(object sender, EventArgs e)
        {
            caliperTool.caliperParams.contrastThreshold = (int)m_NumContrastThreshold.Value;
        }

        private void m_NumConnectionMin_ValueChanged(object sender, EventArgs e)
        {
            blobTool.minArea = (int) m_NumConnectionMin.Value;
        }

        private void m_btnDeleteProperties_Click(object sender, EventArgs e)
        {
            if (m_BlobMeasurementTable.SelectedRows == null)
                return;
            foreach (DataGridViewRow row in m_BlobMeasurementTable.SelectedRows)
            {
                String m_strName = row.Cells[0].Value.ToString();
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
        }*/
    }
}
