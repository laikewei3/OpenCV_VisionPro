using Emgu.CV;
using System;

namespace OpenCV_Vision_Pro.Interface
{
    public abstract class IToolResult : IDisposable
    {
        public Mat resultImage { get; set; }

        public void Dispose()
        {
            resultImage?.Dispose();
        }
    }
}
