using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.ML;
using Emgu.CV.Reg;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Reflection.Metadata.BlobBuilder;
using static System.Windows.Forms.LinkLabel;

namespace OpenCV_Vision_Pro
{
    public class CaliperTool
    {
        public List<Caliper> calipers { get; set; }
        public DataTable caliperResult { get; set; }
        public Bitmap caliperImage { get; set; }
        public Dictionary<int, int[]> caliperPoints { get; set; }

        public bool ROIBool { get; set; }
        public String polarity0 { get; set; }
        public String polarity1 { get; set; }

        private double[] CalculateContrastScore(int i, Mat image, Point p1)
        {
            // Create an ROI around the pixel of interest
            int X = p1.X - 2;
            X = X < 0 ? 0 : X;
            int width = X + 5 > image.Width ? 2 : 5;
            Rectangle roi = new Rectangle(X, 0, width, image.Height);
            Mat roiImage = new Mat(image, roi);
            // Compute the absolute differences between neighboring pixels in the ROI
            Mat diffImage = new Mat();
            CvInvoke.AbsDiff(roiImage.Col(roiImage.Cols - 1), roiImage.Col(0), diffImage);

            MCvScalar left = CvInvoke.Sum(roiImage.Col(roiImage.Cols - 1));
            MCvScalar right = CvInvoke.Sum(roiImage.Col(0));

            // Compute the sum of absolute differences
            MCvScalar sum = CvInvoke.Sum(diffImage);

            // Calculate the contrast score
            double contrastScore = Math.Abs(sum.V0) / 255.0 / image.Rows;
            double contrast = 0;
            if (left.V0 > right.V0)
                contrast = Math.Abs(sum.V0) / image.Rows;
            else
                contrast = -Math.Abs(sum.V0) / image.Rows;

            return new double[] { Math.Round(contrastScore, 4), Math.Round(contrast, 4) };
        }

        public void showResult(Mat imageClone, Rectangle region)
        {
            caliperResult = new DataTable();
            caliperResult.Columns.Add("ID", typeof(int)).SetOrdinal(0);
            caliperResult.Columns.Add("Score", typeof(double));
            caliperResult.Columns.Add("Edge 0", typeof(int));
            caliperResult.Columns.Add("Position", typeof(double));
            caliperResult.Columns.Add("PositionX", typeof(int));
            caliperResult.Columns.Add("PositionY", typeof(int));
            caliperResult.Columns.Add("Scoring Function 0", typeof(double));
            caliperResult.Columns.Add("Contrast (E0)", typeof(double));
            int i = 0;
            Bitmap combinedImage = new Bitmap(imageClone.Width, imageClone.Height);
            using (Graphics graphics = Graphics.FromImage(combinedImage))
            {
                graphics.DrawImage(imageClone.ToBitmap(), 0, 0);
                foreach (Caliper caliper in calipers)
                {
                    double contrast = caliper.ContrastEdge0;
                    float x = (float)caliper.PositionX;
                    float y = (float)caliper.PositionY;
                    if (polarity0 == "Dark to Light")
                    {
                        if (contrast < 0)
                            continue;
                    }
                    else if (polarity0 == "Light to Dark")
                    {
                        if (contrast > 0)
                            continue;
                    }
                    caliperResult.Rows.Add(new object[] { i++, caliper.Score, caliper.Edge0, caliper.Position, x, y, caliper.ScoringFunction0, caliper.ContrastEdge0 });
                    
                    using (Pen pen = new Pen(Color.SpringGreen, 1))
                    {
                        if (region.IsEmpty)
                        {
                            graphics.DrawLine(pen, x, 0, x, y);
                        }
                        else
                        {
                            graphics.DrawLine(pen, x + region.X, region.Y, x + region.X, region.Y + region.Height);
                        }
                    }
                }
                caliperImage = combinedImage;
            }
        }

        public void Run(Mat image, Rectangle region)
        {
            calipers = new List<Caliper>();
            Mat imageClone = image.Clone();

            CvInvoke.CvtColor(image, image, ColorConversion.Bgr2Gray);
            CvInvoke.Canny(image, image, 40, 150, 3, true);
            /*
             * 当使用 CvInvoke.HoughLinesP 函数进行直线检测时，以下是各个参数的解释：
             * image：这是输入的边缘检测图像，通常是使用Canny边缘检测或其他方法得到的。
             * rho：这是Hough变换中极坐标的分辨率，表示以像素为单位的距离分辨率。它通常设置为1。
             * theta：这是Hough变换中角度的分辨率，表示弧度为单位的角度分辨率。通常设置为 Math.PI / 2，以检测垂直线。
             * threshold：这是用于确定检测到的直线的阈值。只有累加器中的值大于等于阈值时，才会被认为是一条直线。你可以根据图像的复杂性和噪声水平来调整此值。
             * minLineLength：这是一条线段的最小长度。检测到的线段中，小于此长度的线段将被忽略。
             * maxLineGap：这是连接两条线段之间的最大距离。如果两条线段之间的距离小于此值，它们将被合并成一条线段。
            */

            Mat line = new Mat();
            Mat ROI = new Mat(image, region);
            if (region.IsEmpty)
                CvInvoke.HoughLines(image, line, 1, Math.PI, 1);
            else
                CvInvoke.HoughLines(ROI, line, 1, Math.PI, 1);


            caliperPoints = new Dictionary<int, int[]>();
            List<int[]> sortEdge = new List<int[]>();

            for (int i = 0; i < line.Rows; i++)
            {
                Caliper caliper = new Caliper();
                float rho = (float)line.GetData().GetValue(i, 0, 0); // Distance from the origin to the line
                float theta = (float)line.GetData().GetValue(i, 0, 1); // Angle (in radians) of the line

                double a = Math.Cos(theta);
                double b = Math.Sin(theta);
                double x0 = a * rho;
                double y0 = b * rho;

                int x1 = (int)(x0 + 1000 * (-b)); // These values control the length of the lines
                int y1 = (int)(y0 + 1000 * (a));
                int x2 = (int)(x0 - 1000 * (-b));
                int y2 = (int)(y0 - 1000 * (a));

                double[] contrast;
                if (region.IsEmpty)
                {
                    contrast = CalculateContrastScore(i, imageClone, new Point(x1, y1));
                    ROIBool = false;
                }
                else
                {
                    contrast = CalculateContrastScore(i, new Mat(imageClone, region), new Point(x1, y1));
                    ROIBool = true;
                }

                sortEdge.Add(new int[] { i, x1, y1, x2, y2 });

                caliper.Score = contrast[0];
                caliper.ScoringFunction0 = contrast[0];
                caliper.ContrastEdge0 = contrast[1];
                caliper.Position = Math.Round((double)x1 - image.Width / 2, 4);
                caliper.PositionX = x1;
                caliper.PositionY = image.Height;

                calipers.Add(caliper);
            }
            sortEdge = sortEdge.OrderBy(l => l[1]).ToList();
            for (int i = 0; i < sortEdge.Count; i++)
            {
                int[] temp = sortEdge[i];
                calipers[temp[0]].Edge0 = i;
                caliperPoints.Add(i, new int[] { temp[1], temp[2], temp[3], temp[4] });
            }


            showResult(imageClone, region);
        }
    }

}
