using OpenCV_Vision_Pro.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenCV_Vision_Pro
{/*
    public abstract class UserControlBase : UserControl
    {
        public abstract DataGridView resultDataGrid { get; set; }
        public abstract ROI m_roi { get; }
        public abstract IParams parameter { get; set; }

        public void SetDataSource(object bs)
        {
            resultDataGrid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            resultDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            resultDataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            if (String.Compare(this.GetType().Name, "HistogramToolControl") == 0)
            {
                HistogramToolControl m_histToolControl = (HistogramToolControl)this;
                resultDataGrid.DataSource = ((ArrayList)bs)[0];

                HistogramResult m_histogramResult = (HistogramResult)((ArrayList)bs)[1];
                if (m_histogramResult != null)
                {
                    m_histToolControl.m_tbMin.Text = m_histogramResult.Minimum.ToString();
                    m_histToolControl.m_tbMax.Text = m_histogramResult.Maximum.ToString();
                    m_histToolControl.m_tbMean.Text = m_histogramResult.Mean.ToString();
                    m_histToolControl.m_tbMedian.Text = m_histogramResult.Median.ToString();
                    m_histToolControl.m_tbMode.Text = m_histogramResult.Mode.ToString();
                    m_histToolControl.m_tbSample.Text = m_histogramResult.NumberOfSample.ToString();
                    m_histToolControl.m_tbSD.Text = m_histogramResult.StandardDeviation.ToString();
                    m_histToolControl.m_tbVariance.Text = m_histogramResult.Variance.ToString();
                }
            }
            else
                resultDataGrid.DataSource = bs;
        }
    }
    */
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
