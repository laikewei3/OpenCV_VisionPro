using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using OpenCV_Vision_Pro.Tools.ColorMatcher;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCV_Vision_Pro
{
    public class HelperClass
    {
        public static Size resize(int oriWidth, int oriHeight, int currWidth, int currHeight)
        {
            double widthScale = (double)currWidth / oriWidth;
            double heightScale = (double)currHeight / oriHeight;
            double minScale = Math.Min(widthScale, heightScale);
            return new Size((int)(oriWidth * minScale), (int)(oriHeight * minScale));
        }

        public static Mat getROIImage(Mat img, Rectangle region, Point[] points)
        {
            Mat image; 
            Rectangle rect = new Rectangle(0, 0, img.Width, img.Height);
            if(region.X > img.Width || region.Y > img.Height) { region.X = 0; region.Y = 0; }
            if (region.IsEmpty)
                image = img.Clone();
            else if (points == null)
            {
                region.Intersect(rect);
                image = new Mat(img, region);
                CvInvoke.Imshow("",image);
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
            return image;
        }
    }
}
