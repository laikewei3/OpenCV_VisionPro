using Emgu.CV.Structure;
using OpenCV_Vision_Pro.Interface;
using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace OpenCV_Vision_Pro.Tools.ColorMatcher
{
    public partial class ColorMatchToolControl : UserControl, IColorUserControlBase
    {
        public DataGridView resultDataGrid { get; set; }
        public ROI m_roi { get { return ColorMatcherParams.m_roi; } }
        public IParams parameter { get; set; }
        public ColorMatcherParams ColorMatcherParams { get; set; }
        public ColorTools m_colorTools { get; set; }

        public ColorMatchToolControl(IParams parameter)
        {
            InitializeComponent();
            resultDataGrid = m_MatcherResult;
            this.parameter = parameter;
            ColorMatcherParams = (ColorMatcherParams)parameter;
            m_colorTools = new ColorTools(ColorMatcherParams.colorDatas) { Dock = DockStyle.Top };
            m_MatcherInput.Controls.Add(m_colorTools);
            ColorMatcherParams.m_roi.Dock = DockStyle.Top;
            m_MatcherInput.Controls.Add(ColorMatcherParams.m_roi);
        }

        public void SetDataSource(object bs)
        {
            ArrayList array = (ArrayList)bs;
            resultDataGrid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            resultDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            resultDataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            if(array.Count > 0 )
            {
                resultDataGrid.DataSource = (BindingSource)array[0];

                ColorData bestMatch = (ColorData)array[1];
                m_bestColorName.Text = bestMatch.ColorName;
                m_bestColorScore.Text = bestMatch.Score.ToString();
                m_bestColorConfidence.Text = ((double)array[3]).ToString();

                MCvScalar observedColor = (MCvScalar)array[2];
                m_observedB.Text = observedColor.V0.ToString();
                m_observedG.Text = observedColor.V1.ToString();
                m_observedR.Text = observedColor.V2.ToString();
                m_observedColor.BackColor = Color.FromArgb((int)observedColor.V2, (int)observedColor.V1, (int)observedColor.V0);
            }
        }

        private void m_MatcherResult_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Check if this is the cell for the ColorCode column
            if (e.ColumnIndex == m_MatcherResult.Columns["ColorCode"].Index && e.RowIndex >= 0)
            {
                DataGridViewCell cell = m_MatcherResult.Rows[e.RowIndex].Cells[e.ColumnIndex];

                // Retrieve the ColorCode value from the underlying data source
                if (cell.Value is MCvScalar colorCode)
                {
                    // Create a Color object from the MCvScalar values
                    Color color = Color.FromArgb((int)colorCode.V2, (int)colorCode.V1, (int)colorCode.V0);

                    // Set the cell's value to the color
                    e.Value = color.Name;

                    // Optionally, you can customize the cell style
                    cell.Style.BackColor = color;
                    //cell.Style.ForeColor = Color.White; // You can adjust the text color
                }
            }
        }

        private void m_MatcherResult_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            DataGridViewColumn newColumn = e.Column;
            if (String.Compare(newColumn.Name,"Space")==0)
                newColumn.Visible = false;
            else
                newColumn.Visible = true;
        }

        private void ColorMatchToolControl_Load(object sender, EventArgs e)
        {
            if (parameter.m_boolHasROI)
            {
                if (parameter.m_roi.points != null)
                    parameter.m_roi.m_comboBoxROI.SelectedIndex = 2;
                else
                    parameter.m_roi.m_comboBoxROI.SelectedIndex = 1;
            }
        }
    }
}
