using OpenCV_Vision_Pro.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenCV_Vision_Pro
{
    public abstract class UserControlBase : UserControl
    {
        public abstract DataGridView resultDataGrid { get; set; }
        public abstract ROI m_roi { get; set; }
        public abstract IParams parameter { get; set; }

        public void SetDataSource(BindingSource bs)
        {
            resultDataGrid.DataSource = bs;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // UserControlBase
            // 
            this.Name = "UserControlBase";
            this.Size = new System.Drawing.Size(34, 23);
            this.ResumeLayout(false);

        }
    }
}
