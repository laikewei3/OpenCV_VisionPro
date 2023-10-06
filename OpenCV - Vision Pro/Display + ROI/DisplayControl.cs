using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Util;
using OpenCV_Vision_Pro.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace OpenCV_Vision_Pro
{
    public partial class DisplayControl : UserControl
    {
        public VideoCapture m_VideoCapture { get; set; }
        public AutoDisposeDict<string, Mat> m_bitmapList { get; set; }
        public ROI m_roi { get; set; }
        public BindingList<string> m_DisplaySelection { get; set; }
        
        private bool m_boolPlay = true;
        public bool playing
        {
            get { return m_boolPlay; }
            set
            {
                m_boolPlay = value;
                if (m_boolPlay)
                    m_playPauseButton.Image = Resources.pause;
                else
                    m_playPauseButton.Image = Resources.play;
            }
        }
        
        // ROI
        private Rectangle oldRect;
        private int dragHandle = 0;
        private Point dragPoint;

        public DisplayControl()
        {
            InitializeComponent();
            panel2.MouseWheel += panel2_MouseWheel;
            CenterPictureBox();
            DoubleBuffered = true;
            m_playPauseButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(50, 0, 0, 0);
            m_playPauseButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 0, 0, 0);
        }

        private void m_cbImages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_VideoCapture == null)
            {
                if (m_cbImages.SelectedItem == null) return;
                string m_strSelectedItem = m_cbImages.SelectedItem.ToString();
                Mat selectedImage = null;
                if (m_bitmapList.ContainsKey(m_strSelectedItem))
                {
                    selectedImage?.Dispose();
                    selectedImage = m_bitmapList[m_strSelectedItem].Clone();
                    m_display.Width = selectedImage.Width;
                    m_display.Height = selectedImage.Height;
                }

                m_display.Image = selectedImage;
                CenterPictureBox();
            }
        }

        /*
        /// <summary>https://stackoverflow.com/a/24199315/1115360
        /// Resize the image to the specified width and height.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        private Mat ResizeImage(Mat image, int width, int height)
        {
             //use Image as input Image
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }
        Mat destImage = new Mat();
            CvInvoke.Resize(image, destImage, new Size(width, height));
            return destImage;
        }*/
        private void resize(object sender, EventArgs e)
        {
            CenterPictureBox();
        }

        private void panel2_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta != 0 && m_display.Image != null)
            {
                if (e.Delta <= 0)
                {
                    //set minimum size to zoom
                    if (m_display.Width < 10 || m_display.Height < 10)
                        return;
                }
                else
                {
                    //set maximum size to zoom
                    if (m_display.Width > 5000 || m_display.Height > 5000)
                        return;
                }

                if (m_roi != null)
                {
                    if (m_roi.ROIRectangle.Width < 10 || m_roi.ROIRectangle.Height < 10)
                        return;
                    m_roi.ROI_Width += Convert.ToInt32(m_roi.ROIRectangle.Width * e.Delta / 1000);
                    m_roi.ROI_Height += Convert.ToInt32(m_roi.ROIRectangle.Height * e.Delta / 1000);
                    m_roi.X += Convert.ToInt32(m_roi.ROIRectangle.X * e.Delta / 1000);
                    m_roi.Y += Convert.ToInt32(m_roi.ROIRectangle.Y * e.Delta / 1000);
                }

                m_display.Width += Convert.ToInt32(m_display.Width * e.Delta / 1000);
                m_display.Height += Convert.ToInt32(m_display.Height * e.Delta / 1000);
                CenterPictureBox();
            }
        }

        private void CenterPictureBox()
        {
            panel2.AutoScrollPosition = new Point((m_display.Parent.ClientSize.Width + m_display.Width / 2),
                                        m_display.Parent.ClientSize.Height / 2 + m_display.Height / 2);

            m_display.Location = new Point((m_display.Parent.ClientSize.Width / 2 - m_display.Width / 2),
                                        (m_display.Parent.ClientSize.Height / 2 - m_display.Height / 2));
            m_display.Refresh();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED       
                return cp;
            }
        }

        private void m_trackBarVideoDuration_Scroll(object sender, EventArgs e)
        {
            if (m_VideoCapture != null)
            {
                m_VideoCapture.Set(CapProp.PosFrames, m_trackBarVideoDuration.Value);

                TimeSpan t = TimeSpan.FromSeconds(m_trackBarVideoDuration.Value / m_VideoCapture.Get(CapProp.Fps));

                string answer = string.Format("{0:D2}h:{1:D2}m:{2:D2}s",
                                t.Hours,
                                t.Minutes,
                                t.Seconds);

                m_toolTipTrackBar.SetToolTip(m_trackBarVideoDuration, answer);
            }
        }

        private void m_trackBarVideoDuration_ValueChanged(object sender, EventArgs e)
        {
            if (m_VideoCapture != null)
            {
                TimeSpan t = TimeSpan.FromSeconds(m_trackBarVideoDuration.Value / m_VideoCapture.Get(CapProp.Fps));

                string answer = string.Format("{0:D2}:{1:D2}:{2:D2}",
                                t.Hours,
                                t.Minutes,
                                t.Seconds);

                m_labelCurrentTime.Text = answer;
            }

        }

        private void panel1_VisibleChanged(object sender, EventArgs e)
        {
            if (m_VideoCapture != null)
            {
                TimeSpan t = TimeSpan.FromSeconds(m_VideoCapture.Get(CapProp.FrameCount) / m_VideoCapture.Get(CapProp.Fps));

                string answer = string.Format("{0:D2}:{1:D2}:{2:D2}",
                                t.Hours,
                                t.Minutes,
                                t.Seconds);

                m_labelTotalTime.Text = " / " + answer;
            }
        }

        
        // ROI METHODS
        private Point GetHandlePoint(int value)
        {
            Point result = Point.Empty;
            if (m_roi != null)
            {
                if (value == 1)
                    result = new Point(m_roi.ROIRectangle.Left, m_roi.ROIRectangle.Top);
                else if (value == 2)
                    result = new Point(m_roi.ROIRectangle.Left, m_roi.ROIRectangle.Top + (m_roi.ROIRectangle.Height / 2));
                else if (value == 3)
                    result = new Point(m_roi.ROIRectangle.Left, m_roi.ROIRectangle.Bottom);
                else if (value == 4)
                    result = new Point(m_roi.ROIRectangle.Left + (m_roi.ROIRectangle.Width / 2), m_roi.ROIRectangle.Top);
                else if (value == 5)
                    result = new Point(m_roi.ROIRectangle.Left + (m_roi.ROIRectangle.Width / 2), m_roi.ROIRectangle.Bottom);
                else if (value == 6)
                    result = new Point(m_roi.ROIRectangle.Right, m_roi.ROIRectangle.Top);
                else if (value == 7)
                    result = new Point(m_roi.ROIRectangle.Right, m_roi.ROIRectangle.Top + (m_roi.ROIRectangle.Height / 2));
                else if (value == 8)
                    result = new Point(m_roi.ROIRectangle.Right, m_roi.ROIRectangle.Bottom);
            }
            return result;
        }

        private Rectangle GetHandleRect(int value)
        {
            Point p = GetHandlePoint(value);
            p.Offset(-2, -2);
            return new Rectangle(p, new Size(5, 5));
        }

        private void m_display_Paint(object sender, PaintEventArgs e)
        {
            if (m_roi != null)
            {
                if (m_cbImages.SelectedIndex == 0 && m_roi.m_comboBoxROI.SelectedIndex == 1)
                {
                    m_roi.polygonPoint = null;
                    using (Brush cornerP = new SolidBrush(Color.DarkRed))
                    using (Pen p = new Pen(Color.DeepSkyBlue, 2) { DashStyle = DashStyle.Dash })
                    {
                        e.Graphics.DrawRectangle(p, m_roi.ROIRectangle);
                        for (int i = 1; i < 9; i++)
                        {
                            e.Graphics.FillRectangle(cornerP, GetHandleRect(i));
                        }
                    }
                }
                else if (m_cbImages.SelectedIndex == 0 && m_roi.m_comboBoxROI.SelectedIndex == 2)
                {
                    using (GraphicsPath path = new GraphicsPath())
                    {
                        VectorOfPoint vop = new VectorOfPoint();
                        
                        Point[] points = new Point[] {
    new Point(48, 81),
    new Point(32, 26),
    new Point(255, 145),
    new Point(48, 22),
    };

                        path.StartFigure();
                        path.AddPolygon(points);
                        path.CloseFigure();
                        e.Graphics.DrawPath(new Pen(Color.Black, 2), path);

                        Region myRegion = new Region(path);
                        Rectangle rect = Rectangle.Round(myRegion.GetBounds(e.Graphics));
                        e.Graphics.DrawRectangle(Pens.Red, rect);
                        m_roi.ROIRectangle = rect;
                        m_roi.polygonPoint = points;
                    };
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    m_display.Invalidate();
                }
            }
            base.OnPaint(e);
        }

        private void m_display_MouseDown(object sender, MouseEventArgs e)
        {
            bool move = true;
            base.OnMouseDown(e);
            for (int i = 1; i < 9; i++)
            {
                if (GetHandleRect(i).Contains(e.Location))
                {
                    dragHandle = i;
                    oldRect = m_roi.ROIRectangle;
                    dragPoint = GetHandlePoint(i);
                    move = false;
                }
            }
            if (move)
            {
                if (m_roi.ROIRectangle.Contains(e.Location))
                {
                    dragHandle = 10;
                    oldRect = m_roi.ROIRectangle;
                    dragPoint = new Point(e.Location.X, e.Location.Y);
                }
            }
        }

        private void m_display_MouseUp(object sender, MouseEventArgs e)
        {
            dragHandle = 0;
            base.OnMouseUp(e);
        }

        private void m_display_MouseMove(object sender, MouseEventArgs e)
        {
            if (m_roi != null)
            {
                int diffX = dragPoint.X - e.Location.X;
                int diffY = dragPoint.Y - e.Location.Y;
                Rectangle rectangle = new Rectangle();
                if (dragHandle > 0)
                {
                    switch (dragHandle)
                    {
                        case 1: //TOP LEFT
                            if (oldRect.Left - diffX < 0)
                            {
                                rectangle.X = 0;
                                rectangle.Width = oldRect.Right;
                            }
                            else
                            {
                                rectangle.X = oldRect.Left - diffX;
                                rectangle.Width = oldRect.Width + diffX;
                            }

                            if (oldRect.Top - diffY < 0)
                            {
                                rectangle.Y = 0;
                                rectangle.Height = oldRect.Bottom;
                            }
                            else
                            {
                                rectangle.Y = oldRect.Top - diffY;
                                rectangle.Height = oldRect.Height + diffY;
                            }
                            m_roi.ROIRectangle = rectangle;
                            break;
                        case 2: // MIDDLE LEFT
                            if (oldRect.Left - diffX < 0)
                            {
                                rectangle.X = 0;
                                rectangle.Width = oldRect.Right;
                            }
                            else
                            {
                                rectangle.X = oldRect.Left - diffX;
                                rectangle.Width = oldRect.Width + diffX;
                            }
                            rectangle.Y = oldRect.Top;
                            rectangle.Height = oldRect.Height;
                            m_roi.ROIRectangle = rectangle;
                            break;
                        case 3: // BOTTOM LEFT
                            if (oldRect.Left - diffX < 0)
                            {
                                rectangle.X = 0;
                                rectangle.Width = oldRect.Right;
                            }
                            else
                            {
                                rectangle.X = oldRect.Left - diffX;
                                rectangle.Width = oldRect.Width + diffX;
                            }

                            rectangle.Y = oldRect.Top;
                            if (oldRect.Bottom - diffY >= m_display.Height)
                                rectangle.Height = m_display.Height - oldRect.Top;
                            else
                                rectangle.Height = oldRect.Height - diffY;
                            m_roi.ROIRectangle = rectangle;
                            break;
                        case 4:
                            rectangle.X = oldRect.Left;
                            rectangle.Width = oldRect.Width;

                            if (oldRect.Top - diffY < 0)
                            {
                                rectangle.Y = 0;
                                rectangle.Height = oldRect.Bottom;
                            }
                            else
                            {
                                rectangle.Y = oldRect.Top - diffY;
                                rectangle.Height = oldRect.Height + diffY;
                            }
                            m_roi.ROIRectangle = rectangle;
                            break;
                        case 5:
                            rectangle.X = oldRect.Left;
                            rectangle.Width = oldRect.Width;

                            rectangle.Y = oldRect.Top;
                            if (oldRect.Bottom - diffY >= m_display.Height)
                                rectangle.Height = m_display.Height - oldRect.Top;
                            else
                                rectangle.Height = oldRect.Height - diffY;
                            m_roi.ROIRectangle = rectangle;
                            break;
                        case 6:
                            rectangle.X = oldRect.Left;
                            if (oldRect.Right - diffX >= m_display.Width)
                                rectangle.Width = m_display.Width - oldRect.Left;
                            else
                                rectangle.Width = oldRect.Width - diffX;

                            if (oldRect.Top - diffY < 0)
                            {
                                rectangle.Y = 0;
                                rectangle.Height = oldRect.Bottom;
                            }
                            else
                            {
                                rectangle.Y = oldRect.Top - diffY;
                                rectangle.Height = oldRect.Height + diffY;
                            }
                            m_roi.ROIRectangle = rectangle;
                            break;
                        case 7:
                            rectangle.X = oldRect.Left;
                            if (oldRect.Right - diffX >= m_display.Width)
                                rectangle.Width = m_display.Width - oldRect.Left;
                            else
                                rectangle.Width = oldRect.Width - diffX;
                            rectangle.Y = oldRect.Top;
                            rectangle.Height = oldRect.Height;

                            m_roi.ROIRectangle = rectangle;
                            break;
                        case 8:
                            rectangle.X = oldRect.Left;
                            rectangle.Y = oldRect.Top;
                            if (oldRect.Right - diffX >= m_display.Width)
                                rectangle.Width = m_display.Width - oldRect.Left;
                            else
                                rectangle.Width = oldRect.Width - diffX;

                            if (oldRect.Bottom - diffY >= m_display.Height)
                                rectangle.Height = m_display.Height - oldRect.Top;
                            else
                                rectangle.Height = oldRect.Height - diffY;

                            m_roi.ROIRectangle = rectangle;
                            break;
                        case 10:
                            diffX = dragPoint.X - oldRect.X;
                            diffY = dragPoint.Y - oldRect.Y;
                            int finalX = e.Location.X - diffX;
                            int finalY = e.Location.Y - diffY;
                            if (finalX < 0)
                                m_roi.X = 0;
                            else if (finalX + m_roi.ROIRectangle.Width < m_display.Width)
                                m_roi.X = finalX;

                            if (finalY < 0)
                                m_roi.Y = 0;
                            else if (finalY + m_roi.Height < m_display.Height)
                                m_roi.Y = finalY;
                            break;
                        default: break;
                    }
                    this.Invalidate();
                }
                if (m_cbImages.SelectedIndex == 0 && m_roi.m_comboBoxROI.SelectedIndex != 0)
                {
                    bool inRect = false;
                    if (m_roi.ROIRectangle.Contains(e.Location))
                    {
                        this.Cursor = Cursors.SizeAll;
                        inRect = true;
                    }

                    for (int i = 1; i < 9; i++)
                    {
                        if (GetHandleRect(i).Contains(e.Location))
                        {
                            if (i == 1 || i == 8)
                                this.Cursor = Cursors.SizeNWSE;
                            else if (i == 2 || i == 7)
                                this.Cursor = Cursors.SizeWE;
                            else if (i == 3 || i == 6)
                                this.Cursor = Cursors.SizeNESW;
                            else if (i == 4 || i == 5)
                                this.Cursor = Cursors.SizeNS;
                            break;
                        }
                    }

                    if (!inRect) { this.Cursor = Cursors.Default; }

                }
            }
            base.OnMouseMove(e);
        }
    }
}
