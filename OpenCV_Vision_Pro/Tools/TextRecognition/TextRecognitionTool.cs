using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Reg;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using OpenCV_Vision_Pro.Interface;
using OpenCV_Vision_Pro.Properties;
using Shared.ComponentModel.SortableBindingList;

namespace OpenCV_Vision_Pro
{

    public class TextRecognitionParams: IParams
    {
        public ROI m_roi { get; set; } = new ROI();
        public bool m_boolHasROI { get; set; } = false;
        public string mode { get; set; } = "Symbol";
        public string language { get; set; } = "eng";
    }

    public class TextRecognitionResult : IDisposable, IToolResult
    {
        public Mat resultImage { get; set; }
        public string text { get; set; }

        public void Dispose()
        {
            resultImage?.Dispose();
        }
    }

    public partial class TextRecognitionTool : IToolBase
    {   
        public string ToolName { get; set; }
        public AutoDisposeDict<string, Mat> m_bitmapList { get; set; }
        public UserControlBase m_toolControl { get; set; }
        public BindingList<string> m_DisplaySelection { get; set; } = new BindingList<string>();
        public BindingSource resultSource { get; set; }
        public Rectangle m_rectROI { get; set; }
        public IParams parameter { get; set; } = new TextRecognitionParams();

        public IToolResult toolResult { get; set; }
        public TextRecognitionResult m_TextRecognitionResult { get { return (TextRecognitionResult)toolResult; } set { toolResult = value; } }

        public TextRecognitionTool(string toolName) { ToolName = toolName; }

        public  void getGUI()
        {
            if(m_rectROI != null && !m_rectROI.IsEmpty)
            {
                parameter.m_roi.location = new Point(m_rectROI.X, m_rectROI.Y);
                parameter.m_roi.ROI_Width = m_rectROI.Width;
                parameter.m_roi.ROI_Height = m_rectROI.Height;
            }
            m_toolControl = new TextRecognitionToolControl(parameter) { Dock = DockStyle.Fill };
        }

        public  void Run(Mat img, Rectangle region)
        {
            m_TextRecognitionResult?.Dispose();
            m_TextRecognitionResult = new TextRecognitionResult();

            parameter.m_roi.ROIRectangle = HelperClass.getROIImage(img, region, parameter.m_roi.points, out Mat image);
            Tesseract.TesseractEngine engine = new Tesseract.TesseractEngine("C:\\Users\\T0571\\source\\repos\\OpenCV_Vision_Pro\\OpenCV_Vision_Pro\\tessdata\\", ((TextRecognitionParams)parameter).language);
            Tesseract.BitmapToPixConverter converter = new Tesseract.BitmapToPixConverter();

            Enum.TryParse(((TextRecognitionParams)parameter).mode, out Tesseract.PageIteratorLevel myLevel);
            var page = engine.Process(converter.Convert(image.ToBitmap()));
            var iter = page.GetIterator();
            iter.Begin();
            do
            {
                if (iter.TryGetBoundingBox(myLevel, out var textRect))
                {
                    string curText = iter.GetText(myLevel);
                    Rectangle rec = new Rectangle(textRect.X1, textRect.Y1, textRect.Width, textRect.Height);
                    CvInvoke.Rectangle(image, rec , new MCvScalar(0, 0, 255));
                    m_TextRecognitionResult.text += curText;
                    //CvInvoke.PutText(image, curText, new Point(rec.X,rec.Y-rec.Height/2),FontFace.HersheySimplex,0.5,new MCvScalar(200,150,120),2);
                }
            } while (iter.Next(myLevel));
            m_TextRecognitionResult.text = page.GetText();
            page.Dispose();
            engine.Dispose();
            iter.Dispose();
            m_TextRecognitionResult.resultImage = image.Clone();
            image.Dispose();
        }

        public  void Dispose()
        {
            m_bitmapList?.Dispose();
            m_toolControl?.Dispose();
            m_TextRecognitionResult.Dispose();
            resultSource?.Dispose();
        }

        public object showResult()
        {
            return m_TextRecognitionResult?.text;
        }

        public  void showResultImages()
        {
            if (Form1.m_bitmapList.ContainsKey("LastRun." + ToolName + ".TextRecognitionImage"))
            {
                Form1.m_bitmapList["LastRun." + ToolName + ".TextRecognitionImage"]?.Dispose();
                Form1.m_bitmapList["LastRun." + ToolName + ".TextRecognitionImage"] = m_TextRecognitionResult.resultImage.Clone();
            }
            else
            {
                Form1.m_bitmapList.Add("LastRun." + ToolName + ".TextRecognitionImage", m_TextRecognitionResult.resultImage.Clone());
                if (!Form1.m_form1DisplaySelection.Contains("LastRun." + ToolName + ".TextRecognitionImage"))
                    Form1.m_form1DisplaySelection.Add("LastRun." + ToolName + ".TextRecognitionImage");
            }


            if (m_bitmapList.ContainsKey("LastRun." + ToolName + ".TextRecognitionImage"))
            {
                m_bitmapList["LastRun." + ToolName + ".TextRecognitionImage"]?.Dispose();
                m_bitmapList["LastRun." + ToolName + ".TextRecognitionImage"] = m_TextRecognitionResult.resultImage.Clone();
            }
            else
            {
                m_bitmapList.Add("LastRun." + ToolName + ".TextRecognitionImage", m_TextRecognitionResult.resultImage.Clone());
                if (!m_DisplaySelection.Contains("LastRun." + ToolName + ".TextRecognitionImage"))
                    m_DisplaySelection.Add("LastRun." + ToolName + ".TextRecognitionImage");
            }
        }
    }
}
