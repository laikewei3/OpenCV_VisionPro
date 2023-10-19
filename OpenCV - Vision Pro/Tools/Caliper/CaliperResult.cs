using Emgu.CV;
using OpenCV_Vision_Pro.Interface;
using Shared.ComponentModel.SortableBindingList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCV_Vision_Pro.Caliper
{
    public class CaliperResult : IDisposable, IToolResult
    {
        public SortableBindingList<Edges> caliperEdges { get; set; } = new SortableBindingList<Edges>();
        public Mat resultImage { get; set; }

        public void Dispose()
        {
            resultImage?.Dispose();
        }
    }

    public class Edges
    {
        public double Score { get; set; }
        public int Edge0 { get; set; }
        public double Position { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double ScoringFunction0 { get; set; }
        public double Contrast_E0 { get; set; }
    }

    public class EdgesPair
    {
        public EdgesPair(double score, int edge0, int edge1, double measured_Width, double position, double x, double y, double scoringFunction0, double contrast_E0, double distance_E0, double x0, double y0, double contrast_E1, double distance_E1, double x1, double y1)
        {
            Score = score;
            Edge0 = edge0;
            Edge1 = edge1;
            Measured_Width = measured_Width;
            Position = position;
            X = x;
            Y = y;
            ScoringFunction0 = scoringFunction0;
            Contrast_E0 = contrast_E0;
            Distance_E0 = distance_E0;
            X0 = x0;
            Y0 = y0;
            Contrast_E1 = contrast_E1;
            Distance_E1 = distance_E1;
            X1 = x1;
            Y1 = y1;
        }

        public double Score { get; set; }
        public int Edge0 { get; set; }
        public int Edge1 { get; set; }
        public double Measured_Width { get; set; }
        public double Position { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double ScoringFunction0 { get; set; }
        public double Contrast_E0 { get; set; }
        public double Distance_E0 { get; set; }
        public double X0 { get; set; }
        public double Y0 { get; set; }
        public double Contrast_E1 { get; set; }
        public double Distance_E1 { get; set; }
        public double X1 { get; set; }
        public double Y1 { get; set; }
    }

}
