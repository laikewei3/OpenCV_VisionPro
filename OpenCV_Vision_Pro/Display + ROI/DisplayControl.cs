using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using ICSharpCode.SharpZipLib.Zip;
using OpenCV_Vision_Pro.Properties;
using OpenCV_Vision_Pro.Tools.ImageProcess.ProcessTool;
using OpenCV_Vision_Pro.Tools.PolarUnWrap;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Mime;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static OpenCV_Vision_Pro.ROI;

namespace OpenCV_Vision_Pro
{
    public partial class DisplayControl : UserControl
    {
        public ITool toolBase { get; set; }

        private bool drawLines = false;

        public VideoCapture m_VideoCapture { get; set; }
        public AutoDisposeDict<string, Mat> m_bitmapList { get; set; }
        public ROI m_roi { get; set; }

        public ColorTools m_colorTools { get; set; }

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
        private string moveType = "";
        private Rectangle oldRect;
        private int dragHandle = -1;
        private Point dragPoint;
        public int[] zoom { get; set; } = new int[4];

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
                if (m_roi != null && m_cbImages.SelectedIndex == 0)
                {
                    m_roi.X -= zoom[0];
                    m_roi.Y -= zoom[1];
                    m_roi.ROI_Width -= zoom[2];
                    m_roi.ROI_Height -= zoom[3];
                    zoom = new int[4];
                }
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

                if (m_roi != null && m_cbImages.SelectedIndex == 0)
                {
                    if (m_roi.ROIRectangle.Width < 10 || m_roi.ROIRectangle.Height < 10)
                        return;

                    Int32 Width = Convert.ToInt32(m_roi.ROIRectangle.Width * e.Delta / 1000);
                    Int32 Height = Convert.ToInt32(m_roi.ROIRectangle.Height * e.Delta / 1000);
                    Int32 X = Convert.ToInt32(m_roi.ROIRectangle.X * e.Delta / 1000);
                    Int32 Y = Convert.ToInt32(m_roi.ROIRectangle.Y * e.Delta / 1000);
                    m_roi.X += X; zoom[0] += X;
                    m_roi.Y += Y; zoom[1] += Y;
                    m_roi.ROI_Width += Width; zoom[2] += Width;
                    m_roi.ROI_Height += Height; zoom[3] += Height;
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
        private Point GetHandlePoint(Rectangle rect, int value)
        {
            Point result = Point.Empty;

            if (value == 1)
                result = new Point(rect.Left, rect.Top);
            else if (value == 2)
                result = new Point(rect.Left, rect.Top + (rect.Height / 2));
            else if (value == 3)
                result = new Point(rect.Left, rect.Bottom);
            else if (value == 4)
                result = new Point(rect.Left + (rect.Width / 2), rect.Top);
            else if (value == 5)
                result = new Point(rect.Left + (rect.Width / 2), rect.Bottom);
            else if (value == 6)
                result = new Point(rect.Right, rect.Top);
            else if (value == 7)
                result = new Point(rect.Right, rect.Top + (rect.Height / 2));
            else if (value == 8)
                result = new Point(rect.Right, rect.Bottom);

            return result;
        }

        private Rectangle GetHandleRect(Rectangle rect, int value)
        {
            Point p = GetHandlePoint(rect, value);
            p.Offset(-2, -2);
            return new Rectangle(p, new Size(5, 5));
        }

        private void m_display_Paint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);
            m_display.Invalidate();
            if (m_display.Image == null)
                return;

            if (m_roi != null)
            {
                if (m_cbImages.SelectedIndex == 0 && m_roi.m_comboBoxROI.SelectedItem?.ToString() == "CogRectangle")
                {
                    m_roi.points = null;
                    using (Brush cornerP = new SolidBrush(Color.DarkRed))
                    using (Pen p = new Pen(Color.DeepSkyBlue, 2) { DashStyle = DashStyle.Dash })
                    {
                        e.Graphics.DrawRectangle(p, m_roi.ROIRectangle);
                        if (this.ParentForm.Text.StartsWith("ImagePolarUnWrapTool"))
                        {
                            Pen pen = new Pen(Color.Yellow, 1);
                            e.Graphics.DrawEllipse(pen, m_roi.ROIRectangle);
                            Rectangle innerRect = m_roi.ROIRectangle;
                            int circlewidth = ((PolarUnWrapParams)toolBase.parameter).lineheight;
                            innerRect.X += circlewidth;
                            innerRect.Y += circlewidth;
                            innerRect.Width -= circlewidth * 2;
                            innerRect.Height -= circlewidth * 2;
                            e.Graphics.DrawEllipse(pen, innerRect);
                            pen.Dispose();
                        }
                        for (int i = 1; i < 9; i++)
                        {
                            e.Graphics.FillRectangle(cornerP, GetHandleRect(m_roi.ROIRectangle, i));
                        }
                        cornerP.Dispose();
                        p.Dispose();
                    }
                }
                else if (m_cbImages.SelectedIndex == 0 && m_roi.m_comboBoxROI.SelectedItem?.ToString() == "CogPolygon")
                {
                    using (GraphicsPath path = new GraphicsPath())
                    {
                        m_roi.points = m_roi.polygonPoint.Select(p => new Point(p.CoordX, p.CoordY)).ToArray();
                        Point[] points = m_roi.points;
                        path.StartFigure();
                        path.AddPolygon(points);
                        path.CloseFigure();
                        e.Graphics.DrawPath(new Pen(Color.Black, 2), path);

                        using (Brush cornerP = new SolidBrush(Color.DarkRed))
                        {
                            for (int i = 0; i < points.Length; i++)
                                e.Graphics.FillRectangle(cornerP, new Rectangle(points[i], new Size(5, 5)));
                            cornerP.Dispose();
                        }
                        Region myRegion = new Region(path);
                        m_roi.ROIRectangle = Rectangle.Round(myRegion.GetBounds(e.Graphics));
                        e.Graphics.DrawRectangle(Pens.Yellow, m_roi.ROIRectangle);
                        path.Dispose();
                    };
                }
                else
                {
                    this.Cursor = Cursors.Default;
                }
            }

            if (m_colorTools != null && m_cbImages.SelectedIndex == 0)
            {
                if (m_colorTools.addColorRect || m_colorTools.addColorPoint)
                {
                    if (m_colorTools.addColorRect)
                    {
                        using (Brush cornerP = new SolidBrush(Color.Aqua))
                        using (Pen p = new Pen(Color.DarkOliveGreen, 2))
                        {
                            e.Graphics.DrawRectangle(p, m_colorTools.colorRect);
                            for (int i = 1; i < 9; i++)
                            {
                                e.Graphics.FillRectangle(cornerP, GetHandleRect(m_colorTools.colorRect, i));
                            }
                            cornerP.Dispose();
                            p.Dispose();
                        }
                    }
                    else if (m_colorTools.addColorPoint)
                    {
                        using (Pen p = new Pen(Color.DeepSkyBlue, 2))
                        {
                            e.Graphics.DrawRectangle(p, m_colorTools.colorRect);
                            p.Dispose();
                        }
                    }

                    Rectangle colorRect = m_colorTools.colorRect;
                    if (colorRect.Width < 5 || colorRect.Height < 5)
                        return;
                    Mat colorMat = new Mat(m_bitmapList["Current.InputImage"], m_colorTools.colorRect);

                    int n = colorMat.Rows * colorMat.Cols;
                    Mat data = colorMat.Clone().Reshape(1, n);
                    data.ConvertTo(data, DepthType.Cv32F);

                    VectorOfInt labels = new VectorOfInt();
                    Mat centers = new Mat();
                    CvInvoke.Kmeans(data, 10, labels, new MCvTermCriteria(), 1, KMeansInitType.PPCenters, centers);

                    m_colorTools.colorPalette = new List<MCvScalar>();
                    for (int i = 0; i < labels.Size; i++)
                    {
                        m_colorTools.colorPalette.Add(new MCvScalar
                        {
                            V0 = (int)(float)centers.GetData().GetValue(labels[i], 0),
                            V1 = (int)(float)centers.GetData().GetValue(labels[i], 1),
                            V2 = (int)(float)centers.GetData().GetValue(labels[i], 2)
                        });
                    }

                    data.Dispose();
                    labels.Dispose();
                    centers.Dispose();

                    MCvScalar scalar = CvInvoke.Mean(colorMat);
                    colorMat?.Dispose();
                    m_colorTools.m_nudBlue.Value = (decimal)scalar.V0;
                    m_colorTools.m_nudGreen.Value = (decimal)scalar.V1;
                    m_colorTools.m_nudRed.Value = (decimal)scalar.V2;
                }
            }

            if (toolBase is PaintTool)
            {
                if (((PaintParams)toolBase.parameter).InPaintPoints.Count >= 2 && m_cbImages.SelectedIndex == 0)
                {
                    using (Pen pen = new Pen(Color.GreenYellow, ((PaintParams)toolBase.parameter).paintSize))
                    {
                        e.Graphics.DrawCurve(pen, ((PaintParams)toolBase.parameter).InPaintPoints.ToArray());
                        pen.Dispose();
                    }
                }
            }
        }

        private void m_display_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                m_panelContextMenu.Show(m_display, e.Location);
                return;
            }
            bool move = true;
            base.OnMouseDown(e);
            if (m_roi != null)
            {
                if (m_roi.m_comboBoxROI.SelectedItem.ToString() == "CogRectangle")
                {
                    dragHandle = 10;
                    moveType = "ROIRect";
                    for (int i = 1; i < 9; i++)
                    {
                        if (GetHandleRect(m_roi.ROIRectangle, i).Contains(e.Location))
                        {
                            oldRect = m_roi.ROIRectangle;
                            dragHandle = i;
                            dragPoint = GetHandlePoint(m_roi.ROIRectangle, i);
                            move = false;
                            break;
                        }
                    }

                }
                else if (m_roi.m_comboBoxROI.SelectedItem.ToString() == "CogPolygon")
                {
                    dragHandle = -10; moveType = "ROIPoly";
                    for (int i = 0; i < m_roi.points.Length; i++)
                    {
                        Rectangle point = new Rectangle(m_roi.points[i], new Size(5, 5));
                        if (point.Contains(e.Location))
                        {
                            oldRect = m_roi.ROIRectangle;
                            dragHandle = i;
                            move = false;
                            break;
                        }
                    }
                }

                if (move)
                {
                    if (m_roi.ROIRectangle.Contains(e.Location))
                    {
                        oldRect = m_roi.ROIRectangle;
                        dragPoint = new Point(e.Location.X, e.Location.Y);
                    }
                    else
                        dragHandle = -1;
                }
            }

            move = true;
            if (m_colorTools != null && m_cbImages.SelectedIndex == 0)
            {
                if (m_colorTools.addColorRect)
                {
                    for (int i = 1; i < 9; i++)
                    {
                        if (GetHandleRect(m_colorTools.colorRect, i).Contains(e.Location))
                        {
                            moveType = "Color";
                            oldRect = m_colorTools.colorRect;
                            dragHandle = i;
                            dragPoint = GetHandlePoint(m_colorTools.colorRect, i);
                            move = false;
                            break;
                        }
                    }

                }
                if (m_colorTools.addColorPoint || m_colorTools.addColorRect)
                {

                    if (move)
                    {
                        Rectangle colorRect = m_colorTools.colorRect;
                        if (colorRect.Contains(e.Location))
                        {
                            moveType = "Color";
                            dragHandle = 10;
                            oldRect = m_colorTools.colorRect;
                            dragPoint = new Point(e.Location.X, e.Location.Y);
                        }
                    }
                }
            }

            if (toolBase is PaintTool)
            {
                drawLines = true;
                ((PaintParams)toolBase.parameter).InPaintPoints.Clear();
                ((PaintParams)toolBase.parameter).InPaintPoints.Add(e.Location);
            }
        }

        private void m_display_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                return;
            dragHandle = -1;
            base.OnMouseUp(e);
            if (toolBase is PaintTool)
            {
                if (((PaintParams)toolBase.parameter).InPaintPoints.Count > 0)
                {
                    drawLines = false;
                }
            }
        }

        private void m_display_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                return;
            this.Invalidate();
            int diffX = dragPoint.X - e.Location.X;
            int diffY = dragPoint.Y - e.Location.Y;
            if (oldRect != null || !oldRect.IsEmpty)
            {

                if (moveType == "Color" || moveType == "ROIRect")
                {
                    Size oriSize = m_bitmapList["Current.InputImage"].Size;
                    Size currentSize = m_display.Size;
                    double xScale = 1 - (double)oriSize.Width / (double)currentSize.Width;
                    double yScale = 1 - (double)oriSize.Height / (double)currentSize.Height;
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

                                rectangle.Y = oldRect.Y;
                                if (oldRect.Bottom - diffY >= m_display.Height)
                                    rectangle.Height = m_display.Height - oldRect.Top;
                                else
                                    rectangle.Height = oldRect.Height - diffY;
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
                                break;
                            case 5:
                                rectangle.X = oldRect.Left;
                                rectangle.Width = oldRect.Width;

                                rectangle.Y = oldRect.Top;
                                if (oldRect.Bottom - diffY >= m_display.Height)
                                    rectangle.Height = m_display.Height - oldRect.Top;
                                else
                                    rectangle.Height = oldRect.Height - diffY;
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
                                break;
                            case 7:
                                rectangle.X = oldRect.Left;
                                if (oldRect.Right - diffX >= m_display.Width)
                                    rectangle.Width = m_display.Width - oldRect.Left;
                                else
                                    rectangle.Width = oldRect.Width - diffX;
                                rectangle.Y = oldRect.Top;
                                rectangle.Height = oldRect.Height;

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

                                break;
                            case 10:
                                diffX = dragPoint.X - oldRect.X;
                                diffY = dragPoint.Y - oldRect.Y;
                                int finalX = e.Location.X - diffX;
                                int finalY = e.Location.Y - diffY;
                                rectangle.Width = oldRect.Width; rectangle.Height = oldRect.Height;
                                if (finalX < 0)
                                    rectangle.X = 0;
                                else if (finalX + oldRect.Width < m_display.Width)
                                    rectangle.X = finalX;
                                else
                                    rectangle.X = m_display.Width - oldRect.Width;


                                if (finalY < 0)
                                    rectangle.Y = 0;
                                else if (finalY + oldRect.Height < m_display.Height)
                                    rectangle.Y = finalY;
                                else
                                    rectangle.Y = m_display.Height - oldRect.Height;

                                break;
                            default: break;
                        }
                        if (moveType == "Color")
                            m_colorTools.colorRect = rectangle;
                        else
                            m_roi.ROIRectangle = rectangle;
                    }
                }
                else if (moveType == "ROIPoly")
                {
                    if (dragHandle >= 0)
                    {
                        if (e.Location.X >= 0 && e.Location.X < m_display.Width)
                        {
                            m_roi.polygonPoint[dragHandle].CoordX = e.Location.X;
                        }
                        if (e.Location.Y >= 0 && e.Location.Y < m_display.Height)
                        {
                            m_roi.polygonPoint[dragHandle].CoordY = e.Location.Y;
                        }
                    } // MOVE POLYGON POINT
                    else if (dragHandle == -10)
                    {
                        bool valid = true;
                        BindingList<PointCoord> bl = new BindingList<PointCoord>();
                        for (int i = 0; i < m_roi.points.Length; i++)
                        {
                            PointCoord coord = new PointCoord();
                            diffX = dragPoint.X - m_roi.polygonPoint[i].CoordX;
                            diffY = dragPoint.Y - m_roi.polygonPoint[i].CoordY;
                            int finalX = e.Location.X - diffX;
                            int finalY = e.Location.Y - diffY;

                            if (m_roi.ROIRectangle.X >= 0 && (m_roi.ROIRectangle.X + m_roi.ROIRectangle.Width) <= m_display.Width)
                            {
                                if (finalX >= 0 && finalX <= m_display.Width)
                                    coord.CoordX = finalX;
                                else
                                {
                                    valid = false;
                                    break;
                                }
                            }
                            else
                            {
                                valid = false;
                                break;
                            }

                            if (m_roi.ROIRectangle.Y >= 0 && (m_roi.ROIRectangle.Y + m_roi.ROIRectangle.Height) <= m_display.Height)
                            {
                                if (finalY >= 0 && finalY <= m_display.Height)
                                    coord.CoordY = finalY;
                                else
                                {
                                    valid = false;
                                    break;
                                }
                            }
                            else
                            {
                                valid = false;
                                break;
                            }
                            bl.Add(coord);
                        }
                        if (valid)
                        {
                            for (int i = 0; i < m_roi.points.Length; i++)
                            {
                                m_roi.polygonPoint[i].CoordX = bl[i].CoordX;
                                m_roi.polygonPoint[i].CoordY = bl[i].CoordY;
                            }
                        }
                        dragPoint = e.Location;
                    } //MOVE ENTIRE POLYGON
                }
            }

            if (toolBase is PaintTool)
            {
                if (((PaintParams)toolBase.parameter).InPaintPoints.Count > 0)
                {
                    if (drawLines)
                        ((PaintParams)toolBase.parameter).InPaintPoints.Add(e.Location);
                }
            }
            base.OnMouseMove(e);
        }

        private void m_display_Resize(object sender, EventArgs e)
        {
            CenterPictureBox();
        }

        private void panel2_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                m_panelContextMenu.Show(panel2, e.Location);
            }
        }

        private void openDisplayInNewWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmptyForm ef = Application.OpenForms[this.ParentForm.Text + " Display"] as EmptyForm;
            ef?.Close();
            ef?.Dispose();

            EmptyForm emptyForm = new EmptyForm()
            {
                Name = this.ParentForm.Text + " Display",
                Text = this.ParentForm.Text + " Display"
            };
            DisplayControl newDisplay = new DisplayControl()
            {
                m_bitmapList = this.m_bitmapList?.CloneDictionaryCloningValues()
            };
            newDisplay.m_cbImages.DataSource = new BindingSource() { DataSource = m_DisplaySelection };
            emptyForm.Controls.Add(newDisplay);
            emptyForm.Show();

        }

        private void saveImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_display.Image == null || m_bitmapList == null)
            {
                MessageBox.Show("No Image(s) to Save");
                return;
            }

            bool image = ((ToolStripMenuItem)sender).Name == "ImageToolStripMenuItem";
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            if (image)
            {
                saveFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Png Image|*.png";
                saveFileDialog1.Title = "Save an Image File";
            }
            else
            {
                saveFileDialog1.Filter = "Zip file|*.zip";
                saveFileDialog1.Title = "Save Images";
                saveFileDialog1.FileName = this.ParentForm.Text;
            }

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog1.FileName != "" && image)
                    CvInvoke.Imwrite(saveFileDialog1.FileName, m_display.Image);
                else if(saveFileDialog1.FileName != "")
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        ZipArchive zipArc = new ZipArchive(ms, ZipArchiveMode.Create, true);

                        foreach (KeyValuePair<string, Mat> kvp in m_bitmapList)
                        {
                            ZipArchiveEntry entry = zipArc.CreateEntry(kvp.Key + ".jpg", CompressionLevel.Optimal);
                            using (var entryStream = entry.Open())
                            {
                                kvp.Value.ToBitmap().Save(entryStream, ImageFormat.Jpeg);
                            }

                        }
                        zipArc.Dispose();//MUST DISPOSE SO IT CAN WRITE

                        using (var fileStream = new FileStream(saveFileDialog1.FileName, FileMode.Create))
                        {
                            ms.Seek(0, SeekOrigin.Begin);
                            ms.CopyTo(fileStream);
                            fileStream.Close();
                            fileStream.Dispose();
                        }
                        ms.Dispose();
                    }

                }
            }
            
            saveFileDialog1.Dispose();
        }
    }
}
