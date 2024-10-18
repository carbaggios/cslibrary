namespace Cspro.Collection;

public class DoublyLinkedListNode : LinkedListNode
{

    public LinkedListNode? Prev { get; set; }

    public DoublyLinkedListNode(object value)
      : base(value)
    {
    }

    public DoublyLinkedListNode(object value, LinkedListNode? prev, LinkedListNode? next) : base(value, next)
    {
        this.Prev = prev;
    }
}

public class DoublyLinkedList : LinkedList
{
    public new LinkedListNode? Last { get; private set; }

    public override void Clear()
    {
        Last = null;
        base.Clear();
    }

    protected override LinkedListNode CreateNode(object value, LinkedListNode? prev = null, LinkedListNode? next = null)
      => new DoublyLinkedListNode(value, prev, next);

    protected override void RemoveNodeInternal(LinkedListNode removeNode, LinkedListNode prevNode)
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

    protected override LinkedListNode AddInternal(object value, LinkedListNode prev, LinkedListNode next)
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
