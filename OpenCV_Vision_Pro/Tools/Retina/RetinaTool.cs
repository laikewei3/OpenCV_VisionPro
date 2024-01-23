using Emgu.CV;
using Emgu.CV.Bioinspired;
using Emgu.CV.CvEnum;
using OpenCV_Vision_Pro.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace OpenCV_Vision_Pro.Tools.Retina
{
    public class RetinaParams : IParams
    {
        public bool colorMode { get; set; } = true;
        public bool normaliseOutput { get; set; } = true;
        public float photoreceptorsLocalAdaptationSensitivity { get; set; } = 0.7f;
        public float photoreceptorsTemporalConstant { get; set; } = 0.5f;
        public float photoreceptorsSpatialConstant { get; set; } = 0.53f;
        public float horizontalCellsGain { get; set; } = 0.0f;
        public float HcellsTemporalConstant { get; set; } = 1.0f;
        public float HcellsSpatialConstant { get; set; } = 7.0f;
        public float ganglionCellsSensitivity { get; set; } = 0.7f;
        public int iteration { get; set; } = 20;
    }

    public class RetinaResult : IToolResult
    {
    }

    public class RetinaTool : ITool
    {
        public string ToolName { get; set; }
        public AutoDisposeDict<string, Mat> m_bitmapList { get; set; }
        public BindingList<string> m_DisplaySelection { get; set; } = new BindingList<string>();
        public IUserControlBase m_toolControl { get; set; }
        public IParams parameter { get; set; } = new RetinaParams();
        public IToolResult toolResult { get; set; }
        private RetinaResult RetinaResult { get { return (RetinaResult)toolResult; } set { toolResult = value; } }

        public void Dispose()
        {
            m_bitmapList?.Dispose();
            m_toolControl?.Dispose();
        }

        public void getGUI()
        {
            m_toolControl = new RetinaToolControl(parameter) { Dock = DockStyle.Fill };
        }

        public RetinaTool(string toolName)
        {
            ToolName = toolName;
        }

        public void Run(Mat img, Rectangle region)
        {
            if (((RetinaToolControl)m_toolControl) != null)
                parameter = ((RetinaToolControl)m_toolControl).RetinaParams;
            else
                parameter = new RetinaParams();

            //=============================================== Delete Previous Results =============================================
            RetinaResult?.Dispose();
            RetinaResult = new RetinaResult();
            //=====================================================================================================================

            parameter.m_roi.ROIRectangle = HelperClass.getROIImage(img, region, parameter.m_roi.points, out Mat image);
            Emgu.CV.Bioinspired.Retina retina = new Emgu.CV.Bioinspired.Retina(image.Size);

            Emgu.CV.Bioinspired.Retina.OPLandIplParvoParameters parvoParameters = retina.Parameters.OPLandIplParvo;
            parvoParameters.HorizontalCellsGain = ((RetinaParams)parameter).horizontalCellsGain;
            parvoParameters.ColorMode = ((RetinaParams)parameter).colorMode;
            parvoParameters.NormaliseOutput = ((RetinaParams)parameter).normaliseOutput;
            parvoParameters.PhotoreceptorsSpatialConstant = ((RetinaParams)parameter).photoreceptorsSpatialConstant;
            parvoParameters.GanglionCellsSensitivity = ((RetinaParams)parameter).ganglionCellsSensitivity;
            parvoParameters.HcellsSpatialConstant = ((RetinaParams)parameter).HcellsSpatialConstant;
            parvoParameters.PhotoreceptorsLocalAdaptationSensitivity = ((RetinaParams)parameter).photoreceptorsLocalAdaptationSensitivity;
            parvoParameters.PhotoreceptorsTemporalConstant = ((RetinaParams)parameter).photoreceptorsTemporalConstant;
            parvoParameters.HcellsTemporalConstant = ((RetinaParams)parameter).HcellsTemporalConstant;

            Emgu.CV.Bioinspired.Retina.RetinaParameters para = new Emgu.CV.Bioinspired.Retina.RetinaParameters
            {
                OPLandIplParvo = parvoParameters
            };
            retina.Parameters = para;
            for (int i = 0; i < ((RetinaParams)parameter).iteration; i++)
            {
                retina.Run(image);
            }

            RetinaResult.resultImage = new Mat();
            retina.GetParvo(RetinaResult.resultImage);
            image.Dispose();
        }


        public void showResultImages()
        {
            HelperClass.showResultImagesStatic(m_bitmapList, m_DisplaySelection, RetinaResult.resultImage, ToolName, "RetinaImage");
        }
    }
}
