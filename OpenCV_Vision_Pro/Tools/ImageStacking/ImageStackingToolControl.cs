using Emgu.CV;
using Microsoft.WindowsAPICodePack.Dialogs;
using OpenCV_Vision_Pro.Interface;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace OpenCV_Vision_Pro.Tools.ImageStacking
{
    public partial class ImageStackingToolControl : UserControl, IUserControlBase
    {

        public ROI m_roi { get { return StackingParams.m_roi; } }

        public ImageStackingParams StackingParams { get; set; }

        public IParams parameter { get; set; }

        public ImageStackingToolControl(IParams stackParam)
        {
            InitializeComponent();
            parameter = stackParam;
            this.StackingParams = (ImageStackingParams)parameter;
            this.StackingParams.m_roi.Dock = DockStyle.Top;
            this.Controls.Add(StackingParams.m_roi);
        }

        private void ImageStackingToolContorl_Load(object sender, EventArgs e)
        {
            if (parameter.m_boolHasROI)
            {
                if (parameter.m_roi.points != null)
                    parameter.m_roi.m_comboBoxROI.SelectedIndex = 2;
                else
                    parameter.m_roi.m_comboBoxROI.SelectedIndex = 1;
            }
            m_cbStackingOperation.SelectedItem = StackingParams.operation;
            m_listImagesSelected.DataSource = new BindingSource() { DataSource = StackingParams.selectedImage };
            
            switch (StackingParams.toneMapParameter.GetType().Name)
            {
                case "DragoParams":
                    m_cbToneMappingType.SelectedItem = "Drago";
                    DragoParamsGUI((DragoParams)StackingParams.toneMapParameter);
                    break;
                case "DurandParams":
                    m_cbToneMappingType.SelectedItem = "Durand";
                    DurandParamsGUI((DurandParams)StackingParams.toneMapParameter);
                    break;
                case "ReinhardParams":
                    m_cbToneMappingType.SelectedItem = "Reinhard";
                    ReinhardParamsGUI((ReinhardParams)StackingParams.toneMapParameter);
                    break;
                case "MantiukParams":
                    m_cbToneMappingType.SelectedItem = "Mantiuk";
                    MantiukParamsGUI((MantiukParams)StackingParams.toneMapParameter);
                    break;
            }
            if (StackingParams.times.Size > 2)
            {
                m_labelLoadTimes.Text = "Success";
                m_labelLoadTimes.ForeColor = Color.LawnGreen;
            }
            else
            {
                m_labelLoadTimes.Text = "Empty";
                m_labelLoadTimes.ForeColor = Color.Gray;
            }
        }

        private void MantiukParamsGUI(MantiukParams para)
        {
            m_nudP1.Value = (decimal)para.gamma;
            m_nudP2.Value = (decimal)para.saturation;
            m_labelP2.Text = "Saturation:";
            m_nudP3.Value = (decimal)para.scale;
            m_labelP3.Text = "Scale:";
            m_nudP4.Visible = false;
            m_labelP4.Visible = false;
            m_nudP5.Visible = false;
            m_labelP5.Visible = false;
        }

        private void ReinhardParamsGUI(ReinhardParams para)
        {
            m_nudP1.Value = (decimal)para.gamma;
            m_nudP2.Value = (decimal)para.intensity;
            m_labelP2.Text = "Intensity:";
            m_nudP3.Value = (decimal)para.light_adapt;
            m_labelP3.Text = "Light Adaptation:";
            m_nudP4.Visible = true;
            m_labelP4.Visible = true; 
            m_nudP4.Value = (decimal)para.color_adapt;
            m_labelP4.Text = "Color Adaptation:";
            m_nudP5.Visible = false;
            m_labelP5.Visible = false;
        }

        private void DurandParamsGUI(DurandParams para)
        {
            m_nudP1.Value = (decimal)para.gamma;
            m_nudP2.Value = (decimal)para.saturation;
            m_labelP2.Text = "Saturation:";
            m_nudP3.Value = (decimal)para.contrast;
            m_labelP3.Text = "Contrast:";
            m_nudP4.Visible = true;
            m_labelP4.Visible = true; 
            m_nudP4.Value = (decimal)para.sigma_space;
            m_labelP4.Text = "Sigma Space:";
            m_nudP5.Visible = true;
            m_labelP5.Visible = true;
            m_nudP5.Value = (decimal)para.sigma_color;
            m_labelP5.Text = "Sigma Color:";
        }

        private void DragoParamsGUI(DragoParams para)
        {
            m_nudP1.Value = (decimal)para.gamma;
            m_nudP2.Value = (decimal)para.saturation;
            m_labelP2.Text = "Saturation:";
            m_nudP3.Value = (decimal)para.bias;
            m_labelP3.Text = "Bias:";
            m_nudP4.Visible = false;
            m_labelP4.Visible = false;
            m_nudP5.Visible = false;
            m_labelP5.Visible = false;
        }

        private void m_btnStackingOpen_Click(object sender, EventArgs e)
        {
            m_openMenuStrip.Show(m_btnStackingOpen, 0, 0);
        }

        private void m_listImagesSelected_SelectedIndexChanged(object sender, EventArgs e)
        {
            Mat tempMat = StackingParams.vom[m_listImagesSelected.SelectedIndex]; //StackingParams.m_selectedImageList[m_listImagesSelected.Text];
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
                    StackingParams.selectedImage.Clear();
                    StackingParams.vom.Clear();//.m_selectedImageList.Clear();
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
                                                StackingParams.selectedImage.Add(files[i]+"("+j+")");
                                                StackingParams.vom.Push(tempMat);
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

        private void m_btnOpenTimes_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Text File (*.txt) | *.txt";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string[] timesStr = File.ReadAllLines(openFileDialog.FileName);
                        for (int i = 0; i < timesStr.Length; i++)
                        {
                            StackingParams.times.Push(new float[] { float.Parse(timesStr[i]) });
                        }
                        m_labelLoadTimes.Text = "Success";
                        m_labelLoadTimes.ForeColor = Color.LawnGreen;
                    }
                    openFileDialog.Dispose();
                }
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

        private void m_cbStackingOperation_SelectedIndexChanged(object sender, EventArgs e)
        {
            StackingParams.operation = m_cbStackingOperation.SelectedItem.ToString();
            switch(StackingParams.operation)
            {
                case "Focus":
                    m_tableHDR.Visible = false;
                    m_tableFocus.Visible = true;
                    m_tableFusion.Visible = false;
                    break;
                case "Exposure - Fusion":
                    m_tableHDR.Visible = false;
                    m_tableFocus.Visible = false;
                    m_tableFusion.Visible = true;
                    break;
                case "Exposure - HDR":
                    m_tableHDR.Visible = true;
                    m_tableFocus.Visible = false;
                    m_tableFusion.Visible = false;
                    break;
            }
        }

        private void m_cbToneMappingType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (m_cbToneMappingType.SelectedItem.ToString())
            {
                case "Drago":
                    StackingParams.toneMapParameter = new DragoParams();
                    DragoParamsGUI((DragoParams)StackingParams.toneMapParameter);
                    break;
                case "Durand":
                    StackingParams.toneMapParameter = new DurandParams();
                    DurandParamsGUI((DurandParams)StackingParams.toneMapParameter);
                    break;
                case "Reinhard":
                    StackingParams.toneMapParameter = new ReinhardParams();
                    ReinhardParamsGUI((ReinhardParams)StackingParams.toneMapParameter);
                    break;
                case "Mantiuk":
                    StackingParams.toneMapParameter = new MantiukParams();
                    MantiukParamsGUI((MantiukParams)StackingParams.toneMapParameter);
                    break;
            }
        }

        private void m_nudP1_ValueChanged(object sender, EventArgs e)
        {
            StackingParams.toneMapParameter.gamma = (float)m_nudP1.Value;
        }

        private void m_nudP2_ValueChanged(object sender, EventArgs e)
        {
            switch (StackingParams.toneMapParameter.GetType().Name)
            {
                case "DragoParams":
                    ((DragoParams)StackingParams.toneMapParameter).saturation = (float)m_nudP2.Value;
                    break;
                case "DurandParams":
                    ((DurandParams)StackingParams.toneMapParameter).saturation = (float)m_nudP2.Value;
                    break;
                case "ReinhardParams":
                    ((ReinhardParams)StackingParams.toneMapParameter).intensity = (float)m_nudP2.Value;
                    break;
                case "MantiukParams":
                    ((MantiukParams)StackingParams.toneMapParameter).saturation = (float)m_nudP2.Value;
                    break;
            }
        }

        private void m_nudP3_ValueChanged(object sender, EventArgs e)
        {
            switch (StackingParams.toneMapParameter.GetType().Name)
            {
                case "DragoParams":
                    ((DragoParams)StackingParams.toneMapParameter).bias = (float)m_nudP3.Value;
                    break;
                case "DurandParams":
                    ((DurandParams)StackingParams.toneMapParameter).contrast = (float)m_nudP3.Value;
                    break;
                case "ReinhardParams":
                    ((ReinhardParams)StackingParams.toneMapParameter).light_adapt = (float)m_nudP3.Value;
                    break;
                case "MantiukParams":
                    ((MantiukParams)StackingParams.toneMapParameter).scale = (float)m_nudP3.Value;
                    break;
            }
        }

        private void m_nudP4_ValueChanged(object sender, EventArgs e)
        {
            switch (StackingParams.toneMapParameter.GetType().Name)
            {
                case "DurandParams":
                    ((DurandParams)StackingParams.toneMapParameter).sigma_space = (float)m_nudP4.Value;
                    break;
                case "ReinhardParams":
                    ((ReinhardParams)StackingParams.toneMapParameter).color_adapt = (float)m_nudP4.Value;
                    break;
            }
        }

        private void m_nudP5_ValueChanged(object sender, EventArgs e)
        {
            switch (StackingParams.toneMapParameter.GetType().Name)
            {
                case "DurandParams":
                    ((DurandParams)StackingParams.toneMapParameter).sigma_color = (float)m_nudP5.Value;
                    break;
            }
        }
    }
}
