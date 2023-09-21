using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace OpenCV_Vision_Pro
{
    public partial class ToolWindow : Form
    {
        public DisplayControl m_displayControl { get; set; }
        private BlobToolControl blobToolControl;
        private CaliperToolControl caliperToolControl;
        private HistogramToolControl histogramToolControl;
        private string m_strControlType;
        public ROI m_roi { get; set; }
        public ToolWindow()
        {
            InitializeComponent();
            m_displayControl = new DisplayControl
            {
                Dock = DockStyle.Fill
            };
            splitContainer1.Panel2.Controls.Add(m_displayControl);
        }

        private void ToolWindow_Load(object sender, EventArgs e)
        {
            m_strControlType = tableLayoutPanel1.GetControlFromPosition(0,1).GetType().Name;
            switch (m_strControlType)
            {
                case "BlobToolControl":
                    blobToolControl = (BlobToolControl)tableLayoutPanel1.GetControlFromPosition(0, 1);
                    break;
                case "CaliperToolControl":
                    caliperToolControl = (CaliperToolControl)tableLayoutPanel1.GetControlFromPosition(0, 1);
                    break;
                case "HistogramToolControl":
                    histogramToolControl = (HistogramToolControl)tableLayoutPanel1.GetControlFromPosition(0, 1);
                    break;
                default:
                    MessageBox.Show("Error");
                    break;
            }

            if(m_displayControl.m_bitmapList != null)
            {
                if (m_displayControl.m_bitmapList.Count > 0)
                {
                    if (m_displayControl.m_bitmapList[Form1.m_cntImageIndex].Count == 1)
                    {
                        Bitmap image = m_displayControl.m_bitmapList[Form1.m_cntImageIndex]["Current.InputImage"];
                        m_displayControl.m_display.Width = image.Width;
                        m_displayControl.m_display.Height = image.Height;
                        m_displayControl.m_display.Image = image;
                        m_displayControl.m_cbImages.Items.Add("Current.InputImage");
                        m_displayControl.m_cbImages.SelectedIndex = 0;
                    }
                    else if (m_displayControl.m_bitmapList[Form1.m_cntImageIndex].Count > 1)
                    {
                        foreach (string imageStr in m_displayControl.m_bitmapList[Form1.m_cntImageIndex].Keys)
                        {
                            m_displayControl.m_cbImages.Items.Add(imageStr);
                        }
                        m_displayControl.m_cbImages.SelectedIndex = 0;
                    }
                }
            }
            
            m_displayControl.m_roi = this.m_roi;
            m_roi.m_displayControl = this.m_displayControl;
            m_roi.m_displayControl.m_display.Controls.Add(m_roi.FrameControl);
            if (m_roi.m_comboBoxROI.SelectedIndex != 0)
                m_roi.FrameControl.Visible = true;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            // Check if the form is closing due to user action (not application exit).
            if (e.CloseReason == CloseReason.UserClosing)
            {
                splitContainer1.Panel1.Controls.Clear();
                m_displayControl.m_display.Controls.Clear();
            }
        }

        public void m_RunToolBtn_Click(object sender, EventArgs e)
        {
            if (m_displayControl.m_display.Image == null)
            {
                MessageBox.Show("No Input Image");
                return;
            }
            switch (m_strControlType)
            {
                case "BlobToolControl":
                    runBlob();
                    break;
                case "CaliperToolControl":
                    runCaliper();
                    break;
                case "HistogramToolControl":
                    runHistogram();
                    break;
                default:
                    MessageBox.Show("Error");
                    break;
            }
            int index = m_displayControl.m_cbImages.SelectedIndex;
            m_displayControl.m_cbImages.SelectedIndex = 0;
            m_displayControl.m_cbImages.SelectedIndex = index;
        }

        private void runBlob()
        {
            if (m_displayControl.m_roi.m_comboBoxROI.SelectedIndex != 0)
                blobToolControl.blobTool.Run(m_displayControl.getRegion());
            else
                blobToolControl.blobTool.Run(m_displayControl.m_bitmapList[Form1.m_cntImageIndex]["Current.InputImage"].ToMat());
            
            List<Blob> m_blobResult = blobToolControl.blobTool.blobResults.blobs;
            blobToolControl.showBlobResult(m_blobResult);
            if (m_displayControl.m_bitmapList[Form1.m_cntImageIndex].ContainsKey("LastRun."+this.Text+".BlobImage"))
            {
                m_displayControl.m_bitmapList[Form1.m_cntImageIndex]["LastRun." + this.Text + ".BlobImage"] = blobToolControl.blobTool.blobResults.BlobImage;
                Form1.m_displayControl.m_bitmapList[Form1.m_cntImageIndex]["LastRun." + this.Text + ".BlobImage"] = blobToolControl.blobTool.blobResults.BlobImage;
            }
            else
            {
                Form1.m_displayControl.m_bitmapList[Form1.m_cntImageIndex].Add("LastRun." + this.Text + ".BlobImage", blobToolControl.blobTool.blobResults.BlobImage);
                m_displayControl.m_bitmapList[Form1.m_cntImageIndex].Add("LastRun." + this.Text + ".BlobImage", blobToolControl.blobTool.blobResults.BlobImage);
                if(!Form1.m_displayControl.m_cbImages.Items.Contains("LastRun." + this.Text + ".BlobImage"))
                    Form1.m_displayControl.m_cbImages.Items.Add("LastRun." + this.Text + ".BlobImage");
                if(!m_displayControl.m_cbImages.Items.Contains("LastRun." + this.Text + ".BlobImage"))
                    m_displayControl.m_cbImages.Items.Add("LastRun." + this.Text + ".BlobImage");
            }
            
            blobToolControl.m_bitmapList[Form1.m_cntImageIndex] = CloneDictionaryCloningValues<string, Bitmap>(m_displayControl.m_bitmapList[Form1.m_cntImageIndex]);
            blobToolControl.m_dgvBlobResults.SelectionChanged += m_dgvBlobResults_SelectionChanged;
        }
        
        private void m_dgvBlobResults_SelectionChanged(object sender, EventArgs e)
        {
            if (m_displayControl.m_cbImages.SelectedItem.ToString() != "LastRun." + this.Text + ".BlobImage") { return; }
            try
            {
                m_displayControl.m_display.Image = blobToolControl.resultSelectedImage.ToBitmap();
                blobToolControl.resultSelectedImage.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void runHistogram()
        {
            HistogramTool histogramTool;
            if (m_roi.m_comboBoxROI.SelectedIndex != 0)
            {
                histogramTool = new HistogramTool(m_displayControl.getRegion());
            }
            else
                histogramTool = new HistogramTool(m_displayControl.m_bitmapList[Form1.m_cntImageIndex]["Current.InputImage"]);

            histogramToolControl.showResult(histogramTool);

            if (m_displayControl.m_bitmapList[Form1.m_cntImageIndex].ContainsKey("LastRun." + this.Text + ".Histogram"))
            {
                m_displayControl.m_bitmapList[Form1.m_cntImageIndex]["LastRun." + this.Text + ".Histogram"] = histogramTool.HistogramResult.histogram;
                Form1.m_displayControl.m_bitmapList[Form1.m_cntImageIndex]["LastRun." + this.Text + ".Histogram"] = histogramTool.HistogramResult.histogram;
            }
            else
            {
                Form1.m_displayControl.m_bitmapList[Form1.m_cntImageIndex].Add("LastRun." + this.Text + ".Histogram", histogramTool.HistogramResult.histogram);
                m_displayControl.m_bitmapList[Form1.m_cntImageIndex].Add("LastRun." + this.Text + ".Histogram", histogramTool.HistogramResult.histogram);
                if (!Form1.m_displayControl.m_cbImages.Items.Contains("LastRun." + this.Text + ".Histogram"))
                    Form1.m_displayControl.m_cbImages.Items.Add("LastRun." + this.Text + ".Histogram");
                if (!m_displayControl.m_cbImages.Items.Contains("LastRun." + this.Text + ".Histogram"))
                    m_displayControl.m_cbImages.Items.Add("LastRun." + this.Text + ".Histogram");
            }
                    
        }
        
        private void runCaliper()
        {
            caliperToolControl.m_CaliperRes.Columns.Clear();
            caliperToolControl.m_CaliperRes.DataSource = null;
            caliperToolControl.m_CaliperRes.Refresh();
            if (m_roi.m_comboBoxROI.SelectedIndex != 0)
                caliperToolControl.caliperTool.Run(m_displayControl.m_bitmapList[Form1.m_cntImageIndex]["Current.InputImage"].ToMat(), m_displayControl.getRegionRect());
            else
                caliperToolControl.caliperTool.Run(m_displayControl.m_bitmapList[Form1.m_cntImageIndex]["Current.InputImage"].ToMat(), new Rectangle());

            caliperToolControl.m_CaliperRes.DataSource = caliperToolControl.caliperTool.caliperResult;
            caliperToolControl.m_CaliperRes.Columns[0].Frozen = true;
            if (m_displayControl.m_bitmapList[Form1.m_cntImageIndex].ContainsKey("LastRun." + this.Text + ".Caliper"))
            {
                m_displayControl.m_bitmapList[Form1.m_cntImageIndex]["LastRun." + this.Text + ".Caliper"] = caliperToolControl.caliperTool.caliperImage;
                Form1.m_displayControl.m_bitmapList[Form1.m_cntImageIndex]["LastRun." + this.Text + ".Caliper"] = caliperToolControl.caliperTool.caliperImage;
            }
            else
            {
                Form1.m_displayControl.m_bitmapList[Form1.m_cntImageIndex].Add("LastRun." + this.Text + ".Caliper", caliperToolControl.caliperTool.caliperImage);
                m_displayControl.m_bitmapList[Form1.m_cntImageIndex].Add("LastRun." + this.Text + ".Caliper", caliperToolControl.caliperTool.caliperImage);
                if (!Form1.m_displayControl.m_cbImages.Items.Contains("LastRun." + this.Text + ".Caliper"))
                    Form1.m_displayControl.m_cbImages.Items.Add("LastRun." + this.Text + ".Caliper");
                if (!m_displayControl.m_cbImages.Items.Contains("LastRun." + this.Text + ".Caliper"))
                    m_displayControl.m_cbImages.Items.Add("LastRun." + this.Text + ".Caliper");
            }
            caliperToolControl.m_CaliperRes.SelectionChanged += m_CaliperRes_SelectionChanged;
        }

        private void m_CaliperRes_SelectionChanged(object sender, EventArgs e)
        {
            if (m_displayControl.m_cbImages.SelectedItem.ToString() != "LastRun." + this.Text + ".Caliper") { return; }
            try
            {
                m_displayControl.m_display.Image = caliperToolControl.resultSelectedImage.ToBitmap();
                caliperToolControl.resultSelectedImage.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public Dictionary<TKey, TValue> CloneDictionaryCloningValues<TKey, TValue>(Dictionary<TKey, TValue> original) where TValue : ICloneable
        {
            Dictionary<TKey, TValue> ret = new Dictionary<TKey, TValue>(original.Count,
                                                                    original.Comparer);
            foreach (KeyValuePair<TKey, TValue> entry in original)
            {
                ret.Add(entry.Key, (TValue)entry.Value.Clone());
            }
            return ret;
        }
        

    }
}
