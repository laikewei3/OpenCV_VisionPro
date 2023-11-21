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
        public ProcessToolList(string toolName, IBaseTool toolProcess)
        {
            this.toolName = toolName;
            this.toolProcess = toolProcess;
        }

        public string toolName {  get; set; }
        public IBaseTool toolProcess {  get; private set; }

        public void Dispose()
        {
            toolProcess.Dispose();
        }
    }

    public class ProcessParams : IParams
    {
        public BindingList<ProcessToolList> toolProcessList { get; set; } = new BindingList<ProcessToolList>();
    }

    public class ImageProcessTool : IToolData
    {
        public  string ToolName { get; set; }
        public  AutoDisposeDict<string, Mat> m_bitmapList { get; set; }
        public  BindingList<string> m_DisplaySelection { get; set; } = new BindingList<string>();
        public  IUserControlBase m_toolControl { get; set; }
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
            m_toolControl = new ImageProcessToolControl(parameter) { Dock = DockStyle.Fill };
        }

        public  void Run(Mat img, Rectangle region)
        {
            parameter.m_roi.ROIRectangle = HelperClass.getROIImage(img, region, parameter.m_roi.points, out Mat image);
            ProcessResult?.Dispose();
            ProcessResult = new ProcessResults();

            for(int i = 0; i < ((ProcessParams)parameter).toolProcessList.Count; i++)
            {
                IBaseTool tool = ((ProcessParams)parameter).toolProcessList[i].toolProcess;
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
            HelperClass.showResultImagesStatic(m_bitmapList, m_DisplaySelection, ProcessResult.resultImage, ToolName, "ProcessImage");
        }

        private class ProcessResults : IToolResult
        {}

    }
}
