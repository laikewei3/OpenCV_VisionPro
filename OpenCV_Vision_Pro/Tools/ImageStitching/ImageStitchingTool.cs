using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.CV.XPhoto;
using OpenCV_Vision_Pro.Interface;
using Shared.ComponentModel.SortableBindingList;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Emgu.CV.Features2D;
using System.Collections.Generic;
using System.Threading;
using Google.Protobuf.WellKnownTypes;
using Emgu.CV.Stitching;

namespace OpenCV_Vision_Pro.Tools.ImageStitching
{
    public class ImageStitchingParams : IParams
    {
        public SortableBindingList<string> selectedImage { get; set; } = new SortableBindingList<string>();
        public VectorOfMat vom { get; set; } = new VectorOfMat();
    }

    public class ImageStitchingResults : IToolResult
    {
    }

    public class ImageStitchingTool : ITool
    {
        public string ToolName { get; set; }
        public AutoDisposeDict<string, Mat> m_bitmapList { get; set; }
        public BindingList<string> m_DisplaySelection { get; set; } = new BindingList<string>();
        public BindingSource resultSource { get; set; }
        public IUserControlBase m_toolControl { get; set; }
        public IParams parameter { get; set; } = new ImageStitchingParams();
        public IToolResult toolResult { get; set; }
        private ImageStitchingResults ImageStitchingResult { get { return (ImageStitchingResults)toolResult; } set { toolResult = value; } }

        public ImageStitchingTool(string toolName)
        {
            this.ToolName = toolName;
        }

        public void Dispose()
        {
            m_bitmapList?.Dispose();
            resultSource?.Dispose();
            m_toolControl?.Dispose();
        }

        public void getGUI()
        {
            m_toolControl = new ImageStitchingToolControl(parameter) { Dock = DockStyle.Top };
        }

        public void Run(Mat img, Rectangle region)
        {
            ImageStitchingResult?.Dispose();
            ImageStitchingResult = new ImageStitchingResults();

            int inputCnt = ((ImageStitchingParams)parameter).selectedImage.Count;
            if (inputCnt < 2)
            {
                MessageBox.Show("Please input AT LEAST 2 images for the operation.");
                ImageStitchingResult.resultImage = new Mat();
                return;
            }

            Stitcher stitcher = new Stitcher();
            Mat output = new Mat();
            Stitcher.Status error = stitcher.Stitch(((ImageStitchingParams)parameter).vom, output);
            stitcher.Dispose();

            if (error == Stitcher.Status.Ok)
            {
                Mat processedImg = new Mat();
                CvInvoke.CopyMakeBorder(output, processedImg, 10, 10, 10, 10, BorderType.Constant, new MCvScalar(0, 0, 0));
                output.Dispose();

                Mat gray = new Mat();
                CvInvoke.CvtColor(processedImg, gray, ColorConversion.Bgr2Gray);
                Mat thresholdImg = new Mat();
                CvInvoke.Threshold(gray, thresholdImg, 0, 255, ThresholdType.Binary);

                gray.Dispose();

                VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
                CvInvoke.FindContours(thresholdImg, contours, null, RetrType.External, ChainApproxMethod.ChainApproxSimple);

                Point[] point = contours.ToArrayOfArray().OrderByDescending(i => CvInvoke.ContourArea(new VectorOfPoint(i))).ToList()[0];
                Rectangle bbox = CvInvoke.BoundingRectangle(point);
                Mat mask = Mat.Zeros(thresholdImg.Rows, thresholdImg.Cols, thresholdImg.Depth, thresholdImg.NumberOfChannels);
                CvInvoke.Rectangle(mask, bbox, new MCvScalar(255), -1);
                contours.Dispose();

                Mat sub = mask.Clone();
                while (CvInvoke.CountNonZero(sub) > 0)
                {
                    CvInvoke.Erode(mask, mask, new Mat(), new Point(-1, -1), 3, BorderType.Default, new MCvScalar(0, 0, 0));
                    CvInvoke.Subtract(mask, thresholdImg, sub);
                }
                sub.Dispose();

                contours = new VectorOfVectorOfPoint();
                CvInvoke.FindContours(mask, contours, null, RetrType.External, ChainApproxMethod.ChainApproxSimple);
                mask.Dispose();
                thresholdImg.Dispose();

                point = contours.ToArrayOfArray().OrderByDescending(i => CvInvoke.ContourArea(new VectorOfPoint(i))).ToList()[0];
                bbox = CvInvoke.BoundingRectangle(point);
                ImageStitchingResult.resultImage = new Mat(processedImg, bbox);

                processedImg.Dispose();
                contours.Dispose();
            }
            else
            {
                MessageBox.Show("Cannot stitch images. \n" + error.ToString());
                ImageStitchingResult.resultImage = new Mat();
            }

            showResultImages();
        }

        public void showResultImages()
        {
            HelperClass.showResultImagesStatic(m_bitmapList, m_DisplaySelection, ImageStitchingResult.resultImage, ToolName, "StitchImage");
        }
    }
}
