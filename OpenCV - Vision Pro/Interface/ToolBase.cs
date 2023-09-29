using System;
using Emgu.CV;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;

namespace OpenCV_Vision_Pro
{
    public abstract class IToolBase : IDisposable
    {
        public abstract string ToolName { get; set; }
        public abstract AutoDisposeDict<string, Mat> m_bitmapList {  get; set; }
        public abstract BindingList<string> m_DisplaySelection { get; set; }
        public abstract UserControlBase m_toolControl { get; set; }
        public abstract Rectangle m_rectROI { get; set; }
        public abstract Interface.IParams parameter { get; set; }
        public abstract BindingSource resultSource { get; set; }
        public abstract void Dispose();
        public abstract void Run(Mat image, Rectangle region);
        public abstract object showResult();
        public abstract void showResultImages();
        public abstract void getGUI();
    }
}