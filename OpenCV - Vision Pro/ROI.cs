using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenCV_Vision_Pro
{
    public partial class ROI : UserControl
    {
        private double m_Xcoord = 0;
        private double m_Ycoord = 0;
        private double m_width = 50;
        private double m_height = 50;
        private double m_rotation = 0;
        private double m_skew = 0;

        public ROI()
        {
            InitializeComponent();
            m_comboBoxROI.SelectedIndex = 0;
        }

        public double X
        {
            get { return m_Xcoord; }
            set
            {
                m_Xcoord = value;
                Invalidate();
            }
        }

        public double Y
        {
            get { return m_Ycoord; }
            set
            {
                m_Ycoord = value;
                Invalidate();
            }
        }

        public double ROI_Width
        {
            get { return m_width; }
            set
            {
                m_width = value;
                Invalidate();
            }
        }

        public double ROI_Height
        {
            get { return m_height; }
            set
            {
                m_height = value;
                Invalidate();
            }
        }

        public double ROI_rotation
        {
            get { return m_rotation; }
            set
            {
                m_rotation = value;
                Invalidate();
            }
        }

        public double ROI_skew
        {
            get { return m_skew; }
            set
            {
                m_skew = value;
                Invalidate();
            }
        }
    }
}
