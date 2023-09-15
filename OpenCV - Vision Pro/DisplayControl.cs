using OpenCV_Vision_Pro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenCV_Vision_Pro
{
    public partial class DisplayControl : UserControl
    {
        public Dictionary<String, Bitmap> m_bitmapList {  get; set; } = new Dictionary<String, Bitmap>();

        public DisplayControl()
        {
            InitializeComponent();
            panel2.MouseWheel += panel2_MouseWheel;
        }
        
        private void panel2_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta != 0 && m_display.Image != null)
            {
                if (e.Delta <= 0)
                {/*
                    if (m_roi.FrameControl.Width < 10 || m_roi.FrameControl.Height < 10)
                    {
                        m_roi.FrameControl.Width = 10;
                        m_roi.FrameControl.Height = 10;
                    }*/
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

                m_display.Width += Convert.ToInt32(m_display.Width * e.Delta / 1000);
                m_display.Height += Convert.ToInt32(m_display.Height * e.Delta / 1000);
                //m_roi.FrameControl.Width += Convert.ToInt32(m_roi.FrameControl.Width * e.Delta / 1000);
                //m_roi.FrameControl.Height += Convert.ToInt32(m_roi.FrameControl.Height * e.Delta / 1000);
                //m_roi.FrameControl.X += Convert.ToInt32(m_roi.FrameControl.X * (double)e.Delta / 1000);
                //m_roi.FrameControl.Y += Convert.ToInt32(m_roi.FrameControl.Y * (double)e.Delta / 1000);
                CenterPictureBox();
            }
        }

        private void CenterPictureBox()
        {
            panel2.AutoScrollPosition = new Point((panel2.Width + m_display.Width / 2),
                                        m_display.Parent.ClientSize.Height / 2 + m_display.Height / 2);

            m_display.Location = new Point((m_display.Parent.ClientSize.Width / 2 - m_display.Width / 2),
                                        (m_display.Parent.ClientSize.Height / 2 - m_display.Height / 2));
            m_display.Refresh();
        }
        
        private void m_cbImages_SelectedIndexChanged(object sender, EventArgs e)
        {

            String m_strSelectedItem = m_cbImages.SelectedItem.ToString();
            Bitmap selectedBitmap = m_bitmapList[m_strSelectedItem];
            m_display.Width = selectedBitmap.Width;
            m_display.Height = selectedBitmap.Height;
            m_display.Image = selectedBitmap;
            CenterPictureBox();
            //if (m_cbImages.SelectedIndex == 0 && m_display.Controls.Count > 0)
                //m_roi.FrameControl.Visible = true;
            //else if (m_display.Controls.Count > 0)
                //m_roi.FrameControl.Visible = false;
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

        /// <summary>https://stackoverflow.com/a/24199315/1115360
        /// Resize the image to the specified width and height.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        private Bitmap ResizeImage(Image image, int width, int height)
        {
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
                    wrapMode.Dispose();
                }
                graphics.Dispose();
            }

            return destImage;
        }

        private void panel2_Resize(object sender, EventArgs e)
        {
            CenterPictureBox();
        }
    }
}
