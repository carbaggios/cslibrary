using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cspro.Collection.Interfaces
{
    public interface ILinkedList : ICollection
    {
        void AddFirst(object value);
        void AddLast(object value);
        ILinkedListNode Insert(ILinkedListNode node, object value);
    }
}
