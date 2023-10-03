using Emgu.CV;
using Emgu.CV.CvEnum;
using OpenCV_Vision_Pro.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OpenCV_Vision_Pro
{
    public partial class DisplayControl : UserControl
    {
        public VideoCapture m_VideoCapture { get; set; }
        public AutoDisposeDict<string, Mat> m_bitmapList { get; set; }
        public ROI m_roi { get; set; }
        public BindingList<string> m_DisplaySelection { get; set; }
        public DisplayControl()
        {
            InitializeComponent();
            panel2.MouseWheel += panel2_MouseWheel;
            CenterPictureBox();
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

                if (m_roi != null)
                {
                    if (m_cbImages.SelectedIndex == 0 && m_roi.m_comboBoxROI.SelectedIndex != 0)
                        m_roi.FrameControl.Visible = true;
                    else
                        m_roi.FrameControl.Visible = false;
                }
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
                    if (m_display.Width < 0)
                        return;
                }
                else
                {
                    //set maximum size to zoom
                    if (m_display.Width > 8000)
                        return;
                }

                if (m_roi != null)
                {
                    if (m_roi.FrameControl.Width < 10 || m_roi.FrameControl.Height < 10)
                    {
                        m_roi.FrameControl.Width = 10;
                        m_roi.FrameControl.Height = 10;
                    }
                    m_roi.FrameControl.Width += Convert.ToInt32(m_roi.FrameControl.Width * e.Delta / 1000);
                    m_roi.FrameControl.Height += Convert.ToInt32(m_roi.FrameControl.Height * e.Delta / 1000);
                    m_roi.FrameControl.X += Convert.ToInt32(m_roi.FrameControl.X * (double)e.Delta / 1000);
                    m_roi.FrameControl.Y += Convert.ToInt32(m_roi.FrameControl.Y * (double)e.Delta / 1000);
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

        /*
        public Mat getRegion()
        {
            Mat m = ResizeImage((Mat)m_display.Image, m_display.Width, m_display.Height);
            //Mat regionImage = new Mat(m, getRegionRect());
            //m.Dispose();
            return m;
        }*/

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED       
                return cp;
            }
        }

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

                m_labelTotalTime.Text = " / "+answer;
            }
        }

    }
}
