using Emgu.CV;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading.Tasks;
using Emgu.CV.CvEnum;
using System.ComponentModel;
using System.Collections.Generic;
using System.Management;

namespace OpenCV_Vision_Pro
{
    public partial class Form1 : Form
    {
        private static DisplayControl m_displayControl;
        public static AutoDisposeDict<string,Mat> m_bitmapList {  get { return m_displayControl.m_bitmapList; } private set { m_displayControl.m_bitmapList = value; } }
        public static BindingList<string> m_form1DisplaySelection { get; private set; }

        public static AutoDisposeList<Mat> m_inputImagesList;
        private AutoDisposeList<IToolBase> m_toolsList;
        private static int m_cntImageIndex = 0;
        private int m_intCntBlob = 0;
        private int m_intCntCaliper = 0;
        private int m_intCntHistogram = 0;
        private Timer m_timer;

        private VideoCapture videoCapture;
        private bool processing = false; // Flag to avoid processing multiple frames simultaneously
        private bool resizedOnce = false;
        private double fps;

        private static bool checkContinue = false;
        public static bool runContinue
        {
            get { return checkContinue; }
            set { 
                checkContinue = value;
                ToolWindow.runContinue = value;
            }
        }
        
        private static bool m_boolNextImage = false;
        public static bool nextImage
        {
            get { return m_boolNextImage; }
            set
            {
                m_boolNextImage = value;
                ToolWindow.nextImage = value;
            }
        }

        private void GetAllConnectedCameras()
        {
            var cameraNames = new List<string>();
            using (var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE (PNPClass = 'Image' OR PNPClass = 'Camera')"))
            {
                foreach (var device in searcher.Get())
                {
                    var item = openCameraToolStripMenuItem.DropDownItems.Add((device["Caption"].ToString()));
                    item.Click += openCamera_Click;
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
            m_displayControl = new DisplayControl()
            {
                Dock = DockStyle.Fill,
                m_DisplaySelection = new BindingList<string>()
            };
            splitContainer1.Panel2.Controls.Add(m_displayControl);
            m_form1DisplaySelection = m_displayControl.m_DisplaySelection;
            BindingSource m_bindingSource = new BindingSource();
            m_bindingSource.DataSource = m_form1DisplaySelection;
            m_displayControl.m_cbImages.DataSource = m_bindingSource;
            m_toolsList = new AutoDisposeList<IToolBase>();
            GetAllConnectedCameras();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            videoCapture?.Stop();
            videoCapture?.Dispose();
            Application.Idle -= ProcessFrame;
            if (runContinue)
            {
                runContinue = false;
                m_timer.Stop();
                m_timer.Dispose();
            }
            base.OnFormClosing(e);
        }

        private void m_OpenBtn_Click(object sender, EventArgs e)
        {
            m_GetInputImageMenu.Show(m_OpenBtn, new Point(0, m_OpenBtn.Height));
        }

        private void openImageFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "All File (*.*) | *.*";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        if (videoCapture != null)
                        {
                            Application.Idle -= ProcessFrame;
                            videoCapture.Stop();
                            videoCapture.Dispose();
                            videoCapture = null;
                            m_displayControl.m_playPauseButton.Parent.Visible = false;
                            m_displayControl.m_playPauseButton.Click -= PlayPauseClick;
                        }
                        m_form1DisplaySelection.Clear();
                        m_bitmapList?.Dispose();
                        using (Image image = Image.FromFile(openFileDialog.FileName))
                        {
                            if (image != null)
                            {
                                m_cntImageIndex = 0;
                                int numberOfPages = image.GetFrameCount(FrameDimension.Page);

                                m_inputImagesList = new AutoDisposeList<Mat>();
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
                                            Mat m_mat = new Mat();
                                            CvInvoke.CvtColor(m_image.ToMat(), m_mat, ColorConversion.Bgr2Gray);
                                            m_inputImagesList.Add(m_mat);
                                        }
                                    }
                                }
                                m_bitmapList = new AutoDisposeDict<string, Mat> { { "LastRun.OutputImage", m_inputImagesList[m_cntImageIndex].Clone() } };
                                m_displayControl.m_display.Image = m_bitmapList["LastRun.OutputImage"];
                                m_form1DisplaySelection.Add("LastRun.OutputImage");
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Images Input");
            }
        }

        private async void ProcessFrame(object sender, EventArgs e)
        {
            if (processing) return; 
            processing = true;

            try
            {
                Mat frame = new Mat();
                bool? ret = videoCapture?.Read(frame);
                if (ret != null)
                {
                    if (videoCapture != null && !frame.IsEmpty)
                    {
                        if (!resizedOnce)
                        {
                            double widthScale = (double)m_displayControl.m_display.Width / frame.Width;
                            double heightScale = (double)m_displayControl.m_display.Height / frame.Height;
                            double minScale = Math.Min(widthScale, heightScale);

                            Size newSize = new Size((int)(frame.Width * minScale), (int)(frame.Height * minScale));
                            CvInvoke.Resize(frame, frame, newSize);
                            m_displayControl.m_display.Size = newSize;
                        }

                        CvInvoke.CvtColor(frame, frame, ColorConversion.Bgr2Gray);

                        m_bitmapList?.Dispose();
                        await Task.Run(() =>
                        {
                            if (m_displayControl.m_display.Image != null)
                                m_displayControl.m_display.Image.Dispose();

                            if (m_inputImagesList != null)
                            {
                                m_inputImagesList[0]?.Dispose();
                                m_inputImagesList[0] = frame.Clone();
                            }
                            else
                                m_inputImagesList = new AutoDisposeList<Mat> { frame.Clone() };
                            m_bitmapList = new AutoDisposeDict<string, Mat> { { "LastRun.OutputImage", m_inputImagesList[0].Clone() } };
                        });

                        if (!runContinue)
                            m_displayControl.m_display.Image = null;
                        if (String.Compare(m_displayControl.m_cbImages.SelectedItem.ToString(), "LastRun.OutputImage") == 0)
                            m_displayControl.m_display.Image = m_bitmapList[m_displayControl.m_cbImages.SelectedItem.ToString()];
                        if (m_displayControl.m_playPauseButton.Visible)
                            m_displayControl.m_trackBarVideoDuration.Value++;

                        frame.Dispose();
                        System.Threading.Thread.Sleep((int)(1 / fps * 1000));
                    }
                    else if(videoCapture != null && frame.IsEmpty)
                    {
                        videoCapture.Set(CapProp.PosFrames, 0); 
                        m_displayControl.m_trackBarVideoDuration.Value = 0;
                    }
                }
                
            }
            finally
            {
                processing = false;
            }
        }

        private void openCamera_Click(object sender, EventArgs e)
        {
            m_bitmapList?.Dispose();
            m_inputImagesList?.Dispose();
            m_form1DisplaySelection.Clear();
            videoCapture?.Stop();
            videoCapture?.Dispose();

            ToolStripMenuItem itemSelection = (ToolStripMenuItem)sender;
            videoCapture = new VideoCapture(openCameraToolStripMenuItem.DropDownItems.IndexOf(itemSelection));
            fps = videoCapture.Get(CapProp.Fps);

            resizedOnce = false;
            processing = false;
            m_displayControl.m_VideoCapture = videoCapture;
            m_form1DisplaySelection.Add("LastRun.OutputImage");
            Application.Idle += ProcessFrame;
            m_displayControl.m_playPauseButton.Parent.Visible = false;
            m_displayControl.m_playPauseButton.Click -= PlayPauseClick;
        }

        private void openVideoFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Video File (*.mp4) | *.mp4";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        m_displayControl.m_playPauseButton.Parent.Visible = false;
                        m_displayControl.m_playPauseButton.Click -= PlayPauseClick;
                        m_bitmapList?.Dispose();
                        m_inputImagesList?.Dispose();

                        resizedOnce = false;
                        processing = false;
                        m_form1DisplaySelection.Clear();
                        m_form1DisplaySelection.Add("LastRun.OutputImage");

                        videoCapture?.Stop();
                        videoCapture?.Dispose();
                        videoCapture = new VideoCapture(openFileDialog.FileName);
                        m_displayControl.m_VideoCapture = videoCapture;
                        double totalFrame = videoCapture.Get(CapProp.FrameCount);
                        fps = videoCapture.Get(CapProp.Fps);
                        m_displayControl.m_trackBarVideoDuration.Maximum = (int)totalFrame;

                        Application.Idle += ProcessFrame;
                        m_displayControl.m_playPauseButton.Parent.Visible = true;
                        m_displayControl.m_playPauseButton.Click += PlayPauseClick;
                        m_displayControl.m_trackBarVideoDuration.Value = 0;
                    }
                }
            }
            catch(Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void PlayPauseClick(object sender, EventArgs e)
        {
            if(videoCapture != null)
            {
                m_displayControl.playing = !m_displayControl.playing;

                if (m_displayControl.playing)
                    Application.Idle += ProcessFrame;
                else
                    Application.Idle -= ProcessFrame;
            }
        }

        private void m_BtnAddTool_Click(object sender, EventArgs e)
        {
            m_AddToolList.Show(m_BtnAddTool, new Point(0, m_BtnAddTool.Height));
        }

        private void m_RunBtn_Click(object sender, EventArgs e)
        {
            // Return if no input
            if (m_inputImagesList == null && videoCapture == null)
            {
                runContinue = false;
                m_timer?.Stop();
                m_OpenBtn.Enabled = true;
                m_BtnAddTool.Enabled = true;
                m_treeViewTools.Enabled = true;
                MessageBox.Show("No Input Image");
                return;
            }

            if (m_inputImagesList == null)
                return;

            // Return if no input
            if (m_inputImagesList.Count <= 0)
                return;
            
            // Update input image index
            m_cntImageIndex++;
            if (m_cntImageIndex == m_inputImagesList.Count)
                m_cntImageIndex = 0;
           
            m_bitmapList?.Dispose();
            m_bitmapList = new AutoDisposeDict<string, Mat> { { "LastRun.OutputImage", m_inputImagesList[m_cntImageIndex].Clone() } };

            // Continuously run all the tool
            foreach (IToolBase tool in m_toolsList)
            {
                tool.m_bitmapList?.Dispose();
                tool.m_bitmapList = new AutoDisposeDict<string, Mat> { { "Current.InputImage", m_inputImagesList[m_cntImageIndex].Clone() } };
                if (!tool.m_DisplaySelection.Contains("Current.InputImage"))
                    tool.m_DisplaySelection.Add("Current.InputImage");
                nextImage = true;
                Rectangle m_rectangle;
                if (tool.m_rectROI == null || !tool.parameter.m_boolHasROI)
                    m_rectangle = new Rectangle();
                else
                    m_rectangle = tool.m_rectROI;

                tool.Run(tool.m_bitmapList["Current.InputImage"], m_rectangle);
                tool.showResultImages();
            }

            // Update the display image according to the combo box selection
            m_displayControl.m_display.Image = m_bitmapList[m_displayControl.m_cbImages.SelectedItem.ToString()];
        }

        private void blobToolMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode m_treeNode = new TreeNode("BlobTool" + (++m_intCntBlob).ToString())
            {
                ImageIndex = 0,
                SelectedImageIndex = 0
            };
            m_treeViewTools.Nodes.Add(m_treeNode);
            BlobTool blobTool = new BlobTool("BlobTool" + (m_intCntBlob).ToString());
            m_toolsList.Add(blobTool);
        }

        private void caliperToolMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode m_treeNode = new TreeNode("CaliperTool" + (++m_intCntCaliper).ToString())
            {
                ImageIndex = 1,
                SelectedImageIndex = 1
            };
            m_treeViewTools.Nodes.Add(m_treeNode);
            CaliperTool caliperTool = new CaliperTool("CaliperTool" + (m_intCntCaliper).ToString());
            m_toolsList.Add(caliperTool);
        }

        private void histogramToolMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode m_treeNode = new TreeNode("HistogramTool" + (++m_intCntHistogram).ToString())
            {
                ImageIndex = 2,
                SelectedImageIndex = 2
            };
            m_treeViewTools.Nodes.Add(m_treeNode);
            HistogramTool histogramTool = new HistogramTool("HistogramTool" + (m_intCntHistogram).ToString());
            m_toolsList.Add(histogramTool);
        }

        private void m_treeViewTools_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {   
            if(e.Button == MouseButtons.Right) {
                TreeView m_treeView = (TreeView)sender;
                if (m_treeView == null)
                    return;
                if(m_treeView.SelectedNode == null)
                    return;
                DialogResult m_deleteSelection = MessageBox.Show("Are u sure want to delete "+ m_treeView.SelectedNode.Text+"?","",MessageBoxButtons.YesNo);
                if (m_deleteSelection == DialogResult.Yes)
                {
                    TreeNode node = m_treeView.SelectedNode;
                    string toolNode = node.Text;
                    if (m_form1DisplaySelection.Any<string>(x => ((String)x).Contains(toolNode)))
                        m_form1DisplaySelection.Remove(m_form1DisplaySelection.First<string>(x => ((String)x).Contains(toolNode)));
                    m_toolsList[node.Index].m_bitmapList?.Dispose();
                    m_toolsList[node.Index].Dispose();
                    m_toolsList.RemoveAt(node.Index);
                    m_treeView.Nodes.Remove(node);
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
                if (m_treeView.SelectedNode == null)
                    return;
                IToolBase tool = m_toolsList[m_treeView.SelectedNode.Index];

                if (m_bitmapList != null)
                {
                    if (tool.m_bitmapList == null)
                    {
                        tool.m_DisplaySelection.Clear();
                        tool.m_bitmapList = new AutoDisposeDict<string, Mat> { { "Current.InputImage", m_inputImagesList[m_cntImageIndex].Clone() } };
                        tool.m_DisplaySelection.Add("Current.InputImage");
                    }
                    else
                    {
                        tool.m_bitmapList["Current.InputImage"]?.Dispose();
                        tool.m_bitmapList["Current.InputImage"] = m_inputImagesList[m_cntImageIndex].Clone();
                    }
                }

                ToolWindow fc = Application.OpenForms[tool.ToolName] as ToolWindow;
                fc?.Close();
                fc?.Dispose();

                ToolWindow toolWindow = new ToolWindow(tool)
                {
                    Text = m_treeView.SelectedNode.Text,
                    Name = tool.ToolName
                };

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
                m_timer = new Timer();
                m_timer.Tick += timer1_Tick;
                runContinue = true;
                m_timer.Start();
                m_OpenBtn.Enabled = false;
                m_BtnAddTool.Enabled = false;
            }
            else
            {
                // Stop continuous clicking of m_RunBtnContinuous when m_RunBtn is clicked for the second time.
                runContinue = false;
                m_timer.Stop();
                m_timer.Dispose();
                m_OpenBtn.Enabled = true;
                m_BtnAddTool.Enabled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // When the Timer ticks, simulate a click on Button
            m_RunBtn.PerformClick();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                m_displayControl.m_playPauseButton.PerformClick();
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
