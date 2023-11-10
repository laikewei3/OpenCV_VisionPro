using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Dnn;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCV_Vision_Pro.AITool
{
    public class HandLandmarkDetection : IAITool
    {
        Net Model;
        Dictionary<string, int> BodyPart;
        int[,] point_pairs;
        int nPoints = 22;

        float threshold;
        int defaultSize;
        Size imageSize;

        List<Point> points;

        public HandLandmarkDetection(string prototxt = "C:\\Users\\T0571\\source\\repos\\openpose\\models\\hand\\pose_deploy.prototxt",
            string modelPath = "C:\\Users\\T0571\\source\\repos\\openpose\\models\\hand\\pose_iter_102000.caffemodel",
            float threshold = 0.1f,
            int defaultSize = 368)
        {
            BodyPart = new Dictionary<string, int>()
                {
                    { "Nose", 0 },
                    { "Neck", 1 },
                    { "RShoulder", 2 },
                    { "RElbow", 3 },
                    { "RWrist", 4 },
                    {"LShoulder",5},
                    { "LElbow", 6 },
                    { "LWrist", 7 },
                    { "MidHip", 8 },
                    { "RHip", 9 },
                    { "RKnee", 10 },
                    {"RAnkle",11},
                    { "LHip", 12 },
                    { "LKnee", 13 },
                    { "LAnkle", 14 },
                    { "REye", 15 },
                    { "LEye", 16 },
                    {"REar",17},
                    { "LEar", 18 },
                    { "LBigToe", 19 },
                    { "LSmallToe", 20 },
                    { "LHeel", 21 },
                    { "RBigToe", 22 },
                    {"RSmallToe",23},
                    { "RHeel", 24 },
                    { "Background", 25 }
                };
            point_pairs = new int[,] { { 0, 1 }, { 1, 2 }, { 2, 3 }, { 3, 4 }, { 0, 5 }, { 5, 6 }, { 6, 7 },
                    { 7, 8 }, { 0, 9 }, { 9, 10 }, { 10, 11 }, { 11, 12 }, { 0, 13 }, { 13, 14 }, { 14, 15 }, { 15, 16 },
                    { 0, 17 }, { 17, 18 }, { 18, 19 }, { 19, 20 } };
            Model = DnnInvoke.ReadNetFromCaffe(prototxt, modelPath);
            Model.SetPreferableTarget(Target.Cuda);
            Model.SetPreferableBackend(Emgu.CV.Dnn.Backend.Cuda);
            this.defaultSize = defaultSize;
            this.threshold = threshold;
        }

        public Mat Draw(Mat resizeMat, int topBottom, int leftRight, Size newSize)
        {
            // display points on image

            for (int i = 0; i < points.Count; i++)
            {
                var p = points[i];
                if (p != Point.Empty)
                {
                    CvInvoke.Circle(resizeMat, p, 5, new MCvScalar(0, 255, 0), -1);
                    CvInvoke.PutText(resizeMat, i.ToString(), p, FontFace.HersheySimplex, 0.8, new MCvScalar(0, 0, 255), 1, LineType.AntiAlias);
                }
            }

            // draw skeleton

            for (int i = 0; i < point_pairs.GetLongLength(0); i++)
            {
                var startIndex = point_pairs[i, 0];
                var endIndex = point_pairs[i, 1];

                if (!points[startIndex].IsEmpty && !points[endIndex].IsEmpty)
                {
                    CvInvoke.Line(resizeMat, points[startIndex], points[endIndex], new MCvScalar(255, 0, 0), 2);
                }
            }
            return resizeMat;
        }

        public void PreProcess(Mat frame, out Mat resizeMat, out int topBottom, out int leftRight, out Size newSize)
        {
            topBottom = 0;
            leftRight = 0;
            imageSize = frame.Size;
            resizeMat = frame.Clone();
            newSize = imageSize;
            Mat input = DnnInvoke.BlobFromImage(frame, 1 / 255.0, new Size(defaultSize, defaultSize), new MCvScalar(0, 0, 0));
            Model.SetInput(input);
            input.Dispose();
        }

        public void Process()
        {
            Mat output = Model.Forward();

            var H = output.SizeOfDimension[2];
            var W = output.SizeOfDimension[3];
            var HeatMap = output.GetData();

            points = new List<Point>();

            for (int i = 0; i < nPoints; i++)
            {
                Matrix<float> matrix = new Matrix<float>(H, W);
                for (int row = 0; row < H; row++)
                {
                    for (int col = 0; col < W; col++)
                    {
                        matrix[row, col] = (float)HeatMap.GetValue(0, i, row, col);
                    }
                }

                double minVal = 0, maxVal = 0;
                Point minLoc = default, maxLoc = default;

                CvInvoke.MinMaxLoc(matrix, ref minVal, ref maxVal, ref minLoc, ref maxLoc);

                var x = (imageSize.Width * maxLoc.X) / W;
                var y = (imageSize.Height * maxLoc.Y) / H;

                if (maxVal > threshold)
                {
                    points.Add(new Point(x, y));
                }
                else
                {
                    points.Add(Point.Empty);
                }
            }
        }
    }
}
