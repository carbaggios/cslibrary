using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cspro.Collection.Interfaces
{
    public interface ICollection : System.Collections.IEnumerable
    {
        int Count { get; }
        object[] ToArray();
        void Clear();
        bool Contains(object value);
    }
}
