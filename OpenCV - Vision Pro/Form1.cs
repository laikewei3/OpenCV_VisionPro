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

namespace OpenCV_Vision_Pro
{

    public partial class Form1 : Form
    {
        Dictionary<String, Bitmap> bitmapList = new Dictionary<String, Bitmap>();
        string m_strFileName;
        ROI m_roi = new ROI();
        Panel panel;
        BlobTool blobTool = new BlobTool();
        CaliperTool caliperTool = new CaliperTool();

        public Form1()
        {
            InitializeComponent();
            panel2.MouseWheel += m_display_MouseWheel;
            CenterPictureBox(m_display);

            Panel tempPanel = new Panel();
            panel = new Panel();
            panel.Height = 65;

            m_HistogramInput.Controls.Add(panel);
            panel.Controls.Add(tempPanel);
            tempPanel.Controls.Add(m_roi);

            blobTool.MeasurementProperties = new Dictionary<string, ArrayList>();

            m_roi.Dock = DockStyle.Fill;
            panel.Dock = DockStyle.Top;
            tempPanel.Dock = DockStyle.Top;

            //m_display.Paint += ROI_Paint;
            m_roi.m_comboBoxROI.SelectedIndexChanged += m_comboBoxROI_SelectedIndexChanged;

            for (int i = 0; i < 3; i++)
            {
                m_cbBlobProperties.SelectedIndex = 0;
                m_cbBlobProperties.SelectedIndex = -1;
            }

            m_cbSegMode.SelectedIndex = 2;
            m_cbSegPolarity.SelectedIndex = 0;
            m_cbConnectMode.SelectedIndex = 0;
            m_cbConnectClean.SelectedIndex = 2;
        }

        private void m_OpenBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All File (*.*) | *.*";
            if(openFileDialog.ShowDialog() == DialogResult.OK) { 

                m_strFileName = openFileDialog.FileName;

                Bitmap m_image = new Bitmap(m_strFileName);
                m_display.Width = m_image.Width;
                m_display.Height = m_image.Height;

                if (bitmapList.ContainsKey("LastRun.OutputImage"))
                    bitmapList["LastRun.OutputImage"] = m_image;
                else
                    bitmapList.Add("LastRun.OutputImage", m_image);

                m_display.Image = bitmapList["LastRun.OutputImage"];
                m_cbImages.Items.Clear();
                m_cbImages.Items.Add("LastRun.OutputImage");
                m_cbImages.SelectedIndex = 0;
            }
        }

        private void m_display_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta != 0 && m_display.Image != null)
            {
                if (e.Delta <= 0)
                {
                    if (m_roi.FrameControl.Width < 10 || m_roi.FrameControl.Height < 10)
                        return;
                    //set minimum size to zoom
                    if (m_display.Width < 0)
                        return;
                }
                else
                {
                    //set maximum size to zoom
                    if (m_display.Width > 8000)
                        return;
                }
                
                m_display.Width += Convert.ToInt32(m_display.Width * e.Delta / 1000);
                m_display.Height += Convert.ToInt32(m_display.Height * e.Delta / 1000);
                m_roi.FrameControl.Width += Convert.ToInt32(m_roi.FrameControl.Width * e.Delta / 1000);
                m_roi.FrameControl.Height += Convert.ToInt32(m_roi.FrameControl.Height * e.Delta / 1000);
                m_roi.FrameControl.X += Convert.ToInt32(m_roi.FrameControl.X * (double)e.Delta / 1000);
                m_roi.FrameControl.Y += Convert.ToInt32(m_roi.FrameControl.Y * (double)e.Delta / 1000);
                CenterPictureBox(m_display);
            }
        }

        private void CenterPictureBox(PictureBox picBox)
        {
            panel2.AutoScrollPosition = new Point((panel2.Width + picBox.Width / 2),
                                        picBox.Parent.ClientSize.Height / 2 + picBox.Height / 2);

            picBox.Location = new Point((picBox.Parent.ClientSize.Width / 2 - picBox.Width / 2),
                                        (picBox.Parent.ClientSize.Height / 2 - picBox.Height / 2));
            picBox.Refresh();
        }

        private void panel2_Resize(object sender, EventArgs e)
        {
            CenterPictureBox(m_display);
        }

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
        }

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
            m_cbImages.SelectedIndex = 0;
        }

        private void runHistogram()
        {
            HistogramTool histogramTool;
            if (m_roi.m_comboBoxROI.SelectedIndex != 0)
            {
                Bitmap bitmap = new Bitmap(m_display.Image);
                histogramTool = new HistogramTool(getRegion());
            }else
                histogramTool = new HistogramTool(bitmapList["LastRun.OutputImage"]);
            //bitmapList.Add("LastRun.Histogram.InputImage", new Bitmap(m_display.Image));
            //m_cbImages.Items.Add("LastRun.Histogram.InputImage");

            m_tbMin.Text = histogramTool.Minimum.ToString();
            m_tbMax.Text = histogramTool.Maximum.ToString();
            m_tbMedian.Text = histogramTool.Median.ToString();
            m_tbMode.Text = histogramTool.Mode.ToString();
            m_tbMean.Text = Math.Round(histogramTool.Mean,4).ToString();
            m_tbSD.Text = Math.Round(histogramTool.StandardDeviation,4).ToString();
            m_tbVariance.Text = Math.Round(histogramTool.Variance,4).ToString();

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

        private void runBlob() {
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
            int i = 1;
            List<string> m_listData = new List<string>();
            m_dgvBlobResults.Columns.Add("m_measure1", "ID");
            //m_listData.Add("N");
            m_listData.Add("ID");

            foreach (DataGridViewRow r in rows)
            {
                m_dgvBlobResults.Columns.Add("m_measure" + i++, r.Cells[0].Value.ToString());
                m_listData.Add(r.Cells[0].Value.ToString());
            }
            foreach (Blob r in m_listResults)
            {
                i = 0;
                string[] m_listTemp = new string[m_listData.Count];
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
                caliperTool.Run(getRegion());
            else
                caliperTool.Run(bitmapList["LastRun.OutputImage"].ToMat());
            /*
            m_CaliperRes.DataSource = caliperTool.caliperResult;

            if (bitmapList.ContainsKey("LastRun.Caliper"))
                bitmapList["LastRun.Caliper"] = caliperTool.caliperImage;
            else
            {
                bitmapList.Add("LastRun.Caliper", caliperTool.caliperImage);
                m_cbImages.Items.Add("LastRun.Caliper");
            }*/
        }

        private void m_cbImages_SelectedIndexChanged(object sender, EventArgs e)
        {
            String m_strSelectedItem = m_cbImages.SelectedItem.ToString();
            Bitmap selectedBitmap = bitmapList[m_strSelectedItem];
            m_display.Width = selectedBitmap.Width;
            m_display.Height = selectedBitmap.Height;
            m_display.Image = selectedBitmap;
            CenterPictureBox(m_display);
        }

        /*
        private void ROI_Paint(object sender, PaintEventArgs e)
        {
            if(m_display.Controls.Count <= 0)
                return;
            e.Graphics.ExcludeClip(m_display.Controls[0].Bounds);
            using (var b = new SolidBrush(Color.FromArgb(100, Color.Black)))
                e.Graphics.FillRectangle(b, m_display.ClientRectangle);
            
        }*/

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED       
                return cp;
            }
        }

        private void m_comboBoxROI_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_roi.m_comboBoxROI.SelectedIndex == 0)
            {
                m_display.Controls.Clear();
                return;
            }
            
            m_display.Controls.Add(m_roi.FrameControl);
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
            blobTool.polarity = m_cbSegPolarity.SelectedItem.ToString() ;
        }

        private void m_dgvBlobResults_SelectionChanged(object sender, EventArgs e)
        {
            if (m_dgvBlobResults.Rows.Count == 0) { return; }
            if (m_dgvBlobResults.SelectedRows.Count == 0) { return; }
            if(m_cbImages.SelectedItem.ToString() != "LastRun.BlobImage") { return; }
            try
            {
                int m_intNum = m_dgvBlobResults.SelectedRows[0].Index;
                int ID = int.Parse(m_dgvBlobResults.SelectedRows[0].Cells[0].Value.ToString());
                Mat tempMat = bitmapList["LastRun.BlobImage"].ToMat();
                CvInvoke.Polylines(tempMat, blobTool.contourByID[ID], true, new MCvScalar(100,150), 2);
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

            int width,height;
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

            return new Mat(m, new Rectangle(X, Y, width, height));
        }
        private void m_RunBtn_Click(object sender, EventArgs e)
        {
            
        }

        /// <summary>https://stackoverflow.com/a/24199315/1115360
        /// Resize the image to the specified width and height.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        private Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
    }
}
