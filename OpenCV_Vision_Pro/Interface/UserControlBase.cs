using OpenCV_Vision_Pro.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenCV_Vision_Pro
{
    public interface UserControlBase : IDisposable
    {
        DataGridView resultDataGrid { get; set; }
        ROI m_roi { get; }
        IParams parameter { get; set; }
        void SetDataSource(object bs);
    }

    public interface ColorUserControlBase : UserControlBase
    {
        ColorTools m_colorTools { get; set; }
    }

}
