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
{//https://docs.opencv.org/4.x/dd/d49/tutorial_py_contour_features.html
    public class BlobTool
    {
        public String polarity { get; set; }
        public List<Blob> blobs { get; set; }
        public Dictionary<int,VectorOfPoint> contourByID { get; set; }
        public Bitmap BlobImage { get; set; }
        public Dictionary<String,ArrayList> MeasurementProperties { get; set; }

        public async void Run(Mat image)
        {
            CvInvoke.CvtColor(image, image, ColorConversion.Bgr2Gray);
            //CvInvoke.GaussianBlur(image, image, new Size(3, 3), 3);
            Mat filter_image = new Mat();
            CvInvoke.BilateralFilter(image, filter_image, 9, 20, 20);
            if (polarity == "Light blobs, Dark background")
                CvInvoke.Threshold(filter_image, image, 128, 255, ThresholdType.Binary);
            else
                CvInvoke.Threshold(filter_image, image, 128, 255, ThresholdType.BinaryInv);
            
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

            CvInvoke.FindContours(image, contours, hierarchy, RetrType.Tree, ChainApproxMethod.ChainApproxSimple);
            blobs = new List<Blob>();
            contourByID = new Dictionary<int,VectorOfPoint>();
            Bitmap combinedImage = new Bitmap(image.Width, image.Height);
            using (Graphics graphics = Graphics.FromImage(combinedImage))
            {
                graphics.DrawImage(image.ToBitmap(), 0, 0);
                for (int i = 0; i < contours.Size; i++)
                {
                    Blob m_blob = new Blob();
                    Moments m_moments = CvInvoke.Moments(contours[i]);

                    if (m_moments.M00 <= 0)
                        continue;

                    double CenterMassX = Math.Round(m_moments.M10 / m_moments.M00, 4);
                    double CenterMassY = Math.Round(m_moments.M01 / m_moments.M00, 4);

                    m_blob.ID = i;
                    m_blob.Area = m_moments.M00;
                    m_blob.CenterMassX = CenterMassX;
                    m_blob.CenterMassY = CenterMassY;
                    m_blob.ConnectivityLabel = "";
                    m_blob.Perimeter = CvInvoke.ArcLength(contours[i],true);
                    
                    Rectangle boundingbox = CvInvoke.BoundingRectangle(contours[i]);
                    m_blob.BoundHeight = boundingbox.Height;
                    m_blob.BoundWidth = boundingbox.Width;
                    m_blob.BoundMinX = boundingbox.X - CenterMassX;
                    m_blob.BoundMinY = boundingbox.Y - CenterMassY;
                    m_blob.BoundMaxX = boundingbox.X+boundingbox.Width - CenterMassX;
                    m_blob.BoundMaxY = boundingbox.Y+boundingbox.Height - CenterMassY;
                    
                    RotatedRect boundPrincipal = CvInvoke.MinAreaRect(contours[i]);
                    m_blob.BoundPrincipalHeight = boundPrincipal.MinAreaRect().Height;
                    m_blob.BoundPrincipalWidth = boundPrincipal.MinAreaRect().Width;

                    //https://stackoverflow.com/questions/14854592/retrieve-elongation-feature-in-python-opencv-what-kind-of-moment-it-supposed-to
                    m_blob.Elongation = ((m_moments.Mu20 + m_moments.Mu02) + Math.Sqrt(4 * Math.Pow(m_moments.Mu11, 2) + Math.Pow(m_moments.Mu20 - m_moments.Mu02, 2))) / ((m_moments.Mu20 + m_moments.Mu02) - Math.Sqrt(4 * Math.Pow(m_moments.Mu11, 2) + Math.Pow(m_moments.Mu20 - m_moments.Mu02, 2)));
                    using (Pen pen = new Pen(Color.SpringGreen,2))
                    using (Graphics contourGraphics = Graphics.FromImage(combinedImage))
                    {
                        contourGraphics.DrawPolygon(pen, contours[i].ToArray());
                    }
                    contourByID.Add(i, contours[i]);
                    blobs.Add(m_blob);
                }
                BlobImage = combinedImage;
            }
            String m_strBlobsFilter = "";
            m_strBlobsFilter = createFilterString(MeasurementProperties, m_strBlobsFilter);
            if (m_strBlobsFilter != "")
            {
                var options = ScriptOptions.Default.AddReferences(typeof(Blob).Assembly);
                Func<Blob, bool> discountFilterExpression = await CSharpScript.EvaluateAsync<Func<Blob, bool>>(m_strBlobsFilter, options);
                blobs = blobs.Where(discountFilterExpression).ToList();
            }
        }

        private String createFilterString(Dictionary<String, ArrayList> MeasurementProperties, String m_strBlobsFilter)
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

    }
}
