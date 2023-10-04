using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.ML;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using OpenCV_Vision_Pro.Interface;
using OpenCV_Vision_Pro.Properties;
using Shared.ComponentModel.SortableBindingList;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
    public class BlobTool:IToolBase
    { 
        // One Results
        private class Blob
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
        private class BlobResults : IDisposable
        {
            public List<Blob> blobs { get; set; } = new List<Blob>();
            public Mat BlobImage { get; set; }

            public void Dispose()
            {
                BlobImage?.Dispose();
            }
        }
        public BlobTool(string toolName) { this.ToolName = toolName; }

        public override Bitmap toolIcon { get; } = Resources.blob;
        public override string ToolName { get; set; }
        public override UserControlBase m_toolControl { get; set; }
        public override AutoDisposeDict<string, Mat> m_bitmapList { get; set; }
        public override BindingList<string> m_DisplaySelection { get; set; } = new BindingList<string>();
        public override BindingSource resultSource { get; set; }
        public override Rectangle m_rectROI { get; set; }
        public override IParams parameter { get; set; } = new BlobParams();

        private BlobResults blobResults;
        public Dictionary<int, Point[]> contourByRow { get; set; } = new Dictionary<int, Point[]>();

        public override void getGUI()
        {
            if (m_rectROI != null && !m_rectROI.IsEmpty)
            {
                parameter.m_roi.location = new Point(m_rectROI.X, m_rectROI.Y);
                parameter.m_roi.ROI_Width = m_rectROI.Width;
                parameter.m_roi.ROI_Height = m_rectROI.Height;
            }
            m_toolControl = new BlobToolControl(parameter) { Dock = DockStyle.Fill };
        }
        
        public override void Run(Mat img, Rectangle region)
        {
            Mat image;
            if (region.IsEmpty)
                image = img.Clone();
            else
                image = new Mat(img,region);

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
            using (Graphics graphics = Graphics.FromImage(combinedImage))
            {
                Brush grayBrush = new SolidBrush(Color.Gray);
                graphics.FillRectangle(grayBrush, new Rectangle(0, 0, image.Width, image.Height));
                grayBrush.Dispose();

                bool[] calcDrawDone = new bool[contours.Length];
                BlobRecursiveRun(hierarchy, contours, calcDrawDone, 0, true, combinedImage);
                blobResults.BlobImage = combinedImage.ToMat();

                combinedImage.Dispose();
            }
            contours.Dispose();
            hierarchy.Dispose();
            imageClone.Dispose();
            //=============================================================================================================

            /*
            //============================================= Filter Results ================================================
            string m_strBlobsFilter = "";
            m_strBlobsFilter = createFilterString(((BlobParams)parameter).MeasurementProperties, m_strBlobsFilter);
            if (m_strBlobsFilter != "")
            {
                var options = ScriptOptions.Default.AddReferences(typeof(Blob).Assembly);
                Func<Blob, bool> FilterExpression = await CSharpScript.EvaluateAsync<Func<Blob, bool>>(m_strBlobsFilter, options);
                blobResults.blobs = new List<Blob>(blobResults.blobs.Where(FilterExpression).ToList());
            }
            //=============================================================================================================
            */
            image.Dispose();
        }

        private Mat GetThresholdImage(Mat filter_image, Mat imageClone)
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
                    bestThreshold = CvInvoke.Threshold(filter_image, imageClone,0, 255, ThresholdType.Otsu);
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
                    return filter_image.Clone();
            }
            return imageClone;
            /*
            CvInvoke.Threshold(filter_image, imageClone, ((BlobParams)parameter).threshold, 255, ThresholdType.Mask);
            CvInvoke.Imshow("Mask", imageClone);
            */
            
        }

        public override object showResult()
        {
            resultSource?.Dispose();

            resultSource = new BindingSource();
            if (blobResults == null)
                return resultSource;
            if (m_toolControl == null)
                return resultSource;
            
            SortableBindingList<Blob> resultList = new SortableBindingList<Blob>();
            resultSource.DataSource = resultList;
            
            foreach (Blob r in blobResults.blobs)
                resultList.Add(r);
           
            return resultSource;
        }

        public override void showResultImages()
        {
            if (Form1.m_bitmapList.ContainsKey("LastRun." + ToolName + ".BlobImage"))
            {
                Form1.m_bitmapList["LastRun." + ToolName + ".BlobImage"]?.Dispose();
                Form1.m_bitmapList["LastRun." + ToolName + ".BlobImage"] = blobResults.BlobImage.Clone();
            }
            else
            {
                Form1.m_bitmapList.Add("LastRun." + ToolName + ".BlobImage", blobResults.BlobImage.Clone());
                if (!Form1.m_form1DisplaySelection.Contains("LastRun." + ToolName + ".BlobImage"))
                    Form1.m_form1DisplaySelection.Add("LastRun." + ToolName + ".BlobImage");
            }

            if (m_bitmapList.ContainsKey("LastRun." + ToolName + ".BlobImage"))
            {
                m_bitmapList["LastRun." + ToolName + ".BlobImage"]?.Dispose();
                m_bitmapList["LastRun." + ToolName + ".BlobImage"] = blobResults.BlobImage.Clone();
            }
            else
            {
                m_bitmapList.Add("LastRun." + ToolName + ".BlobImage", blobResults.BlobImage.Clone());
                if (!m_DisplaySelection.Contains("LastRun." + ToolName + ".BlobImage"))
                    m_DisplaySelection.Add("LastRun." + ToolName + ".BlobImage");
            }
        }

        public override void Dispose()
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

        private void BlobRecursiveRun(Mat hierarchy, VectorOfVectorOfPoint contours, bool[] calcDrawDone, int index, bool isBlob, Bitmap combinedImage)
        {
            try
            {
                if (index == -1)
                    return;
                if (index >= calcDrawDone.Length)
                    return;
                if (calcDrawDone[index])
                    return;
                calcDrawDone[index] = true;

                Moments m_moments = CvInvoke.Moments(contours[index]);
                bool m_boolPass = true;
                if (m_moments.M00 > ((BlobParams)parameter).minArea)
                {
                    Blob m_blob = new Blob();
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
                        PropertyInfo propInfo = typeof(Blob).GetProperty(key);
                        double lowValue = double.Parse((String)value[1]);
                        double highValue = double.Parse((String)value[2]);
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
                                if (m_doubleResult < lowValue && m_doubleResult > highValue) //要跳过
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
                                }
                            }

                            else if (!isBlob)
                            {
                                using (Brush hole = new SolidBrush(Color.Black))
                                {
                                    contourGraphics.FillPolygon(hole, points);
                                }
                            }
                        }
                    }
                    else
                    {
                        using (Graphics contourGraphics = Graphics.FromImage(combinedImage))
                        {
                            using (Brush hole = new SolidBrush(Color.Gray))
                            {
                                contourGraphics.FillPolygon(hole, contours[index].ToArray());
                            }
                        }
                    }
                }

                // hierarchy : [Next, Previous, First_Child, Parent]
                if ((int)hierarchy.GetData().GetValue(0, index, 0) != -1)
                    BlobRecursiveRun(hierarchy, contours, calcDrawDone, (int)hierarchy.GetData().GetValue(0, index, 0), isBlob, combinedImage);
                if ((int)hierarchy.GetData().GetValue(0, index, 2) != -1)
                    BlobRecursiveRun(hierarchy, contours, calcDrawDone, (int)hierarchy.GetData().GetValue(0, index, 2), !isBlob, combinedImage);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        
        /*
        private string createFilterString(Dictionary<string, ArrayList> MeasurementProperties, string m_strBlobsFilter)
        {
            if (MeasurementProperties.Count == 0)
            {
                m_strBlobsFilter = "";
                return m_strBlobsFilter;
            }
            if (m_strBlobsFilter == "")
                m_strBlobsFilter = "res => ";
            foreach (var condition in MeasurementProperties)
            {
                string m_strName = condition.Key;
                ArrayList c = condition.Value;
                if ((String)c[0] == "Exclude")
                {
                    if (m_strBlobsFilter.Length > 7)
                        m_strBlobsFilter += " && ";
                    if (m_strName == "ConnectivityLabel")
                    {
                        if ((String)c[1] == "0")
                            c[1] = "Hole";
                        else
                            c[1] = "Blob";

                        if ((String)c[2] == "0")
                            c[2] = "Hole";
                        else
                            c[2] = "Blob";

                        m_strBlobsFilter += " res." + m_strName + " != \"" + c[1] + "\" && res." + m_strName + " != \"" + c[2] + "\"";
                    }
                    else
                        m_strBlobsFilter += " res." + m_strName + " < " + c[1] + " || res." + m_strName + " > " + c[2];
                }
                else
                {
                    if (m_strBlobsFilter.Length > 7)
                        m_strBlobsFilter += " && ";
                    if (m_strName == "ConnectivityLabel")
                    {
                        if ((String)c[1] == "0")
                            c[1] = "Hole";
                        else
                            c[1] = "Blob";

                        if ((String)c[2] == "0")
                            c[2] = "Hole";
                        else
                            c[2] = "Blob";

                        m_strBlobsFilter += " res." + m_strName + " == \"" + c[1] + "\" || res." + m_strName + " == \"" + c[2] + "\"";
                    }
                    else
                        m_strBlobsFilter += " res." + m_strName + " >= " + c[1] + " && res." + m_strName + " <= " + c[2];
                }
            }
            return m_strBlobsFilter;
        }*/
    }
    
    public class BlobParams: IParams
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
}