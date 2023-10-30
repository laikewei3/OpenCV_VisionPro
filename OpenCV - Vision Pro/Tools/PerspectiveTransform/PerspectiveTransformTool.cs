using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using OpenCV_Vision_Pro.Interface;

namespace OpenCV_Vision_Pro
{

    public class PerspectiveTransformParams: IParams
    {
        public ROI m_roi { get; set; } = new ROI(); 
        public bool m_boolHasROI { get; set; } = true;
    }

    public class PerspectiveTransformResult : IDisposable, IToolResult
    {
        public Mat resultImage { get; set; }

        public void Dispose()
        {
            resultImage?.Dispose();
        }
    }

    public partial class PerspectiveTransformTool : IToolBase
    {
        public string ToolName { get; set; }
        public AutoDisposeDict<string, Mat> m_bitmapList { get; set; }
        public UserControlBase m_toolControl { get; set; }
        public BindingList<string> m_DisplaySelection { get; set; } = new BindingList<string>();
        public BindingSource resultSource { get; set; }
        public Rectangle m_rectROI { get; set; }
        public IParams parameter { get; set; } = new PerspectiveTransformParams();

        public IToolResult toolResult { get; set; }
        public PerspectiveTransformResult m_PerspectiveTransformResult { get { return (PerspectiveTransformResult)toolResult; } set { toolResult = value; } }

        public PerspectiveTransformTool(string toolName) { ToolName = toolName; }

        public  void getGUI()
        {
            if(m_rectROI != null && !m_rectROI.IsEmpty)
            {
                parameter.m_roi.location = new Point(m_rectROI.X, m_rectROI.Y);
                parameter.m_roi.ROI_Width = m_rectROI.Width;
                parameter.m_roi.ROI_Height = m_rectROI.Height;
            }
            m_toolControl = new PerspectiveTransformToolControl(parameter) { Dock = DockStyle.Fill };
        }

        public  void Run(Mat img, Rectangle region)
        {
            m_PerspectiveTransformResult?.Dispose();
            m_PerspectiveTransformResult = new PerspectiveTransformResult();
            if (parameter.m_roi.points == null)
            {
                m_PerspectiveTransformResult.resultImage = img.Clone();
                return;
            }

            Point topLeft = parameter.m_roi.points[0];
            Point topRight = parameter.m_roi.points[1];
            Point bottomLeft = parameter.m_roi.points[3];
            Point bottomRight = parameter.m_roi.points[2];

            int rows =  img.Rows;
            int cols =  img.Cols;

            // Image center
            double u0 = cols / 2.0;
            double v0 = rows / 2.0;

            double w1 = Math.Sqrt(Math.Pow(topLeft.X - topRight.X, 2) + Math.Pow(topLeft.Y - topRight.Y, 2));
            double w2 = Math.Sqrt(Math.Pow(bottomLeft.X - bottomRight.X, 2) + Math.Pow(bottomLeft.Y - bottomRight.Y, 2));
            double h1 = Math.Sqrt(Math.Pow(topLeft.X - bottomLeft.X, 2) + Math.Pow(topLeft.Y - bottomLeft.Y, 2));
            double h2 = Math.Sqrt(Math.Pow(topRight.X - bottomRight.X, 2) + Math.Pow(topRight.Y - bottomRight.Y, 2));

            double w = Math.Max(w1, w2);
            double h = Math.Max(h1, h2);
            double ar_vis = w / h;

            Mat m1 = new Mat(1, 3, DepthType.Cv32F,1);
            m1.SetTo<float>(new float[] {
            topLeft.X, topLeft.Y, 1});
            Mat m2 = new Mat(1, 3, DepthType.Cv32F, 1);
            m2.SetTo(new float[] { topRight.X, topRight.Y, 1 });
            Mat m3 = new Mat(1, 3, DepthType.Cv32F, 1);
            m3.SetTo(new float[] { bottomLeft.X, bottomLeft.Y, 1 });
            Mat m4 = new Mat(1, 3, DepthType.Cv32F, 1);
            m4.SetTo(new float[] { bottomRight.X, bottomRight.Y, 1 });

            double k2 = (float)((m1.Cross(m4).Dot(m3)) / (m2.Cross(m4).Dot(m3)));
            double k3 = (float)((m1.Cross(m4).Dot(m2)) / (m3.Cross(m4).Dot(m2)));

            Mat n2 = new Mat();
            m2 *= k2;
            CvInvoke.Subtract(m2, m1, n2);

            Mat n3 = new Mat();
            m3 *= k3;
            CvInvoke.Subtract(m3, m1, n3);

            m1.Dispose();
            m2.Dispose();
            m3.Dispose();
            m4.Dispose();

            float n21 = (float)n2.GetData().GetValue(0, 0);
            float n22 = (float)n2.GetData().GetValue(0, 1);
            float n23 = (float)n2.GetData().GetValue(0, 2);
            float n31 = (float)n3.GetData().GetValue(0, 0);
            float n32 = (float)n3.GetData().GetValue(0, 1);
            float n33 = (float)n3.GetData().GetValue(0, 2);

            double f = Math.Sqrt(Math.Abs((1.0 / (n23 * n33)) * ((n21 * n31 - (n21 * n33 + n23 * n31) * u0 + n23 * n33 * u0 * u0) + (n22 * n32 - (n22 * n33 + n23 * n32) * v0 + n23 * n33 * v0 * v0))));
            
            Matrix<float> A = new Matrix<float>(new float[,] { { (float)f, 0, (float)u0 }, { 0, (float)f, (float)v0 }, { 0, 0, 1 } });
            Matrix<float> At = A.Transpose();
            Mat Ati = new Mat();
            
            CvInvoke.Invert(At.Mat, Ati, DecompMethod.Cholesky);
            Mat Ai = new Mat();
            CvInvoke.Invert(A.Mat, Ai, DecompMethod.Cholesky);
           
            Mat temp = new Mat();
            CvInvoke.Gemm(n2,Ati,1,null,1,temp);
            Mat temp2 = new Mat();
            CvInvoke.Gemm(temp, Ai, 1, null, 1, temp2);
            temp.Dispose();

            Mat temp3 = new Mat();
            CvInvoke.Gemm(n3, Ati, 1, null, 1, temp3);
            Mat temp4 = new Mat();
            CvInvoke.Gemm(temp3, Ai, 1, null, 1, temp4);
            temp3.Dispose();

            double ar_real = Math.Sqrt(temp2.Dot(n2)/ temp4.Dot(n3));

            temp2.Dispose();
            temp4.Dispose();
            n2.Dispose();
            n3.Dispose();

            int W, H;

            if (ar_real < ar_vis)
            {
                W = (int)w;
                H = (int)(w / ar_real);
            }
            else
            {
                H = (int)h;
                W = (int)(ar_real * H);
            }

            PointF[] pts1 = new PointF[] { topLeft, topRight, bottomLeft, bottomRight };
            PointF[] pts2 = { new PointF(0, 0), new PointF(W, 0), new PointF(0, H), new PointF(W, H) };

            Mat M = CvInvoke.GetPerspectiveTransform(pts1, pts2);
            Mat dst = new Mat();
            CvInvoke.WarpPerspective(img, dst, M, new Size(W, H));
            m_PerspectiveTransformResult.resultImage = dst.Clone();
            dst.Dispose();
            M.Dispose();
            dst.Dispose();
        }

        public  void Dispose()
        {
            m_bitmapList?.Dispose();
            m_toolControl?.Dispose();
            m_PerspectiveTransformResult.Dispose();
            resultSource?.Dispose();
        }

        public  object showResult()
        {
            return null;
        }

        public  void showResultImages()
        {
            if (Form1.m_bitmapList.ContainsKey("LastRun." + ToolName + ".PerspectiveTransformImage"))
            {
                Form1.m_bitmapList["LastRun." + ToolName + ".PerspectiveTransformImage"]?.Dispose();
                Form1.m_bitmapList["LastRun." + ToolName + ".PerspectiveTransformImage"] = m_PerspectiveTransformResult.resultImage.Clone();
            }
            else
            {
                Form1.m_bitmapList.Add("LastRun." + ToolName + ".PerspectiveTransformImage", m_PerspectiveTransformResult.resultImage.Clone());
                if (!Form1.m_form1DisplaySelection.Contains("LastRun." + ToolName + ".PerspectiveTransformImage"))
                    Form1.m_form1DisplaySelection.Add("LastRun." + ToolName + ".PerspectiveTransformImage");
            }


            if (m_bitmapList.ContainsKey("LastRun." + ToolName + ".PerspectiveTransformImage"))
            {
                m_bitmapList["LastRun." + ToolName + ".PerspectiveTransformImage"]?.Dispose();
                m_bitmapList["LastRun." + ToolName + ".PerspectiveTransformImage"] = m_PerspectiveTransformResult.resultImage.Clone();
            }
            else
            {
                m_bitmapList.Add("LastRun." + ToolName + ".PerspectiveTransformImage", m_PerspectiveTransformResult.resultImage.Clone());
                if (!m_DisplaySelection.Contains("LastRun." + ToolName + ".PerspectiveTransformImage"))
                    m_DisplaySelection.Add("LastRun." + ToolName + ".PerspectiveTransformImage");
            }
        }
    }
}
