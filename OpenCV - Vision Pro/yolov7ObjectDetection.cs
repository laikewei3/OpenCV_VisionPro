using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.Dnn;
using Microsoft.WindowsAPICodePack.Dialogs;
using Emgu.CV.Util;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System.ComponentModel;
using OpenCV_Vision_Pro.Interface;
using System.Collections;
using System.Windows;
using OpenCV_Vision_Pro.LineSegment;

namespace OpenCV_Vision_Pro
{
    public class YoloParams : IParams
    {
        public ROI m_roi { get; set; } = new ROI();
        public bool m_boolHasROI { get; set; } = false;
    }

    public class yolov7ObjectDetection: IToolBase
    {
        Net Model = null;
        List<string> labels = null;
        private class yoloResult : IToolResult, IDisposable
        {
            public Mat resultImage { get; set; }

            public void Dispose()
            {
                resultImage?.Dispose();
            }
        }

        public Bitmap toolIcon { get; }

        public string ToolName { get; set; }
        public AutoDisposeDict<string, Mat> m_bitmapList { get; set; }
        public BindingList<string> m_DisplaySelection { get; set; } = new BindingList<string>();
        public UserControlBase m_toolControl { get; set; }
        public Rectangle m_rectROI { get; set; }
        public IParams parameter { get; set; } = new YoloParams();
        public System.Windows.Forms.BindingSource resultSource { get; set; }
        public IToolResult toolResult { get; set; }
        private yoloResult yoloResults { get { return (yoloResult)toolResult; } set { toolResult = value; } }

        public yolov7ObjectDetection(string toolName)
        {
            ToolName = toolName;
        }

        public void Dispose()
        {
            toolIcon?.Dispose();
            m_bitmapList?.Dispose();
            m_toolControl?.Dispose();
            resultSource?.Dispose();
        }

        public void getGUI()
        {
            
        }

        public void loadModel()
        {
            try
            {
                using (CommonOpenFileDialog openFileDialog = new CommonOpenFileDialog { Multiselect = true })
                {
                    if(openFileDialog.ShowDialog() == CommonFileDialogResult.Ok)
                    {
                        string PathWeights = openFileDialog.FileNames.Where(x => x.ToLower().EndsWith(".weights")).First();
                        string PathConfig = openFileDialog.FileNames.Where(x => x.ToLower().EndsWith(".cfg")).First();
                        string PathLabels = openFileDialog.FileNames.Where(x => x.ToLower().EndsWith(".names")).First();

                        Model = DnnInvoke.ReadNetFromDarknet(PathConfig,PathWeights);
                        labels = File.ReadAllLines(PathLabels).ToList();
                    }
                    openFileDialog.Dispose();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void Run(Mat imgInput, Rectangle region)
        {
            yoloResults?.Dispose();
            yoloResults = new yoloResult();

            float confThreshold = 0.5f;
            float nmsThreshold = 0.4f;
            int defaultSize = 416;

            System.Drawing.Size newSize = HelperClass.resize(imgInput.Width, imgInput.Height, defaultSize, defaultSize);
            Mat resizeMat = new Mat();
            CvInvoke.Resize(imgInput, resizeMat, newSize);
            int topBottom = (defaultSize - newSize.Height) / 2;
            int leftRight = (defaultSize - newSize.Width) / 2;
            CvInvoke.CopyMakeBorder(resizeMat, resizeMat, topBottom,topBottom,leftRight,leftRight,BorderType.Constant,new MCvScalar(0,0,0));
            
            Image<Bgr, byte> imageInput = resizeMat.ToImage<Bgr, byte>().Resize(defaultSize, defaultSize, Inter.Cubic);
            resizeMat.Dispose();

            Mat input = DnnInvoke.BlobFromImage(imageInput,1/255.0,swapRB:true);
            Model.SetInput(input);
            Model.SetPreferableBackend(Emgu.CV.Dnn.Backend.OpenCV);
            Model.SetPreferableTarget(Target.Cpu);

            VectorOfMat vectorOfMat = new VectorOfMat();
            Model.Forward(vectorOfMat, Model.UnconnectedOutLayersNames);

            input.Dispose();

            VectorOfRect bboxes = new VectorOfRect();
            VectorOfFloat scores = new VectorOfFloat();
            VectorOfInt indices = new VectorOfInt();

            for(int i = 0; i < vectorOfMat.Size; i++)
            {
                Mat mat = vectorOfMat[i];
                var data = ArrayTo2DList(mat.GetData());
                for(int j = 0; j < data.Count; j++)
                {
                    var row = data[j];
                    var rowScores = row.Skip(5).ToArray();
                    var classId = rowScores.ToList().IndexOf(rowScores.Max());
                    var confidence = rowScores[classId];
                    if(confidence > confThreshold)
                    {
                        var center_x = (int)(row[0]*imageInput.Width);
                        var center_y = (int)(row[1] * imageInput.Width);

                        var width = (int)(row[2] * imageInput.Width);
                        var height = (int)(row[3] * imageInput.Width);

                        var x = (int)(center_x - width / 2);
                        var y = (int)(center_y - height / 2);

                        bboxes.Push(new Rectangle[] { new Rectangle(x, y, width, height) });
                        indices.Push(new int[] { classId });
                        scores.Push(new float[] { confidence });
                    }
                }
            }

            var idx = DnnInvoke.NMSBoxes(bboxes.ToArray(), scores.ToArray(), confThreshold, nmsThreshold);
            var imgOutput = imageInput.Clone();
            for(int i = 0; i < idx.Length; i++)
            {
                int index = idx[i];
                var bbox = bboxes[index];
                imgOutput.Draw(bbox, new Bgr(0, 0, 255), 2);
                //CvInvoke.PutText(imgOutput, index.ToString(), new System.Drawing.Point(bbox.X, bbox.Y + 20), FontFace.HersheySimplex, 0.5, new Emgu.CV.Structure.MCvScalar(255, 0, 0), 2);
                CvInvoke.PutText(imgOutput, labels[indices[index]],new System.Drawing.Point(bbox.X,bbox.Y+20),FontFace.HersheySimplex,0.5,new Emgu.CV.Structure.MCvScalar(255,0,0),2);
            }
            bboxes.Dispose();
            scores.Dispose();
            indices.Dispose();
            yoloResults.resultImage = imgOutput.Mat.Clone();
            imgOutput?.Dispose();
        }

        public object showResult()
        {
            return null;
        }

        public void showResultImages()
        {
            if (Form1.m_bitmapList.ContainsKey("LastRun." + ToolName + ".DetectionImage"))
            {
                Form1.m_bitmapList["LastRun." + ToolName + ".DetectionImage"]?.Dispose();
                Form1.m_bitmapList["LastRun." + ToolName + ".DetectionImage"] = yoloResults.resultImage.Clone();
            }
            else
            {
                Form1.m_bitmapList.Add("LastRun." + ToolName + ".DetectionImage", yoloResults.resultImage.Clone());
                if (!Form1.m_form1DisplaySelection.Contains("LastRun." + ToolName + ".DetectionImage"))
                    Form1.m_form1DisplaySelection.Add("LastRun." + ToolName + ".DetectionImage");
            }

            if (m_bitmapList.ContainsKey("LastRun." + ToolName + ".DetectionImage"))
            {
                m_bitmapList["LastRun." + ToolName + ".DetectionImage"]?.Dispose();
                m_bitmapList["LastRun." + ToolName + ".DetectionImage"] = yoloResults.resultImage.Clone();
            }
            else
            {
                m_bitmapList.Add("LastRun." + ToolName + ".DetectionImage", yoloResults.resultImage.Clone());
                if (!m_DisplaySelection.Contains("LastRun." + ToolName + ".DetectionImage"))
                    m_DisplaySelection.Add("LastRun." + ToolName + ".DetectionImage");
            }
        }

        private List<float[]> ArrayTo2DList(Array array)
        {
            System.Collections.IEnumerator enumerator = array.GetEnumerator();
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);
            List<float[]> list = new List<float[]>();
            List<float> temp = new List<float>();
            for(int i = 0;i < rows;i++)
            {
                temp.Clear();
                for(int j = 0;j < cols;j++)
                {
                    temp.Add(float.Parse(array.GetValue(i, j).ToString()));
                }
                list.Add(temp.ToArray());
            }
            return list;
        }
    }
}
