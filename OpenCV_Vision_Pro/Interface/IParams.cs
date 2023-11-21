namespace OpenCV_Vision_Pro.Interface
{
    public abstract class IParams
    {
        public ROI m_roi { get; set; } = new ROI();
        public bool m_boolHasROI { get; set; } = false;
    }
}
