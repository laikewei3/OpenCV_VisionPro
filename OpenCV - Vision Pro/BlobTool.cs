using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace OpenCV_Vision_Pro
{
    //https://docs.opencv.org/4.x/dd/d49/tutorial_py_contour_features.html
    public class BlobTool
    {
        public string polarity { get; set; }
        public List<Blob> blobs { get; set; } = new List<Blob>();
        public Dictionary<int,VectorOfPoint> contourByRow { get; set; } = new Dictionary<int,VectorOfPoint>();
        public Bitmap BlobImage { get; set; }
        public Dictionary<string,ArrayList> MeasurementProperties { get; set; } = new Dictionary<string,ArrayList>();
        public double threshold { get; set; }
        public int minArea { get; set; } = 10;
        public List<String> morphologyOperation {  get; set; } = new List<String>();

        public async void Run(Mat image)
        {
            CvInvoke.CvtColor(image, image, ColorConversion.Bgr2Gray);
            //CvInvoke.GaussianBlur(image, image, new Size(3, 3), 3);
            Mat filter_image = new Mat();
            CvInvoke.BilateralFilter(image, filter_image, 9, 20, 20);
            if (polarity == "Light blobs, Dark background")
                CvInvoke.Threshold(filter_image, image, threshold, 255, ThresholdType.Binary);
            else
                CvInvoke.Threshold(filter_image, image, threshold, 255, ThresholdType.BinaryInv);
            
            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
            Mat hierarchy = new Mat();
            /*
             * CV_RETR_CCOMP retrieves all of the contours and organizes them into a two-level hierarchy. 
             * At the top level, there are external boundaries of the components. At the second level, there are boundaries of the holes.
             * If there is another contour inside a hole of a connected component, it is still put at the top level.
             * 
             * CV_RETR_TREE retrieves all of the contours and reconstructs a full hierarchy of nested contours. 
             * This full hierarchy is built and shown in the OpenCV contours.c demo.
             * https://stackoverflow.com/questions/60095520/understanding-contour-hierarchies-how-to-distinguish-filled-circle-contour-and
             * [next, previous, first child, parent]
             */
            if(morphologyOperation.Count > 0)
            {
                foreach(String operation in  morphologyOperation)
                {
                    image = RunMorphologyOperation(image,operation);
                }
            }
            CvInvoke.FindContours(image, contours, hierarchy, RetrType.Tree, ChainApproxMethod.ChainApproxSimple);
            blobs = new List<Blob>();
            contourByRow = new Dictionary<int,VectorOfPoint>();
            Bitmap combinedImage = new Bitmap(image.Width, image.Height);
            using (Graphics graphics = Graphics.FromImage(combinedImage))
            {
                graphics.DrawImage(image.ToBitmap(), 0, 0);
                for (int i = 0, j = 0; i < contours.Size; i++)
                {
                    Blob m_blob = new Blob();
                    Moments m_moments = CvInvoke.Moments(contours[i]);

                    if (m_moments.M00 <= minArea)
                        continue;

                    double CenterMassX = Math.Round(m_moments.M10 / m_moments.M00, 4);
                    double CenterMassY = Math.Round(m_moments.M01 / m_moments.M00, 4);

                    m_blob.ID = i;
                    m_blob.Area = m_moments.M00;
                    m_blob.CenterMassX = CenterMassX;
                    m_blob.CenterMassY = CenterMassY;
                    m_blob.ConnectivityLabel = "";
                    m_blob.Perimeter = CvInvoke.ArcLength(contours[i],true);
                    m_blob.Acircularity = Math.Pow(m_blob.Perimeter, 2) / (4 * Math.PI * m_moments.M00);
                    //m_blob.AcircularityRms = CalculateAcircularityRMS(contours[i],m_moments.M00, m_moments.GravityCenter);
                    m_blob.InertiaX = Math.Round(m_moments.Mu20,4);
                    m_blob.InertiaY = Math.Round(m_moments.Mu02,4);

                    Rectangle boundingbox = CvInvoke.BoundingRectangle(contours[i]);
                    m_blob.BoundHeight = boundingbox.Height;
                    m_blob.BoundWidth = boundingbox.Width;
                    m_blob.BoundMinX = boundingbox.X - CenterMassX;
                    m_blob.BoundMinY = boundingbox.Y - CenterMassY;
                    m_blob.BoundMaxX = boundingbox.X+boundingbox.Width - CenterMassX;
                    m_blob.BoundMaxY = boundingbox.Y+boundingbox.Height - CenterMassY;
                    m_blob.BoundAspect = boundingbox.Height/boundingbox.Width;
                    
                    RotatedRect boundPrincipal = CvInvoke.MinAreaRect(contours[i]);
                    m_blob.BoundPrincipalHeight = boundPrincipal.MinAreaRect().Height;
                    m_blob.BoundPrincipalWidth = boundPrincipal.MinAreaRect().Width;
                    m_blob.BoundPrincipalAspect = boundingbox.Width/boundingbox.Height;

                    //https://stackoverflow.com/questions/14854592/retrieve-elongation-feature-in-python-opencv-what-kind-of-moment-it-supposed-to
                    m_blob.Elongation = ((m_moments.Mu20 + m_moments.Mu02) + Math.Sqrt(4 * Math.Pow(m_moments.Mu11, 2) + Math.Pow(m_moments.Mu20 - m_moments.Mu02, 2))) / ((m_moments.Mu20 + m_moments.Mu02) - Math.Sqrt(4 * Math.Pow(m_moments.Mu11, 2) + Math.Pow(m_moments.Mu20 - m_moments.Mu02, 2)));
                    using (Pen pen = new Pen(Color.SpringGreen,2))
                    using (Graphics contourGraphics = Graphics.FromImage(combinedImage))
                    {
                        contourGraphics.DrawPolygon(pen, contours[i].ToArray());
                    }
                    contourByRow.Add(j++, contours[i]);
                    blobs.Add(m_blob);
                }
                BlobImage = combinedImage;
            }
            String m_strBlobsFilter = "";
            m_strBlobsFilter = createFilterString(MeasurementProperties, m_strBlobsFilter);
            if (m_strBlobsFilter != "")
            {
                var options = ScriptOptions.Default.AddReferences(typeof(Blob).Assembly);
                Func<Blob, bool> FilterExpression = await CSharpScript.EvaluateAsync<Func<Blob, bool>>(m_strBlobsFilter, options);
                blobs = blobs.Where(FilterExpression).ToList();
            }
            hierarchy.Dispose();
        }

        private Mat RunMorphologyOperation(Mat image,string operation)
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

            return image;
        }

        private string createFilterString(Dictionary<String, ArrayList> MeasurementProperties, String m_strBlobsFilter)
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
                String m_strName = condition.Key;
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
                    }else
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
                    }else
                        m_strBlobsFilter += " res." + m_strName + " >= " + c[1] + " && res." + m_strName + " <= " + c[2];
                }
            }
            return m_strBlobsFilter;
        }
        /*
        private double CalculateAcircularityRMS(VectorOfPoint contour, double contourArea, MCvPoint2D64f center)
        {
            double r0 = Math.Sqrt(contourArea / Math.PI);

            double sumSquaredDifferences = 0;
            double y = 0;
            for (int i = 0; i < contour.Size; i++)
            {
                PointF point = contour[i];
                double distanceToCentroid = Math.Sqrt(Math.Pow(point.X - center.X, 2) + Math.Pow(point.Y - center.Y, 2));
                double difference = distanceToCentroid - r0;
                sumSquaredDifferences += Math.Pow(difference, 2);
                y += point.Y;
            }

            double meanSquaredDifference = sumSquaredDifferences / contour.Size;
            double acircularityRMS = Math.Sqrt(meanSquaredDifference) / (y/contour.Size);

            return acircularityRMS;
        }*/
    }



    public class Blob
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
}
