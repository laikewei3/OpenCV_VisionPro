using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Features2D;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using OpenCV_Vision_Pro.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Windows.Forms;

namespace OpenCV_Vision_Pro
{
    public enum ToolIndex
    {
        BlobTool,
        CaliperTool,
        HistogramTool,
        ImageConvertTool,
        ColorSegmentorTool,
        ColorMatcherTool,
        ColorExtractorTool,
        ImageSharpenerTool,
        LineSegmentTool,
        yoloObjectDetectionTool,
        PolarUnWrapTool,
        PerspectiveTransformTool,
        TextRecognitionTool,
        ImageProcessTool,
        IDTool, 
        PaintTool,
        ImageStackingTool,
        ImageStitchingTool,
        ImageBlendingTool,
        RetinaTool,
        RetinexTool
    }

    public static class HelperClass
    {
        public static CalibrationResult CalibrationResult { get; set; }

        public static Dictionary<string, int> m_dictToolCount = new Dictionary<string, int> {
            {"BlobTool",0},
            {"CaliperTool",0},
            {"HistogramTool",0},
            {"ImageConvertTool",0},
            {"ColorSegmentorTool",0},
            {"ColorMatcherTool",0},
            {"ColorExtractorTool",0},
            {"ImageSharpenerTool",0 },
            {"LineSegmentTool", 0},
            {"PolarUnWrapTool",0 },
            {"PerspectiveTransformTool",0 },
            {"TextRecognitionTool", 0 },
            {"ImageProcessTool",0 },
            {"IDTool",0},
            {"ImagePaintTool",0 },
            {"ImageStackingTool",0 },
            {"ImageStitchingTool",0},
            {"ImageBlendingTool",0},
            {"RetinaTool",0},
            {"RetinexTool",0}
        };

        public static ImageList iconList = new ImageList()
        {
            Images = { Resources.blob, Resources.caliper, Resources.histogram, Resources.convert, Resources.segmentor, Resources.match, Resources.extractor, Resources.editor, Resources.line,
                Resources.yolo, Resources.polarUnwrap, Resources.transform, Resources.ocr, Resources.process, Resources.id, Resources.paint, Resources.stack, Resources.stitch, 
                Resources.blend, Resources.retina, Resources.retinex }
        };

        public static Size resize(int oriWidth, int oriHeight, int currWidth, int currHeight)
        {
            double widthScale = (double)currWidth / oriWidth;
            double heightScale = (double)currHeight / oriHeight;
            double minScale = Math.Min(widthScale, heightScale);
            return new Size((int)(oriWidth * minScale), (int)(oriHeight * minScale));
        }

        public static Rectangle getROIImage(Mat img, Rectangle region, Point[] points, out Mat image)
        {
            Rectangle rect = new Rectangle(0, 0, img.Width, img.Height);
            if (region.X > img.Width || region.Y > img.Height) { region.X = 0; region.Y = 0; }
            if (region.IsEmpty)
            {
                image = img.Clone();
                return rect;
            }
            else if (points == null)
            {
                region.Intersect(rect);
                image = new Mat(img, region);
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
            return region;
        }

        public static void GetAllConnectedCameras(ToolStripMenuItem openCameraToolStripMenuItem, EventHandler openCamera_Click)
        {
            var cameraNames = new List<string>();
            using (var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE (PNPClass = 'Image' OR PNPClass = 'Camera')"))
            {
                foreach (var device in searcher.Get())
                {
                    var item = openCameraToolStripMenuItem.DropDownItems.Add((device["Caption"].ToString()));
                    item.Click += openCamera_Click;
                }
                searcher.Dispose();
            }
        }

        public static VectorOfMat alignImages(VectorOfMat mats)
        {
            VectorOfMat alignImages = new VectorOfMat();
            SIFT sift = new SIFT();

            //Add base image, other align with it
            alignImages.Push(mats[0]);

            Mat gray = new Mat();
            CvInvoke.CvtColor(mats[0], gray, ColorConversion.Bgr2Gray);
            VectorOfKeyPoint keyPoint = new VectorOfKeyPoint();
            Mat descriptors = new Mat();
            sift.DetectAndCompute(gray, null, keyPoint, descriptors, false);
            
            gray.Dispose();

            for (int i = 1; i < mats.Size; i++)
            {
                VectorOfKeyPoint keyPointi = new VectorOfKeyPoint();
                Mat descriptorsi = new Mat();
                sift.DetectAndCompute(mats[i], null, keyPointi, descriptorsi, false);

                VectorOfVectorOfDMatch dMatch = new VectorOfVectorOfDMatch();
                BFMatcher bf = new BFMatcher(DistanceType.L2);
                bf.KnnMatch(descriptorsi, descriptors, dMatch, 2); //This returns the top two matches for each feature point (list of list)
                bf.Dispose();
                List<MDMatch> rawMatches = new List<MDMatch>();
                for (int m = 0; m < dMatch.Size; m++)
                {
                    if (dMatch[m][0].Distance < 0.75 * dMatch[m][1].Distance)
                        rawMatches.Add(dMatch[m][0]);
                }
                dMatch.Dispose();
                List<MDMatch> sortMatches = rawMatches.OrderBy(m => m.Distance).Take(rawMatches.Count > 128 ? 128 : rawMatches.Count).ToList();

                Mat homography = findHomography(keyPointi, keyPoint, sortMatches);
                Mat output = new Mat();
                if (homography.Size.IsEmpty)
                    continue;
                CvInvoke.WarpPerspective(mats[i], output, homography, mats[i].Size);

                alignImages.Push(output.Clone());
                output.Dispose();
                homography.Dispose();
                keyPointi.Dispose();
                descriptorsi.Dispose();
            }
            keyPoint.Dispose();
            descriptors.Dispose();
            sift.Dispose();
            return alignImages;
        }

        private static Mat findHomography(VectorOfKeyPoint keyPointi, VectorOfKeyPoint keyPoint, List<MDMatch> sortMatches)
        {
            Matrix<float> image1Points = new Matrix<float>(sortMatches.Count, 2);
            Matrix<float> image2Points = new Matrix<float>(sortMatches.Count, 2);

            for (int i = 0; i < sortMatches.Count; i++)
            {
                /*
                If you look at matrixa.Data, this will be a float[,] with the first dimension corresponding 
                to rows and the second being the columns and channels merged into one dimension. 
                If the number of channels is N, the current channel is n and 
                the current column is m, the index j of the second dimension is
                j = m*N + n
                */
                int index1 = sortMatches[i].QueryIdx;
                int index2 = sortMatches[i].TrainIdx;
                image1Points[i, 0] = keyPointi[index1].Point.X;
                image1Points[i, 1] = keyPointi[index1].Point.Y;
                image2Points[i, 0] = keyPoint[index2].Point.X;
                image2Points[i, 1] = keyPoint[index2].Point.Y;
            }
            if (sortMatches.Count < 4)
                return new Mat();
            
            Mat output = CvInvoke.FindHomography(image1Points, image2Points, RobustEstimationAlgorithm.Ransac, 2.0);
            image1Points.Dispose();
            image2Points.Dispose();

            return output;
        }

        public static void showResultImagesStatic(AutoDisposeDict<string, Mat> m_bitmapList, BindingList<string> m_DisplaySelection, Mat resultMat, string ToolName, string ProcessOutName)
        {
            if(Form1.m_bitmapList == null)
            {
                //MessageBox.Show("No Input Image in Main Form. Please try again.");
                //return;
            }
            if (Form1.m_bitmapList.ContainsKey("LastRun." + ToolName + "." + ProcessOutName))
            {
                Form1.m_bitmapList["LastRun." + ToolName + "." + ProcessOutName]?.Dispose();
                Form1.m_bitmapList["LastRun." + ToolName + "." + ProcessOutName] = resultMat.Clone();
            }
            else
            {
                Form1.m_bitmapList.Add("LastRun." + ToolName + "." + ProcessOutName, resultMat.Clone());
                if (!Form1.m_form1DisplaySelection.Contains("LastRun." + ToolName + "." + ProcessOutName))
                    Form1.m_form1DisplaySelection.Add("LastRun." + ToolName + "." + ProcessOutName);
            }

            if (m_bitmapList.ContainsKey("LastRun." + ToolName + "." + ProcessOutName))
            {
                m_bitmapList["LastRun." + ToolName + "." + ProcessOutName]?.Dispose();
                m_bitmapList["LastRun." + ToolName + "." + ProcessOutName] = resultMat.Clone();
            }
            else
            {
                m_bitmapList.Add("LastRun." + ToolName + "." + ProcessOutName, resultMat.Clone());
                if (!m_DisplaySelection.Contains("LastRun." + ToolName + "." + ProcessOutName))
                    m_DisplaySelection.Add("LastRun." + ToolName + "." + ProcessOutName);
            }
        }
    }
}
