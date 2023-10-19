using Emgu.CV;
using OpenCV_Vision_Pro.Interface;
using Shared.ComponentModel.SortableBindingList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCV_Vision_Pro.LineSegment
{
    public class LineSegmentResult : IDisposable, IToolResult
    {
        public SortableBindingList<LineSegments> LineSegmentEdges { get; set; } = new SortableBindingList<LineSegments>();
        public Mat resultImage { get; set; }

        public void Dispose()
        {
            resultImage?.Dispose();
        }
    }

    public class LineSegments
    {
        public LineSegments() { }
        public LineSegments(int Edge0, double distance, double angle)
        {
            this.Edge0 = Edge0;
            this.Distance = distance;
            this.Angle = angle;
        }

        //public double Score { get; set; }
        public int Edge0 { get; set; }
        public double Distance { get; set; }
        public double Angle { get; set; }
        //public double Position { get; set; }
        //public double X { get; set; }
        //public double Y { get; set; }
        //public double ScoringFunction0 { get; set; }
        //public double Contrast_E0 { get; set; }
    } 
}
