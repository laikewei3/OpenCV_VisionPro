using Emgu.CV;
using OpenCV_Vision_Pro.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCV_Vision_Pro
{
    // One Results
    public class BlobData
    {
        public int ID { get; set; }
        public double Area { get; set; }
        public double CenterMassX { get; set; }
        public double CenterMassY { get; set; }
        public string ConnectivityLabel { get; set; }
        public double Angle { get; set; }
        public double BoundaryPixelLength { get; set; }
        public double Perimeter { get; set; }
        public int NumChildren { get; set; }
        public double InertiaX { get; set; }
        public double InertiaY { get; set; }
        public double InertiaMin { get; set; }
        public double InertiaMax { get; set; }
        public double Elongation { get; set; }
        public double Acircularity { get; set; }
        public double AcircularityRms { get; set; }
        public double ImageBoundCenterX { get; set; }
        public double ImageBoundCenterY { get; set; }
        public double ImageBoundMinX { get; set; }
        public double ImageBoundMaxX { get; set; }
        public double ImageBoundMinY { get; set; }
        public double ImageBoundMaxY { get; set; }
        public double ImageBoundWidth { get; set; }
        public double ImageBoundHeight { get; set; }
        public double ImageBoundAspect { get; set; }
        public double MedianX { get; set; }
        public double MedianY { get; set; }
        public double BoundCenterX { get; set; }
        public double BoundCenterY { get; set; }
        public double BoundMinX { get; set; }
        public double BoundMaxX { get; set; }
        public double BoundMinY { get; set; }
        public double BoundMaxY { get; set; }
        public double BoundWidth { get; set; }
        public double BoundHeight { get; set; }
        public double BoundAspect { get; set; }
        public double BoundPrincipalMinX { get; set; }
        public double BoundPrincipalMaxX { get; set; }
        public double BoundPrincipalMinY { get; set; }
        public double BoundPrincipalMaxY { get; set; }
        public double BoundPrincipalWidth { get; set; }
        public double BoundPrincipalHeight { get; set; }
        public double BoundPrincipalAspect { get; set; }
        public double NotClipped { get; set; }
    }

    // List of Blob and BlobImage
    public class BlobResults : IDisposable, IToolResult
    {
        public List<BlobData> blobs { get; set; } = new List<BlobData>();

        public Mat resultImage { get; set; }

        public void Dispose()
        {
            resultImage?.Dispose();
        }
    }

}
