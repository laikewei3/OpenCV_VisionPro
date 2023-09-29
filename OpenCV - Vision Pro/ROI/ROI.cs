using Microsoft.CodeAnalysis;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace OpenCV_Vision_Pro
{
    public partial class ROI : UserControl
    {
        private FrameControl frameControl;
        public ROI()
        {
            InitializeComponent();
            m_comboBoxROI.SelectedIndex = 0;
            frameControl = new FrameControl
            {
                Size = new Size(100, 100),
                Location = new Point(0, 0),
                Visible = false
            };
        }

        public FrameControl FrameControl
        {
            get { return frameControl; }
        }

        public int X
        {
            get { return FrameControl.X; }
        }

        public Point location
        {
            set => FrameControl.Location = value;
        }

        public int Y
        {
            get { return FrameControl.Y; }
        }

        public int ROI_Width
        {
            get { return FrameControl.Width; }
            set { FrameControl.Width = value; }
        }

        public int ROI_Height
        {
            get { return FrameControl.Height; }
            set { FrameControl.Height = value; }
        }

        public ROI Clone()
        {
            ROI roi = new ROI();
            roi.location = new Point(X, Y);
            roi.ROI_Height = ROI_Height;
            roi.ROI_Width = ROI_Width;
            return roi;
        }
    }
}
