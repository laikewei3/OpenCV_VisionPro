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
        private double m_rotation = 0;
        private double m_skew = 0;
        private FrameControl frameControl = new FrameControl();
        public ROI()
        {
            InitializeComponent();
            m_comboBoxROI.SelectedIndex = 0;
            frameControl.Size = new Size(100, 100);
            frameControl.Location = new Point(0, 0);
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

        public double ROI_rotation
        {
            get { return m_rotation; }
            set
            {
                m_rotation = value;
                Invalidate();
            }
        }

        public double ROI_skew
        {
            get { return m_skew; }
            set
            {
                m_skew = value;
                Invalidate();
            }
        }
    }
}
