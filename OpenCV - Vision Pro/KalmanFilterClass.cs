using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCV_Vision_Pro
{
    public class KalmanFilterClass
    {
        private KalmanFilter kalmanFilter;

        public KalmanFilterClass()
        {
            kalmanFilter = new KalmanFilter(4, 2, 0);
            float measurementNoiseValue = 9.999f;
            float processNoise = 0.001f;
            Matrix<float> transitionMatrix = new Matrix<float>(new[,]
            {
                {1f, 1f, 0f, 0f},
                {0, 1, 1, 0},
                {0, 0, 1, 1},
                {0, 0, 0, 1}
            });
            var measurementMatrix = new Matrix<float>(new[,] { { 1f, 0, 0, 0 } });
            var procNoiseCov = new Matrix<float>(4, 4);
            var measurementNoise = new Matrix<float>(1, 1);
            var errorCovPost = new Matrix<float>(4, 4);

            procNoiseCov.SetIdentity(new MCvScalar(processNoise));
            measurementNoise.SetIdentity(new MCvScalar(measurementNoiseValue));
            errorCovPost.SetIdentity(new MCvScalar(10));

            transitionMatrix.Mat.CopyTo(kalmanFilter.TransitionMatrix);
            
            measurementMatrix.Mat.CopyTo(kalmanFilter.MeasurementMatrix);
            procNoiseCov.Mat.CopyTo(kalmanFilter.ProcessNoiseCov);
            measurementNoise.Mat.CopyTo(kalmanFilter.MeasurementNoiseCov);
            errorCovPost.Mat.CopyTo(kalmanFilter.ErrorCovPost);
            kalmanFilter.StatePost.SetTo(new float[] { 0, 1, 1, 1 });
        }

        public Point predict(int coordX, int coordY)
        {
            Matrix<float> measurement = new Matrix<float>(new float[,]
            {
                { coordX },
                { coordY }
            });
            Matrix<float> predicted = new Matrix<float>(2, 1);
            kalmanFilter.Correct(measurement.Mat);
            kalmanFilter.Predict().CopyTo(predicted); ;
            Point point = new Point();
            point.X = (int)predicted[0, 0];
            point.Y = (int)predicted[1, 0];
            return point;
        }
    }

    public class Track
    {
        private KalmanFilterClass kalmanFilterClass;
        public Track()
        {
            kalmanFilterClass = new KalmanFilterClass();

        }
    }
}
