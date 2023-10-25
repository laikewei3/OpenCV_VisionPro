using System;
using Emgu.CV;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using OpenCV_Vision_Pro.Interface;

namespace OpenCV_Vision_Pro
{
    public interface IToolBase : IDisposable
    {
        string ToolName { get; set; }
        AutoDisposeDict<string, Mat> m_bitmapList { get; set; }
        BindingList<string> m_DisplaySelection { get; set; }
        UserControlBase m_toolControl { get; set; }
        IParams parameter { get; set; }
        BindingSource resultSource { get; set; }
        IToolResult toolResult { get; set; }

        void Run(Mat image, Rectangle region);
        object showResult();
        void showResultImages();
        void getGUI();

    }

}