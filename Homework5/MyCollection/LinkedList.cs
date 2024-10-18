using Cspro.Collection.Interfaces;

namespace Cspro.Collection;

public class LinkedListNode : ILinkedListNode
{
    public object Value { get; }
    public ILinkedListNode? Next { get; set; }

    public LinkedListNode(object value)
    {
        Value = value;
        Next = null;
    }

    public LinkedListNode(object value, ILinkedListNode next)
    {
        Value = value;
        Next = next;
    }
}

public class LinkedList : ILinkedList
{
    public ILinkedListNode? First { get; protected set; }
    public ILinkedListNode? Last { get; protected set; }
    public int Count { get; protected set; }

    protected virtual ILinkedListNode CreateNode(object value, ILinkedListNode prev, ILinkedListNode next) => new LinkedListNode(value, next);

    protected virtual ILinkedListNode AddInternal(object value, ILinkedListNode prev, ILinkedListNode next)
    {
        var node = CreateNode(value, prev, next);
        
        if (prev != null)
            prev.Next = node;

        Count++;

        return node;
    }

    public System.Collections.IEnumerator GetEnumerator() => new LinkedListEnumerator(First);

    protected virtual void RemoveNodeInternal(ILinkedListNode removeNode, ILinkedListNode prevNode)
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

    public ILinkedListNode Insert(ILinkedListNode node, object value) =>
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

    private class LinkedListEnumerator : System.Collections.IEnumerator
    {

        private readonly ILinkedListNode first;
        private ILinkedListNode current;

        public LinkedListEnumerator(ILinkedListNode node) => first = node;

        public object Current => current.Value;

        public bool MoveNext()
        {
            current = current == null ? first : current.Next;
            return current != null;
        }

        public void Reset() => current = first;
    }
}

