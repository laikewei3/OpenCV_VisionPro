using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCV_Vision_Pro.AITool
{
    public interface IAITool
    {
        Mat Draw(Mat resizeMat, int topBottom, int leftRight, Size newSize);
        void Process();
        void PreProcess(Mat frame, out Mat resizeMat, out int topBottom, out int leftRight, out Size newSize);
    }
}
