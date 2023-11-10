using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenCV_Vision_Pro
{
    public class Calibration
    {
        public CalibrationResult Result { get; set; }
        public Calibration(bool useVideo)
        {
            AutoDisposeList<Mat> mats = new AutoDisposeList<Mat>();
            Size imageSize;
            if (useVideo)
                imageSize = GetCalibrationImagesCamera(mats);
            else
                imageSize = GetCalibrationImagesFolder(mats);
            VectorOfVectorOfPoint3D32F objectPoints = new VectorOfVectorOfPoint3D32F();
            VectorOfVectorOfPointF imagePoints = new VectorOfVectorOfPointF();

            VectorOfPoint3D32F objp = new VectorOfPoint3D32F();
            Size chessboardSize = new Size(17,24); //count the 'inside' corners.
            for (int i = 0; i < chessboardSize.Width; i++)
            {
                for (int j = 0; j < chessboardSize.Height; j++)
                {
                    objp.Push(new MCvPoint3D32f[] { new MCvPoint3D32f(j, i, 0) });
                }
            }

            for (int i = 0;i <mats.Count; i++)
            {
                Process(mats[i], chessboardSize, objectPoints, imagePoints, objp);
            }
            objp.Dispose();

            Result = Calibrate(objectPoints, imagePoints, imageSize);
            if(!Result.cameraMatrix.IsEmpty)
                SaveMatrix(Result.cameraMatrix);

            objectPoints.Dispose();
            imagePoints.Dispose();
            mats.Dispose();
        }

        private Size GetCalibrationImagesCamera(AutoDisposeList<Mat> mats)
        {
            VideoCapture videoCapture = new VideoCapture(1);
            Mat frame = new Mat();
            Size imageSize = new Size();
            while (videoCapture.IsOpened) 
            { 
                bool ret = videoCapture.Read(frame);
                if (ret)
                {
                    if (CvInvoke.WaitKey(5) == 's')
                    {
                        MessageBox.Show("ADDED SUCCESSFULLY");
                        mats.Add(frame);
                    }
                    if (CvInvoke.WaitKey(5) == 'q')
                        break;
                    CvInvoke.Imshow("Capture Calibration Images", frame);
                }
                imageSize = frame.Size;
            }
            CvInvoke.DestroyAllWindows();
            videoCapture.Stop();
            videoCapture.Dispose();
            return imageSize;
        }

        private Size GetCalibrationImagesFolder(AutoDisposeList<Mat> mats, string file = "C:\\Users\\T0571\\Downloads\\calibration")
        {
            string[] files = Directory.GetFiles(file);
            
            for (int i = 0; i < files.Length; i++)
            {
                FileStream fileStream = new FileStream(files[i], FileMode.Open, FileAccess.Read);
                using (Image image = Image.FromStream(fileStream, true, false))
                {
                    if (image != null)
                    {
                        using (MemoryStream memStream = new MemoryStream())
                        {
                            if (Path.GetExtension(files[i]) == ".png")
                                image.Save(memStream, ImageFormat.Png);
                            else
                                image.Save(memStream, ImageFormat.Bmp);
                            using (Bitmap m_image = (Bitmap)Bitmap.FromStream(memStream))
                            {
                                Mat tempMat = m_image.ToMat();

                                mats.Add(tempMat);
                                
                                m_image.Dispose();
                            }
                            memStream.Dispose();
                        }
                    }
                    image.Dispose();
                }
            }
            
            return mats.Count > 0 ? mats[0].Size : new Size();
        }

        private void Process(Mat image, Size chessboardSize, VectorOfVectorOfPoint3D32F objectPoints, VectorOfVectorOfPointF imagePoints, VectorOfPoint3D32F objp)
        {
            Mat gray = new Mat();
            CvInvoke.CvtColor(image, gray, ColorConversion.Bgr2Gray);
            VectorOfPointF corners = new VectorOfPointF();
            bool ret = CvInvoke.FindChessboardCorners(gray, chessboardSize, corners,CalibCbType.AdaptiveThresh | CalibCbType.FastCheck | CalibCbType.NormalizeImage);
            
            if (ret)
            {
                MCvTermCriteria criteria = new MCvTermCriteria(30, 0.001);
                CvInvoke.CornerSubPix(gray, corners, new Size(11, 11), new Size(-1, -1), criteria);
                CvInvoke.DrawChessboardCorners(image, chessboardSize, corners, ret);
                objectPoints.Push(objp);
                imagePoints.Push(corners);
            }
            corners.Dispose();
            gray.Dispose();
        }

        private CalibrationResult Calibrate(VectorOfVectorOfPoint3D32F objectPoints, VectorOfVectorOfPointF imagePoints, Size imageSize)
        {
            try
            {
                CalibrationResult res = new CalibrationResult();
                CvInvoke.CalibrateCamera(objectPoints, imagePoints, imageSize, res.cameraMatrix, res.distCoeffs, res.R, res.T, CalibType.Default, new MCvTermCriteria());
                return res;
            }
            catch(Exception e)
            {
                MessageBox.Show("Input Error"+"\n\n"+e.ToString());
            }
            return new CalibrationResult();
        }
    
        private void SaveMatrix(Mat cameraMatrix, string fileName = "C:\\Users\\T0571\\source\\repos\\OpenCV_Vision_Pro\\OpenCV_Vision_Pro\\intrinsic.txt")
        {
            Numpy.np.savetxt(fileName, Numpy.np.asarray(cameraMatrix.GetData()));
            MessageBox.Show("Save Successfully");
            
        }
    }

    public class CalibrationResult : IDisposable
    {
        public Mat cameraMatrix { get; set; } = new Mat();
        public Mat distCoeffs { get; set; } = new Mat();
        public Mat R { get; set; } = new Mat();
        public Mat T { get; set; } = new Mat();

        public void Dispose()
        {
            cameraMatrix.Dispose();
            distCoeffs.Dispose();
            R.Dispose();
            T.Dispose();
        }
    }
}
