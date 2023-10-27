using System;
using Emgu.CV;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using OpenCV_Vision_Pro.Interface;

namespace OpenCV_Vision_Pro
{
    public interface IToolBase : ISimpleToolBase
    {
        string ToolName { get; set; }
        AutoDisposeDict<string, Mat> m_bitmapList { get; set; }
        BindingList<string> m_DisplaySelection { get; set; }
        BindingSource resultSource { get; set; }

        object showResult();
        void showResultImages();
    }

    public interface ISimpleToolBase : IDisposable
    {
        UserControlBase m_toolControl { get; set; }
        IParams parameter { get; set; }
        IToolResult toolResult { get; set; }
        void Run(Mat image, Rectangle region); 
        void getGUI();
    }

}