using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using OpenCV_Vision_Pro.Properties;
using OpenCV_Vision_Pro.Tools.ColorMatcher;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenCV_Vision_Pro
{
    public enum ToolIndex
    {
        BlobTool,
        CaliperTool,
        HistogramTool,
        ImageConvertTool,
        ColorSegmentorTool,
        ColorMatcherTool,
        ColorExtractorTool,
        ImageSharpenerTool,
        LineSegmentTool,
        PolarUnWrapTool
    }

    public class HelperClass
    {
        public static ImageList iconList = new ImageList()
        {
            Images = { Resources.blob, Resources.caliper, Resources.histogram, Resources.convert, Resources.segmentor, Resources.match, Resources.extractor, Resources.editor, Resources.line, Resources.yolo }
        };

        public static Size resize(int oriWidth, int oriHeight, int currWidth, int currHeight)
        {
            double widthScale = (double)currWidth / oriWidth;
            double heightScale = (double)currHeight / oriHeight;
            double minScale = Math.Min(widthScale, heightScale);
            return new Size((int)(oriWidth * minScale), (int)(oriHeight * minScale));
        }

        public static Rectangle getROIImage(Mat img, Rectangle region, Point[] points, out Mat image)
        {
            Rectangle rect = new Rectangle(0, 0, img.Width, img.Height);
            if (region.X > img.Width || region.Y > img.Height) { region.X = 0; region.Y = 0; }
            if (region.IsEmpty)
            {
                image = img.Clone();
                return rect;
            }
            else if (points == null)
            {
                region.Intersect(rect);
                image = new Mat(img, region);
            }
            else
            {
                Mat mask = Mat.Zeros(img.Rows, img.Cols, img.Depth, img.NumberOfChannels);
                CvInvoke.FillPoly(mask, new VectorOfPoint(points), new MCvScalar(255, 255, 255));
                Mat bitImage = new Mat();
                CvInvoke.BitwiseAnd(img, mask, bitImage);
                region.Intersect(rect);
                image = new Mat(bitImage, region);
                bitImage?.Dispose();
                mask?.Dispose();
            }
            return region;
        }

        public static void GetAllConnectedCameras(ToolStripMenuItem openCameraToolStripMenuItem, EventHandler openCamera_Click)
        {
            var cameraNames = new List<string>();
            using (var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE (PNPClass = 'Image' OR PNPClass = 'Camera')"))
            {
                foreach (var device in searcher.Get())
                {
                    var item = openCameraToolStripMenuItem.DropDownItems.Add((device["Caption"].ToString()));
                    item.Click += openCamera_Click;
                }
                searcher.Dispose();
            }
        }

    }
}
