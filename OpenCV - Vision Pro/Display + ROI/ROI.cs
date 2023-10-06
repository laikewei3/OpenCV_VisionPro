using Microsoft.CodeAnalysis;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace OpenCV_Vision_Pro
{
    public partial class ROI : UserControl
    {
        private Rectangle roiRectangle;
        public ROI()
        {
            InitializeComponent();
            m_comboBoxROI.SelectedIndex = 0;
            ROIRectangle = new Rectangle(0, 0, 100, 100);
        }

        public Rectangle ROIRectangle
        {
            get { return roiRectangle; }
            set { roiRectangle = value; }
        }

        public int X
        {
            get { return roiRectangle.X; }
            set => roiRectangle.X = value;
        }

        public Point location
        {
            set => roiRectangle.Location = value;
        }

        public int Y
        {
            get { return roiRectangle.Y; }
            set => roiRectangle.Y = value;
        }

        public int ROI_Width
        {
            get { return roiRectangle.Width; }
            set { roiRectangle.Width = value; }
        }

        public int ROI_Height
        {
            get { return roiRectangle.Height; }
            set { roiRectangle  .Height = value; }
        }

        public Point[] polygonPoint { get; set; }

        public ROI Clone()
        {
            ROI roi = new ROI
            {
                location = new Point(X, Y),
                ROI_Height = ROI_Height,
                ROI_Width = ROI_Width,
                polygonPoint = polygonPoint
            };
            return roi;
        }
    }
}
