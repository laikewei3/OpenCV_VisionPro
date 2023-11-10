using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Dnn;
using Emgu.CV.Flann;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Microsoft.WindowsAPICodePack.Dialogs;
using OpenCV_Vision_Pro.AITool;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Forms;
using Image = System.Drawing.Image;

namespace OpenCV_Vision_Pro
{
    public partial class AIForm : Form
    {

        private DisplayControl m_displayControl;

        //Images
        private string[] files;
        private int m_cntFileIndex = 0;
        private int[] m_cntImageIndices;
        private int m_cntImageIndex;
        private int skipFrame;

        private System.Windows.Forms.Timer timer;

        private VideoCapture videoCapture;
        private bool resizedOnce = false;
        private double fps = 1;

        private BindingList<AIToolInfo> m_AITool = new BindingList<AIToolInfo>();

        private class AIToolInfo
        {
            public IAITool m_AITool;
            public string Name { get; set; }

            public bool isUsing;

            public AIToolInfo(IAITool m_AITool, string name, bool isUsing)
            {
                this.Name = name;
                this.isUsing = isUsing;
                this.m_AITool = m_AITool;
            }
        }

        public AIForm()
        {
            InitializeComponent();
            m_displayControl = new DisplayControl()
            {
                Dock = DockStyle.Fill,
                m_DisplaySelection = new BindingList<string>()
            };
            splitContainer1.Panel2.Controls.Add(m_displayControl);
            
            m_displayControl.m_cbImages.Visible = false; 
            HelperClass.GetAllConnectedCameras(openCameraToolStripMenuItem, openCamera_Click);
            skipFrame = 0;
            files = Form1.files;
            m_cntFileIndex = Form1.m_cntFileIndex;
            m_cntImageIndices = Form1.m_cntImageIndices;
            m_cntImageIndex = Form1.m_cntImageIndex;

            m_dgvTool.DataSource = new BindingSource() { DataSource = m_AITool };
            DataGridViewButtonColumn bc = new DataGridViewButtonColumn();
            bc.Name = "Status";
            bc.HeaderText = "Status";
            m_dgvTool.Columns.Add(bc);

            timer = new System.Windows.Forms.Timer();
            timer.Tick += ProcessFrame;
            timer.Start();
        }

        private void m_OpenBtn_Click(object sender, EventArgs e)
        {
            m_GetInputImageMenu.Show(m_OpenBtn, new Point(0, m_OpenBtn.Height)); skipFrame = 0;
        }

        private void m_labelToMLDL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form form = Application.OpenForms["Form1"];
            form.Show();
            Hide();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Form form = Application.OpenForms["Form1"]; form?.Show();
            timer.Tick -= ProcessFrame;
            videoCapture?.Stop();
            videoCapture = null;
            videoCapture?.Dispose();
            base.OnFormClosing(e);
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
                            videoCapture.Stop();
                            videoCapture.Dispose();
                            videoCapture = null;
                            m_displayControl.m_VideoCapture = null;
                            m_displayControl.m_playPauseButton.Parent.Visible = false;
                            m_displayControl.m_playPauseButton.Click -= PlayPauseClick;
                        }

                        if (isFolder)
                            files = Directory.GetFiles(openFileDialog.FileName);
                        else
                            files = new string[] { openFileDialog.FileName };

                        m_cntFileIndex = 0; m_cntImageIndex = 0;
                        m_cntImageIndices = new int[files.Length];

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
            if (files == null)
                return null;
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
                                if (tempMat.NumberOfChannels > 3)
                                    CvInvoke.CvtColor(tempMat, tempMat, ColorConversion.Bgra2Bgr);
                                CvInvoke.Resize(tempMat, tempMat, newSize);
                                m_displayControl.m_display.Size = newSize;
                                m_displayControl.m_display.Image?.Dispose();
                                m_displayControl.m_display.Image = tempMat.Clone();

                                tempMat.Dispose();
                                m_image.Dispose();
                            }
                            memStream.Dispose();
                        }
                        image.Dispose();
                    }
                    fileStream.Dispose();
                }
                return (Mat)m_displayControl.m_display.Image;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new Mat();
        }

        private void ProcessFrame(object sender, EventArgs e)
        {
            //  if (skipFrame++ % 2 != 0)
            // {
            try
            {
                Mat frame = new Mat();
                bool? ret = videoCapture?.Read(frame);
                // Use Image
                if (ret == null)
                {
                    frame = OpenImages(files, m_cntFileIndex, m_cntImageIndex)?.Clone();
                    if (frame == null)
                        return;
                    m_cntImageIndex++;
                    if (m_cntImageIndex >= m_cntImageIndices[m_cntFileIndex])
                    {
                        m_cntFileIndex++;
                        if (m_cntFileIndex >= files.Length)
                            m_cntFileIndex = 0;
                        m_cntImageIndex = 0;
                    }
                }

                if (!frame.IsEmpty)
                {
                    if (!resizedOnce)
                    {
                        Size size = HelperClass.resize(frame.Width, frame.Height, m_displayControl.m_display.Width, m_displayControl.m_display.Height);
                        CvInvoke.Resize(frame, frame, size);
                        m_displayControl.m_display.Size = size;
                    }
                    m_displayControl.m_display.Image?.Dispose();

                    foreach (AIToolInfo info in m_AITool)
                    {
                        if (info.isUsing)
                        {
                            info.m_AITool.PreProcess(frame, out Mat resizeMat, out int topBottom, out int leftRight, out Size newSize);
                            info.m_AITool.Process();
                            frame = info.m_AITool.Draw(resizeMat, topBottom, leftRight, newSize);
                        }
                    }

                    m_displayControl.m_display.Image = frame;
                    if (m_AITool.Count == 0 && videoCapture != null)
                            Thread.Sleep((int)(1 / fps * 1000));

                    if (m_displayControl.m_playPauseButton.Visible)
                        m_displayControl.m_trackBarVideoDuration.Value++;

                    frame.Dispose();

                }
                else if (videoCapture != null && frame.IsEmpty)
                {
                    videoCapture.Set(CapProp.PosFrames, 0);
                    m_displayControl.m_trackBarVideoDuration.Value = 0;
                }
            }
            finally{ this.Cursor = Cursors.Default; }
            //  }
        }

        private void openCamera_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            videoCapture?.Stop();
            videoCapture?.Dispose();

            ToolStripMenuItem itemSelection = (ToolStripMenuItem)sender;
            videoCapture = new VideoCapture(openCameraToolStripMenuItem.DropDownItems.IndexOf(itemSelection));

            resizedOnce = false;
            m_displayControl.m_VideoCapture = videoCapture;
            fps = videoCapture.Get(CapProp.Fps);

            m_cntImageIndices = null;

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

                        resizedOnce = false;

                        videoCapture?.Stop();
                        videoCapture?.Dispose();
                        videoCapture = new VideoCapture(openFileDialog.FileName);
                        m_displayControl.m_VideoCapture = videoCapture;
                        double totalFrame = videoCapture.Get(CapProp.FrameCount);
                        m_displayControl.m_trackBarVideoDuration.Maximum = (int)totalFrame;

                        m_cntImageIndices = null;
                        fps = videoCapture.Get(CapProp.Fps);
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
                    timer.Tick += ProcessFrame;
                else
                    timer.Tick -= ProcessFrame;
            }
        }

        private void m_BtnAddTool_Click(object sender, EventArgs e)
        {
            m_AddToolList.Show(m_BtnAddTool, new Point(0, m_BtnAddTool.Height));
        }

        private void yOLOv7ObjectDetectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            YoloDetection yolo = new YoloDetection();
            m_AITool.Add(new AIToolInfo(yolo,yolo.GetType().Name,true));
        }

        private void m_dgvTool_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            m_dgvTool["Status", m_dgvTool.Rows.GetLastRow(DataGridViewElementStates.None)].Value = "Disable";
        }

        private void m_dgvTool_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                m_AITool[e.RowIndex].isUsing = !m_AITool[e.RowIndex].isUsing;
                if (m_AITool[e.RowIndex].isUsing)
                    senderGrid[e.ColumnIndex, e.RowIndex].Value = "Disable";
                else
                    senderGrid[e.ColumnIndex, e.RowIndex].Value = "Enable";
            }
        }

        private void humanPoseDetectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            HumanPoseDetection humanPose = new HumanPoseDetection();
            m_AITool.Add(new AIToolInfo(humanPose, humanPose.GetType().Name, true));
        }

        private void handLandmarkDetectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            HandLandmarkDetection handLandmark = new HandLandmarkDetection();
            m_AITool.Add(new AIToolInfo(handLandmark, handLandmark.GetType().Name, true));
        }
    }
}
