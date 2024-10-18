using System.Runtime.CompilerServices;

namespace Cspro.Collection
{
    public class List
    {
        private const int _defaultCapacity = 8;
        private object?[] _array;

        public int Count { get; private set; } = 0;
        public int Capacity => _array.Length;

        public List() 
            : this(_defaultCapacity)
        {}

        public List(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException();
            else if (capacity == 0)
                _array = [];
            else
                _array = new object[capacity];
        }

        public object? this[int index]
        {
            get
            {
                if (index < Count)
                    return _array[index];
                else
                    throw new ArgumentOutOfRangeException(nameof(index));
            }
            set
            {
                if (index < Count)
                    _array[index] = value;
                else
                    throw new ArgumentOutOfRangeException(nameof(index));
            }
        }

        public void CopyFrom(object?[] array, int index)
        {
            for (int i = index; i < Count; i++)
            {
                _array[i] = array[i];
            }
        }

        private void Grow()
        {
            if (Count + 1 >= Capacity)
            {
                object?[] array = _array;
                _array = new object[_array.Length * 2];
                CopyFrom(array, 0);
            }
        }

        public int IndexOf(object? value)
        {
            for (int i = 0; i < Count; i++)
            {
                if (Equals(_array[i], value))
                    return i;
            }
            return -1;
        }

        public void Add(object? value)
        {
            Grow();

            _array[Count] = value;
            Count++;
        }

        public void Insert(int index, object? value)
        {
            if (index < 0 || index > Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            Grow();

            for (int i = Count - 1; i >= index; i--)
            {
                var currentItem = _array[i];
                _array[i + 1] = currentItem;
            }

            _array[index] = value;
            Count++;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index > Count - 1)
            {
                throw new ArgumentOutOfRangeException();
            }

            for (int i = index; i < Count - 1; i++)
            {
                var nextItem = _array[i + 1];
                _array[i] = nextItem;
            }

            _array[--Count] = default;
        }

        public void Remove(object? value)
        {
            int index = IndexOf(value);

            if (index != -1) 
                RemoveAt(index);
        }


        public void Clear()
        {
            for (int i = 0; i < Count; i++) 
                _array[i] = default;
            Count = 0;
        }

        public bool Contains(object? value) => IndexOf(value) != -1;

        public object?[] ToArray()
        {
            if (Count == 0) 
                return Array.Empty<object?>();

            object?[] array = new object?[Count];

            for (int i = 0; i < array.Length; i++)
                array[i] = _array[i];

            return array;
        }

        public void Reverse()
        {
            object? first, last;
            for (int i = 0; i < Count / 2; i++)
            {
                first = _array[i];
                last = _array[Count - i - 1];
                _array[i] = last;
                _array[Count - i - 1] = first;
            }
        }
    }
}
