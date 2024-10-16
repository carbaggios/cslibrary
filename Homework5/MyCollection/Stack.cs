using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Cspro.Collection;

public class Stack
{
    private const int DefCapacity = 8;
    private int[] _items;
    private int _count;

    public Stack() 
        : this(DefCapacity)
    {
    }

    public Stack(int capacity)
    {
        _items = new int[capacity];
        _count = 0;
    }

    public int Count
    {
        get { return _count; }
    }

    public void Push(int item)
    {
        EnsureCapacity(_count + 1);
        _items[_count] = item;
        _count++;
    }

    private void EnsureCapacity(int capacity)
    {
        if (_items.Length < capacity)
        {
            int newCapacity = _items.Length == 0 ? DefCapacity : _items.Length * 2;
            int[] newItems = new int[newCapacity];

            for (int i = 0; i < _count; i++)
            {
                newItems[i] = _items[i];
            }

            _items = newItems;
        }
    }

    public int Peek()
    {
        if (_count == 0)
            throw new ArgumentNullException(nameof(_count));

        return _items[_count - 1];
    }

    public int Pop()
    {
        if (_count == 0)
            throw new ArgumentNullException(nameof(_count));

        int item = _items[_count - 1];
        _items[_count - 1] = default;
        _count--;

        return item;
    }

    public int[] ToArray()
    {
        int[] arr = new int[_count];

        for (int i = 0; i < _count; i++)
        {
            arr[i] = _items[i];
        }
        return arr;
    }

    public void Clear()
    {
        for (int i = 0; i < _items.Length; i++)
        {
            _items[i] = default;
        }
        _count = 0;
    }

    public bool Contains(int item)
    {
        for (int i = 0; i < _count; i++)
        {
            if (_items[i].Equals(item))
                return true;
        }
        return false;
    }
}
