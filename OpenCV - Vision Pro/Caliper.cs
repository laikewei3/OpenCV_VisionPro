using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCV_Vision_Pro
{
    public class Caliper
    {
        public int ID {  get; set; }
        public double Score {  get; set; }
        public int Edge0 { get; set; }
        public int Edge1 { get; set; }
        public double MeasuredWidth { get; set; }
        public double Position { get; set; }
        public double PositionX { get; set; }
        public double PositionY { get; set; }
        public double ScoringFunction0 { get; set; }
        public double ContrastEdge0 {  get; set; }
        public double PositionEdge0 { get; set; }
        public double PositionXEdge0 { get; set; }
        public double PositionYEdge0 { get;set; }
        public double ContrastEdge1 { get; set; }
        public double PositionEdge1 { get; set; }
        public double PositionXEdge1 { get; set; }
        public double PositionYEdge1 { get; set; }

    }
}
