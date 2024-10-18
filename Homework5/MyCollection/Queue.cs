using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cspro.Collection;
public class Queue
{
    private const int DefCapacity = 8;

    private int[] _items;
    private int _lead;
    private int _tail;
    private int _count;

    public Queue()
        : this(DefCapacity)
    { }

    public Queue(int capacity)
    {
        _items = new int[capacity];
        _lead = _tail = _count = 0;
        
    }

    public void Enqueue(int item)
    {
        EnsureCapacity(_count + 1);

        _items[_tail] = item;
        _tail = (_tail + 1) % _items.Length;

        _count++;
    }

    public int Dequeue()
    {
        if (_count == 0)
        {
            throw new ArgumentNullException(nameof(_count));
        }

        int item = _items[_lead];
        _items[_lead] = default;
        _lead = (_lead + 1) % _items.Length;
        _count--;

        return item;
    }

    public int Count
    {
        get { return _count; }
    }

    public void Clear()
    {
        for (int i = 0; i < _items.Length; i++)
        {
            _items[i] = default(int);
        }

        _lead = 0;
        _tail = 0;
        _count = 0;
    }

    public bool Contains(int item)
    {
        for (int i = 0; i < _count; i++)
        {
            if (_items[(_lead + i) % _items.Length].Equals(item))
                return true;
        }
        return false;
    }

    public int Peek()
    {
        if (_count == 0)
            throw new ArgumentNullException(nameof(_count));

        return _items[_lead];
    }

    public int[] ToArray()
    {
        int[] arr = new int[_count];

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
            int[] newItems = new int[newCapacity];
            
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
