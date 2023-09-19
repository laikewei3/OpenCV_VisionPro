using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenCV_Vision_Pro
{
    public partial class ROI : UserControl
    {
        private FrameControl frameControl;
        public DisplayControl m_displayControl { get; set; }

        public ROI()
        {
            InitializeComponent();
            m_comboBoxROI.SelectedIndex = 0;
            frameControl = new FrameControl();
            frameControl.Size = new Size(100, 100);
            frameControl.Location = new Point(0, 0);
            frameControl.Visible = false;
        }

        public Rectangle ROI_Region
        {
            get
            {
               return new Rectangle(X, Y, ROI_Width, ROI_Height);
            }
        }

        public FrameControl FrameControl
        {
            get { return frameControl; }
        }

        public int X
        {
            get { return FrameControl.X; }
        }

        public int Y
        {
            get { return FrameControl.Y; }
        }

        public int ROI_Width
        {
            get { return FrameControl.Width; }
        }

        public int ROI_Height
        {
            get { return FrameControl.Height; }
        }

        private void m_comboBoxROI_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox m_cbROI = (ComboBox)sender;
            if(m_displayControl != null )
            {
                FrameControl.Visible = false;
                if (m_cbROI.SelectedIndex == 0)
                {
                    m_displayControl.m_display.Controls.Clear();
                    return;
                }
                m_displayControl.m_display.Controls.Add(FrameControl);
                if (m_displayControl.m_cbImages.SelectedItem != null)
                {
                    if (m_displayControl.m_cbImages.SelectedItem.ToString() == "Current.InputImage")
                        FrameControl.Visible = true;
                    else
                        FrameControl.Visible = false;
                }

            }
        }
    }
}
