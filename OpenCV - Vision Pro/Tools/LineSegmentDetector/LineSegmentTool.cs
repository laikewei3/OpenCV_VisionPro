using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.ML;
using Emgu.CV.Structure;
using OpenCV_Vision_Pro.LineSegment;
using OpenCV_Vision_Pro.Interface;
using OpenCV_Vision_Pro.Properties;
using Shared.ComponentModel.SortableBindingList;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using OpenCV_Vision_Pro.Caliper;
using System.Security.Cryptography;
using System.Windows.Media;
using Emgu.CV.Util;
using System.Linq.Dynamic.Core;

namespace OpenCV_Vision_Pro.LineSegment
{
    public class LineSegmentParams : IParams
    {
        public bool ROIBool { get; set; }
        public double minLineLength { get; set; } = 50;
        public double maxLineGap { get; set; } = 20;
        public double minSlope { get; set; } = 4;
        public double maxSlope { get; set; } = 4;
        public int maxResult { get; set; } = 1;
        public int contrastThreshold { get; set; } = 50;
        public ROI m_roi { get; set; } = new ROI();
        public bool m_boolHasROI { get; set; } = false;
    }

    public class LineSegmentTool : IToolBase
    {
        public Bitmap toolIcon { get; } = Resources.caliper;
        public string ToolName { get; set; }
        public UserControlBase m_toolControl { get; set; }
        public AutoDisposeDict<string, Mat> m_bitmapList { get; set; }
        public BindingList<string> m_DisplaySelection { get; set; } = new BindingList<string>();
        public BindingSource resultSource { get; set; }
        public Rectangle m_rectROI { get; set; }
        public IParams parameter { get; set; } = new LineSegmentParams();
        public IToolResult toolResult { get; set; }
        private LineSegmentResult LineSegmentResult { get { return (LineSegmentResult)toolResult; } set { toolResult = value; } }
        public Dictionary<int, List<int>> LineSegmentPoints { get; set; }

        public LineSegmentTool(string toolName)
        {
            LineSegmentPoints = new Dictionary<int, List<int>>();
            ToolName = toolName;
        }

        public void getGUI()
        {
            if (m_rectROI != null && !m_rectROI.IsEmpty)
            {
                parameter.m_roi.location = new Point(m_rectROI.X, m_rectROI.Y);
                parameter.m_roi.ROI_Width = m_rectROI.Width;
                parameter.m_roi.ROI_Height = m_rectROI.Height;
            }
            m_toolControl = new LineSegmentToolControl(parameter) { Dock = DockStyle.Fill };
        }

        public void Run(Mat image, Rectangle region)
        {
            if (((LineSegmentToolControl)m_toolControl) != null)
                parameter = ((LineSegmentToolControl)m_toolControl).LineSegmentParams;
            else
                parameter = new LineSegmentParams();

            //=============================================== Delete Previous Results =============================================
            LineSegmentPoints.Clear();
            LineSegmentResult?.Dispose();
            LineSegmentResult = new LineSegmentResult();
            //=====================================================================================================================

            Mat imageClone = image.Clone(); // Clone for future Reference

            //=============================================== Image Preprocessing =================================================
            Mat imageBlur;
            if (image.NumberOfChannels == 1)
            {
                imageBlur = new Mat();
                CvInvoke.CvtColor(image, imageBlur, ColorConversion.Bgr2Gray);
            }
            else
                imageBlur = image.Clone();
            CvInvoke.GaussianBlur(imageBlur, imageBlur, new Size(5, 5), 1);
            Mat imageCanny = image.Clone();
            CvInvoke.Canny(imageBlur, imageCanny, 40, 150, 3, true);
            imageBlur.Dispose();
            /*
             * 当使用 CvInvoke.HoughLinesP 函数进行直线检测时，以下是各个参数的解释：
             * image：这是输入的边缘检测图像，通常是使用Canny边缘检测或其他方法得到的。
             * rho：这是Hough变换中极坐标的分辨率，表示以像素为单位的距离分辨率。它通常设置为1。
             * theta：这是Hough变换中角度的分辨率，表示弧度为单位的角度分辨率。通常设置为 Math.PI / 2，以检测垂直线。
             * threshold：这是用于确定检测到的直线的阈值。只有累加器中的值大于等于阈值时，才会被认为是一条直线。你可以根据图像的复杂性和噪声水平来调整此值。
             * minLineLength：这是一条线段的最小长度。检测到的线段中，小于此长度的线段将被忽略。
             * maxLineGap：这是连接两条线段之间的最大距离。如果两条线段之间的距离小于此值，它们将被合并成一条线段。
            */
            //=====================================================================================================================

            //============================================ Get Line using HoughLineP ==============================================
            Mat line = new Mat();
            Mat lines = new Mat();
            Mat ROI = new Mat(imageCanny, region);

            if (region.IsEmpty)
            {
                CvInvoke.HoughLinesP(imageCanny, lines, 1, Math.PI / 180, ((LineSegmentParams)parameter).contrastThreshold, ((LineSegmentParams)parameter).minLineLength, ((LineSegmentParams)parameter).maxLineGap);
                CvInvoke.HoughLines(imageCanny, line, 1, Math.PI / 180, ((LineSegmentParams)parameter).contrastThreshold);
            }
            else
            {
                CvInvoke.HoughLines(ROI, line, 1, Math.PI / 180, ((LineSegmentParams)parameter).contrastThreshold);
                CvInvoke.HoughLinesP(ROI, lines, 1, Math.PI / 180, ((LineSegmentParams)parameter).contrastThreshold, ((LineSegmentParams)parameter).minLineLength, ((LineSegmentParams)parameter).maxLineGap);
            }


            //=====================================================================================================================


            List<LineSegment2D> lineSegment2Ds = new List<LineSegment2D>();
            VectorOfPointF intersectionPoints = new VectorOfPointF();

            int counter = 0; 
            while(lineSegment2Ds.Count < 10 && counter < line.Rows)
            {
                float rho = (float)line.GetData().GetValue(counter, 0, 0); // Distance from the origin to the line
                float theta = (float)line.GetData().GetValue(counter, 0, 1);
                double thetaDeg = Math.Abs(90 - (theta * (180.0 / Math.PI))); // Angle (in degrees) of the line
                if (thetaDeg >= ((LineSegmentParams)parameter).minSlope && thetaDeg <= (90 - ((LineSegmentParams)parameter).maxSlope))
                {
                    double a = Math.Cos(theta);
                    double b = Math.Sin(theta);
                    double x0 = a * rho;
                    double y0 = b * rho;

                    int x1 = (int)(x0 + 1000 * (-b)); // These values control the length of the lines
                    int y1 = (int)(y0 + 1000 * (a));
                    int x2 = (int)(x0 - 1000 * (-b));
                    int y2 = (int)(y0 - 1000 * (a));

                    LineSegment2D tempLine = new LineSegment2D(new Point(x1, y1), new Point(x2, y2));
                    lineSegment2Ds.Add(tempLine);
                    for (int i = 0; i < lineSegment2Ds.Count; i++)
                    {   
                        if(FindIntersectionPoint(tempLine, lineSegment2Ds[i], out Point intersect))
                            intersectionPoints.Push(new PointF[] { intersect });
                        if (region.IsEmpty)
                            CvInvoke.Line(imageCanny, new Point(x1, y1), new Point(x2, y2), new MCvScalar(204, 255, 255), 1);
                        else
                            CvInvoke.Line(ROI, new Point(x1, y1), new Point(x2, y2), new MCvScalar(204, 255, 255), 1);
                    }
                }
                counter++;
            }

            VectorOfInt labels = new VectorOfInt(); Mat centers = new Mat();
            if (lineSegment2Ds.Count > 2)
            {
                CvInvoke.Kmeans(intersectionPoints, 5, labels, new MCvTermCriteria(1000, 0.2), 2, KMeansInitType.PPCenters, centers);
                intersectionPoints.Dispose();

                int[] cntLabels = new int[5];
                for (int i = 0; i < labels.Size; i++)
                    cntLabels[labels[i]]++;

                int index = 0, max = 0;
                for (int i = 0; i < cntLabels.Length; i++)
                {
                    if (cntLabels[i] > max)
                    {
                        index = i;
                        max = cntLabels[i];
                    }
                }

                Point vanishPoint = new Point((int)(float)centers.GetData().GetValue(index, 0), (int)(float)centers.GetData().GetValue(index, 1));
                labels?.Dispose();
                centers?.Dispose();
                DrawLines(lineSegment2Ds, imageClone, region, vanishPoint);
            }
            for (int i = 0, j = 0; i < lines.Rows && j < ((LineSegmentParams)parameter).maxResult; i++ )
            {
                Point pt1 = new Point((int)lines.GetData().GetValue(i, 0, 0), (int)lines.GetData().GetValue(i, 0, 1));
                Point pt2 = new Point((int)lines.GetData().GetValue(i, 0, 2), (int)lines.GetData().GetValue(i, 0, 3));

                double slope = pt2.X != pt1.X ? Math.Abs((pt2.Y - pt1.Y) / (pt2.X - pt1.X)) : 100000;  // Avoid division by zero
                double theta = Math.Abs(Math.Atan(slope) * (180.0 / Math.PI));

                if (theta >= ((LineSegmentParams)parameter).minSlope && Math.Abs(theta) <= (90 - ((LineSegmentParams)parameter).maxSlope))
                {
                    if (region.IsEmpty)
                        CvInvoke.Line(imageClone, pt1, pt2, new MCvScalar(230, 100, 255), 2);
                    else
                        CvInvoke.Line(imageClone, new Point(pt1.X + region.X, pt1.Y + region.Y), new Point(pt2.X + region.X, pt2.Y + region.Y), new MCvScalar(230, 100, 255), 2);

                    j++;
                }


                   
            }

            ROI.Dispose();
            imageCanny.Dispose();
            lines?.Dispose();

            LineSegmentResult.resultImage = imageClone.Clone();
            imageClone.Dispose();
        }

        private bool FindIntersectionPoint(LineSegment2D line1, LineSegment2D line2, out Point intersection)
        {
            double a1 = (line1.P1.Y - line1.P2.Y) / (double)(line1.P1.X - line1.P2.X);
            double b1 = line1.P1.Y - a1 * line1.P1.X;

            double a2 = (line2.P1.Y - line2.P2.Y) / (double)(line2.P1.X - line2.P2.X);
            double b2 = line2.P1.Y - a2 * line2.P1.X;

            if (Math.Abs(a1 - a2) < double.Epsilon)
            {
                intersection = Point.Empty;
                return false;
            }
            double x = (b2 - b1) / (a1 - a2);
            double y = a1 * x + b1;
            intersection =  new Point((int)x, (int)y);

            return true;
        }

        private double calculateDistance(double p1X, double p1Y, double p2X, double p2Y)
        {
            return Math.Sqrt(Math.Pow(p2X - p1X, 2) + Math.Pow(p2Y - p1Y, 2));
        }

        private double calculateAngle()
        {
            return 0;
        }

        public object showResult()
        {
            resultSource?.Dispose();
            resultSource = new BindingSource();
            if (LineSegmentResult == null)
                return resultSource;
            if (m_toolControl == null)
                return resultSource;
            resultSource.DataSource = LineSegmentResult.LineSegmentEdges;
            return resultSource;
        }

        public void showResultImages()
        {
            if (Form1.m_bitmapList.ContainsKey("LastRun." + ToolName + ".LineSegmentImage"))
            {
                Form1.m_bitmapList["LastRun." + ToolName + ".LineSegmentImage"]?.Dispose();
                Form1.m_bitmapList["LastRun." + ToolName + ".LineSegmentImage"] = LineSegmentResult.resultImage.Clone();
            }
            else
            {
                Form1.m_bitmapList.Add("LastRun." + ToolName + ".LineSegmentImage", LineSegmentResult.resultImage.Clone());
                if (!Form1.m_form1DisplaySelection.Contains("LastRun." + ToolName + ".LineSegmentImage"))
                    Form1.m_form1DisplaySelection.Add("LastRun." + ToolName + ".LineSegmentImage");
            }

            if (m_bitmapList.ContainsKey("LastRun." + ToolName + ".LineSegmentImage"))
            {
                m_bitmapList["LastRun." + ToolName + ".LineSegmentImage"]?.Dispose();
                m_bitmapList["LastRun." + ToolName + ".LineSegmentImage"] = LineSegmentResult.resultImage.Clone();
            }
            else
            {
                m_bitmapList.Add("LastRun." + ToolName + ".LineSegmentImage", LineSegmentResult.resultImage.Clone());
                if (!m_DisplaySelection.Contains("LastRun." + ToolName + ".LineSegmentImage"))
                    m_DisplaySelection.Add("LastRun." + ToolName + ".LineSegmentImage");
            }
        }

        public void Dispose()
        {
            LineSegmentResult?.Dispose();
            m_bitmapList?.Dispose();
            m_toolControl?.Dispose();
            resultSource?.Dispose();
        }

        private void DrawLines(List<LineSegment2D> lineSegment2Ds, Mat image, Rectangle region, Point vanishPoint)
        {
            CvInvoke.Rectangle(image, region, new MCvScalar(255, 255, 255));
            if (region.IsEmpty)
            {
                CvInvoke.Circle(image, vanishPoint, 3, new MCvScalar(255, 144, 255), 2);
                for (int i = 0, j = 0; i < lineSegment2Ds.Count; i++)
                {
                    Point pt1 = lineSegment2Ds[i].P1;
                    Point pt2 = lineSegment2Ds[i].P2;

                    Point myPoint = new Point(pt2.Y < vanishPoint.Y ? pt1.X : pt2.X, pt2.Y < vanishPoint.Y ? pt1.Y : pt2.Y);

                    double x = myPoint.X + ((vanishPoint.Y + 30 - myPoint.Y) * (vanishPoint.X - myPoint.X)) / (vanishPoint.Y - myPoint.Y+1e-10);
                    Point p1 = new Point((int)x, vanishPoint.Y + 30);
                    LineSegmentResult.LineSegmentEdges.Add(new LineSegments(j++, calculateDistance(vanishPoint.X, vanishPoint.Y, myPoint.X, myPoint.Y), calculateAngle()));
                    
                    CvInvoke.ArrowedLine(image, myPoint, p1, new MCvScalar(0, 150, 150), 1, tipLength: 0.01);
                }
            }
            else
            {
                Mat mask = new Mat(image.Size, image.Depth, image.NumberOfChannels);
                Mat rectMask = new Mat(region.Size, image.Depth, image.NumberOfChannels);
                Mat colorMask = new Mat(image.Size, image.Depth, image.NumberOfChannels);
                colorMask.SetTo(new MCvScalar(0, 150, 150));
                mask.SetTo(new MCvScalar(0,0,0));
                rectMask.SetTo(new MCvScalar(0,0,0));
                CvInvoke.Circle(mask, new Point(vanishPoint.X + region.X, vanishPoint.Y + region.Y), 3, new MCvScalar(255,255,255), 2);
                for (int i = 0, j = 0; i < lineSegment2Ds.Count; i++)
                {
                    Point pt1 = lineSegment2Ds[i].P1;
                    Point pt2 = lineSegment2Ds[i].P2;

                    Point myPoint = new Point(pt2.Y < vanishPoint.Y ? pt1.X  : pt2.X, pt2.Y< vanishPoint.Y ? pt1.Y: pt2.Y);

                    double x = myPoint.X + ((vanishPoint.Y + 30 - myPoint.Y) * (vanishPoint.X - myPoint.X)) / (vanishPoint.Y - myPoint.Y);
                    Point p1 = new Point((int)x, vanishPoint.Y + 30);
                    LineSegmentResult.LineSegmentEdges.Add(new LineSegments(j++, calculateDistance(vanishPoint.X, vanishPoint.Y, myPoint.X, myPoint.Y), calculateAngle()));

                    CvInvoke.ArrowedLine(rectMask, myPoint, p1, new MCvScalar(255,255,255), 1, tipLength: 0.01);
                }

                CvInvoke.CopyMakeBorder(rectMask, rectMask, region.Top, image.Height - region.Bottom, region.Left, image.Width - region.Right, BorderType.Constant, new MCvScalar(0,0,0));
                CvInvoke.BitwiseOr(mask,rectMask,mask);
                CvInvoke.BitwiseAnd(mask, colorMask, colorMask);
                CvInvoke.BitwiseNot(mask, mask);
                CvInvoke.BitwiseAnd(mask, image,image);
                CvInvoke.Add(image,colorMask,image);

                mask.Dispose();
                rectMask.Dispose();
                colorMask.Dispose();
            }
        }

    }
}
