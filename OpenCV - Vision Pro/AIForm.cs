using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Dnn;
using Emgu.CV.Flann;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Image = System.Drawing.Image;
using Timer = System.Windows.Forms.Timer;

namespace OpenCV_Vision_Pro
{
    public partial class AIForm : Form
    {
        Net Model = null;
        List<string> labels = null;
        private DisplayControl m_displayControl;
        private string[] files;
        private int m_cntFileIndex = 0;
        private int[] m_cntImageIndices;
        private int m_cntImageIndex;
        private int skipFrame;

        private VideoCapture videoCapture;
        private bool resizedOnce = false;
        private double fps;

        public AIForm()
        {
            InitializeComponent();
            m_displayControl = new DisplayControl()
            {
                Dock = DockStyle.Fill,
                m_DisplaySelection = new BindingList<string>()
            };
            splitContainer1.Panel2.Controls.Add(m_displayControl);

            m_displayControl.m_cbImages.Visible = false; Application.Idle += ProcessFrame;
            HelperClass.GetAllConnectedCameras(openCameraToolStripMenuItem, openCamera_Click); 
            skipFrame = 0;
            files = Form1.files;
            m_cntFileIndex = Form1.m_cntFileIndex;
            m_cntImageIndices = Form1.m_cntImageIndices;
            m_cntImageIndex = Form1.m_cntImageIndex;
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
            Application.Idle -= ProcessFrame;
            videoCapture?.Stop();
            videoCapture = null;
            videoCapture?.Dispose();
            Model?.Dispose();
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
                MessageBox.Show("Invalid Images Input");
                Console.WriteLine(ex.Message);
            }
            return new Mat();
        }

        private void ProcessFrame(object sender, EventArgs e)
        {
            if (skipFrame++ % 2 == 0)
                return;
            try
            {
                Mat frame = new Mat();
                bool? ret = videoCapture?.Read(frame);
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

                    if (Model != null)
                    {
                        float confThreshold = 0.7f;
                        float nmsThreshold = 0.5f;
                        int defaultSize = 416;

                        Size newSize = HelperClass.resize(frame.Width, frame.Height, defaultSize, defaultSize);
                        Mat resizeMat = new Mat();
                        CvInvoke.Resize(frame, resizeMat, newSize);
                        int topBottom = (defaultSize - newSize.Height) / 2;
                        int leftRight = (defaultSize - newSize.Width) / 2;
                        newSize = resizeMat.Size;
                        CvInvoke.CopyMakeBorder(resizeMat, resizeMat, topBottom, topBottom, leftRight, leftRight, BorderType.Constant, new MCvScalar(0, 0, 0));

                        CvInvoke.Resize(resizeMat, resizeMat, new Size(defaultSize, defaultSize));

                        Mat input = DnnInvoke.BlobFromImage(resizeMat, 1 / 255.0, swapRB: true);
                        Model.SetInput(input);
                        input.Dispose();

                        VectorOfMat vectorOfMat = new VectorOfMat();
                        VectorOfRect bboxes = new VectorOfRect();
                        VectorOfFloat scores = new VectorOfFloat();
                        VectorOfInt indices = new VectorOfInt();
                        Model.Forward(vectorOfMat, Model.UnconnectedOutLayersNames);

                        for (int i = 0; i < vectorOfMat.Size; i++)
                        {
                            Mat mat = vectorOfMat[i];
                            var data = ArrayTo2DList(mat.GetData());
                            for (int j = 0; j < data.Count; j++)
                            {
                                var row = data[j];
                                var rowScores = row.Skip(5).ToArray();
                                var classId = rowScores.ToList().IndexOf(rowScores.Max());
                                var confidence = rowScores[classId];
                                if (confidence > confThreshold)
                                {
                                    var center_x = (int)(row[0] * defaultSize);
                                    var center_y = (int)(row[1] * defaultSize);

                                    var width = (int)(row[2] * defaultSize);
                                    var height = (int)(row[3] * defaultSize);

                                    var x = (int)(center_x - width / 2);
                                    var y = (int)(center_y - height / 2);

                                    bboxes.Push(new Rectangle[] { new Rectangle(x, y, width, height) });
                                    indices.Push(new int[] { classId });
                                    scores.Push(new float[] { confidence });
                                }
                            }
                            mat?.Dispose();
                        }
                        vectorOfMat.Dispose();

                        var idx = DnnInvoke.NMSBoxes(bboxes.ToArray(), scores.ToArray(), confThreshold, nmsThreshold);
                        for (int i = 0; i < idx.Length; i++)
                        {
                            int index = idx[i];
                            var bbox = bboxes[index];
                            CvInvoke.Rectangle(resizeMat, bbox, new MCvScalar(0, 0, 255), 2);
                            CvInvoke.PutText(resizeMat, labels[indices[index]], new Point(bbox.X, bbox.Y + 20), FontFace.HersheySimplex, 0.5, new MCvScalar(255, 0, 0), 2);
                        }
                        bboxes.Dispose();
                        scores.Dispose();
                        indices.Dispose();
                        Point point = topBottom < 1 ? new Point(leftRight, 0) : new Point(0, topBottom);
                        Mat tempMat = new Mat(resizeMat, new Rectangle(point, newSize));

                        m_displayControl.m_display.Image = tempMat;
                        resizeMat.Dispose();
                    }
                    else
                    {
                        m_displayControl.m_display.Image = frame;
                        //System.Threading.Thread.Sleep((int)(1 / fps * 1000));
                    }

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
            finally
            {

            }
        }

        private List<float[]> ArrayTo2DList(Array array)
        {
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);
            List<float[]> list = new List<float[]>();
            List<float> temp = new List<float>();
            for (int i = 0; i < rows; i++)
            {
                temp.Clear();
                for (int j = 0; j < cols; j++)
                {
                    temp.Add(float.Parse(array.GetValue(i, j).ToString()));
                }
                list.Add(temp.ToArray());
            }
            return list;
        }

        private void openCamera_Click(object sender, EventArgs e)
        {
            videoCapture?.Stop();
            videoCapture?.Dispose();

            ToolStripMenuItem itemSelection = (ToolStripMenuItem)sender;
            videoCapture = new VideoCapture(openCameraToolStripMenuItem.DropDownItems.IndexOf(itemSelection));
            fps = videoCapture.Get(CapProp.Fps);

            resizedOnce = false;
            m_displayControl.m_VideoCapture = videoCapture;

            m_cntImageIndices = null;

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

                        resizedOnce = false;

                        videoCapture?.Stop();
                        videoCapture?.Dispose();
                        videoCapture = new VideoCapture(openFileDialog.FileName);
                        m_displayControl.m_VideoCapture = videoCapture;
                        double totalFrame = videoCapture.Get(CapProp.FrameCount);
                        fps = videoCapture.Get(CapProp.Fps);
                        m_displayControl.m_trackBarVideoDuration.Maximum = (int)totalFrame;

                        m_cntImageIndices = null;

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

        private void yOLOv7ObjectDetectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string PathWeights = "C:\\Users\\T0571\\Downloads\\yolov7-tiny.weights";
            string PathConfig = "C:\\Users\\T0571\\Downloads\\yolov7-tiny.cfg";
            string PathLabels = "C:\\Users\\T0571\\Downloads\\coco.names";
            Model = DnnInvoke.ReadNetFromDarknet(PathConfig, PathWeights);
            labels = File.ReadAllLines(PathLabels).ToList();
            Model.SetPreferableBackend(Emgu.CV.Dnn.Backend.Cuda);
            Model.SetPreferableTarget(Target.Cuda);
        }
    }
}
