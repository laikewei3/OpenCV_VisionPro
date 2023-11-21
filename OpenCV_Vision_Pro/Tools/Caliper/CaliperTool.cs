using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.ML;
using Emgu.CV.Structure;
using OpenCV_Vision_Pro.Interface;
using OpenCV_Vision_Pro.Properties;
using Shared.ComponentModel.SortableBindingList;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace OpenCV_Vision_Pro
{
    public class CaliperResult : IToolResult, IDisposable
    {
        public SortableBindingList<Edges> caliperEdges { get; set; } = new SortableBindingList<Edges>();
    }

    public class Edges
    {
        public double Score { get; set; }
        public int Edge0 { get; set; }
        public double Position { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double ScoringFunction0 { get; set; }
        public double Contrast_E0 { get; set; }
    }

    public class EdgesPair
    {
        public EdgesPair(double score, int edge0, int edge1, double measured_Width, double position, double x, double y, double scoringFunction0, double contrast_E0, double distance_E0, double x0, double y0, double contrast_E1, double distance_E1, double x1, double y1)
        {
            Score = score;
            Edge0 = edge0;
            Edge1 = edge1;
            Measured_Width = measured_Width;
            Position = position;
            X = x;
            Y = y;
            ScoringFunction0 = scoringFunction0;
            Contrast_E0 = contrast_E0;
            Distance_E0 = distance_E0;
            X0 = x0;
            Y0 = y0;
            Contrast_E1 = contrast_E1;
            Distance_E1 = distance_E1;
            X1 = x1;
            Y1 = y1;
        }

        public double Score { get; set; }
        public int Edge0 { get; set; }
        public int Edge1 { get; set; }
        public double Measured_Width { get; set; }
        public double Position { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double ScoringFunction0 { get; set; }
        public double Contrast_E0 { get; set; }
        public double Distance_E0 { get; set; }
        public double X0 { get; set; }
        public double Y0 { get; set; }
        public double Contrast_E1 { get; set; }
        public double Distance_E1 { get; set; }
        public double X1 { get; set; }
        public double Y1 { get; set; }
    }

    public class CaliperParams : IParams
    {
        public bool ROIBool { get; set; }
        public string polarity0 { get; set; }
        public string polarity1 { get; set; }
        public string EdgeMode { get; set; }
        public double estimatedWidth { get; set; } = 10;
        public int maxResult { get; set; } = 1;
        public int contrastThreshold { get; set; } = 5;
    }

    public partial class CaliperTool : IToolData
    {
        public string ToolName { get; set; }
        public IUserControlBase m_toolControl { get; set; }
        public AutoDisposeDict<string, Mat> m_bitmapList { get; set; }
        public BindingList<string> m_DisplaySelection { get; set; } = new BindingList<string>();
        public BindingSource resultSource { get; set; }
        
        public IParams parameter { get; set; } = new CaliperParams();

        public IToolResult toolResult { get; set; }
        private CaliperResult caliperResult { get { return (CaliperResult)toolResult; } set { toolResult = value; } }
        public Dictionary<int, List<int>> caliperPoints { get; set; }

        private SortableBindingList<EdgesPair> caliperEdgesPair;
        public CaliperTool(string toolName)
        {
            caliperPoints = new Dictionary<int, List<int>>();
            ToolName = toolName;
        }

        public  void getGUI()
        {
            m_toolControl = new CaliperToolControl(parameter) { Dock = DockStyle.Fill };
        }

        public  void Run(Mat image, Rectangle region)
        {
            if (((CaliperToolControl)m_toolControl) != null)
                parameter = ((CaliperToolControl)m_toolControl).CaliperParams;
            else
                parameter = new CaliperParams();

            //=============================================== Delete Previous Results =============================================
            caliperPoints.Clear();
            caliperResult?.Dispose();
            caliperResult = new CaliperResult();
            //=====================================================================================================================
            
            Mat imageClone = image.Clone(); // Clone for future Reference

            //=============================================== Image Preprocessing =================================================
            Mat imageCanny = image.Clone();
            CvInvoke.Canny(image,imageCanny, 40, 150, 3, true);
            //=====================================================================================================================

            //======================================== Get Caliper Edge using HoughLine ===========================================
            Mat line = new Mat();
            Mat ROI = new Mat(imageCanny, region);

            if (region.IsEmpty)
                CvInvoke.HoughLines(imageCanny, line, 1, Math.PI, ((CaliperParams)parameter).contrastThreshold);
            else
                CvInvoke.HoughLines(ROI, line, 1, Math.PI, ((CaliperParams)parameter).contrastThreshold);
            //=====================================================================================================================
            ROI.Dispose();
            imageCanny.Dispose();

            //============================================== Calculate Edges Data =================================================
            List<int[]> sortEdge = new List<int[]>();

            for (int i = 0; i < line.Rows; i++)
            {
                Edges edges = new Edges();
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
                    ((CaliperParams)parameter).ROIBool = false;
                }
                else
                {
                    contrast = CalculateContrastScore(i, new Mat(imageClone, region), new Point(x1, y1));
                    ((CaliperParams)parameter).ROIBool = true;
                }

                sortEdge.Add(new int[] { i, x1, y1, x2, y2 });
                edges.Score = contrast[0];
                edges.ScoringFunction0 = contrast[0];
                edges.Contrast_E0 = contrast[1];
                edges.Position = Math.Round((double)x1 - imageClone.Width / 2, 4);
                edges.X = x1;
                edges.Y = imageClone.Height;

                caliperResult.caliperEdges.Add(edges);
            }
            
            sortEdge = sortEdge.OrderBy(l => l[1]).ToList();
            for (int i = 0; i < sortEdge.Count; i++)
            {
                int[] temp = sortEdge[i];
                caliperResult.caliperEdges[temp[0]].Edge0 = i;
                caliperPoints.Add(i, new List<int> { temp[1], temp[2], temp[3], temp[4] });
            }
            //=====================================================================================================================
            
            if (((CaliperParams)parameter).EdgeMode == "Edge Pair")
                PairResult(imageClone, region);
            else
                EdgesResult(imageClone, region);
        }

        public  object showResult()
        {
            resultSource?.Dispose();
            resultSource = new BindingSource();
            if (caliperResult == null)
                return resultSource;
            if (m_toolControl == null)
                return resultSource;

            if (((CaliperParams)parameter).EdgeMode == "Edge Pair")
                resultSource.DataSource = caliperEdgesPair;
            else
                resultSource.DataSource = caliperResult.caliperEdges;
            return resultSource;
        }

        public  void showResultImages()
        {
            HelperClass.showResultImagesStatic(m_bitmapList, m_DisplaySelection, caliperResult.resultImage, ToolName, "CaliperImage");
        }

        public  void Dispose()
        {
            caliperResult?.Dispose();
            m_bitmapList?.Dispose();
            m_toolControl?.Dispose();
            resultSource?.Dispose();
        }

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

        private void EdgesResult(Mat imageClone, Rectangle region)
        {
            //============================================ Draw Edge Data =============================================
            Bitmap combinedImage = new Bitmap(imageClone.Width, imageClone.Height);
            using (Graphics graphics = Graphics.FromImage(combinedImage))
            {
                graphics.DrawImage(imageClone.ToBitmap(), 0, 0);
                List<int> m_listDeleteIndex = new List<int>();
                for (int i = 0; i < caliperResult.caliperEdges.Count; i++)
                {
                    Edges caliper = caliperResult.caliperEdges[i];
                    if (i <= ((CaliperParams)parameter).maxResult - 1)
                    {
                        double contrast = caliper.Contrast_E0;
                        float x = (float)caliper.X;
                        float y = (float)caliper.Y;
                        if (((CaliperParams)parameter).polarity0 == "Dark to Light")
                        {
                            if (contrast < 0)
                            {
                                m_listDeleteIndex.Add(i);
                                continue;
                            }
                        }
                        else if (((CaliperParams)parameter).polarity0 == "Light to Dark")
                        {
                            if (contrast > 0)
                            {
                                m_listDeleteIndex.Add(i);
                                continue;
                            }
                        }
                        using (Pen pen = new Pen(Color.SpringGreen, 2))
                        using (Graphics contourGraphics = Graphics.FromImage(combinedImage))
                        {
                            if (region.IsEmpty)
                                contourGraphics.DrawLine(pen, x, 0, x, y);
                            else
                                contourGraphics.DrawLine(pen, x + region.X, region.Y, x + region.X, region.Y + region.Height);
                            pen.Dispose();
                            contourGraphics.Dispose();
                        }
                    }
                    else
                        m_listDeleteIndex.Add(i);
                    graphics.Dispose();
                }
                for (int i = m_listDeleteIndex.Count-1; i >= 0; i--)
                    caliperResult.caliperEdges.RemoveAt(m_listDeleteIndex[i]);

                caliperResult.resultImage = combinedImage.ToMat();
                combinedImage.Dispose();
            }
            //=========================================================================================================
        }

        private void PairResult(Mat imageClone, Rectangle region)
        {
            //======================================= Calculate/Draw Edge Data ========================================
            Bitmap combinedImage = new Bitmap(imageClone.Width, imageClone.Height);
            using (Graphics graphics = Graphics.FromImage(combinedImage))
            {
                graphics.DrawImage(imageClone.ToBitmap(), 0, 0);
                bool[] draw = new bool[caliperResult.caliperEdges.Count];
                caliperEdgesPair = new SortableBindingList<EdgesPair>();

                for (int i = 0, k = 0; i < caliperResult.caliperEdges.Count - 1; i++)
                {
                    for (int j = i + 1; j < caliperResult.caliperEdges.Count; j++)
                    {
                        if (k > ((CaliperParams)parameter).maxResult - 1)
                            break;
                        Edges edge0 = caliperResult.caliperEdges[i];
                        double contrast0 = edge0.Contrast_E0;
                        float x0 = (float)edge0.X;
                        float y = (float)edge0.Y;

                        if (((CaliperParams)parameter).polarity0 == "Dark to Light")
                        {
                            if (contrast0 < 0)
                                continue;
                        }
                        else if (((CaliperParams)parameter).polarity0 == "Light to Dark")
                        {
                            if (contrast0 > 0)
                                continue;
                        }

                        Edges edge1 = caliperResult.caliperEdges[j];
                        double contrast1 = edge1.Contrast_E0;
                        float x1 = (float)edge1.X;
                        if (((CaliperParams)parameter).polarity1 == "Dark to Light")
                        {
                            if (contrast1 < 0)
                                continue;
                        }
                        else if (((CaliperParams)parameter).polarity1 == "Light to Dark")
                        {
                            if (contrast1 > 0)
                                continue;
                        }

                        double width = Math.Abs(x1 - x0);
                        if (width > ((CaliperParams)parameter).estimatedWidth * 2 || width < ((CaliperParams)parameter).estimatedWidth / 2)
                            break;

                        caliperEdgesPair.Add(new EdgesPair(Math.Round((edge0.Score + edge1.Score) / 2, 4),
                            edge0.Edge0, edge1.Edge0, Math.Round(width, 4), Math.Round((edge0.Position + edge1.Position) / 2.0, 4), Math.Round((x0 + x1) / 2, 4), y,
                           Math.Round((edge0.Score + edge1.Score) / 2, 4),
                            edge0.Contrast_E0, edge0.Position, x0, y, edge1.Contrast_E0, edge1.Position, x1, y));

                        using (Pen pen = new Pen(Color.SpringGreen, 1))
                        {
                            if (region.IsEmpty)
                            {
                                if (!draw[i])
                                {
                                    graphics.DrawLine(pen, x0, 0, x0, y);
                                    draw[i] = true;
                                }
                                if (!draw[j])
                                {
                                    graphics.DrawLine(pen, x1, 0, x1, y);
                                    draw[j] = true;
                                }
                            }
                            else
                            {
                                if (!draw[i])
                                {
                                    graphics.DrawLine(pen, x0 + region.X, region.Y, x0 + region.X, region.Y + region.Height);
                                    draw[i] = true;
                                }
                                if (!draw[j])
                                {
                                    graphics.DrawLine(pen, x1 + region.X, region.Y, x1 + region.X, region.Y + region.Height);
                                    draw[j] = true;
                                }
                            }
                            pen.Dispose();
                        }
                    }

                    if (k > ((CaliperParams)parameter).maxResult - 1)
                        break;
                }

                caliperResult.resultImage = combinedImage.ToMat();
                combinedImage.Dispose();
                graphics.Dispose();
            }
            //=========================================================================================================*/
        }
    }

}
