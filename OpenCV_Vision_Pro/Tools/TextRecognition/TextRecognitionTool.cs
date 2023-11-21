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
        public string mode { get; set; } = "Symbol";
        public string language { get; set; } = "eng";
    }

    public class TextRecognitionResult : IToolResult, IDisposable
    {
        public string text { get; set; }
    }

    public partial class TextRecognitionTool : IToolData
    {   
        public string ToolName { get; set; }
        public AutoDisposeDict<string, Mat> m_bitmapList { get; set; }
        public IUserControlBase m_toolControl { get; set; }
        public BindingList<string> m_DisplaySelection { get; set; } = new BindingList<string>();
        public BindingSource resultSource { get; set; }
        public IParams parameter { get; set; } = new TextRecognitionParams();

        public IToolResult toolResult { get; set; }
        public TextRecognitionResult m_TextRecognitionResult { get { return (TextRecognitionResult)toolResult; } set { toolResult = value; } }

        public TextRecognitionTool(string toolName) { ToolName = toolName; }

        public  void getGUI()
        {
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
            HelperClass.showResultImagesStatic(m_bitmapList, m_DisplaySelection, m_TextRecognitionResult.resultImage, ToolName, "TextRecognitionImage");
        }
    }
}
