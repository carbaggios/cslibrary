namespace Cspro.Collection;

public class LinkedListNode
{
    public object Value { get; }
    public LinkedListNode? Next { get; set; }

    public LinkedListNode(object value)
    {
        Value = value;
        Next = null;
    }

    public LinkedListNode(object value, LinkedListNode next)
    {
        Value = value;
        Next = next;
    }
}

public class LinkedList
{
    public LinkedListNode? First { get; protected set; }
    public LinkedListNode? Last { get; protected set; }
    public int Count { get; protected set; }

    protected virtual LinkedListNode CreateNode(object value, LinkedListNode prev, LinkedListNode next) => new LinkedListNode(value, next);

    protected virtual LinkedListNode AddInternal(object value, LinkedListNode prev, LinkedListNode next)
    {
        var node = CreateNode(value, prev, next);
        
        if (prev != null)
            prev.Next = node;

        Count++;

        return node;
    }

    protected virtual void RemoveNodeInternal(LinkedListNode removeNode, LinkedListNode prevNode)
    {

        if (removeNode == null)
            throw new ArgumentNullException(nameof(removeNode));

        if (prevNode == null)
            First = removeNode.Next;
        else
            prevNode.Next = removeNode.Next;

        Count--;
    }

    public virtual void AddLast(object value)
    {
        if (First == null)
            AddFirst(value);
        else
        {
            var last = First;
            while (last.Next != null)
                last = last.Next;
            last.Next = AddInternal(value, prev: last, next: null);
        }
    }

    public virtual void Clear()
    {
        First = Last = null;
        Count = 0;
    }

    public void Add(object item)
    {
        var node = new LinkedListNode(item);
        if (First == null)
            First = Last = node;
        else
            Last!.Next = node;
        Last = node;

        Count++;
    }

    public void AddFirst(object value)
    {
        First = AddInternal(value, prev: null, next: First);
    }

    public LinkedListNode Insert(LinkedListNode node, object value) =>
    AddInternal(value, prev: node, next: node.Next!);

    public bool Contains(object data)
    {
        var current = First;

        while (current != null)
        {
            if (current.Value.Equals(data))
                return true;

            current = current.Next;
        }

        return false;
    }

    public object[] ToArray()
    {
        object[] arr = new object[Count];
        var current = First;

        for (int i = 0; i < Count; i++)
        {
            arr[i] = current!.Value;
            current = current.Next;
        }

        return arr;
    }
}

