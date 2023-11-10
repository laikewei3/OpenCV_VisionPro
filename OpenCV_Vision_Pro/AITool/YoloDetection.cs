using Emgu.CV.CvEnum;
using Emgu.CV.Dnn;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace OpenCV_Vision_Pro.AITool
{

    public class YoloDetection : IAITool, IDisposable
    {
        Net Model;
        List<string> labels = null;
        float confThreshold;
        float nmsThreshold;
        int defaultSize;
        //Detection
        VectorOfRect bboxes;
        VectorOfFloat scores;
        VectorOfInt indices;
        VectorOfInt idx;

        public YoloDetection(string PathWeights = "C:\\Users\\T0571\\Downloads\\yolov7-tiny.weights", 
            string PathConfig = "C:\\Users\\T0571\\Downloads\\yolov7-tiny.cfg",
            string PathLabels = "C:\\Users\\T0571\\Downloads\\coco.names",
            float confThreshold = 0.5f,
            float nmsThreshold = 0.5f,
            int defaultSize = 416)
        {
            bboxes = new VectorOfRect();
            scores = new VectorOfFloat();
            indices = new VectorOfInt();
            idx = new VectorOfInt();
            Model = DnnInvoke.ReadNetFromDarknet(PathConfig, PathWeights);
            Model.SetPreferableBackend(Emgu.CV.Dnn.Backend.Cuda);
            Model.SetPreferableTarget(Target.Cuda);
            labels = File.ReadAllLines(PathLabels).ToList();
            this.nmsThreshold = nmsThreshold;
            this.defaultSize = defaultSize;
            this.confThreshold = confThreshold;
        }

        public void Process()
        {
            VectorOfMat vectorOfMat = new VectorOfMat();

            Model.Forward(vectorOfMat, Model.UnconnectedOutLayersNames);

            for (int i = 0; i < vectorOfMat.Size; i++)
            {
                Mat mat = vectorOfMat[i];

                for (int j = 0; j < mat.Rows; j++)
                {
                    var row = mat.Row(j).GetData().Cast<float>();
                    var rowScores = row.Skip(5).ToList();
                    var classId = rowScores.IndexOf(rowScores.Max());
                    var confidence = rowScores[classId];
                    List<float> info = row.Take(4).ToList();
                    if (confidence > confThreshold)
                    {
                        var center_x = (int)(info[0] * defaultSize);
                        var center_y = (int)(info[1] * defaultSize);

                        var width = (int)(info[2] * defaultSize);
                        var height = (int)(info[3] * defaultSize);

                        var x = (int)(center_x - width / 2);
                        var y = (int)(center_y - height / 2);

                        bboxes.Push(new Rectangle[] { new Rectangle(x, y, width, height) });
                        indices.Push(new int[] { classId });
                        scores.Push(new float[] { confidence });
                    }
                }
                mat?.Dispose();
            }
            vectorOfMat.Dispose();

            DnnInvoke.NMSBoxes(bboxes, scores, confThreshold, nmsThreshold, idx);
        }

        public Mat Draw(Mat resizeMat, int topBottom, int leftRight, Size newSize)
        {
            for (int i = 0; i < idx.Size; i++)
            {
                int index = idx[i];
                var bbox = bboxes[index];
                CvInvoke.Rectangle(resizeMat, bbox, new MCvScalar(0, 0, 255), 2);
                CvInvoke.PutText(resizeMat, labels[indices[index]], new Point(bbox.X, bbox.Y + 20), FontFace.HersheySimplex, 0.5, new MCvScalar(255, 0, 0), 2);
            }
            idx.Clear();
            bboxes.Clear();
            scores.Clear();
            indices.Clear();

            Point point = topBottom < 1 ? new Point(leftRight, 0) : new Point(0, topBottom);
            Mat tempMat = new Mat(resizeMat, new Rectangle(point, newSize));
            resizeMat.Dispose();
            return tempMat;
        }

        public void PreProcess(Mat frame, out Mat resizeMat, out int topBottom, out int leftRight, out Size newSize)
        {
            newSize = HelperClass.resize(frame.Width, frame.Height, defaultSize, defaultSize);
            resizeMat = new Mat();
            CvInvoke.Resize(frame, resizeMat, newSize);
            topBottom = (defaultSize - newSize.Height) / 2;
            leftRight = (defaultSize - newSize.Width) / 2;
            newSize = resizeMat.Size;
            CvInvoke.CopyMakeBorder(resizeMat, resizeMat, topBottom, topBottom, leftRight, leftRight, BorderType.Constant, new MCvScalar(0, 0, 0));

            CvInvoke.Resize(resizeMat, resizeMat, new Size(defaultSize, defaultSize));

            Mat input = DnnInvoke.BlobFromImage(resizeMat, 1 / 255.0, swapRB: true);
            Model.SetInput(input);
            input.Dispose();
        }

        public void Dispose()
        {
            Model?.Dispose();
            bboxes?.Dispose();
            scores?.Dispose();
            indices?.Dispose();
            idx?.Dispose();
        }
    }
}
