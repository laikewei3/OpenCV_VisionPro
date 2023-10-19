using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCV_Vision_Pro.Interface
{
    public interface IToolResult
    {
        Mat resultImage {  get; }
    }
}
