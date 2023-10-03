﻿using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using OpenCV_Vision_Pro.Interface;
using OpenCV_Vision_Pro.Properties;
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
        public Dictionary<int, VectorOfPoint> contourByRow { get; set; } = new Dictionary<int, VectorOfPoint>(); // MIGHT MOVE TO BLOB RESULT

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
        
        public async override void Run(Mat img, Rectangle region)
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
           

            Mat imageClone = image.Clone();
            contourByRow.Clear();
            //================================================= Pre-Processing ============================================
            Mat filter_image = new Mat();
            CvInvoke.BilateralFilter(image, filter_image, 9, 20, 20);
            if (((BlobParams)parameter).polarity == "Light blobs, Dark background")
                CvInvoke.Threshold(filter_image, imageClone, ((BlobParams)parameter).threshold, 255, ThresholdType.Binary);
            else
                CvInvoke.Threshold(filter_image, imageClone, ((BlobParams)parameter).threshold, 255, ThresholdType.BinaryInv);
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
                graphics.DrawImage(imageClone.ToBitmap(), 0, 0);
                for (int i = 0, j = 0; i < contours.Size; i++)
                {
                    Blob m_blob = new Blob();
                    Moments m_moments = CvInvoke.Moments(contours[i]);

                    if (m_moments.M00 <= ((BlobParams)parameter).minArea)
                        continue;

                    double CenterMassX = Math.Round(m_moments.M10 / m_moments.M00, 4);
                    double CenterMassY = Math.Round(m_moments.M01 / m_moments.M00, 4);

                    m_blob.ID = i;
                    m_blob.Area = m_moments.M00;
                    m_blob.CenterMassX = CenterMassX;
                    m_blob.CenterMassY = CenterMassY;
                    m_blob.ConnectivityLabel = "";
                    m_blob.Perimeter = CvInvoke.ArcLength(contours[i], true);
                    m_blob.Acircularity = Math.Pow(m_blob.Perimeter, 2) / (4 * Math.PI * m_moments.M00);
                    //m_blob.AcircularityRms = CalculateAcircularityRMS(contours[i],m_moments.M00, m_moments.GravityCenter);
                    m_blob.InertiaX = Math.Round(m_moments.Mu20, 4);
                    m_blob.InertiaY = Math.Round(m_moments.Mu02, 4);

                    Rectangle boundingbox = CvInvoke.BoundingRectangle(contours[i]);
                    m_blob.BoundHeight = boundingbox.Height;
                    m_blob.BoundWidth = boundingbox.Width;
                    m_blob.BoundMinX = boundingbox.X - CenterMassX;
                    m_blob.BoundMinY = boundingbox.Y - CenterMassY;
                    m_blob.BoundMaxX = boundingbox.X + boundingbox.Width - CenterMassX;
                    m_blob.BoundMaxY = boundingbox.Y + boundingbox.Height - CenterMassY;
                    m_blob.BoundAspect = boundingbox.Height / boundingbox.Width;

                    RotatedRect boundPrincipal = CvInvoke.MinAreaRect(contours[i]);
                    m_blob.BoundPrincipalHeight = boundPrincipal.MinAreaRect().Height;
                    m_blob.BoundPrincipalWidth = boundPrincipal.MinAreaRect().Width;
                    m_blob.BoundPrincipalAspect = boundingbox.Width / boundingbox.Height;

                    //https://stackoverflow.com/questions/14854592/retrieve-elongation-feature-in-python-opencv-what-kind-of-moment-it-supposed-to
                    m_blob.Elongation = ((m_moments.Mu20 + m_moments.Mu02) + Math.Sqrt(4 * Math.Pow(m_moments.Mu11, 2) + Math.Pow(m_moments.Mu20 - m_moments.Mu02, 2))) / ((m_moments.Mu20 + m_moments.Mu02) - Math.Sqrt(4 * Math.Pow(m_moments.Mu11, 2) + Math.Pow(m_moments.Mu20 - m_moments.Mu02, 2)));
                    using (Pen pen = new Pen(Color.SpringGreen, 2))
                    using (Graphics contourGraphics = Graphics.FromImage(combinedImage))
                    {
                        contourGraphics.DrawPolygon(pen, contours[i].ToArray());
                    }
                    contourByRow.Add(j++, contours[i]);
                    blobResults.blobs.Add(m_blob);
                    m_moments.Dispose();
                }
                blobResults.BlobImage = combinedImage.ToMat();
                combinedImage.Dispose();
            }
            contours.Dispose();
            hierarchy.Dispose();
            imageClone.Dispose();
            //=============================================================================================================

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
            image.Dispose();
        }

        public override object showResult()
        {
            resultSource?.Dispose();

            resultSource = new BindingSource();
            if (blobResults == null)
                return resultSource;
            if (m_toolControl == null)
                return resultSource;

            BindingList<Blob> resultList = new BindingList<Blob>();
            resultSource.DataSource = resultList;
            
            foreach (Blob r in blobResults.blobs)
            {
                /*
                
                string[] m_listTemp = new string[m_listData.Count + 1];
                m_listTemp[0] = (j++).ToString();
                foreach (string name in m_listData)
                {
                    PropertyInfo propInfo = typeof(Blob).GetProperty(name);
                    if (propInfo != null)
                    {
                        object value = propInfo.GetValue(r);
                        m_listTemp[i++] = (value.ToString());
                    }
                }
                m_dgvBlobResults.Rows.Add(m_listTemp);*/
                resultList.Add(r);
            }
           
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
        }
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
    }
}