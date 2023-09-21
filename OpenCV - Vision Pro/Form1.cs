using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Linq;

namespace OpenCV_Vision_Pro
{
    public partial class Form1 : Form
    {
        public static DisplayControl m_displayControl;
        public static int m_cntImageIndex = 0;
        private List<ToolsClass> m_toolsList = new List<ToolsClass>();
        public static List<Bitmap> m_inputImagesList;
        private bool runContinue = false;
        private bool openNewImage = false;
        private int m_intCntBlob = 0;
        private int m_intCntCaliper = 0;
        private int m_intCntHistogram = 0;
        private Timer m_timer;

        public Form1()
        {
            InitializeComponent();
            m_displayControl = new DisplayControl();
            m_displayControl.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(m_displayControl);
            //m_display.Paint += ROI_Paint;
            m_timer = new Timer();
            m_timer.Tick += timer1_Tick;
        }

        private void m_OpenBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All File (*.*) | *.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                m_displayControl.m_cbImages.Items.Clear();
                m_displayControl.m_bitmapList.Clear();
                using (Image image = Image.FromFile(openFileDialog.FileName))
                {
                    if (image != null)
                    {
                        m_cntImageIndex = 0;
                        int numberOfPages = image.GetFrameCount(System.Drawing.Imaging.FrameDimension.Page);
                        m_inputImagesList = new List<Bitmap>();
                        for (int page = 0; page < numberOfPages; page++)
                        {
                            image.SelectActiveFrame(FrameDimension.Page, page); // Switch to the current page

                            using (MemoryStream memStream = new MemoryStream())
                            {
                                image.Save(memStream, ImageFormat.Bmp);
                                using (Bitmap m_image = (Bitmap)Bitmap.FromStream(memStream))
                                {
                                    m_displayControl.m_display.Width = m_image.Width;
                                    m_displayControl.m_display.Height = m_image.Height;
                                    m_inputImagesList.Add(new Bitmap(m_image));
                                    m_image.Dispose();
                                }
                                memStream.Dispose();
                            }
                        }
                        m_displayControl.m_bitmapList = m_inputImagesList.Select(x => new Dictionary<string, Bitmap> { { "LastRun.OutputImage", x } }).ToList();
                        m_displayControl.m_display.Image = m_displayControl.m_bitmapList[0]["LastRun.OutputImage"];
                        m_displayControl.m_cbImages.Items.Add("LastRun.OutputImage");
                        m_displayControl.m_cbImages.SelectedIndex = 0;
                        openNewImage = true;
                    }
                    image.Dispose();
                }
            }
            openFileDialog.Dispose();
        }

        private void m_BtnAddTool_Click(object sender, EventArgs e)
        {
            m_AddToolList.Show(m_BtnAddTool, new Point(0, m_BtnAddTool.Height));
        }

        private void m_RunBtn_Click(object sender, EventArgs e)
        {
            if (m_inputImagesList.Count <= 0)
                return;
            
            m_cntImageIndex++;
            if (m_cntImageIndex == m_inputImagesList.Count)
                m_cntImageIndex = 0;

            foreach (ToolsClass tool in m_toolsList)
            {
                string m_strToolType = tool.TypeFilled.ToString();
                ToolWindow toolWindow = new ToolWindow()
                {
                    Size = new Size(0, 0),
                    FormBorderStyle = FormBorderStyle.FixedToolWindow,
                    WindowState = FormWindowState.Minimized,
                    ShowInTaskbar = false
                };

                if (openNewImage) { tool.m_bitmapList = null; }

                bool newImage = false;
                if (tool.m_bitmapList == null)
                {
                    tool.m_bitmapList = m_inputImagesList.Select(x => new Dictionary<string, Bitmap> { { "Current.InputImage", x } }).ToList();
                    newImage = true;
                }

                switch (m_strToolType) { 
                    case "BlobToolControl":
                        BlobToolControl m_tempBlobControl = tool.BlobToolControl;
                        toolWindow.splitContainer1.Panel1.Controls.Add(m_tempBlobControl);
                        toolWindow.m_roi = m_tempBlobControl.m_roi;
                        if (m_tempBlobControl.m_bitmapList != null || !newImage)
                            tool.m_bitmapList = m_tempBlobControl.m_bitmapList;
                        else
                            m_tempBlobControl.m_bitmapList = tool.m_bitmapList;
                        toolWindow.Text = m_tempBlobControl.Name;
                        break;
                    case "CaliperToolControl":
                        CaliperToolControl m_tempCaliperControl = tool.CaliperToolControl;
                        toolWindow.splitContainer1.Panel1.Controls.Add(m_tempCaliperControl);
                        toolWindow.m_roi = m_tempCaliperControl.m_roi;
                        if (m_tempCaliperControl.m_bitmapList != null || !newImage)
                            tool.m_bitmapList = m_tempCaliperControl.m_bitmapList;
                        else
                            m_tempCaliperControl.m_bitmapList = tool.m_bitmapList;
                        toolWindow.Text = m_tempCaliperControl.Name;
                        break;
                    case "HistogramToolControl":
                        HistogramToolControl m_tempHistControl = tool.HistogramToolControl;
                        toolWindow.splitContainer1.Panel1.Controls.Add(m_tempHistControl);
                        toolWindow.m_roi = m_tempHistControl.m_roi;
                        if (m_tempHistControl.m_bitmapList != null || !newImage)
                            tool.m_bitmapList = m_tempHistControl.m_bitmapList;
                        else
                            m_tempHistControl.m_bitmapList = tool.m_bitmapList;
                        toolWindow.Text = m_tempHistControl.Name;
                        break;
                    default:
                        MessageBox.Show("Error");
                        break;
                }
                toolWindow.m_displayControl.m_bitmapList = tool.m_bitmapList;

                toolWindow.Show(); 
                toolWindow.m_RunToolBtn.PerformClick();
                System.Threading.Thread.Sleep(1);
                toolWindow.Close();
                toolWindow.Dispose();
            }
            openNewImage = false;
            m_displayControl.m_display.Image = m_displayControl.m_bitmapList[m_cntImageIndex][m_displayControl.m_cbImages.SelectedItem.ToString()];
        }

        private void blobToolMenuItem_Click(object sender, EventArgs e)
        {
            m_treeViewTools.Nodes.Add("CogBlobTool" + (++m_intCntBlob).ToString());
            BlobToolControl blobTool = new BlobToolControl
            {
                Dock = DockStyle.Fill,
                Name = "CogBlobTool" + (m_intCntBlob)
            };
            m_toolsList.Add(new ToolsClass(blobTool));
        }

        private void caliperToolMenuItem_Click(object sender, EventArgs e)
        {
            m_treeViewTools.Nodes.Add("CogCaliperTool" + (++m_intCntCaliper).ToString());
            CaliperToolControl caliperTool = new CaliperToolControl
            {
                Dock = DockStyle.Fill,
                Name = "CogCaliperTool" + (m_intCntCaliper)
            };
            m_toolsList.Add(new ToolsClass(caliperTool));
        }

        private void histogramToolMenuItem_Click(object sender, EventArgs e)
        {
            m_treeViewTools.Nodes.Add("CogHistogramTool" + (++m_intCntHistogram).ToString());
            HistogramToolControl histogramTool = new HistogramToolControl
            {
                Dock = DockStyle.Fill,
                Name = "CogHistogramTool" + (m_intCntHistogram)
            };
            m_toolsList.Add(new ToolsClass(histogramTool));
        }

        private void m_treeViewTools_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {   
            if(e.Button == MouseButtons.Right) {
                TreeView m_treeView = (TreeView)sender;
                DialogResult m_deleteSelection = MessageBox.Show("Are u sure want to delete "+ m_treeView.SelectedNode.Text+"?","",MessageBoxButtons.YesNo);
                if (m_deleteSelection == DialogResult.Yes)
                {
                    m_toolsList[m_treeView.SelectedNode.Index].Dispose();
                    m_toolsList.RemoveAt(m_treeView.SelectedNode.Index);
                    m_treeView.Nodes.Remove(m_treeView.SelectedNode);
                }
            }
        }

        private void m_treeViewTools_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                TreeView m_treeView = (TreeView)sender;
                if (m_treeView == null)
                    return;
                ToolWindow toolWindow = new ToolWindow
                {
                    Text = m_treeView.SelectedNode.Text
                };
                ToolsClass tool = m_toolsList[m_treeView.SelectedNode.Index];
                if (openNewImage) { tool.m_bitmapList = null; openNewImage = false; }

                bool newImage = false;
                if (tool.m_bitmapList == null || tool.m_bitmapList.Count == 0)
                {
                    tool.m_bitmapList = m_inputImagesList.Select(x => new Dictionary<string, Bitmap> { { "Current.InputImage", x } }).ToList();
                    newImage = true;
                }

                string m_strToolType = tool.TypeFilled.ToString();
                switch (m_strToolType)
                {
                    case "BlobToolControl":
                        BlobToolControl m_tempBlobControl = tool.BlobToolControl;
                        toolWindow.splitContainer1.Panel1.Controls.Add(m_tempBlobControl);
                        toolWindow.m_roi = m_tempBlobControl.m_roi;
                        if (m_tempBlobControl.m_bitmapList != null || !newImage)
                            tool.m_bitmapList = m_tempBlobControl.m_bitmapList;
                        else
                            m_tempBlobControl.m_bitmapList = tool.m_bitmapList;
                        break;
                    case "CaliperToolControl":
                        CaliperToolControl m_tempCaliperControl = tool.CaliperToolControl;
                        toolWindow.splitContainer1.Panel1.Controls.Add(m_tempCaliperControl);
                        toolWindow.m_roi = m_tempCaliperControl.m_roi;
                        if (m_tempCaliperControl.m_bitmapList != null || !newImage)
                            tool.m_bitmapList = m_tempCaliperControl.m_bitmapList;
                        else
                            m_tempCaliperControl.m_bitmapList = tool.m_bitmapList;
                        break;
                    case "HistogramToolControl":
                        HistogramToolControl m_tempHistControl = tool.HistogramToolControl;
                        toolWindow.splitContainer1.Panel1.Controls.Add(m_tempHistControl);
                        toolWindow.m_roi = m_tempHistControl.m_roi;
                        if (m_tempHistControl.m_bitmapList != null || !newImage)
                            tool.m_bitmapList = m_tempHistControl.m_bitmapList;
                        else
                            m_tempHistControl.m_bitmapList = tool.m_bitmapList;
                        break;
                    default:
                        MessageBox.Show("Error");
                        break;
                }

                toolWindow.m_displayControl.m_bitmapList = tool.m_bitmapList;

                toolWindow.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        
        private void m_RunBtnContinuous_MouseClick(object sender, MouseEventArgs e)
        {
            if (!runContinue)
            {
                // Start continuous clicking of m_RunBtnContinuous when m_RunBtn is clicked for the first time.
                runContinue = true;
                m_OpenBtn.Enabled = false;
                m_BtnAddTool.Enabled = false;
                m_treeViewTools.Enabled = false;
                m_timer.Start();
            }
            else
            {
                // Stop continuous clicking of m_RunBtnContinuous when m_RunBtn is clicked for the second time.
                runContinue = false;
                m_timer.Stop();
                m_OpenBtn.Enabled = true;
                m_BtnAddTool.Enabled = true;
                m_treeViewTools.Enabled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // When the Timer ticks, simulate a click on Button
            m_RunBtn.PerformClick();
        }

        /*
        private void ROI_Paint(object sender, PaintEventArgs e)
        {
            if (m_display.Controls.Count <= 0)
                return;
            e.Graphics.ExcludeClip(m_display.Controls[0].Bounds);
            using (var b = new SolidBrush(Color.FromArgb(100, Color.Black)))
                e.Graphics.FillRectangle(b, m_display.ClientRectangle);

        }*/
    }
}
