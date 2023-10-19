using System;
using System.Linq;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Media.Media3D;

namespace OpenCV_Vision_Pro
{
    public partial class ROI : UserControl
    {
        private Rectangle roiRectangle;
        public class PointCoord : INotifyPropertyChanged
        {
            private int X;
            private int Y;
            
            public PointCoord(int X, int Y)
            {
                this.CoordX = X;
                this.CoordY = Y;
            }

            public PointCoord() { }
            public int CoordX { get { return X; } set { X = value; NotifyPropertyChanged("CoordX"); } }
            public int CoordY { get { return Y; } set { Y = value; NotifyPropertyChanged("CoordY"); } }

            public event PropertyChangedEventHandler PropertyChanged;
            private void NotifyPropertyChanged(string p)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(p));
            }
        }

        public BindingList<PointCoord> polygonPoint { get; set; }
        public Point[] points {  get; set; }
        private BindingSource bs;
        public ROI()
        {
            InitializeComponent();
            m_comboBoxROI.SelectedIndex = 0;
            ROIRectangle = new Rectangle(0, 0, 100, 100);
            polygonPoint = new BindingList<PointCoord> { new PointCoord(0, 0), new PointCoord(100, 0), new PointCoord(100, 100), new PointCoord(0, 100) };
            bs = new BindingSource() { DataSource = polygonPoint };
            m_PointTable.DataSource = bs;
            polygonPoint.RaiseListChangedEvents = true;
            polygonPoint.ListChanged += pointListChanged;
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

        public ROI Clone()
        {
            ROI roi = new ROI
            {
                location = new Point(X, Y),
                ROI_Height = ROI_Height,
                ROI_Width = ROI_Width,
                polygonPoint = polygonPoint,
                points = points
            };
            return roi;
        }

        private void m_comboBoxROI_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_comboBoxROI.SelectedIndex == 2)
            {
                bs = new BindingSource() { DataSource = polygonPoint };
                m_PointTable.DataSource = bs;
                points = polygonPoint.Select(p => new Point(p.CoordX, p.CoordY)).ToArray();
                m_PointTable.Visible = true;
                flowLayoutPanel3.Visible = true;
            }
            else
            {
                points = null;
                m_PointTable.Visible = false;
                flowLayoutPanel3.Visible = false;
            }
        }

        private void m_btnAddPoint_Click(object sender, EventArgs e)
        {
            polygonPoint.Add(new PointCoord(0, 0));
            m_PointTable.Refresh();
            points = polygonPoint.Select(p => new Point(p.CoordX, p.CoordY)).ToArray();
        }

        private void pointListChanged(object sender, ListChangedEventArgs e)
        {
            points = polygonPoint.Select(p => new Point(p.CoordX, p.CoordY)).ToArray();
            m_PointTable.Refresh();
        }
    }
}
