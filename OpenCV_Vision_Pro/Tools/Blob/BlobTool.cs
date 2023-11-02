using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using OpenCV_Vision_Pro.Interface;
using OpenCV_Vision_Pro.Properties;
using Shared.ComponentModel.SortableBindingList;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace OpenCV_Vision_Pro
{
    /*
     * References
     * https://docs.opencv.org/4.x/dd/d49/tutorial_py_contour_features.html
     * 
     * CV_RETR_CCOMP retrieves all of the contours and organizes them into a two-level hierarchy. 
     * At the top level, there are external boundaries of the components. At the second level, there are boundaries of the holes.
     * If there is another contour inside a hole of a connected component, it is still put at the top level.
     * 
     * CV_RETR_TREE retrieves all of the contours and reconstructs a full hierarchy of nested contours. 
     * This full hierarchy is built and shown in the OpenCV contours.c demo.
     * https://stackoverflow.com/questions/60095520/understanding-contour-hierarchies-how-to-distinguish-filled-circle-contour-and
     * [next, previous, first child, parent]
     */
    // One Results
    public class BlobData
    {
        public int ID { get; set; }
        public double Area { get; set; }
        public double CenterMassX { get; set; }
        public double CenterMassY { get; set; }
        public string ConnectivityLabel { get; set; }
        public double Angle { get; set; }
        public double BoundaryPixelLength { get; set; }
        public double Perimeter { get; set; }
        public int NumChildren { get; set; }
        public double InertiaX { get; set; }
        public double InertiaY { get; set; }
        public double InertiaMin { get; set; }
        public double InertiaMax { get; set; }
        public double Elongation { get; set; }
        public double Acircularity { get; set; }
        public double AcircularityRms { get; set; }
        public double ImageBoundCenterX { get; set; }
        public double ImageBoundCenterY { get; set; }
        public double ImageBoundMinX { get; set; }
        public double ImageBoundMaxX { get; set; }
        public double ImageBoundMinY { get; set; }
        public double ImageBoundMaxY { get; set; }
        public double ImageBoundWidth { get; set; }
        public double ImageBoundHeight { get; set; }
        public double ImageBoundAspect { get; set; }
        public double MedianX { get; set; }
        public double MedianY { get; set; }
        public double BoundCenterX { get; set; }
        public double BoundCenterY { get; set; }
        public double BoundMinX { get; set; }
        public double BoundMaxX { get; set; }
        public double BoundMinY { get; set; }
        public double BoundMaxY { get; set; }
        public double BoundWidth { get; set; }
        public double BoundHeight { get; set; }
        public double BoundAspect { get; set; }
        public double BoundPrincipalMinX { get; set; }
        public double BoundPrincipalMaxX { get; set; }
        public double BoundPrincipalMinY { get; set; }
        public double BoundPrincipalMaxY { get; set; }
        public double BoundPrincipalWidth { get; set; }
        public double BoundPrincipalHeight { get; set; }
        public double BoundPrincipalAspect { get; set; }
        public double NotClipped { get; set; }
    }

    // List of Blob and BlobImage
    public class BlobResults : IDisposable, IToolResult
    {
        public List<BlobData> blobs { get; set; } = new List<BlobData>();

        public Mat resultImage { get; set; }

        public void Dispose()
        {
            resultImage?.Dispose();
        }
    }
    public class BlobParams : IParams
    {
        public Dictionary<string, ArrayList> MeasurementProperties { get; set; } = new Dictionary<string, ArrayList>();
        public List<string> morphologyOperation { get; set; } = new List<string>();
        public double threshold { get; set; } = 128;
        public int minArea { get; set; } = 10;
        public string polarity { get; set; } = "Dark blobs, Light background";
        public ROI m_roi { get; set; } = new ROI();
        public bool m_boolHasROI { get; set; } = false;
        public string thresholdMode { get; set; } = "Global (Otsu)";
        public int blockSize { get; set; } = 17;
        public int param1 { get; set; } = 10;
    }

    // Declare Variable
    public partial class BlobTool : IToolBase
    {
        public  string ToolName { get; set; }
        public  UserControlBase m_toolControl { get; set; }
        public  AutoDisposeDict<string, Mat> m_bitmapList { get; set; }
        public  BindingList<string> m_DisplaySelection { get; set; } = new BindingList<string>();
        public  BindingSource resultSource { get; set; }
        public  Rectangle m_rectROI { get; set; }
        public  IParams parameter { get; set; } = new BlobParams();

        public  IToolResult toolResult { get; set; }
        public BlobResults blobResults { get { return (BlobResults)toolResult; } set { toolResult = value; } }
        public Dictionary<int, Point[]> contourByRow { get; set; } = new Dictionary<int, Point[]>();
    }

    // Tool Method
    public partial class BlobTool:IToolBase
    {
        public BlobTool(string toolName) { this.ToolName = toolName; }

        public  void getGUI()
        {
            if (m_rectROI != null && !m_rectROI.IsEmpty)
            {
                parameter.m_roi.location = new Point(m_rectROI.X, m_rectROI.Y);
                parameter.m_roi.ROI_Width = m_rectROI.Width;
                parameter.m_roi.ROI_Height = m_rectROI.Height;
            }
            m_toolControl = new BlobToolControl(parameter) { Dock = DockStyle.Fill };
        }
        
        public  void Run(Mat img, Rectangle region)
        {
            parameter.m_roi.ROIRectangle = HelperClass.getROIImage(img, region, parameter.m_roi.points, out Mat image);
            if (!region.IsEmpty && parameter.m_roi.points != null)
            {

            }

           /*
                Mat mask = Mat.Zeros(img.Rows, img.Cols, img.Depth, img.NumberOfChannels);
                CvInvoke.FillPoly(mask, new VectorOfPoint(((BlobToolControl)m_toolControl).m_roi.points), new MCvScalar(255, 255, 255));

                Mat bitImage = new Mat();
                CvInvoke.BitwiseAnd(img, mask, bitImage);

                if(((BlobParams)parameter).polarity == "Dark blobs, Light background")
                {
                    CvInvoke.BitwiseNot(mask, mask);
                    CvInvoke.BitwiseOr(mask, bitImage, bitImage);
                }

                image = new Mat(bitImage, region);
                bitImage?.Dispose();
                mask?.Dispose();*/
            

            blobResults?.Dispose();
            blobResults = new BlobResults();

            if(((BlobToolControl)m_toolControl) != null)
                parameter = ((BlobToolControl)m_toolControl).BlobParams;
            else
                parameter = new BlobParams();

            Mat imageClone = new Mat();
            contourByRow.Clear();
            //================================================= Pre-Processing ============================================
            Mat filter_image = new Mat();
            //CvInvoke.BilateralFilter(image, filter_image, 9, 20, 20);
            CvInvoke.GaussianBlur(image, filter_image, new Size(3, 3), 0);

            imageClone = GetThresholdImage(filter_image, imageClone);
            filter_image.Dispose();

            // If have morphology operation selected
            if (((BlobParams)parameter).morphologyOperation.Count > 0)
            {
                foreach (string operation in ((BlobParams)parameter).morphologyOperation)
                    imageClone = RunMorphologyOperation(imageClone, operation);
            }
            //=============================================================================================================

            //====================================== Find Blobs => Contours ===============================================
            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
            Mat hierarchy = new Mat();
            
            CvInvoke.FindContours(imageClone, contours, hierarchy, RetrType.Tree, ChainApproxMethod.ChainApproxSimple);
            //=============================================================================================================

            //====================================== Draw Blobs + Calculation =============================================
            Bitmap combinedImage = new Bitmap(image.Width, image.Height);
            using (Brush grayBrush = new SolidBrush(Color.Gray))
            using (Graphics graphics = Graphics.FromImage(combinedImage))
            {
                
                graphics.FillRectangle(grayBrush, new Rectangle(0, 0, image.Width, image.Height));
                Stack<int> stack = new Stack<int>();
                stack.Push(0);
                BlobRecursiveRun(hierarchy, contours,true, combinedImage,stack);
                blobResults.resultImage = combinedImage.ToMat();

                grayBrush.Dispose();
                graphics.Dispose();
                combinedImage.Dispose();
            }
            contours.Dispose();
            hierarchy.Dispose();
            imageClone.Dispose();
            //=============================================================================================================
            image.Dispose();
        }

        public  object showResult()
        {
            resultSource?.Dispose();

            resultSource = new BindingSource();
            if (blobResults == null)
                return resultSource;
            if (m_toolControl == null)
                return resultSource;
            
            SortableBindingList<BlobData> resultList = new SortableBindingList<BlobData>();
            resultSource.DataSource = resultList;
            
            foreach (BlobData r in blobResults.blobs)
                resultList.Add(r);
           
            return resultSource;
        }

        public  void showResultImages()
        {
            if (Form1.m_bitmapList.ContainsKey("LastRun." + ToolName + ".BlobImage"))
            {
                Form1.m_bitmapList["LastRun." + ToolName + ".BlobImage"]?.Dispose();
                Form1.m_bitmapList["LastRun." + ToolName + ".BlobImage"] = blobResults.resultImage.Clone();
            }
            else
            {
                Form1.m_bitmapList.Add("LastRun." + ToolName + ".BlobImage", blobResults.resultImage.Clone());
                if (!Form1.m_form1DisplaySelection.Contains("LastRun." + ToolName + ".BlobImage"))
                    Form1.m_form1DisplaySelection.Add("LastRun." + ToolName + ".BlobImage");
            }

            if (m_bitmapList.ContainsKey("LastRun." + ToolName + ".BlobImage"))
            {
                m_bitmapList["LastRun." + ToolName + ".BlobImage"]?.Dispose();
                m_bitmapList["LastRun." + ToolName + ".BlobImage"] = blobResults.resultImage.Clone();
            }
            else
            {
                m_bitmapList.Add("LastRun." + ToolName + ".BlobImage", blobResults.resultImage.Clone());
                if (!m_DisplaySelection.Contains("LastRun." + ToolName + ".BlobImage"))
                    m_DisplaySelection.Add("LastRun." + ToolName + ".BlobImage");
            }
        }

        public  void Dispose()
        {
            blobResults?.Dispose();
            m_toolControl?.Dispose();
            m_bitmapList?.Dispose();
            resultSource?.Dispose();
        }

        private Mat RunMorphologyOperation(Mat image, string operation)
        {
            Mat kernel;
            if (operation.EndsWith("Horizontal"))
                kernel = CvInvoke.GetStructuringElement(ElementShape.Rectangle, new Size(3, 1), new Point(-1, -1));
            else if (operation.EndsWith("Vertical"))
                kernel = CvInvoke.GetStructuringElement(ElementShape.Rectangle, new Size(1, 3), new Point(-1, -1));
            else
                kernel = CvInvoke.GetStructuringElement(ElementShape.Rectangle, new Size(3, 3), new Point(-1, -1));

            if (operation.StartsWith("Erode"))
                CvInvoke.MorphologyEx(image, image, MorphOp.Erode, kernel, new Point(), 1, BorderType.Default, new MCvScalar());
            else if (operation.StartsWith("Dilate"))
                CvInvoke.MorphologyEx(image, image, MorphOp.Dilate, kernel, new Point(), 1, BorderType.Default, new MCvScalar());
            else if (operation.StartsWith("Close"))
                CvInvoke.MorphologyEx(image, image, MorphOp.Close, kernel, new Point(), 1, BorderType.Default, new MCvScalar());
            else if (operation.StartsWith("Open"))
                CvInvoke.MorphologyEx(image, image, MorphOp.Open, kernel, new Point(), 1, BorderType.Default, new MCvScalar());

            kernel.Dispose();
            return image;
        }

        private void BlobRecursiveRun(Mat hierarchy, VectorOfVectorOfPoint contours, bool isBlob, Bitmap combinedImage, Stack<int> stack)
        {
            while (stack.Count > 0)
            {
                Stack<int> childStack = new Stack<int>();
                int index = stack.Pop();
                try
                {
                    Moments m_moments = CvInvoke.Moments(contours[index]);
                    bool m_boolPass = true;
                    if (m_moments.M00 > ((BlobParams)parameter).minArea)
                    {
                        BlobData m_blob = new BlobData();
                        double CenterMassX = Math.Round(m_moments.M10 / m_moments.M00, 4);
                        double CenterMassY = Math.Round(m_moments.M01 / m_moments.M00, 4);

                        m_blob.ID = index;
                        m_blob.Area = m_moments.M00;
                        m_blob.CenterMassX = CenterMassX;
                        m_blob.CenterMassY = CenterMassY;
                        m_blob.Perimeter = CvInvoke.ArcLength(contours[index], true);
                        m_blob.Acircularity = Math.Pow(m_blob.Perimeter, 2) / (4 * Math.PI * m_moments.M00);
                        m_blob.InertiaX = Math.Round(m_moments.Mu20, 4);
                        m_blob.InertiaY = Math.Round(m_moments.Mu02, 4);

                        if (isBlob)
                            m_blob.ConnectivityLabel = "1:Blob";
                        else
                            m_blob.ConnectivityLabel = "0:Hole";

                        Rectangle boundingbox = CvInvoke.BoundingRectangle(contours[index]);
                        m_blob.BoundHeight = boundingbox.Height;
                        m_blob.BoundWidth = boundingbox.Width;
                        m_blob.BoundMinX = boundingbox.X - CenterMassX;
                        m_blob.BoundMinY = boundingbox.Y - CenterMassY;
                        m_blob.BoundMaxX = boundingbox.X + boundingbox.Width - CenterMassX;
                        m_blob.BoundMaxY = boundingbox.Y + boundingbox.Height - CenterMassY;
                        m_blob.BoundAspect = boundingbox.Height / boundingbox.Width;

                        RotatedRect boundPrincipal = CvInvoke.MinAreaRect(contours[index]);
                        m_blob.BoundPrincipalHeight = boundPrincipal.MinAreaRect().Height;
                        m_blob.BoundPrincipalWidth = boundPrincipal.MinAreaRect().Width;
                        m_blob.BoundPrincipalAspect = boundingbox.Width / boundingbox.Height;

                        // https://stackoverflow.com/questions/14854592/retrieve-elongation-feature-in-python-opencv-what-kind-of-moment-it-supposed-to
                        m_blob.Elongation = ((m_moments.Mu20 + m_moments.Mu02) + Math.Sqrt(4 * Math.Pow(m_moments.Mu11, 2) + Math.Pow(m_moments.Mu20 - m_moments.Mu02, 2))) / ((m_moments.Mu20 + m_moments.Mu02) - Math.Sqrt(4 * Math.Pow(m_moments.Mu11, 2) + Math.Pow(m_moments.Mu20 - m_moments.Mu02, 2)));

                        m_moments?.Dispose();
                        foreach (KeyValuePair<string, ArrayList> kvp in ((BlobParams)parameter).MeasurementProperties)
                        {
                            string key = kvp.Key;
                            ArrayList value = kvp.Value;
                            PropertyInfo propInfo = typeof(BlobData).GetProperty(key);
                            double lowValue = double.Parse((string)value[1]);
                            double highValue = double.Parse((string)value[2]);
                            if (propInfo != null)
                            {
                                object result = propInfo.GetValue(m_blob);
                                double m_doubleResult;
                                if (key == "ConnectivityLabel")
                                {
                                    if (result.ToString() == "1:Blob")
                                        m_doubleResult = 1;
                                    else
                                        m_doubleResult = 0;
                                }
                                else
                                    m_doubleResult = (double)result;

                                if ((String)value[0] == "Include")
                                {
                                    if (m_doubleResult < lowValue || m_doubleResult > highValue) //要跳过
                                    {
                                        m_boolPass = false;
                                        break;
                                    }

                                }
                                else if ((String)value[0] == "Exclude")
                                {
                                    if (m_doubleResult >= lowValue && m_doubleResult <= highValue) //要跳过
                                    {
                                        m_boolPass = false;
                                        break;
                                    }
                                }
                            }
                        }

                        if (m_boolPass)
                        {
                            blobResults.blobs.Add(m_blob);

                            using (Graphics contourGraphics = Graphics.FromImage(combinedImage))
                            {
                                Point[] points = contours[index].ToArray();

                                try
                                {
                                    using (Pen pen = new Pen(Color.SpringGreen, 2))
                                    {
                                        contourByRow.Add(index, points);
                                        contourGraphics.DrawPolygon(pen, points);
                                        pen.Dispose();
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.ToString());
                                }

                                if (isBlob)
                                {
                                    using (Brush blob = new SolidBrush(Color.White))
                                    {
                                        contourGraphics.FillPolygon(blob, points);
                                        blob.Dispose();
                                    }
                                }

                                else if (!isBlob)
                                {
                                    using (Brush hole = new SolidBrush(Color.Black))
                                    {
                                        contourGraphics.FillPolygon(hole, points);
                                        hole.Dispose();
                                    }
                                }
                                contourGraphics.Dispose();
                            }
                        }
                        else
                        {
                            using (Graphics contourGraphics = Graphics.FromImage(combinedImage))
                            {
                                using (Brush background = new SolidBrush(Color.Gray))
                                {
                                    contourGraphics.FillPolygon(background, contours[index].ToArray());
                                    background.Dispose();
                                }
                                contourGraphics.Dispose();
                            }
                        }
                    }

                    if ((int)hierarchy.GetData().GetValue(0, index, 2) != -1)
                        childStack.Push((int)hierarchy.GetData().GetValue(0, index, 2));

                    if ((int)hierarchy.GetData().GetValue(0, index, 0) != -1)
                        stack.Push((int)hierarchy.GetData().GetValue(0, index, 0));
                    else
                        BlobRecursiveRun(hierarchy, contours, !isBlob, combinedImage, childStack);

                }
                catch(Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        private Mat GetThresholdImage(Mat filter_image, Mat imageClone)
        {
            try
            {
                double bestThreshold;
                switch (((BlobParams)parameter).thresholdMode)
                {
                    case "Global (Triangle)":
                        bestThreshold = CvInvoke.Threshold(filter_image, imageClone, 0, 255, ThresholdType.Triangle);
                        if (((BlobParams)parameter).polarity == "Dark blobs, Light background")
                            CvInvoke.Threshold(filter_image, imageClone, bestThreshold, 255, ThresholdType.BinaryInv);
                        break;
                    case "Global (Manual)":
                        if (((BlobParams)parameter).polarity == "Dark blobs, Light background")
                            CvInvoke.Threshold(filter_image, imageClone, ((BlobParams)parameter).threshold, 255, ThresholdType.BinaryInv);
                        else
                            CvInvoke.Threshold(filter_image, imageClone, ((BlobParams)parameter).threshold, 255, ThresholdType.Binary);
                        break;
                    case "Global (Otsu)":
                        bestThreshold = CvInvoke.Threshold(filter_image, imageClone, 0, 255, ThresholdType.Otsu);
                        if (((BlobParams)parameter).polarity == "Dark blobs, Light background")
                            CvInvoke.Threshold(filter_image, imageClone, bestThreshold, 255, ThresholdType.BinaryInv);
                        break;
                    case "Local (MeanC)":
                        if (((BlobParams)parameter).polarity == "Dark blobs, Light background")
                            CvInvoke.AdaptiveThreshold(filter_image, imageClone, 255, AdaptiveThresholdType.MeanC, ThresholdType.BinaryInv, ((BlobParams)parameter).blockSize, ((BlobParams)parameter).param1);
                        else
                            CvInvoke.AdaptiveThreshold(filter_image, imageClone, 255, AdaptiveThresholdType.MeanC, ThresholdType.Binary, ((BlobParams)parameter).blockSize, ((BlobParams)parameter).param1);
                        break;
                    case "Local (GaussianC)":
                        if (((BlobParams)parameter).polarity == "Dark blobs, Light background")
                            CvInvoke.AdaptiveThreshold(filter_image, imageClone, 255, AdaptiveThresholdType.GaussianC, ThresholdType.BinaryInv, ((BlobParams)parameter).blockSize, ((BlobParams)parameter).param1);
                        else
                            CvInvoke.AdaptiveThreshold(filter_image, imageClone, 255, AdaptiveThresholdType.GaussianC, ThresholdType.Binary, ((BlobParams)parameter).blockSize, ((BlobParams)parameter).param1);
                        break;
                    default:
                        return filter_image;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("Input Image Error in "+ToolName);
            }
            return imageClone;
        }
    }
    
}