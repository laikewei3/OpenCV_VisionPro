using Emgu.CV.CvEnum;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using OpenCV_Vision_Pro.Tools.ImageSegmentor;
using Shared.ComponentModel.SortableBindingList;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenCV_Vision_Pro
{
    public partial class ColorTools : UserControl
    {
        private SortableBindingList<ColorData> colorDatas;
        private BindingSource bs;
        private bool addRect;
        private bool addPoint;

        public Rectangle colorRect;
        public bool addColorRect
        {
            get { return addRect; }
            set
            {
                addRect = value;
                if (addRect)
                {
                    m_btnAddColor.Visible = true;
                    m_btnCancelAdd.Visible = true;
                }
                else
                {
                    m_btnAddColor.Visible = false;
                    m_btnCancelAdd.Visible = false;
                }
            }
        }
        public bool addColorPoint
        {
            get { return addPoint; }
            set
            {
                addPoint = value;
                if (addPoint)
                {
                    m_btnAddColor.Visible = true;
                    m_btnCancelAdd.Visible = true;
                }
                else
                {
                    m_btnAddColor.Visible = false;
                    m_btnCancelAdd.Visible = false;
                }
            }
        }

        public ColorTools(SortableBindingList<ColorData> colorDatas)
        {
            InitializeComponent();
            this.colorDatas = colorDatas;
            bs = new BindingSource() { DataSource = colorDatas };
            m_ColorTable.DataSource = bs;
            colorRect = new Rectangle(0, 0, 50, 50);
            addColorRect = false;
            addColorPoint = false;
        }

        private void addPointToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addColorPoint = true;
            colorRect.Size = new Size(5, 5);
        }

        private void addRegionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addColorRect = true; 
            colorRect.Size = new Size(50, 50);
        }

        private void m_btnDeleteProperties_Click(object sender, EventArgs e)
        {
            if (m_ColorTable.SelectedRows.Count <= 0)
                return;

            if (m_ColorTable.SelectedRows[0].Index < colorDatas.Count)
            {
                colorDatas.RemoveAt(m_ColorTable.SelectedRows[0].Index);
            }
        }

        private void m_btnSelectColor_Click(object sender, EventArgs e)
        {
            m_selectColorMenuStrip.Show(m_btnSelectColor, new Point(0, m_btnSelectColor.Height)); m_ColorTable.ClearSelection();
        }

        private void m_ColorTable_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Check if this is the cell for the ColorCode column
            if (e.ColumnIndex == m_ColorTable.Columns["ColorCode"].Index && e.RowIndex >= 0)
            {
                DataGridViewCell cell = m_ColorTable.Rows[e.RowIndex].Cells[e.ColumnIndex];

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

        private int index = -1;
        private void m_ColorTable_SelectionChanged(object sender, EventArgs e)
        {
            if(index >= 0 && index < m_ColorTable.RowCount)
            {
                colorDatas[index].ColorCode = new MCvScalar((int)m_nudBlue.Value, (int)m_nudGreen.Value, (int)m_nudRed.Value);
            }

            if (m_ColorTable.SelectedRows.Count <= 0)
            {
                m_colorSample.BackColor = Color.Black;
                m_strColorName.Text = "";
            }
            else
            {
                if (m_ColorTable.RowCount == 1)
                    index = -1;
                else
                    index = m_ColorTable.SelectedRows[0].Index;
                m_strColorName.Text = m_ColorTable.SelectedRows[0].Cells["ColorName"].Value.ToString();
                Color color = m_ColorTable.SelectedRows[0].Cells["ColorCode"].Style.BackColor;
                m_nudRed.Value = color.R;
                m_nudGreen.Value = color.G;
                m_nudBlue.Value = color.B;
            }
        }

        private void m_nud_ValueChanged(object sender, EventArgs e)
        {
            m_colorSample.BackColor = Color.FromArgb((int)m_nudRed.Value, (int)m_nudGreen.Value, (int)m_nudBlue.Value);
        }

        private void m_strColorName_TextChanged(object sender, EventArgs e)
        {
            if (m_ColorTable.SelectedRows.Count <= 0)
                return;
            if (m_ColorTable.SelectedRows[0].Index < colorDatas.Count)
                colorDatas[m_ColorTable.SelectedRows[0].Index].ColorName = m_strColorName.Text;
        }

        private void ColorTools_Load(object sender, EventArgs e)
        {
            m_ColorTable.ClearSelection();
            m_colorSample.BackColor = Color.Black;
        }

        public List<MCvScalar> colorPalette { get; set; }
        private void m_btnAddColor_Click(object sender, EventArgs e)
        {
            if (m_strColorName.Text == "")
            {
                MessageBox.Show("Name Cannot be Empty");
                return;
            }
            addColorRect = false;
            addColorPoint = false;
            if (this.Parent is ColorExtractorToolControl)
                colorDatas.Add(new ColorData(m_strColorName.Text, colorPalette));
            else
                colorDatas.Add(new ColorData(m_strColorName.Text, m_cbColorSpace.Text, new MCvScalar((int)m_nudBlue.Value, (int)m_nudGreen.Value, (int)m_nudRed.Value)));
        }

        private void m_btnCancelAdd_Click(object sender, EventArgs e)
        {
            addColorRect = false;
            addColorPoint = false;
        }

        private void m_ColorTable_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            DataGridViewColumn newColumn = e.Column;
           
            if (this.Parent is ColorExtractorToolControl)
            {
                if ((String.Compare(newColumn.Name, "ColorCode") == 0 || String.Compare(newColumn.Name, "Space") == 0) || String.Compare(newColumn.Name, "Score") == 0)
                    newColumn.Visible = false;
                else
                    newColumn.Visible = true;
            }
            else
            {
                if (String.Compare(newColumn.Name, "Score") == 0)
                    newColumn.Visible = false;
                else
                    newColumn.Visible = true;
            }
        }

        private void m_ColorTable_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            m_ColorTable.ClearSelection();
            index = -1;
        }
    }

    public class ColorData
    {
        public ColorData(string colorName, string space, MCvScalar colorCode)
        {
            this.ColorName = colorName;
            this.Space = space;
            this.ColorCode = colorCode;
        }

        public ColorData(string colorName, List<MCvScalar> colorPalette)
        {
            this.ColorName = colorName;
            this.colorPalette = colorPalette;
        }

        public string ColorName { get; set; }
        public string Space { get; set; }
        public MCvScalar ColorCode { get; set; }
        public List<MCvScalar> colorPalette { get; set; }
        public double Score { get; set; }

    }
}
