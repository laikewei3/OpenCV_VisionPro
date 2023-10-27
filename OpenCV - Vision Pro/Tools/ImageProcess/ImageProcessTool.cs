using Emgu.CV;
using OpenCV_Vision_Pro.Interface;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace OpenCV_Vision_Pro
{
    public class ProcessToolList : IDisposable
    {
        public ProcessToolList(string toolName, ISimpleToolBase toolProcess)
        {
            this.toolName = toolName;
            this.toolProcess = toolProcess;
        }

        public string toolName {  get; set; }
        public ISimpleToolBase toolProcess {  get; private set; }

        public void Dispose()
        {
            toolProcess.Dispose();
        }
    }

    public class ProcessParams : IParams
    {
        public ROI m_roi { get; set; } = new ROI();
        public bool m_boolHasROI { get; set; } = false;
        public BindingList<ProcessToolList> toolProcessList { get; set; } = new BindingList<ProcessToolList>();
    }

    public class ImageProcessTool : IToolBase
    {
        public  string ToolName { get; set; }
        public  AutoDisposeDict<string, Mat> m_bitmapList { get; set; }
        public  BindingList<string> m_DisplaySelection { get; set; } = new BindingList<string>();
        public  UserControlBase m_toolControl { get; set; }
        public  Rectangle m_rectROI { get; set; }
        public  IParams parameter { get; set; } = new ProcessParams();
        public  BindingSource resultSource { get; set; }

        public  IToolResult toolResult { get; set; }
        private ProcessResults ProcessResult { get { return (ProcessResults)toolResult; } set { toolResult = value; } }

        public ImageProcessTool(string toolName) { this.ToolName = toolName; }

        public  void Dispose()
        {
            m_bitmapList?.Dispose();
            m_toolControl?.Dispose();
            resultSource?.Dispose();
        }

        public  void getGUI()
        {
            if (m_rectROI != null && !m_rectROI.IsEmpty)
            {
                parameter.m_roi.location = new Point(m_rectROI.X, m_rectROI.Y);
                parameter.m_roi.ROI_Width = m_rectROI.Width;
                parameter.m_roi.ROI_Height = m_rectROI.Height;
            }
            m_toolControl = new ImageProcessToolControl(parameter) { Dock = DockStyle.Fill };
        }

        public  void Run(Mat img, Rectangle region)
        {
            parameter.m_roi.ROIRectangle = HelperClass.getROIImage(img, region, parameter.m_roi.points, out Mat image);
            ProcessResult?.Dispose();
            ProcessResult = new ProcessResults();

            for(int i = 0; i < ((ProcessParams)parameter).toolProcessList.Count; i++)
            {
                ISimpleToolBase tool = ((ProcessParams)parameter).toolProcessList[i].toolProcess;
                tool.Run(image, new Rectangle());
                image?.Dispose();
                image = tool.toolResult.resultImage;
            }
            ProcessResult.resultImage = image.Clone(); 
            image?.Dispose();
        }

        public object showResult()
        {
            return new BindingSource() { DataSource = ((ProcessParams)parameter).toolProcessList };
        }

        public  void showResultImages()
        {
            if (Form1.m_bitmapList.ContainsKey("LastRun." + ToolName + ".ProcessImage"))
            {
                Form1.m_bitmapList["LastRun." + ToolName + ".ProcessImage"]?.Dispose();
                Form1.m_bitmapList["LastRun." + ToolName + ".ProcessImage"] = ProcessResult.resultImage.Clone();
            }
            else
            {
                Form1.m_bitmapList.Add("LastRun." + ToolName + ".ProcessImage", ProcessResult.resultImage.Clone());
                if (!Form1.m_form1DisplaySelection.Contains("LastRun." + ToolName + ".ProcessImage"))
                    Form1.m_form1DisplaySelection.Add("LastRun." + ToolName + ".ProcessImage");
            }

            if (m_bitmapList.ContainsKey("LastRun." + ToolName + ".ProcessImage"))
            {
                m_bitmapList["LastRun." + ToolName + ".ProcessImage"]?.Dispose();
                m_bitmapList["LastRun." + ToolName + ".ProcessImage"] = ProcessResult.resultImage.Clone();
            }
            else
            {
                m_bitmapList.Add("LastRun." + ToolName + ".ProcessImage", ProcessResult.resultImage.Clone());
                if (!m_DisplaySelection.Contains("LastRun." + ToolName + ".ProcessImage"))
                    m_DisplaySelection.Add("LastRun." + ToolName + ".ProcessImage");
            }
        }

        private class ProcessResults : IDisposable, IToolResult
        {
            public Mat resultImage { get; set; }

            public void Dispose()
            {
                resultImage?.Dispose();
            }
        }

    }
}
