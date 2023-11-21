using OpenCV_Vision_Pro.Interface;
using System;
using System.Windows.Forms;

namespace OpenCV_Vision_Pro
{
    public interface IUserDataControl : IUserControlBase
    {
        DataGridView resultDataGrid { get; set; }
        
        void SetDataSource(object bs);
    }

    public interface IUserControlBase : IDisposable
    {
        ROI m_roi { get; }

        IParams parameter { get; set; }
    }

    public interface IColorUserControlBase : IUserDataControl
    {
        ColorTools m_colorTools { get; set; }
    }

}
