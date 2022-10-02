using System.Collections;

namespace ClassLibrary1
{
    internal class ArrayStack<T> : IEnumerable<T>   
    {
        private T[] _items;

        public ArrayStack()
        {
            const int defaultCpacity = 4;
            _items = new T[defaultCpacity];

        }
        public ArrayStack(int capacity)
        {
            _items = new T[capacity];
        }

        public bool IsEmpty => Count == 0;
        public int Count { get; private set; }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = Count; i >=0; i--)
            {
                yield return _items[i];
            }
        }

        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException();
            return _items[Count - 1];   
        }

        public void Pop()
        {
            if (IsEmpty)
                throw new InvalidOperationException();
            _items[--Count] = default(T);
        }

        public void Push(T item)
        {
            if (_items.Length==Count)
            {
                T[] largerArray = new T[Count * 2];
                Array.Copy(_items, largerArray, Count);
                _items = largerArray;   
            }
            _items[Count++] = item; 
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}