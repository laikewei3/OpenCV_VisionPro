using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Reg;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Reflection.Metadata.BlobBuilder;
using static System.Windows.Forms.LinkLabel;

namespace OpenCV_Vision_Pro
{
    public class CaliperTool
    {
        public DataTable caliperResult { get; set; }
        public Bitmap caliperImage { get; set; }

        public void Run(Mat image)
        {
            Mat imageClone = image.Clone();

            CvInvoke.CvtColor(image, image, ColorConversion.Bgr2Gray);
            CvInvoke.Canny(image, image,40,150,3,true);
            //Mat hierarchy = new Mat();

            //CvInvoke.FindContours(image, contours, hierarchy, RetrType.Tree, ChainApproxMethod.ChainApproxSimple);

            /*
             * 当使用 CvInvoke.HoughLinesP 函数进行直线检测时，以下是各个参数的解释：
             * image：这是输入的边缘检测图像，通常是使用Canny边缘检测或其他方法得到的。
             * rho：这是Hough变换中极坐标的分辨率，表示以像素为单位的距离分辨率。它通常设置为1。
             * theta：这是Hough变换中角度的分辨率，表示弧度为单位的角度分辨率。通常设置为 Math.PI / 2，以检测垂直线。
             * threshold：这是用于确定检测到的直线的阈值。只有累加器中的值大于等于阈值时，才会被认为是一条直线。你可以根据图像的复杂性和噪声水平来调整此值。
             * minLineLength：这是一条线段的最小长度。检测到的线段中，小于此长度的线段将被忽略。
             * maxLineGap：这是连接两条线段之间的最大距离。如果两条线段之间的距离小于此值，它们将被合并成一条线段。
            */

            // LineSegment2D[] line = CvInvoke.HoughLinesP(image, 1, Math.PI / 2, 50);
            Mat line = new Mat();
            CvInvoke.HoughLines(image, line, 1, Math.PI , 50);
            Bitmap combinedImage = new Bitmap(image.Width, image.Height);
            using (Graphics graphics = Graphics.FromImage(combinedImage))
            {
                graphics.DrawImage(imageClone.ToBitmap(), 0, 0);

                for (int i = 0; i < line.Rows; i++)
                {
                    float rho = (float)line.GetData().GetValue(i, 0, 0); // Distance from the origin to the line
                    float theta = (float)line.GetData().GetValue(i, 0, 1); // Angle (in radians) of the line

                    double a = Math.Cos(theta);
                    double b = Math.Sin(theta);
                    double x0 = a * rho;
                    double y0 = b * rho;

                    int x1 = 20;//(int)(x0 + 1000 * (-b)); // These values control the length of the lines
                    int y1 = 20;// (int)(y0 + 1000 * (a));
                    int x2 = 40;// (int)(x0 - 1000 * (-b));
                    int y2 = 40;// (int)(y0 - 1000 * (a));
                    // double angle = Math.Abs(Math.Atan2(line[i].P2.Y - line[i].P1.Y, line[i].P2.X - line[i].P1.X));
                    //double degrees = angle * (180 / Math.PI);

                    //if (Math.Abs(degrees - 90) < 10) // Check if the line is approximately vertical
                    //{
                    using (Pen pen = new Pen(Color.Red, 20))
                    using (Graphics contourGraphics = Graphics.FromImage(combinedImage))
                    {
                        contourGraphics.DrawLine(pen, 0, 0, 150, 150);
                    }
                    //}
                    //}
                }
            }
            CvInvoke.Imshow("", imageClone);
            caliperImage = imageClone.ToBitmap();
        }
    }
}
