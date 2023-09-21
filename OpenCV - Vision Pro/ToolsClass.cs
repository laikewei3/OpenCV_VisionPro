﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCV_Vision_Pro
{
    public class ToolsClass: IDisposable
    {
        public enum EType { BlobToolControl, CaliperToolControl, HistogramToolControl };
        public EType TypeFilled { get; set; }
        public List<Dictionary<string, Bitmap>> m_bitmapList { get; set; }

        BlobToolControl m_BlobToolControl;
        CaliperToolControl m_CaliperToolControl;
        HistogramToolControl m_HistogramToolControl;
        
        public BlobToolControl BlobToolControl
        {
            get { return m_BlobToolControl; }
            set { m_BlobToolControl = value; TypeFilled = EType.BlobToolControl; }
        }

        public CaliperToolControl CaliperToolControl
        {
            get { return m_CaliperToolControl; }
            set { m_CaliperToolControl = value; TypeFilled = EType.CaliperToolControl; }
        }

        public HistogramToolControl HistogramToolControl
        {
            get { return m_HistogramToolControl; }
            set { m_HistogramToolControl = value; TypeFilled = EType.HistogramToolControl; }
        }


        public ToolsClass(BlobToolControl b) {
            BlobToolControl = b;
        }
        public ToolsClass(CaliperToolControl c) {
            CaliperToolControl = c;
        }
        public ToolsClass(HistogramToolControl h) {
            HistogramToolControl = h;
        }

        public void Dispose()
        {
            if (m_BlobToolControl != null)
            {
                m_BlobToolControl.Dispose();
            }else if (m_CaliperToolControl != null)
            {
                m_CaliperToolControl.Dispose();
            }else if (m_HistogramToolControl != null)
            {
                m_HistogramToolControl.Dispose();
            }
        }



    }
}