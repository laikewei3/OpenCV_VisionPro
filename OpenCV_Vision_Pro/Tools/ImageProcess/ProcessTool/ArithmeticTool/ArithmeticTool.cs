using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using Emgu.CV.Util;
using OpenCV_Vision_Pro.Interface;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace OpenCV_Vision_Pro.Tools.ImageProcess.ProcessTool
{
    public class ArithmeticParams:IParams
    {
        public string ArithmeticMode { get; set; } = "Add/Substract";
        public string overflow { get; set; } = "Clamp";
        public double P1 { get; set; } = 1.0;
        public double P2 { get; set; } = 1.0;
        public double P3 { get; set; } = 1.0;
        public ROI m_roi { get; set; } = new ROI();
        public bool m_boolHasROI { get; set; } = false;
    }

    public class ArithmeticTool : ISimpleToolBase
    {
        public UserControlBase m_toolControl { get; set; }
        public IParams parameter { get; set; } = new ArithmeticParams();
        public IToolResult toolResult { get; set; }
        public ArithmeticResult ArithmeticResult { get { return (ArithmeticResult)toolResult; } set { toolResult = value; } }

        public void Dispose()
        {
            m_toolControl?.Dispose();
        }

        public void getGUI()
        {
            m_toolControl = new ArithmeticToolControl(parameter) { Dock = DockStyle.Fill };
        }

        public void Run(Mat image, Rectangle region)
        {
            ArithmeticResult?.Dispose();
            ArithmeticResult = new ArithmeticResult();
            string mode = ((ArithmeticParams)parameter).ArithmeticMode;
            image.ConvertTo(image, DepthType.Cv32F);
            
            if (String.Compare(mode, "Add/Substract") == 0)
            {
                if(image.NumberOfChannels == 1)
                    image += ((ArithmeticParams)parameter).P1;
                else
                    image += new MCvScalar(((ArithmeticParams)parameter).P1, ((ArithmeticParams)parameter).P2, ((ArithmeticParams)parameter).P3);
                
                if (((ArithmeticParams)parameter).overflow != "Clamp")
                {
                    if (image.NumberOfChannels == 1)
                    {
                        Image<Gray, float> imageGray = image.ToImage<Gray, float>();
                        for (int y = 0; y < image.Rows; y++)
                        {
                            for (int x = 0; x < image.Cols; x++)
                            {
                                double temp;
                                Gray pixel = imageGray[y, x];
                                if (pixel.MCvScalar.V0 < 0)
                                {
                                    temp = pixel.MCvScalar.V0;
                                    while (temp < 0)
                                        temp += 255;
                                    pixel.MCvScalar = new MCvScalar(temp);;
                                }
                                else if (pixel.MCvScalar.V0 > 255)
                                {
                                    temp = pixel.MCvScalar.V0;
                                    while(temp > 255) 
                                        temp -= 255; 
                                    pixel.MCvScalar = new MCvScalar(pixel.MCvScalar.V0 - 255);
                                }
                                imageGray[y, x] = pixel;
                            }
                        }
                        image = imageGray.Mat;
                    }
                    else
                    {
                        Image<Bgr, float> imageFloat = image.ToImage<Bgr, float>();
                        for (int y = 0; y < image.Rows; y++)
                        {
                            for (int x = 0; x < image.Cols; x++)
                            {
                                Bgr pixel = imageFloat[y, x];
                                double temp;

                                if (pixel.Red < 0)
                                {
                                    temp = pixel.Red;
                                    while (temp < 0)
                                        temp += 255;
                                    pixel.Red = (byte)(temp);  
                                }
                                else if (pixel.Red > 255)
                                {
                                    temp = pixel.Red;
                                    while (temp > 255)
                                        temp -= 255;
                                    pixel.Red = (byte)(temp);  // 大于255的值减去255
                                }

                                if (pixel.Green < 0)
                                {
                                    temp = pixel.Green;
                                    while (temp < 0)
                                        temp += 255;
                                    pixel.Green = (byte)(temp);
                                }
                                else if (pixel.Green > 255)
                                {
                                    temp = pixel.Green;
                                    while (temp > 255)
                                        temp -= 255;
                                    pixel.Green = (byte)(temp);  // 大于255的值减去255
                                }

                                if (pixel.Blue < 0)
                                {
                                    temp = pixel.Blue;
                                    while (temp < 0)
                                        temp += 255;
                                    pixel.Blue = (byte)(temp);
                                }
                                else if (pixel.Blue > 255)
                                {
                                    temp = pixel.Blue;
                                    while (temp > 255)
                                        temp -= 255;
                                    pixel.Blue = (byte)(temp);  // 大于255的值减去255
                                }
                                
                                imageFloat[y, x] = pixel;
                            }
                        }
                        image = imageFloat.Mat;
                    }
                }

            }
            else if (String.Compare(mode, "Multiply") == 0)
            {
                if (image.NumberOfChannels == 1)
                    image *= ((ArithmeticParams)parameter).P1;
                else
                {
                    VectorOfMat vom = new VectorOfMat();
                    CvInvoke.Split(image, vom);
                    image.Dispose();
                    image = new Mat();
                    Mat p1 = vom[0] * ((ArithmeticParams)parameter).P1;
                    Mat p2 = vom[1] * ((ArithmeticParams)parameter).P2;
                    Mat p3 = vom[2] * ((ArithmeticParams)parameter).P3;
                    vom.Dispose();
                    vom = new VectorOfMat(new Mat[] { p1, p2, p3 });
                    CvInvoke.Merge(vom, image);
                    p1.Dispose(); p2.Dispose(); p3.Dispose(); vom.Dispose();
                }
                
                if (((ArithmeticParams)parameter).overflow != "Clamp")
                {
                    if (image.NumberOfChannels == 1)
                    {
                        Image<Gray, float> imageGray = image.ToImage<Gray, float>();
                        for (int y = 0; y < image.Rows; y++)
                        {
                            for (int x = 0; x < image.Cols; x++)
                            {
                                double temp;
                                Gray pixel = imageGray[y, x];
                                if (pixel.MCvScalar.V0 < 0)
                                {
                                    temp = pixel.MCvScalar.V0;
                                    while (temp < 0)
                                        temp += 255;
                                    pixel.MCvScalar = new MCvScalar(temp); ;
                                }
                                else if (pixel.MCvScalar.V0 > 255)
                                {
                                    temp = pixel.MCvScalar.V0;
                                    while (temp > 255)
                                        temp -= 255;
                                    pixel.MCvScalar = new MCvScalar(pixel.MCvScalar.V0 - 255);
                                }
                                imageGray[y, x] = pixel;
                            }
                        }
                        image = imageGray.Mat;
                    }
                    else
                    {
                        Image<Bgr, float> imageFloat = image.ToImage<Bgr, float>();
                        for (int y = 0; y < image.Rows; y++)
                        {
                            for (int x = 0; x < image.Cols; x++)
                            {
                                double temp;
                                Bgr pixel = imageFloat[y, x];

                                if (pixel.Red < 0)
                                {
                                    temp = pixel.Red;
                                    while (temp < 0)
                                        temp += 255;
                                    pixel.Red = (byte)(temp);
                                }
                                else if (pixel.Red > 255)
                                {
                                    temp = pixel.Red;
                                    while (temp > 255)
                                        temp -= 255;
                                    pixel.Red = (byte)(temp);  // 大于255的值减去255
                                }

                                if (pixel.Green < 0)
                                {
                                    temp = pixel.Green;
                                    while (temp < 0)
                                        temp += 255;
                                    pixel.Green = (byte)(temp);
                                }
                                else if (pixel.Green > 255)
                                {
                                    temp = pixel.Green;
                                    while (temp > 255)
                                        temp -= 255;
                                    pixel.Green = (byte)(temp);  // 大于255的值减去255
                                }

                                if (pixel.Blue < 0)
                                {
                                    temp = pixel.Blue;
                                    while (temp < 0)
                                        temp += 255;
                                    pixel.Blue = (byte)(temp);
                                }
                                else if (pixel.Blue > 255)
                                {
                                    temp = pixel.Blue;
                                    while (temp > 255)
                                        temp -= 255;
                                    pixel.Blue = (byte)(temp);  // 大于255的值减去255
                                }

                                imageFloat[y, x] = pixel;
                            }
                        }
                        image = imageFloat.Mat;
                    }
                }
            }
            image.ConvertTo(image, DepthType.Cv8U);
            ArithmeticResult.resultImage = image.Clone();
            image.Dispose();
        }
    }

    public class ArithmeticResult : IToolResult, IDisposable
    {
        public Mat resultImage { get; set;}

        public void Dispose()
        {
            resultImage?.Dispose();
        }
    }
}
