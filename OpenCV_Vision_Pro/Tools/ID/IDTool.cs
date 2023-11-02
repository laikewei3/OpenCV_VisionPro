using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using MS.WindowsAPICodePack.Internal;
using OpenCV_Vision_Pro.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Media;
using ZXing;
using ZXing.Common;
using ZXing.Datamatrix;

namespace OpenCV_Vision_Pro.Tools.ID
{
    public class IDParams : IParams
    {
        public ROI m_roi { get; set; } = new ROI();
        public bool m_boolHasROI { get; set; } = false;
        public string mode { get; set; } = "BarCode";
    }

    public class IDdata
    {
        public Point[] m_rect;
        public string Code { get; set; }
        public IDdata(Point[] rect, string id)
        {
            m_rect = rect;
            this.Code = id;
        }
    }

    public class IDResult : IToolResult, IDisposable
    {
        public Mat resultImage { get; set; }
        public BindingList<IDdata> idList { get; set; } = new BindingList<IDdata>();

        public void Dispose()
        {
            resultImage?.Dispose();
        }
    }
    public class IDTool : IToolBase
    {
        public string ToolName { get; set; }
        public IDTool(string toolName)
        {
            ToolName = toolName;
        }

        public AutoDisposeDict<string, Mat> m_bitmapList { get; set; }
        public BindingList<string> m_DisplaySelection { get; set; } = new BindingList<string>();
        public BindingSource resultSource { get; set; }
        public UserControlBase m_toolControl { get; set; }
        public IParams parameter { get; set; } = new IDParams();
        public IToolResult toolResult { get; set; }
        public Rectangle m_rectROI { get; set; }
        private IDResult IDResult { get { return (IDResult)toolResult; } set { toolResult = value; } }

        public void Dispose()
        {
            IDResult?.Dispose();
            m_toolControl?.Dispose();
            m_bitmapList?.Dispose();
            resultSource?.Dispose();
        }

        public void getGUI()
        {
            if (m_rectROI != null && !m_rectROI.IsEmpty)
            {
                parameter.m_roi.location = new Point(m_rectROI.X, m_rectROI.Y);
                parameter.m_roi.ROI_Width = m_rectROI.Width;
                parameter.m_roi.ROI_Height = m_rectROI.Height;
            }
            m_toolControl = new IDToolControl(parameter) { Dock = DockStyle.Fill };
        }

        public void Run(Mat img, Rectangle region)
        {
            parameter.m_roi.ROIRectangle = HelperClass.getROIImage(img, region, parameter.m_roi.points, out Mat image);
            IDResult?.Dispose();
            IDResult = new IDResult();

            if (((IDToolControl)m_toolControl) != null)
                parameter = ((IDToolControl)m_toolControl).IDParams;
            else
                parameter = new IDParams();

            Mat imageClone = img.Clone();
            if (String.Compare(((IDParams)parameter).mode, "BarCode") == 0)
            {
                Result[] results = new BarcodeReader().DecodeMultiple(image.ToBitmap());
                if (results != null)
                {
                    for (int i = 0; i < results.Length; i++)
                    {
                        Result result = results[i];
                        result.BarcodeFormat.ToString();

                        if (result != null)
                        {
                            ResultPoint[] points = result.ResultPoints;
                            Point[] pointArr = points[0].X > points[1].X ? new Point[] { new Point((int)points[1].X, (int)points[1].Y), new Point((int)points[0].X, (int)points[0].Y) } :
                                new Point[] { new Point((int)points[0].X, (int)points[0].Y), new Point((int)points[1].X, (int)points[1].Y) };
                            if (!region.IsEmpty)
                            {
                                pointArr[0].X += region.X;
                                pointArr[1].X += region.X;
                                pointArr[0].Y += region.Y;
                                pointArr[1].Y += region.Y;
                            }

                            IDResult.idList.Add(new IDdata(pointArr, result.Text));
                            CvInvoke.PutText(imageClone, result.Text, pointArr[0], FontFace.HersheySimplex, 0.7, new MCvScalar(255, 0, 0), 2);
                            CvInvoke.Line(imageClone, pointArr[0], pointArr[1], new MCvScalar(0, 0, 255), 4);
                        }
                    }
                }
            }
            else
            {
                Bitmap bMap = image.ToBitmap();
                LuminanceSource source = new RGBLuminanceSource(bMap.ToImage<Bgr, byte>().Bytes,bMap.Width,bMap.Height);
                bMap.Dispose();

                BinaryBitmap bitmap = new BinaryBitmap(new HybridBinarizer(source));
                Result result = new ZXing.QrCode.QRCodeReader().decode(bitmap);
                if (result != null)
                {
                    ResultPoint[] points = result.ResultPoints;
                    Rectangle loc = new Rectangle((int)points[1].X, (int)points[1].Y, (int)(points[2].X - points[1].X), (int)(points[0].Y - points[1].Y)); 
                    Point[] pointArr = { loc.Location, new Point(loc.Size.Width, loc.Size.Height) };
                    if (!region.IsEmpty)
                    {
                        loc.X += region.X;
                        loc.Y += region.Y;
                        pointArr[0].X += region.X;
                        pointArr[1].X += region.X;
                        pointArr[2].X += region.X;
                        pointArr[2].Y += region.Y;
                        pointArr[0].Y += region.Y;
                        pointArr[1].Y += region.Y;
                    }

                    IDResult.idList.Add(new IDdata(pointArr, result.Text));
                    CvInvoke.Rectangle(imageClone, loc, new MCvScalar(0, 0, 255), 4);
                }
            }
            

            IDResult.resultImage = imageClone.Clone();
            imageClone.Dispose();
        }

        public object showResult()
        {
            resultSource?.Dispose();

            resultSource = new BindingSource();
            if (IDResult == null)
                return resultSource;
            if (m_toolControl == null)
                return resultSource;

            resultSource.DataSource = IDResult.idList;
            return resultSource;
        }

        public void showResultImages()
        {
            if (Form1.m_bitmapList.ContainsKey("LastRun." + ToolName + ".ID"))
            {
                Form1.m_bitmapList["LastRun." + ToolName + ".ID"]?.Dispose();
                Form1.m_bitmapList["LastRun." + ToolName + ".ID"] = IDResult.resultImage.Clone();
            }
            else
            {
                Form1.m_bitmapList.Add("LastRun." + ToolName + ".ID", IDResult.resultImage.Clone());
                if (!Form1.m_form1DisplaySelection.Contains("LastRun." + ToolName + ".ID"))
                    Form1.m_form1DisplaySelection.Add("LastRun." + ToolName + ".ID");
            }

            if (m_bitmapList.ContainsKey("LastRun." + ToolName + ".ID"))
            {
                m_bitmapList["LastRun." + ToolName + ".ID"]?.Dispose();
                m_bitmapList["LastRun." + ToolName + ".ID"] = IDResult.resultImage.Clone();
            }
            else
            {
                m_bitmapList.Add("LastRun." + ToolName + ".ID", IDResult.resultImage.Clone());
                if (!m_DisplaySelection.Contains("LastRun." + ToolName + ".ID"))
                    m_DisplaySelection.Add("LastRun." + ToolName + ".ID");
            }
        }
    }
}
