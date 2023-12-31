﻿using Emgu.CV;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Linq;
using Emgu.CV.CvEnum;
using System.ComponentModel;
using OpenCV_Vision_Pro.LineSegment;
using OpenCV_Vision_Pro.Tools.ColorMatcher;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Threading;
using Timer = System.Windows.Forms.Timer;
using OpenCV_Vision_Pro.Tools.PolarUnWrap;
using OpenCV_Vision_Pro.Tools.ID;
using OpenCV_Vision_Pro.Tools.ImageProcess.ProcessTool;
using System.Diagnostics;
using OpenCV_Vision_Pro.Tools.ImageStacking;
using OpenCV_Vision_Pro.Tools.ImageStitching;
using OpenCV_Vision_Pro.Tools.ImageBlending;

namespace OpenCV_Vision_Pro
{
    partial class Form1 : Form
    {
        Process process;
        private static DisplayControl m_displayControl;
        public static AutoDisposeDict<string, Mat> m_bitmapList { get { return m_displayControl.m_bitmapList; }  set { m_displayControl.m_bitmapList = value; } }
        public static BindingList<string> m_form1DisplaySelection { get; private set; }
        

        public static string[] files;
        public static int m_cntFileIndex = 0;
        public static int[] m_cntImageIndices;
        public static int m_cntImageIndex;

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
            m_treeViewTools.ImageList = HelperClass.iconList;
            m_treeViewTools.ItemDrag += m_treeViewTools_ItemDrag;
            HelperClass.GetAllConnectedCameras(openCameraToolStripMenuItem, openCamera_Click);
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
                        m_displayControl.m_display.Width = splitContainer1.Panel2.Width - 50; m_displayControl.m_display.Height = splitContainer1.Panel2.Height - 50;
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
                                image.Dispose();
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
                                Size newSize = HelperClass.resize(tempMat.Width, tempMat.Height, m_displayControl.m_display.Width, m_displayControl.m_display.Height);
                                m_bitmapList?.Dispose();
                                m_bitmapList = new AutoDisposeDict<string, Mat> { { "LastRun.OutputImage", tempMat.Clone() } };
                                CvInvoke.Resize(tempMat, tempMat, newSize); 
                                if(m_displayControl.m_cbImages.SelectedItem?.ToString() == "LastRun.OutputImage" || m_displayControl.m_cbImages.SelectedItem == null)
                                {
                                    m_displayControl.m_display.Size = newSize; 
                                    m_displayControl.m_display.Image?.Dispose();
                                    m_displayControl.m_display.Image = m_bitmapList["LastRun.OutputImage"];
                                }
                                
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
            catch (Exception ex)
            {
                MessageBox.Show("Invalid Images Input");
                Console.WriteLine(ex.Message);
            }
            return new Mat();
        }

        private void ProcessFrame(object sender, EventArgs e)
        {
            if (processing) return;
            processing = true;

            try
            {
                Mat frame = new Mat();

                bool? ret = videoCapture?.Read(frame);
                if (ret == null)
                    return;

                if (videoCapture != null && !frame.IsEmpty)
                {
                    if (!resizedOnce)
                    {
                        Size newSize = HelperClass.resize(frame.Width, frame.Height, m_displayControl.m_display.Width, m_displayControl.m_display.Height);
                        CvInvoke.Resize(frame, frame, newSize);
                        m_displayControl.m_display.Size = newSize;
                    }

                    if (m_displayControl.m_display.Image != null)
                        m_displayControl.m_display.Image.Dispose();
                    m_bitmapList?.Dispose();
                    m_bitmapList = new AutoDisposeDict<string, Mat> { { "LastRun.OutputImage", frame.Clone() } };

                    if (!runContinue)
                        m_displayControl.m_display.Image = null;
                    if (String.Compare(m_displayControl.m_cbImages.SelectedItem.ToString(), "LastRun.OutputImage") == 0)
                        m_displayControl.m_display.Image = frame;
                    if (m_displayControl.m_playPauseButton.Visible)
                        m_displayControl.m_trackBarVideoDuration.Value++;

                    frame.Dispose();
                    Thread.Sleep((int)(1 / fps * 1000));
                }
                else if (videoCapture != null && frame.IsEmpty)
                {
                    videoCapture.Set(CapProp.PosFrames, 0);
                    m_displayControl.m_trackBarVideoDuration.Value = 0;
                }
            }
            finally
            {
                processing = false;
            }
        }

        private void openCamera_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
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
            this.Cursor = Cursors.Default;
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
                        this.Cursor = Cursors.WaitCursor;
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
                        this.Cursor = Cursors.Default;
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

            if (videoCapture != null) { }
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

            Size imageSize = m_bitmapList[m_displayControl.m_cbImages.SelectedItem.ToString()].Size;
            Size displaySize = m_displayControl.m_display.Size;
            
            if (imageSize.Height / imageSize.Width != displaySize.Height / displaySize.Width)
            {
                m_displayControl.m_display.Width = imageSize.Width;
                m_displayControl.m_display.Height = imageSize.Height;
            }

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
            if (node.tool.parameter.m_roi.ROIRectangle == null || !node.tool.parameter.m_boolHasROI)
                m_rectangle = new Rectangle();
            else
                m_rectangle = node.tool.parameter.m_roi.ROIRectangle;

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

        private void AddToolMenuItem_Click(object sender, EventArgs e)
        {
            ITool tool;
            int imageIndex;
            switch (((ToolStripMenuItem)sender).Name)
            {
                case "blobToolMenuItem":
                    tool = new BlobTool("BlobTool" + (++HelperClass.m_dictToolCount["BlobTool"]).ToString());
                    imageIndex = 0;
                    break;
                case "caliperToolMenuItem":
                    tool = new CaliperTool("CaliperTool" + (++HelperClass.m_dictToolCount["CaliperTool"]).ToString());
                    imageIndex = 1;
                    break;
                case "histogramToolMenuItem":
                    tool = new HistogramTool("HistogramTool" + (++HelperClass.m_dictToolCount["HistogramTool"]).ToString());
                    imageIndex = 2;
                    break;
                case "imageConvertToolToolStripMenuItem":
                    tool = new ImageConvertTool("ImageConvertTool" + (++HelperClass.m_dictToolCount["ImageConvertTool"]).ToString());
                    imageIndex = 3;
                    break;
                case "colorSegmentorToolToolStripMenuItem":
                    tool = new ColorSegmentorTool("ColorSegmentorTool" + (++HelperClass.m_dictToolCount["ColorSegmentorTool"]).ToString());
                    imageIndex = 4;
                    break;
                case "colorMatchToolToolStripMenuItem":
                    tool = new ColorMatcherTool("ColorMatcherTool" + (++HelperClass.m_dictToolCount["ColorMatcherTool"]).ToString());
                    imageIndex = 5;
                    break;
                case "colorExtractorToolToolStripMenuItem":
                    tool = new ColorExtractorTool("ColorExtractorTool" + (++HelperClass.m_dictToolCount["ColorExtractorTool"]).ToString());
                    imageIndex = 6;
                    break;
                case "imageSharpenerToolToolStripMenuItem":
                    tool = new ImageSharpenerTool("ImageSharpenerTool" + (++HelperClass.m_dictToolCount["ImageSharpenerTool"]).ToString());
                    imageIndex = 7;
                    break;
                case "findLineToolToolStripMenuItem":
                    tool = new LineSegmentTool("LineSegmentTool" + (++HelperClass.m_dictToolCount["LineSegmentTool"]).ToString());
                    imageIndex = 8;
                    break;
                case "polarUnwarpToolToolStripMenuItem":
                    tool = new PolarUnWrapTool("ImagePolarUnWrapTool" + (++HelperClass.m_dictToolCount["PolarUnWrapTool"]).ToString());
                    imageIndex = 10;
                    break;
                case "perspectiveTransformToolToolStripMenuItem":
                    tool = new PerspectiveTransformTool("ImagePerspectiveTransformTool" + (++HelperClass.m_dictToolCount["PerspectiveTransformTool"]).ToString());
                    imageIndex = 11;
                    break;
                case "textRecognitionToolToolStripMenuItem":
                    tool = new TextRecognitionTool("TextRecognitionTool" + (++HelperClass.m_dictToolCount["TextRecognitionTool"]).ToString());
                    imageIndex = 12;
                    break;
                case "imageProcessToolToolStripMenuItem":
                    tool = new ImageProcessTool("ImageProcessTool" + (++HelperClass.m_dictToolCount["ImageProcessTool"]).ToString());
                    imageIndex = 13;
                    break;
                case "iDToolToolStripMenuItem":
                    tool = new IDTool("IDTool" + (++HelperClass.m_dictToolCount["IDTool"]).ToString());
                    imageIndex = 14;
                    break;
                case "imagePaintToolToolStripMenuItem":
                    tool = new PaintTool("ImagePaintTool" + (++HelperClass.m_dictToolCount["ImagePaintTool"]).ToString());
                    imageIndex = 15;
                    break;
                case "imageStackingToolToolStripMenuItem":
                    tool = new ImageStackingTool("ImageStackingTool" + (++HelperClass.m_dictToolCount["ImageStackingTool"]).ToString());
                    imageIndex = 16;
                    break;
                case "imageStitchingToolToolStripMenuItem":
                    tool = new ImageStitchingTool("ImageStitchingTool" + (++HelperClass.m_dictToolCount["ImageStitchingTool"]).ToString());
                    imageIndex = 17;
                    break;
                case "imageBlendingToolToolStripMenuItem":
                    tool = new ImageBlendingTool("ImageBlendingTool" + (++HelperClass.m_dictToolCount["ImageBlendingTool"]).ToString());
                    imageIndex = 17;
                    break;
                default:
                    MessageBox.Show("Invalid Tool Added");
                    return;
            }
            ToolsTreeNode m_treeNode = new ToolsTreeNode(tool)
            {
                Name = tool.ToolName,
                Text = tool.ToolName,
                ImageIndex = imageIndex,
                SelectedImageIndex = imageIndex
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
                ITool tool = selectedNode.tool;
                
                
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
                else // m_bitmapList == null
                {
                    m_bitmapList = new AutoDisposeDict<string, Mat> { { "Current.InputImage", new Mat() } };
                    m_form1DisplaySelection.Add("Current.InputImage");
                    tool.m_bitmapList = new AutoDisposeDict<string, Mat> { { "Current.InputImage", new Mat() } };
                    tool.m_DisplaySelection.Add("Current.InputImage");
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
            m_RunBtn.PerformClick();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                m_displayControl.m_playPauseButton.PerformClick();
        }

        private void m_labelToMLDL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form form = Application.OpenForms["AIForm"];
            if (form == null)
            {
                AIForm aIForm = new AIForm();
                aIForm.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
            Hide();
        }

        private void m_rbCameraCalibrated_CheckedChanged(object sender, EventArgs e)
        {
            if (m_rbCameraCalibrated.Checked)
            {
                DialogResult m_calibrationSelection = MessageBox.Show("Do u want to use VIDEO as input? If no, FOLDER will be selected.", "", MessageBoxButtons.YesNoCancel);
                this.Cursor = Cursors.WaitCursor;
                if (m_calibrationSelection == DialogResult.Yes)
                {
                    new Calibration(true);
                }
                else if(m_calibrationSelection == DialogResult.No)
                {
                    new Calibration(false);
                }
                else if(m_calibrationSelection == DialogResult.Cancel)
                {
                    m_rbCameraCalibrated.Checked = false;
                }
                this.Cursor = Cursors.Default;
            }
            else
            {
                HelperClass.CalibrationResult?.Dispose();
                HelperClass.CalibrationResult = null;
    }
        }

        private void m_labelTo3D_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string pythonScriptPath = "C:\\Users\\T0571\\source\\repos\\OpenCV_Vision_Pro\\OpenCV_Vision_Pro\\PythonGUI.py";

            // Create a new process start info
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = "python"; // Use "python3" if required
            psi.Arguments = pythonScriptPath;
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;

            // Start the Python process
            process = new Process();
            process.StartInfo = psi;
            
            process.Exited += (s, ev) =>
            {
                // Dispose of the process when it exits
                process.Dispose();
                process = null;
            };
            try
            {
                process.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (process != null && !process.HasExited)
            {
                process?.CloseMainWindow();
                process?.Dispose();
            }
        }
    }
}
