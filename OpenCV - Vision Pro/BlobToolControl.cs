using OpenCV_Vision_Pro;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenCV___Vision_Pro
{
    public partial class BlobToolControl : UserControl
    {
        ROI m_roi = new ROI();
        public BlobToolControl()
        {
            InitializeComponent();
            Panel panel = new Panel();
            Panel tempPanel = new Panel();
            panel = new Panel();
            panel.Height = 65;
            
            this.Controls.Add(panel);
            panel.Controls.Add(tempPanel);
            tempPanel.Controls.Add(m_roi);
            m_roi.Dock = DockStyle.Fill;
            panel.Dock = DockStyle.Top;
            tempPanel.Dock = DockStyle.Top;

            for (int i = 0; i < 3; i++)
            {
                m_cbBlobProperties.SelectedIndex = 0;
                m_cbBlobProperties.SelectedIndex = -1;
            }

            m_cbSegMode.SelectedIndex = 2;
            m_cbSegPolarity.SelectedIndex = 0;
            m_cbConnectMode.SelectedIndex = 0;
            m_cbConnectClean.SelectedIndex = 2;

            m_NumSegmentation1.Value = 128;
        }
    }
}
