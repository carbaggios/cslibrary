using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cspro.Collection.Interfaces
{
    public interface IDoublyLinkedListNode : ILinkedListNode
    {
        ILinkedListNode Next { get; set; }
        object Value { get; }
    }
}
