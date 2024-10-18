using System.Collections;

namespace Cspro.Collection.Interfaces
{
    public interface IQueue
    {
        int Count { get; }
        void Enqueue(int item);
        object Dequeue();
        void Clear();
        bool Contains(object item);
        object Peek();
        object[] ToArray();
    }
}
