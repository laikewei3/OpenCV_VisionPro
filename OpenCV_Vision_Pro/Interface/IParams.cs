using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCV_Vision_Pro.Interface
{
    public interface IParams
    {
        ROI m_roi { get; set; }
        bool m_boolHasROI { get; set; }
    }
}
