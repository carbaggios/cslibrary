using Cspro.Collection.Interfaces;

namespace Cspro.Collection;
public class Queue : IQueue, ICollection
{
    private const int DefCapacity = 8;

    private object[] _items;
    private int _lead;
    private int _tail;
    private int _count;

    public int Count
    {
        get { return _count; }
    }

    public System.Collections.IEnumerator GetEnumerator() => _items.GetEnumerator();

    public Queue()
        : this(DefCapacity)
    { }

    public Queue(int capacity)
    {
        _items = new object[capacity];
        _lead = _tail = _count = 0;
        
    }

    public void Enqueue(int item)
    {
        EnsureCapacity(_count + 1);

        _items[_tail] = item;
        _tail = (_tail + 1) % _items.Length;

        _count++;
    }

    public object Dequeue()
    {
        if (_count == 0)
        {
            throw new ArgumentNullException(nameof(_count));
        }

        object item = _items[_lead];
        _items[_lead] = default;
        _lead = (_lead + 1) % _items.Length;
        _count--;

        return item;
    }

    public void Clear()
    {
        for (int i = 0; i < _items.Length; i++)
        {
            _items[i] = default(object);
        }

        _lead = 0;
        _tail = 0;
        _count = 0;
    }

    public bool Contains(object item)
    {
        for (int i = 0; i < _count; i++)
        {
            if (_items[(_lead + i) % _items.Length].Equals(item))
                return true;
        }
        return false;
    }

    public object Peek()
    {
        if (_count == 0)
            throw new ArgumentNullException(nameof(_count));

        return _items[_lead];
    }

    public object[] ToArray()
    {
        object[] arr = new object[_count];

        for (int i = 0; i < _count; i++)
        {
            arr[i] = _items[(_lead + i) % _items.Length];
        }

        return arr;
    }

    private void EnsureCapacity(int capacity)
    {
        if (_items.Length < capacity)
        {
            int newCapacity = _items.Length == 0 ? 4 : _items.Length * 2;
            object[] newItems = new object[newCapacity];
            
            for (int i = 0; i < _count; i++)
            {
                newItems[i] = _items[(_lead + i) % _items.Length];
            }

            _items = newItems;
            _lead = 0;
            _tail = _count;
        }
    }
}
