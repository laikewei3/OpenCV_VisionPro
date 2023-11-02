using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCV_Vision_Pro
{
    public class AutoDisposeList<T> : List<T>, IDisposable where T : IDisposable
    {
        public AutoDisposeList() { }
        public AutoDisposeList(IEnumerable<T> items) {
            foreach (var obj in items)
            {
                this.Add(obj);
                obj?.Dispose();
            }
        }
        public void Dispose()
        {
            if(this != null)
            {
                foreach (var obj in this)
                {
                    if(obj != null)
                    {
                        obj.Dispose();
                    }
                }
            }
        }

        public AutoDisposeList<T> Clone()
        {
            AutoDisposeList<T> clone = new AutoDisposeList<T>();
            foreach(var obj in this)
            {
                if (obj is Mat mat)
                {
                    if(mat != null)
                        clone.Add((T)(object)mat.Clone());
                }
            }
            return clone;
        }
    }
}
