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

    public partial class Form1 : Form
    {
        Dictionary<String, Bitmap> bitmapList = new Dictionary<String, Bitmap>();
        string m_strFileName;
        ROI m_roi = new ROI();

        public Form1()
        {
            InitializeComponent();
            //m_roi.m_comboBoxROI.SelectedIndexChanged += m_comboBoxROI_SelectedIndexChanged;
        }

        private async void m_OpenBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All File (*.*) | *.*";
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                BackgroundWorker bw = new BackgroundWorker();
                bw.WorkerReportsProgress = false;
                bw.WorkerSupportsCancellation = false;
                bw.DoWork += Bw_DoWork;
                bw.RunWorkerCompleted += Bw_RunWorkerCompleted;
                bw.RunWorkerAsync();

                m_strFileName = openFileDialog.FileName;
                m_cbImages.Items.Clear();
                m_cbImages.Items.Add("LastRun.OutputImage");
                m_cbImages.SelectedIndex = 0;
            }
        }

        private void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            m_picBox.Image = bitmapList["LastRun.OutputImage"];
        }

        private void Bw_DoWork(object sender, DoWorkEventArgs e)
        {
            Bitmap m_image = new Bitmap(m_strFileName);
            bitmapList.Add("LastRun.OutputImage", m_image);
        }

        private void m_picBox_Paint(object sender, PaintEventArgs e)
        {

        }

        

    }
}
