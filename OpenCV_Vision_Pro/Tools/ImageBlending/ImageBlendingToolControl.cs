using Emgu.CV;
using Microsoft.WindowsAPICodePack.Dialogs;
using OpenCV_Vision_Pro.Interface;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace OpenCV_Vision_Pro.Tools.ImageBlending
{
    public partial class ImageBlendingToolControl : UserControl, IUserControlBase
    {
        public ROI m_roi { get { return BlendingParams.m_roi; } }

        public ImageBlendingParams BlendingParams { get; set; }

        public IParams parameter { get; set; }

        public ImageBlendingToolControl(IParams stackParam)
        {
            InitializeComponent();
            parameter = stackParam;
            this.BlendingParams = (ImageBlendingParams)parameter;
            this.BlendingParams.m_roi.Dock = DockStyle.Top;
            this.Controls.Add(BlendingParams.m_roi);
        }

        private void ImageBlendingToolContorl_Load(object sender, EventArgs e)
        {
            if (parameter.m_boolHasROI)
            {
                if (parameter.m_roi.points != null)
                    parameter.m_roi.m_comboBoxROI.SelectedIndex = 2;
                else
                    parameter.m_roi.m_comboBoxROI.SelectedIndex = 1;
            }
            m_listImagesSelected.DataSource = new BindingSource() { DataSource = BlendingParams.selectedImage };
            if(BlendingParams.weight != "")
                m_tbWeightQue.Text = BlendingParams.weight;
            m_tbWeightQue.GotFocus += m_tbWeightQue_GotFocus;
            m_tbWeightQue.LostFocus += m_tbWeightQue_LostFocus;
            m_cbBlendingOperation.SelectedItem = BlendingParams.colorMode;
        }

        private void m_btnBlendingOpen_Click(object sender, EventArgs e)
        {
            m_openMenuStrip.Show(m_btnBlendingOpen, 0, m_btnBlendingOpen.Height);
        }

        private void m_listImagesSelected_SelectedIndexChanged(object sender, EventArgs e)
        {
            Mat tempMat = BlendingParams.vom[m_listImagesSelected.SelectedIndex]; //BlendingParams.m_selectedImageList[m_listImagesSelected.Text];
            if(tempMat == null)
                return;
            Size newSize = HelperClass.resize(tempMat.Width, tempMat.Height, 500, 500);
            CvInvoke.Resize(tempMat, tempMat, newSize);
            ((ToolWindow)ParentForm).m_displayControl.m_display.Size = newSize;
            ((ToolWindow)ParentForm).m_displayControl.m_display.Image = tempMat;
        }

        private void OpenEvent(object sender, EventArgs e)
        {
            try
            {
                bool isFolder = false;
                string[] files;
                using (CommonOpenFileDialog openFileDialog = new CommonOpenFileDialog())
                {
                    if (String.Compare(((ToolStripMenuItem)sender).Name, "folderToolStripMenuItem") == 0)
                    {
                        openFileDialog.IsFolderPicker = true;
                        isFolder = true;
                    }
                    BlendingParams.selectedImage.Clear();
                    BlendingParams.vom.Clear();//.m_selectedImageList.Clear();
                    if (openFileDialog.ShowDialog() == CommonFileDialogResult.Ok)
                    {
                        if (isFolder)
                            files = Directory.GetFiles(openFileDialog.FileName);
                        else
                            files = new string[] { openFileDialog.FileName };

                        for (int i = 0; i < files.Length; i++)
                        {
                            FileStream fileStream = new FileStream(files[i], FileMode.Open, FileAccess.Read);
                            using (Image image = Image.FromStream(fileStream, true, false))
                            {
                                if (image != null)
                                {
                                    int cnt = image.GetFrameCount(FrameDimension.Page);
                                    for (int j = 0; j < cnt; j++)
                                    {
                                        image.SelectActiveFrame(FrameDimension.Page, j); // Switch to the current page
                                        using (MemoryStream memStream = new MemoryStream())
                                        {
                                            if (Path.GetExtension(m_listImagesSelected.Text) == ".png")
                                                image.Save(memStream, ImageFormat.Png);
                                            else
                                                image.Save(memStream, ImageFormat.Bmp);
                                            using (Bitmap m_image = (Bitmap)Bitmap.FromStream(memStream))
                                            {
                                                Mat tempMat = m_image.ToMat();
                                                BlendingParams.selectedImage.Add(files[i]+"("+j+")");
                                                BlendingParams.vom.Push(tempMat);
                                                 tempMat.Dispose();
                                                m_image.Dispose();
                                            }
                                            memStream.Dispose();
                                        }
                                    }
                                }
                                image.Dispose();
                            }
                        }
                    }
                    openFileDialog.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid Input Images\n\n"+ex.Message);
            }
            finally
            {
                ((ToolWindow)ParentForm).BringToFront();
            }
        }

        private void m_btnOpenWeight_Click(object sender, EventArgs e)
        {
            try
            {
                string text = "";
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Text File (*.txt) | *.txt";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string[] weightStr = File.ReadAllLines(openFileDialog.FileName);
                        for (int i = 0; i < weightStr.Length; i++)
                        {   
                            if(i == weightStr.Length - 1)
                            {
                                text += weightStr;
                                break;
                            }
                            text += weightStr + ",";
                        }
                        m_labelLoadTimes.Text = "Success";
                        m_labelLoadTimes.ForeColor = Color.LawnGreen;
                    }
                    openFileDialog.Dispose();
                }

                m_tbWeightQue.Text = text;
                BlendingParams.weight = text;
            }
            catch (Exception)
            {
                m_labelLoadTimes.Text = "ERROR";
                m_labelLoadTimes.ForeColor = Color.Red;
            }
            finally
            {
                ((ToolWindow)ParentForm).BringToFront();
            }
        }

        private void m_cbBlendingOperation_SelectedIndexChanged(object sender, EventArgs e)
        {
            BlendingParams.colorMode = m_cbBlendingOperation.SelectedItem.ToString();
        }

        private void m_tbWeightQue_GotFocus(object sender, EventArgs e)
        {
            if (m_tbWeightQue.Text.Length == 0)
                return;
            if (Char.IsLetter(m_tbWeightQue.Text[0]))
                m_tbWeightQue.Text = "";
        }

        private void m_tbWeightQue_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(m_tbWeightQue.Text))
                m_tbWeightQue.Text = "Enter the weight in format (***,***,***,......) else every image will have same weight";
            if (!Char.IsLetter(m_tbWeightQue.Text[0]))
                BlendingParams.weight = m_tbWeightQue.Text;
        }
    }
}
