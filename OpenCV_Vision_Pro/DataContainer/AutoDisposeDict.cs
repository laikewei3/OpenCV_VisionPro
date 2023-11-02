using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCV_Vision_Pro
{
    public class AutoDisposeDict<TKey, TValue> : Dictionary<TKey, TValue>, IDisposable where TValue : IDisposable
    {
        public void Dispose()
        {
            if (this != null)
            {
                foreach (var obj in this)
                {
                    if (obj.Value != null) obj.Value.Dispose();
                }
            }
        }

        public AutoDisposeDict<TKey, TValue> CloneDictionaryCloningValues()
        {
            AutoDisposeDict<TKey, TValue> ret = new AutoDisposeDict<TKey, TValue>();

            foreach (KeyValuePair<TKey, TValue> entry in this)
            {
                if (entry.Value is Mat)
                {
                    Mat mat = entry.Value as Mat;
                    ret.Add(entry.Key, (TValue)(object)mat.Clone());
                }
            }

            return ret;

        }
    }
}
