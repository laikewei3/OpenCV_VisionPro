using Emgu.CV;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace OpenCV_Vision_Pro
{
    public partial class ToolWindow : Form
    {
        public DisplayControl m_displayControl { get; set; }
        public IToolBase m_toolBase;
        private Timer m_timer;
        public static bool runContinue { get; set; } = false;
        public static bool nextImage { get; set; } = false;

        private bool m_boolHasROI = false;
        private BindingSource bindingSource;

        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern bool DestroyIcon(IntPtr handle);

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
            bindingSource = new BindingSource() { DataSource = m_displayControl.m_DisplaySelection };
            m_displayControl.m_cbImages.DataSource = bindingSource;

            splitContainer1.Panel2.Controls.Add(m_displayControl);
            m_toolBase.getGUI();
            tableLayoutPanel1.Controls.Add((Control)m_toolBase.m_toolControl);
            tableLayoutPanel1.SetRow((Control)m_toolBase.m_toolControl, 1);
            m_displayControl.m_roi = m_toolBase.m_toolControl.m_roi;

            m_timer = new Timer();
            m_timer.Start();
            m_timer.Tick += timer1_Tick;
        }

        private void ToolWindow_Load(object sender, EventArgs e)
        {
            m_toolBase.m_toolControl.SetDataSource(m_toolBase.showResult());
            IntPtr iconHandle = m_toolBase.toolIcon.GetHicon();
            Icon icon = Icon.FromHandle(iconHandle);
            this.Icon = (Icon)icon.Clone();
            icon.Dispose();
            DestroyIcon(iconHandle);

            if (m_displayControl.m_bitmapList != null)
            {
                if (m_displayControl.m_bitmapList.Count > 0)
                {
                    Mat image = m_displayControl.m_bitmapList["Current.InputImage"].Clone();
                    m_displayControl.m_display.Width = image.Width;
                    m_displayControl.m_display.Height = image.Height;
                    m_displayControl.m_display.Image = image.Clone();
                    image?.Dispose();
                }
            }
            m_toolBase.m_toolControl.m_roi.m_comboBoxROI.SelectedIndexChanged += m_comboBoxROI_SelectedIndexChanged;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!runContinue)
                m_toolBase.m_bitmapList = m_displayControl.m_bitmapList?.CloneDictionaryCloningValues();
            m_displayControl.m_bitmapList?.Dispose();
            m_toolBase.parameter = m_toolBase.m_toolControl.parameter;
            m_toolBase.m_rectROI = m_displayControl.m_roi.ROIRectangle;
            m_toolBase.parameter.m_roi = m_displayControl.m_roi.Clone();
            m_displayControl.m_roi = null;
            m_toolBase.parameter.m_boolHasROI = m_boolHasROI;
            m_timer.Dispose();
            bindingSource?.Dispose();
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
               m_rectangle = m_toolBase.m_toolControl.m_roi.ROIRectangle;
            
            Mat m_imageProcess = m_displayControl.m_bitmapList["Current.InputImage"].Clone();
            m_toolBase.Run(m_imageProcess, m_rectangle);
            m_toolBase.showResultImages();
            m_toolBase.m_toolControl.SetDataSource(m_toolBase.showResult());
            m_imageProcess?.Dispose();
            int index = m_displayControl.m_cbImages.SelectedIndex;
            m_displayControl.m_cbImages.SelectedIndex = 0;
            m_displayControl.m_cbImages.SelectedIndex = index;
        }

        private void m_comboBoxROI_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox m_cbROI = (ComboBox)sender;
            m_boolHasROI = true;
            
            if (m_displayControl != null)
            {
                m_displayControl.m_display.Invalidate();
                if (m_cbROI.SelectedIndex == 0)
                {
                    m_displayControl.Cursor = Cursors.Default;
                    m_boolHasROI = false;
                    return;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (runContinue || nextImage)
            {
                this.Refresh();
                this.m_displayControl.m_bitmapList = m_toolBase.m_bitmapList?.CloneDictionaryCloningValues();
                this.m_displayControl.m_display.Image?.Dispose();
                this.m_displayControl.m_display.Image = m_toolBase.m_bitmapList[m_displayControl.m_cbImages.SelectedItem.ToString()].Clone();
                m_toolBase.m_toolControl.SetDataSource(m_toolBase.showResult());
                Form1.nextImage = false;
            }
            if (!runContinue)
                this.m_displayControl.m_bitmapList = m_toolBase.m_bitmapList;
        }
    }
}
