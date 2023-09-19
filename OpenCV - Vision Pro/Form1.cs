using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace OpenCV_Vision_Pro
{
    public partial class Form1 : Form
    {
        public static DisplayControl m_displayControl;
        public List<ToolsClass> m_toolsList = new List<ToolsClass>();
        private int m_intCntBlob = 0;
        private int m_intCntCaliper = 0;
        private int m_intCntHistogram = 0;

        public Form1()
        {
            InitializeComponent();
            m_displayControl = new DisplayControl();
            m_displayControl.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(m_displayControl);
            //m_display.Paint += ROI_Paint;
        }
        
        private void m_OpenBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All File (*.*) | *.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Bitmap m_image = new Bitmap(openFileDialog.FileName);
                m_displayControl.m_display.Width = m_image.Width;
                m_displayControl.m_display.Height = m_image.Height;

                m_displayControl.m_cbImages.Items.Clear();
                m_displayControl.m_bitmapList.Clear();
                m_displayControl.m_bitmapList.Add("LastRun.OutputImage", m_image);

                m_displayControl.m_display.Image = m_displayControl.m_bitmapList["LastRun.OutputImage"];
                m_displayControl.m_cbImages.Items.Add("LastRun.OutputImage");
                m_displayControl.m_cbImages.SelectedIndex = 0;
            }
        }

        private void m_BtnAddTool_Click(object sender, EventArgs e)
        {
            m_AddToolList.Show(m_BtnAddTool, new Point(0, m_BtnAddTool.Height));
        }

        private void blobToolMenuItem_Click(object sender, EventArgs e)
        {
            m_treeViewTools.Nodes.Add("CogBlobTool" + (++m_intCntBlob).ToString());
            BlobToolControl blobTool = new BlobToolControl();
            blobTool.Dock = DockStyle.Fill;
            m_toolsList.Add(new ToolsClass(blobTool));
        }

        private void m_treeViewTools_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeView m_treeView = (TreeView)sender;
            ToolWindow toolWindow = new ToolWindow
            {
                Text = m_treeView.SelectedNode.Text
            };
            ToolsClass tool = m_toolsList[m_treeView.SelectedNode.Index];
            string m_strToolType = tool.TypeFilled.ToString();
            switch (m_strToolType)
            {
                case "BlobToolControl":
                    BlobToolControl m_tempBlobControl = tool.BlobToolControl;
                    toolWindow.splitContainer1.Panel1.Controls.Add(m_tempBlobControl);
                    toolWindow.m_roi = m_tempBlobControl.m_roi;
                    tool.m_bitmapList = m_tempBlobControl.m_bitmapList;
                    break;
                case "CaliperToolControl":
                    CaliperToolControl m_tempCaliperControl = tool.CaliperToolControl;
                    toolWindow.splitContainer1.Panel1.Controls.Add(m_tempCaliperControl);
                    toolWindow.m_roi = m_tempCaliperControl.m_roi;
                    tool.m_bitmapList = m_tempCaliperControl.m_bitmapList;
                    break;
                case "HistogramToolControl":
                    HistogramToolControl m_tempHistControl = tool.HistogramToolControl;
                    toolWindow.splitContainer1.Panel1.Controls.Add(m_tempHistControl);
                    toolWindow.m_roi = m_tempHistControl.m_roi;
                    tool.m_bitmapList = m_tempHistControl.m_bitmapList;
                    break;
                default:
                    MessageBox.Show("Error");
                    break;
            }
            if(m_displayControl.m_bitmapList.Count >= 1)
            {
                if(m_displayControl.m_bitmapList.Count == 1)
                    tool.m_bitmapList.Clear();
                if (!tool.m_bitmapList.ContainsKey("Current.InputImage"))
                    tool.m_bitmapList.Add("Current.InputImage", m_displayControl.m_bitmapList["LastRun.OutputImage"]);
            }
            toolWindow.m_displayControl.m_bitmapList = tool.m_bitmapList;

            toolWindow.Show();
        }

        private void caliperToolMenuItem_Click(object sender, EventArgs e)
        {
            m_treeViewTools.Nodes.Add("CogCaliperTool" + (++m_intCntCaliper).ToString());
            CaliperToolControl caliperTool = new CaliperToolControl();
            caliperTool.Dock = DockStyle.Fill;
            m_toolsList.Add(new ToolsClass(caliperTool));
        }

        private void histogramToolMenuItem_Click(object sender, EventArgs e)
        {
            m_treeViewTools.Nodes.Add("CogHistogramTool" + (++m_intCntHistogram).ToString());
            HistogramToolControl histogramTool = new HistogramToolControl();
            histogramTool.Dock = DockStyle.Fill;
            m_toolsList.Add(new ToolsClass(histogramTool));
        }

        private void m_treeViewTools_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {   
            if(e.Button == MouseButtons.Right) {
                TreeView m_treeView = (TreeView)sender;
                DialogResult m_deleteSelection = MessageBox.Show("Are u sure want to delete "+ m_treeView.SelectedNode.Text+"?","",MessageBoxButtons.YesNo);
                if (m_deleteSelection == DialogResult.Yes)
                {
                    m_toolsList.RemoveAt(m_treeView.SelectedNode.Index);
                    m_treeView.Nodes.Remove(m_treeView.SelectedNode);
                }
            }
        }
        /*
        private void ROI_Paint(object sender, PaintEventArgs e)
        {
            if(m_display.Controls.Count <= 0)
                return;
            e.Graphics.ExcludeClip(m_display.Controls[0].Bounds);
            using (var b = new SolidBrush(Color.FromArgb(100, Color.Black)))
                e.Graphics.FillRectangle(b, m_display.ClientRectangle);
            
        }*/
    }
}
