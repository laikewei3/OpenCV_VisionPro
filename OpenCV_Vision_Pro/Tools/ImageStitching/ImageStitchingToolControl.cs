using Emgu.CV;
using Microsoft.WindowsAPICodePack.Dialogs;
using OpenCV_Vision_Pro.Interface;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace OpenCV_Vision_Pro.Tools.ImageStitching
{
    public partial class ImageStitchingToolControl : UserControl, IUserControlBase
    {
        public ROI m_roi { get { return StitchingParams.m_roi; } }

        public ImageStitchingParams StitchingParams { get; set; }

        public IParams parameter { get; set; }

        public ImageStitchingToolControl(IParams stitchParam)
        {
            InitializeComponent();
            parameter = stitchParam;
            this.StitchingParams = (ImageStitchingParams)parameter;
            this.StitchingParams.m_roi.Dock = DockStyle.Top;
            this.Controls.Add(StitchingParams.m_roi);
        }

        private void ImageStitchingToolContorl_Load(object sender, EventArgs e)
        {
            if (parameter.m_boolHasROI)
            {
                if (parameter.m_roi.points != null)
                    parameter.m_roi.m_comboBoxROI.SelectedIndex = 2;
                else
                    parameter.m_roi.m_comboBoxROI.SelectedIndex = 1;
            }
            m_listImagesSelected.DataSource = new BindingSource() { DataSource = StitchingParams.selectedImage };

        }

        private void m_btnStitchingOpen_Click(object sender, EventArgs e)
        {
            m_openMenuStrip.Show(m_btnStitchingOpen,0,m_btnStitchingOpen.Height);
        }

        private void m_listImagesSelected_SelectedIndexChanged(object sender, EventArgs e)
        {
            Mat tempMat = StitchingParams.vom[m_listImagesSelected.SelectedIndex];
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
                    StitchingParams.selectedImage.Clear();
                    StitchingParams.vom.Clear();//.m_selectedImageList.Clear();
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
                                                StitchingParams.selectedImage.Add(files[i]+"("+j+")");
                                                StitchingParams.vom.Push(tempMat);
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
    }
}
