using Emgu.CV;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace OpenCV_Vision_Pro
{
    public partial class ToolWindow : Form
    {
        public DisplayControl m_displayControl { get; set; }
        private IToolBase m_toolBase;
        private Timer m_timer;
        public static bool runContinue { get; set; } = false;
        private bool m_boolHasROI = false;
        
        public ToolWindow(IToolBase tool)
        {
            m_toolBase = tool;
            InitializeComponent();
            m_displayControl = new DisplayControl
            {
                Dock = DockStyle.Fill,
                m_DisplaySelection = m_toolBase.m_DisplaySelection,
                m_bitmapList = m_toolBase.m_bitmapList
            };
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = m_displayControl.m_DisplaySelection;
            m_displayControl.m_cbImages.DataSource = bindingSource;
            splitContainer1.Panel2.Controls.Add(m_displayControl);
            m_toolBase.getGUI();
            tableLayoutPanel1.Controls.Add(m_toolBase.m_toolControl);
            tableLayoutPanel1.SetRow(m_toolBase.m_toolControl, 1);

            m_toolBase.m_toolControl.m_roi.FrameControl.m_displayControlSize = m_displayControl.m_display.Size;
            m_toolBase.m_toolControl.m_roi.m_comboBoxROI.SelectedIndexChanged += m_comboBoxROI_SelectedIndexChanged;
        }

        private void ToolWindow_Load(object sender, EventArgs e)
        {
            m_toolBase.m_toolControl.SetDataSource((BindingSource)m_toolBase.showResult());

            if (runContinue)
            {
                m_timer = new Timer();
                m_timer.Tick += timer1_Tick;
                m_timer.Start();
            }

            if (m_displayControl.m_bitmapList != null)
            {
                if (m_displayControl.m_bitmapList.Count > 0)
                {
                    Mat image = m_displayControl.m_bitmapList["Current.InputImage"];
                    m_displayControl.m_display.Width = image.Width;
                    m_displayControl.m_display.Height = image.Height;
                    m_displayControl.m_display.Image = image;
                }
            }

            m_displayControl.m_roi = m_toolBase.m_toolControl.m_roi;
            
            if (m_toolBase.m_toolControl.m_roi.m_comboBoxROI.SelectedIndex != 0)
                m_toolBase.m_toolControl.m_roi.FrameControl.Visible = true;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!runContinue)
                m_toolBase.m_bitmapList = m_displayControl.m_bitmapList?.CloneDictionaryCloningValues();
            m_displayControl.m_bitmapList?.Dispose();
            m_toolBase.parameter = m_toolBase.m_toolControl.parameter;
            m_toolBase.m_rectROI = m_displayControl.m_roi.FrameControl.getRegionRect();
            m_toolBase.parameter.m_roi = m_displayControl.m_roi.Clone();
            m_displayControl.m_roi = null;
            m_toolBase.parameter.m_boolHasROI = m_boolHasROI;

            base.OnFormClosing(e);
        }

        public void m_RunToolBtn_Click(object sender, EventArgs e)
        {
            if (m_displayControl.m_display.Image == null)
            {
                MessageBox.Show("No Input Image");
                return;
            }

            Rectangle m_rectangle;
            if (m_displayControl.m_roi.m_comboBoxROI.SelectedIndex == 0)
                m_rectangle = new Rectangle();
            else
                m_rectangle = m_toolBase.m_toolControl.m_roi.FrameControl.getRegionRect();

            m_toolBase.Run(m_displayControl.m_bitmapList["Current.InputImage"], m_rectangle);
            m_toolBase.showResultImages();
            m_toolBase.m_toolControl.SetDataSource((BindingSource)m_toolBase.showResult());
            int index = m_displayControl.m_cbImages.SelectedIndex;
            m_displayControl.m_cbImages.SelectedIndex = 0;
            m_displayControl.m_cbImages.SelectedIndex = index;
        }
        /*
        
        private void m_dgvBlobResults_SelectionChanged(object sender, EventArgs e)
        {
            if (m_displayControl.m_cbImages.SelectedItem.ToString() != "LastRun." + this.Text + ".BlobImage") { return; }
            try
            {
                m_displayControl.m_display.Image = blobToolControl.resultSelectedImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private void m_CaliperRes_SelectionChanged(object sender, EventArgs e)
        {
            if (m_displayControl.m_cbImages.SelectedItem.ToString() != "LastRun." + this.Text + ".Caliper") { return; }
            try
            {
                m_displayControl.m_display.Image = caliperToolControl.resultSelectedImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }*/
        private void m_comboBoxROI_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox m_cbROI = (ComboBox)sender;
            m_boolHasROI = true;
            if (m_displayControl != null)
            {
                m_toolBase.m_toolControl.m_roi.FrameControl.Visible = false;
                if (m_cbROI.SelectedIndex == 0)
                {
                    m_displayControl.m_display.Controls.Clear();
                    m_boolHasROI = false;
                    return;
                }
                m_displayControl.m_display.Controls.Add(m_toolBase.m_toolControl.m_roi.FrameControl);
                if (m_displayControl.m_cbImages.SelectedItem != null)
                {
                    if (m_displayControl.m_cbImages.SelectedItem.ToString() == "Current.InputImage")
                        m_toolBase.m_toolControl.m_roi.FrameControl.Visible = true;
                    else
                        m_toolBase.m_toolControl.m_roi.FrameControl.Visible = false;
                }
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            // When the Timer ticks, simulate a click on Button
            this.Refresh();
            Console.WriteLine("Reload");
            if (!runContinue)
            {
                m_timer.Stop();
            }
        }

    }
}
