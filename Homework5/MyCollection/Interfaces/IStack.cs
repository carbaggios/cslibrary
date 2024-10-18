using System.Collections;

namespace Cspro.Collection.Interfaces
{
    public interface IStack
    {
        void Push(object item);
        object Peek();
        object Pop();
        object[] ToArray();
        void Clear();
        bool Contains(object item);
    }
}
