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
using OpenCV_Vision_Pro.LineSegment;
using OpenCV_Vision_Pro.Tools.ColorMatcher;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace OpenCV_Vision_Pro
{
    public partial class Form1 : Form
    {
        private static DisplayControl m_displayControl;
        public static AutoDisposeDict<string, Mat> m_bitmapList { get { return m_displayControl.m_bitmapList; } private set { m_displayControl.m_bitmapList = value; } }
        public static BindingList<string> m_form1DisplaySelection { get; private set; }

        private string[] files;
        private static int m_cntFileIndex = 0;
        private static int[] m_cntImageIndices;
        private static int m_cntImageIndex;

        private Dictionary<string, int> m_dictToolCount = new Dictionary<string, int> {
            {"m_intCntBlob",0},
            {"m_intCntCaliper",0},
            {"m_intCntHistogram",0},
            {"m_intCntConvert",0},
            {"m_intCntSegmentor",0},
            {"m_intCntMatcher",0},
            {"m_intCntExtractor",0},
            {"m_intCntFindLine",0 }
        };

        private Timer m_timer;

        private VideoCapture videoCapture;
        private bool processing = false; // Flag to avoid processing multiple frames simultaneously
        private bool resizedOnce = false;
        private double fps;

        private static bool checkContinue = false;
        public static bool runContinue
        {
            get { return checkContinue; }
            set
            {
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
                searcher.Dispose();
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
            BindingSource m_bindingSource = new BindingSource
            {
                DataSource = m_form1DisplaySelection
            };
            m_displayControl.m_cbImages.DataSource = m_bindingSource;
            m_treeViewTools.ItemDrag += m_treeViewTools_ItemDrag;
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
                bool isFolder = false;
                using (CommonOpenFileDialog openFileDialog = new CommonOpenFileDialog())
                {
                    if (String.Compare(((ToolStripMenuItem)sender).Name, "openFolderToolStripMenuItem") == 0)
                    {
                        openFileDialog.IsFolderPicker = true;
                        isFolder = true;
                    }

                    if (openFileDialog.ShowDialog() == CommonFileDialogResult.Ok)
                    {
                        if (videoCapture != null)
                        {
                            Application.Idle -= ProcessFrame;
                            videoCapture.Stop();
                            videoCapture.Dispose();
                            videoCapture = null;
                            m_displayControl.m_VideoCapture = null;
                            m_displayControl.m_playPauseButton.Parent.Visible = false;
                            m_displayControl.m_playPauseButton.Click -= PlayPauseClick;
                        }
                        m_bitmapList?.Dispose();
                        m_bitmapList = null;

                        if (isFolder)
                            files = Directory.GetFiles(openFileDialog.FileName);
                        else
                            files = new string[] { openFileDialog.FileName };

                        m_cntFileIndex = 0; m_cntImageIndex = 0;
                        m_cntImageIndices = new int[files.Length];
                        m_displayControl.m_display.Width = splitContainer1.Panel2.Width - 20; m_displayControl.m_display.Height = splitContainer1.Panel2.Height - 20;
                        m_form1DisplaySelection.Clear();
                        m_form1DisplaySelection.Add("LastRun.OutputImage");

                        for (int i = 0; i < files.Length; i++)
                        {
                            FileStream fileStream = new FileStream(files[i], FileMode.Open, FileAccess.Read);
                            using (Image image = Image.FromStream(fileStream, true, false))
                            {
                                if (image != null)
                                {
                                    m_cntImageIndices[i] = image.GetFrameCount(FrameDimension.Page);
                                }
                            }
                        }
                        OpenImages(files, m_cntFileIndex, m_cntImageIndex);
                    }
                    openFileDialog.Dispose();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Input Images");
            }

        }

        private Mat OpenImages(string[] files, int fileIndex, int imageIndex)
        {
            try
            {
                FileStream fileStream = new FileStream(files[fileIndex], FileMode.Open, FileAccess.Read);
                using (Image image = Image.FromStream(fileStream, true, false))
                {
                    if (image != null)
                    {

                        image.SelectActiveFrame(FrameDimension.Page, imageIndex); // Switch to the current page
                        using (MemoryStream memStream = new MemoryStream())
                        {
                            if (Path.GetExtension(files[fileIndex]) == ".png")
                                image.Save(memStream, ImageFormat.Png);
                            else
                                image.Save(memStream, ImageFormat.Bmp);
                            using (Bitmap m_image = (Bitmap)Bitmap.FromStream(memStream))
                            {
                                Mat tempMat = m_image.ToMat();
                                Size newSize = resize(tempMat.Width, tempMat.Height, m_displayControl.m_display.Width, m_displayControl.m_display.Height);
                                CvInvoke.Resize(tempMat, tempMat, newSize);
                                m_displayControl.m_display.Size = newSize;
                                m_bitmapList?.Dispose();
                                m_bitmapList = new AutoDisposeDict<string, Mat> { { "LastRun.OutputImage", tempMat.Clone() } };
                                m_displayControl.m_display.Image?.Dispose();
                                m_displayControl.m_display.Image = m_bitmapList["LastRun.OutputImage"];
                                tempMat.Dispose();
                                m_image.Dispose();
                            }
                            memStream.Dispose();
                        }
                        image.Dispose();
                    }
                    fileStream.Dispose();
                }
                return m_bitmapList["LastRun.OutputImage"].Clone();
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Images Input");
            }
            return new Mat();
        }

        public static Size resize(int oriWidth, int oriHeight, int currWidth, int currHeight)
        {
            double widthScale = (double)currWidth / oriWidth;
            double heightScale = (double)currHeight / oriHeight;
            double minScale = Math.Min(widthScale, heightScale);
            Size newSize = new Size((int)(oriWidth * minScale), (int)(oriHeight * minScale));
            return newSize;
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
                            Size newSize = resize(frame.Width, frame.Height, m_displayControl.m_display.Width, m_displayControl.m_display.Height);
                            CvInvoke.Resize(frame, frame, newSize);
                            m_displayControl.m_display.Size = newSize;
                        }

                        m_bitmapList?.Dispose();
                        await Task.Run(() =>
                        {
                            if (m_displayControl.m_display.Image != null)
                                m_displayControl.m_display.Image.Dispose();

                            m_bitmapList = new AutoDisposeDict<string, Mat> { { "LastRun.OutputImage", frame.Clone() } };
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
                    else if (videoCapture != null && frame.IsEmpty)
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

            m_cntImageIndices = null;
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

                        m_cntImageIndices = null;
                        Application.Idle += ProcessFrame;
                        m_displayControl.m_playPauseButton.Parent.Visible = true;
                        m_displayControl.m_playPauseButton.Click += PlayPauseClick;
                        m_displayControl.m_trackBarVideoDuration.Value = 0;
                    }
                    openFileDialog.Dispose();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void PlayPauseClick(object sender, EventArgs e)
        {
            if (videoCapture != null)
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
            if (files == null && videoCapture == null)
            {
                runContinue = false;
                m_timer?.Stop();
                m_OpenBtn.Enabled = true;
                m_BtnAddTool.Enabled = true;
                MessageBox.Show("1:No Input Image");
                return;
            }

            if (videoCapture != null)
            {

            }
            else if (files == null)
            {
                MessageBox.Show("2:No Input Image");
                return;
            }
            else if (files.Length <= 0)
            {
                MessageBox.Show("3:No Input Image");
                return;
            }
            else
            {
                // Update input image index
                m_cntImageIndex++;
                if (m_cntImageIndex >= m_cntImageIndices[m_cntFileIndex])
                {
                    m_cntFileIndex++;
                    if (m_cntFileIndex >= files.Length)
                        m_cntFileIndex = 0;
                    m_cntImageIndex = 0;
                }
                OpenImages(files, m_cntFileIndex, m_cntImageIndex);
            }
            ProcessTree(m_treeViewTools.Nodes);

            // Update the display image according to the combo box selection
            m_displayControl.m_display.Image = m_bitmapList[m_displayControl.m_cbImages.SelectedItem.ToString()];
        }

        private void ProcessGroup(ToolsTreeNode node, Mat inputImage)
        {
            if (node == null)
                return;

            // Perform operations on the current node (e.g., display or process node data)
            node.tool.m_bitmapList?.Dispose();
            if (inputImage == null)
                node.tool.m_bitmapList = new AutoDisposeDict<string, Mat> { { "Current.InputImage", m_bitmapList["LastRun.OutputImage"].Clone() } };
            else
                node.tool.m_bitmapList = new AutoDisposeDict<string, Mat> { { "Current.InputImage", inputImage.Clone() } };

            if (!node.tool.m_DisplaySelection.Contains("Current.InputImage"))
                node.tool.m_DisplaySelection.Add("Current.InputImage");
            nextImage = true;
            Rectangle m_rectangle;
            if (node.tool.m_rectROI == null || !node.tool.parameter.m_boolHasROI)
                m_rectangle = new Rectangle();
            else
                m_rectangle = node.tool.m_rectROI;

            node.tool.Run(node.tool.m_bitmapList["Current.InputImage"], m_rectangle);
            node.tool.showResultImages();

            foreach (ToolsTreeNode childNode in node.Nodes)
                ProcessGroup(childNode, node.tool.toolResult.resultImage); // Recursively process child nodes
        }

        private void ProcessTree(TreeNodeCollection rootNodes)
        {
            foreach (TreeNode node in rootNodes)
                ProcessGroup((ToolsTreeNode)node, null);
        }

        private void blobToolMenuItem_Click(object sender, EventArgs e)
        {
            BlobTool blobTool = new BlobTool("BlobTool" + (++m_dictToolCount["m_intCntBlob"]).ToString());
            ToolsTreeNode m_treeNode = new ToolsTreeNode(blobTool)
            {
                Name = blobTool.ToolName,
                Text = blobTool.ToolName,
                ImageIndex = 0,
                SelectedImageIndex = 0
            };
            m_treeViewTools.Nodes.Add(m_treeNode);
        }

        private void caliperToolMenuItem_Click(object sender, EventArgs e)
        {
            CaliperTool caliperTool = new CaliperTool("CaliperTool" + (++m_dictToolCount["m_intCntCaliper"]).ToString());
            ToolsTreeNode m_treeNode = new ToolsTreeNode(caliperTool)
            {
                Name = caliperTool.ToolName,
                Text = caliperTool.ToolName,
                ImageIndex = 1,
                SelectedImageIndex = 1
            };
            m_treeViewTools.Nodes.Add(m_treeNode);
        }

        private void histogramToolMenuItem_Click(object sender, EventArgs e)
        {
            HistogramTool histogramTool = new HistogramTool("HistogramTool" + (++m_dictToolCount["m_intCntHistogram"]).ToString());
            ToolsTreeNode m_treeNode = new ToolsTreeNode(histogramTool)
            {
                Name = histogramTool.ToolName,
                Text = histogramTool.ToolName,
                ImageIndex = 2,
                SelectedImageIndex = 2
            };
            m_treeViewTools.Nodes.Add(m_treeNode);
        }

        private void imageConvertToolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageConvertTool imageConvertTool = new ImageConvertTool("ImageConvertTool" + (++m_dictToolCount["m_intCntConvert"]).ToString());
            ToolsTreeNode m_treeNode = new ToolsTreeNode(imageConvertTool)
            {
                Name = imageConvertTool.ToolName,
                Text = imageConvertTool.ToolName,
                ImageIndex = 3,
                SelectedImageIndex = 3
            };
            m_treeViewTools.Nodes.Add(m_treeNode);
        }

        private void colorSegmentorToolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorSegmentorTool colorSegmentorTool = new ColorSegmentorTool("ColorSegmentorTool" + (++m_dictToolCount["m_intCntSegmentor"]).ToString());
            ToolsTreeNode m_treeNode = new ToolsTreeNode(colorSegmentorTool)
            {
                Name = colorSegmentorTool.ToolName,
                Text = colorSegmentorTool.ToolName,
                ImageIndex = 4,
                SelectedImageIndex = 4
            };
            m_treeViewTools.Nodes.Add(m_treeNode);
        }

        private void colorMatchToolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorMatcherTool colorMatcherTool = new ColorMatcherTool("ColorMatcherTool" + (++m_dictToolCount["m_intCntMatcher"]).ToString());
            ToolsTreeNode m_treeNode = new ToolsTreeNode(colorMatcherTool)
            {
                Name = colorMatcherTool.ToolName,
                Text = colorMatcherTool.ToolName,
                ImageIndex = 5,
                SelectedImageIndex = 5
            };
            m_treeViewTools.Nodes.Add(m_treeNode);
        }

        private void colorExtractorToolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorExtractorTool colorExtractorTool = new ColorExtractorTool("ColorExtractorTool" + (++m_dictToolCount["m_intCntExtractor"]).ToString());
            ToolsTreeNode m_treeNode = new ToolsTreeNode(colorExtractorTool)
            {
                Name = colorExtractorTool.ToolName,
                Text = colorExtractorTool.ToolName,
                ImageIndex = 6,
                SelectedImageIndex = 6
            };
            m_treeViewTools.Nodes.Add(m_treeNode);
        }

        private void m_treeViewTools_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeView m_treeView = (TreeView)sender;
                if (m_treeView == null)
                    return;
                if (m_treeView.SelectedNode == null)
                    return;
                DialogResult m_deleteSelection = MessageBox.Show("Are u sure want to delete " + m_treeView.SelectedNode.Text + "?", "", MessageBoxButtons.YesNo);
                if (m_deleteSelection == DialogResult.Yes)
                {
                    ToolsTreeNode node = (ToolsTreeNode)m_treeView.SelectedNode;
                    string toolNode = node.Text;
                    if (m_form1DisplaySelection.Any<string>(x => ((String)x).Contains(toolNode)))
                        m_form1DisplaySelection.Remove(m_form1DisplaySelection.First<string>(x => ((String)x).Contains(toolNode)));
                    node.tool.m_bitmapList?.Dispose();
                    node?.Dispose();
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

                ToolsTreeNode selectedNode = ((ToolsTreeNode)m_treeView.SelectedNode);
                IToolBase tool = selectedNode.tool;
                if (selectedNode.Parent == null && m_bitmapList != null)
                {
                    if (tool.m_bitmapList == null)
                    {
                        tool.m_DisplaySelection.Clear();
                        tool.m_bitmapList = new AutoDisposeDict<string, Mat> { { "Current.InputImage", m_bitmapList["LastRun.OutputImage"].Clone() } };
                        tool.m_DisplaySelection.Add("Current.InputImage");
                    }
                    else
                    {
                        tool.m_bitmapList["Current.InputImage"]?.Dispose();
                        tool.m_bitmapList["Current.InputImage"] = m_bitmapList["LastRun.OutputImage"].Clone();
                    }
                }
                else if (selectedNode.Parent != null && m_bitmapList != null)
                {
                    if (((ToolsTreeNode)selectedNode.Parent).tool.m_bitmapList != null && ((ToolsTreeNode)selectedNode.Parent).tool.toolResult != null)
                    {
                        if (tool.m_bitmapList == null)
                        {
                            tool.m_DisplaySelection.Clear();
                            tool.m_bitmapList = new AutoDisposeDict<string, Mat> { { "Current.InputImage", ((ToolsTreeNode)selectedNode.Parent).tool.toolResult.resultImage?.Clone() } };
                            tool.m_DisplaySelection.Add("Current.InputImage");
                        }
                        else
                        {
                            tool.m_bitmapList["Current.InputImage"]?.Dispose();
                            tool.m_bitmapList["Current.InputImage"] = ((ToolsTreeNode)selectedNode.Parent).tool.toolResult.resultImage?.Clone();
                        }
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

        private void m_treeViewTools_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DoDragDrop(e.Item, DragDropEffects.Move);
            }
        }

        private void m_treeViewTools_DragEnter(object sender, DragEventArgs e)
        {
            Point targetPoint = m_treeViewTools.PointToClient(new Point(e.X, e.Y));
            TreeNode targetNode = m_treeViewTools.GetNodeAt(targetPoint);
            if (targetNode == null)
                e.Effect = e.AllowedEffect;
            else if (targetNode.Text.StartsWith("Image") || targetNode.Text.StartsWith("ColorSegmentor"))
                e.Effect = DragDropEffects.None;
            else
                e.Effect = e.AllowedEffect;
        }

        private void m_treeViewTools_DragOver(object sender, DragEventArgs e)
        {
            // Retrieve the client coordinates of the mouse position.
            Point targetPoint = m_treeViewTools.PointToClient(new Point(e.X, e.Y));

            // Select the node at the mouse position.
            m_treeViewTools.SelectedNode = m_treeViewTools.GetNodeAt(targetPoint);

            if (m_treeViewTools.SelectedNode == null)
                e.Effect = e.AllowedEffect;
            else if (!m_treeViewTools.SelectedNode.Text.StartsWith("Image") && !m_treeViewTools.SelectedNode.Text.StartsWith("ColorSegmentor"))
                e.Effect = DragDropEffects.None;
            else
                e.Effect = e.AllowedEffect;
        }

        private void m_treeViewTools_DragDrop(object sender, DragEventArgs e)
        {
            // Retrieve the client coordinates of the drop location.
            Point targetPoint = m_treeViewTools.PointToClient(new Point(e.X, e.Y));

            // Retrieve the node at the drop location.
            TreeNode targetNode = m_treeViewTools.GetNodeAt(targetPoint);

            // Retrieve the node that was dragged.
            TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(ToolsTreeNode));

            // Confirm that the node at the drop location is not 
            // the dragged node or a descendant of the dragged node.
            if (!draggedNode.Equals(targetNode) && !ContainsNode(draggedNode, targetNode))
            {
                // If it is a move operation, remove the node from its current 
                // location and add it to the node at the drop location.
                if (e.Effect == DragDropEffects.Move)
                {
                    draggedNode.Remove();
                    if (targetNode == null)
                        m_treeViewTools.Nodes.Add(draggedNode);
                    else
                    {
                        targetNode.Nodes.Add(draggedNode);
                        // Expand the node at the location 
                        // to show the dropped node.
                        targetNode.Expand();
                    }
                }
            }
        }

        // Determine whether one node is a parent 
        // or ancestor of a second node.
        private bool ContainsNode(TreeNode node1, TreeNode node2)
        {
            if (node2 == null) return false;
            // Check the parent node of the second node.
            if (node2.Parent == null) return false;
            if (node2.Parent.Equals(node1)) return true;

            // If the parent node is not null or equal to the first node, 
            // call the ContainsNode method recursively using the parent of 
            // the second node.
            return ContainsNode(node1, node2.Parent);
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

        private void yOLOv7ObjectDetectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            yolov7ObjectDetection yolo = new yolov7ObjectDetection();
            ToolsTreeNode m_treeNode = new ToolsTreeNode(yolo)
            {
                ImageIndex = 6,
                SelectedImageIndex = 6
            };
            m_treeViewTools.Nodes.Add(m_treeNode);
            yolo.loadModel();
        }

        private void findLineToolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LineSegmentTool lineSegmentTool = new LineSegmentTool("LineSegmentTool" + (++m_dictToolCount["m_intCntFindLine"]).ToString());
            ToolsTreeNode m_treeNode = new ToolsTreeNode(lineSegmentTool)
            {
                Name = lineSegmentTool.ToolName,
                Text = lineSegmentTool.ToolName,
                ImageIndex = 6,
                SelectedImageIndex = 6
            };
            m_treeViewTools.Nodes.Add(m_treeNode);
        }
    }
}
