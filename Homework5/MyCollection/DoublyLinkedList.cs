using Cspro.Collection.Interfaces;

namespace Cspro.Collection;

public class DoublyLinkedListNode : LinkedListNode, IDoublyLinkedListNode
{

    public ILinkedListNode? Prev { get; set; }

    public DoublyLinkedListNode(object value)
      : base(value)
    {
    }

    public DoublyLinkedListNode(object value, ILinkedListNode? prev, ILinkedListNode? next) : base(value, next)
    {
        this.Prev = prev;
    }
}

public class DoublyLinkedList : LinkedList
{
    public new ILinkedListNode? Last { get; private set; }

    public override void Clear()
    {
        Last = null;
        base.Clear();
    }

    protected override ILinkedListNode CreateNode(object value, ILinkedListNode? prev = null, ILinkedListNode? next = null)
      => new DoublyLinkedListNode(value, prev, next);

    protected override void RemoveNodeInternal(ILinkedListNode removeNode, ILinkedListNode prevNode)
    {

        base.RemoveNodeInternal(removeNode, prevNode);
        var nextNode = (DoublyLinkedListNode?)removeNode.Next;
        if (prevNode == null && nextNode != null)
            nextNode.Prev = null;

        if (nextNode == null)
        {
            Last = prevNode;
            if (prevNode != null)
                prevNode.Next = null;
        }
        else
            nextNode.Prev = prevNode;
    }

    protected override ILinkedListNode AddInternal(object value, ILinkedListNode prev, ILinkedListNode next)
    {

        var newNode = base.AddInternal(value, prev, next);
        if (next != null)
            ((DoublyLinkedListNode)next).Prev = newNode;
        else
            Last = newNode;
        return newNode;
    }

    public override void AddLast(object value)
    {
        Last = AddInternal(value, Last, null);

        if (First == null)
            First = Last;
    }

}
