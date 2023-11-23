using Emgu.CV;
using OpenCV_Vision_Pro.Interface;
using Python.Runtime;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace OpenCV_Vision_Pro.Tools.ImageProcess.ProcessTool
{
    public partial class SuperResolutionToolControl : UserControl, IUserControlBase
    {
        public ROI m_roi { get { return SuperResolutionParams.m_roi; } }
        public IParams parameter { get; set; }
        public SuperResolutionParams SuperResolutionParams { get; private set; }

        public SuperResolutionToolControl(IParams SuperResolutionParams)
        {
            InitializeComponent();
            parameter = SuperResolutionParams;
            this.SuperResolutionParams = (SuperResolutionParams)parameter;
            bicubicToolStripMenuItem.Click += m_modeSelection;
            edsrToolStripMenuItem.Click += m_modeSelection;
            espcnToolStripMenuItem.Click += m_modeSelection;
            fsrcnnToolStripMenuItem.Click += m_modeSelection;
            lapsrnToolStripMenuItem.Click += m_modeSelection;
        }

        private void m_rbX_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
                SuperResolutionParams.SuperResolutionMode = ((RadioButton)sender).Text;
        }

        private void SuperResolution_Load(object sender, EventArgs e)
        {
            m_tbWidth.LostFocus += m_tbTextChanged;
            m_tbHeight.LostFocus += m_tbTextChanged;
            if (SuperResolutionParams.resizeSize.IsEmpty)
            {
                Mat img = ((ToolWindow)this.ParentForm).m_displayControl.m_bitmapList["Current.InputImage"];
                if (!img.IsEmpty)
                    SuperResolutionParams.resizeSize = new Size(img.Width, img.Height);
            }
            m_tbHeight.Text = SuperResolutionParams.resizeSize.Height.ToString();
            m_tbWidth.Text = SuperResolutionParams.resizeSize.Width.ToString();
            m_tbUpScale.Text = SuperResolutionParams.upscale.ToString();

            m_btnMode.Text += SuperResolutionParams.SuperResolutionMode;

            ((ToolStripMenuItem)tradisionalToolStripMenuItem.DropDownItems[SuperResolutionParams.SuperResolutionMode.ToLower() + "ToolStripMenuItem"])?.PerformClick();
            ((ToolStripMenuItem)superResolutionToolStripMenuItem.DropDownItems[SuperResolutionParams.SuperResolutionMode.ToLower() + "ToolStripMenuItem"])?.PerformClick();
            if (SuperResolutionParams.maintainRatio)
                m_cbRatio.Checked = true;
            else
                m_cbRatio.Checked = false;
        }

        private void m_modeSelection(object sender, EventArgs e)
        {
            string text = ((ToolStripMenuItem)sender).Text;
            m_btnMode.Text = "Selected Mode: " + text;
            SuperResolutionParams.SuperResolutionMode = text;
        }

        private void m_modeSelectionT(object sender, EventArgs e)
        {
            m_tableTradisional.Visible = true;
            m_panelTradisional.Visible = true;
            m_panelSuper.Visible = false;
        }

        private void m_modeSelectionS(object sender, EventArgs e)
        {
            m_tableTradisional.Visible = false;
            m_panelTradisional.Visible = false;
            m_panelSuper.Visible = true;
        }

        private void m_tbTextChanged(object sender, EventArgs e)
        {   
            try
            {
                if (SuperResolutionParams.maintainRatio)
                {
                    TextBox tb = (TextBox)sender;
                    int value0 = int.Parse(tb.Text);
                    Mat img = ((ToolWindow)this.ParentForm).m_displayControl.m_bitmapList["Current.InputImage"];
                    if (!img.IsEmpty)
                    {
                        Size size = img.Size;
                        if (tb.Name == m_tbWidth.Name)
                        {
                            double scale = (double)value0 / size.Width;
                            int height = (int)(scale * size.Height);
                            SuperResolutionParams.resizeSize = new Size(value0, height);
                            m_tbHeight.Text = height.ToString();
                        }
                        else
                        {
                            double scale = (double)value0 / size.Height;
                            int width = (int)(scale * size.Width);
                            SuperResolutionParams.resizeSize = new Size(width,value0);
                            m_tbWidth.Text = width.ToString();
                        }
                        return;
                    }
                    else
                        MessageBox.Show("No Input Image");
                }
                
                SuperResolutionParams.resizeSize = new Size(int.Parse(m_tbWidth.Text), int.Parse(m_tbHeight.Text));

            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid Input!\n" + ex.ToString());
            }
        }

        private void m_btnInitialSize_Click(object sender, EventArgs e)
        {   
            Mat img = ((ToolWindow)this.ParentForm).m_displayControl.m_bitmapList["Current.InputImage"];
            if (!img.IsEmpty)
            {
                SuperResolutionParams.resizeSize = new Size(img.Width, img.Height);
                m_tbHeight.Text = SuperResolutionParams.resizeSize.Height.ToString();
                m_tbWidth.Text = SuperResolutionParams.resizeSize.Width.ToString();
            }
            else
                MessageBox.Show("No input image");

        }

        private void m_cbRatio_CheckedChanged(object sender, EventArgs e)
        {
            if (m_cbRatio.Checked)
                SuperResolutionParams.maintainRatio = true;
            else
                SuperResolutionParams.maintainRatio = false;
        }

        private void m_btnMode_Click(object sender, EventArgs e)
        {
            m_mode.Show(m_btnMode,0,m_btnMode.Height);
        }

        private void m_tbUpScale_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SuperResolutionParams.upscale = int.Parse(m_tbUpScale.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Integer Input Only.\n"+ex.ToString());
                m_tbUpScale.Text = SuperResolutionParams.upscale.ToString();
            }
        }
    }
}
