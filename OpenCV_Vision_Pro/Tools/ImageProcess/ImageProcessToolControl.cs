using OpenCV_Vision_Pro.Interface;
using OpenCV_Vision_Pro.Tools.ImageProcess.ProcessTool;
using System;
using System.Windows.Forms;

namespace OpenCV_Vision_Pro
{
    public partial class ImageProcessToolControl : UserControl,IUserDataControl
    {
        public DataGridView resultDataGrid { get; set; }

        public ROI m_roi { get { return ProcessParams.m_roi; } }

        public IParams parameter { get; set; }

        public ProcessParams ProcessParams { get; private set; }

        public ImageProcessToolControl(IParams ProcessParams)
        {
            InitializeComponent(); 
            parameter = ProcessParams;
            this.ProcessParams = (ProcessParams)parameter;
            this.ProcessParams.m_roi.Dock = DockStyle.Top;
            this.Controls.Add(ProcessParams.m_roi);
            m_cbProcessMode.SelectedIndex = -1;
        }

        public void SetDataSource(object bs) {
            m_ProcessTable.DataSource = bs;
            m_ProcessTable.Columns[1].Visible = false;
            m_ProcessTable.Columns[0].HeaderText = "Operator";
            m_ProcessTable.Columns[0].Width = m_ProcessTable.Width - 5;
        }

        private void ImageProcessToolControl_Load(object sender, EventArgs e)
        {
            if (parameter.m_boolHasROI)
            {
                if (parameter.m_roi.points != null)
                    parameter.m_roi.m_comboBoxROI.SelectedIndex = 2;
                else
                    parameter.m_roi.m_comboBoxROI.SelectedIndex = 1;
            }
        }

        private void m_cbProcessMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            string m_strSelectedProcess = m_cbProcessMode.SelectedItem?.ToString();
            if (m_strSelectedProcess == null)
                return;
            
            IBaseTool tool = null;
            switch (m_strSelectedProcess)
            {
                case "Rotate / Flip":
                    tool = new RotateFlipTool();
                    ((RotateFlipTool)tool).parameter = new RotateFlipParams();
                    break;
                case "Equalise(Fixed)":
                case "Equalise(Adaptive)":
                    tool = new ImageSharpenerTool("");
                    ((ImageSharpenerTool)tool).parameter = new SharpenerParams();
                    ((SharpenerParams)((ImageSharpenerTool)tool).parameter).runMode = m_strSelectedProcess;
                    break;
                case "Arithmetic":
                    tool = new ArithmeticTool();
                    ((ArithmeticTool)tool).parameter = new ArithmeticParams();
                    break;
                case "Resize":
                    tool = new SuperResolutionTool();
                    ((SuperResolutionTool)tool).parameter = new SuperResolutionParams();
                    break;
                default:
                    MessageBox.Show("Process Error");
                    break;
            }
            if(tool != null)
            {
                ProcessParams.toolProcessList.Add(new ProcessToolList(m_strSelectedProcess,tool));
            }
        }

        private void m_ProcessTable_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selectedRow = m_ProcessTable.SelectedRows;
            if (selectedRow == null || selectedRow?.Count <= 0)
                return;

            Control control = tableLayoutPanel6.GetControlFromPosition(0, 2);
            if (control != null)
                control.Dispose();
            tableLayoutPanel6.Controls.Remove(control);
            IBaseTool tool = ProcessParams.toolProcessList[selectedRow[0].Index].toolProcess;
            if (tool is ImageSharpenerTool)
                return;
            tool.getGUI();
            tableLayoutPanel6.Controls.Add((Control)tool.m_toolControl);
            tableLayoutPanel6.SetRow(tableLayoutPanel6.Controls[tableLayoutPanel6.Controls.Count - 1], 2);
        }

        private void m_btnDeleteProcess_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selectedRow = m_ProcessTable.SelectedRows;
            if (selectedRow == null || selectedRow?.Count <= 0)
                return;
            for(int i = selectedRow.Count-1; i >= 0; i--)
            {
                DataGridViewRow row = selectedRow[i];
                ProcessParams.toolProcessList[row.Index].Dispose();
                ProcessParams.toolProcessList.RemoveAt(row.Index);
            }
        }

        private void m_ProcessTable_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            m_ProcessTable.Columns[0].ReadOnly = true;
        }
    }
}
