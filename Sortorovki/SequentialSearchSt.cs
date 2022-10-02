using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortorovki
{
  public class SequentialSearchSt<TKey,TValue> //символьные таблицы на линейном поиске 
    {
        private class Node
        {
            public Node(TKey key, TValue value, Node next)
            {
                Key = key;
                Value = value;
                Next = next;
            }

            public TKey Key { get; }
            public TValue Value { get; set; }   
            public Node Next { get; set; }
        }

        private Node _first;
        private readonly EqualityComparer<TKey> _comparer;
        public int Count { get; private set; }

        public SequentialSearchSt()
        {
            _comparer = EqualityComparer<TKey>.Default; //дефалтовый механизм сравнения
        }

        public SequentialSearchSt(EqualityComparer<TKey> comparer)
        {
            _comparer = comparer ?? throw new ArgumentNullException();
        }

       public bool TryGet(TKey key, out TValue val) //out- инициализация этого параметра будет в методе
        {
            for (Node x = _first; x !=null; x = x.Next)
            {
                if (_comparer.Equals(key,x.Key))
                {
                    val = x.Value;
                    return true;
                }
            }
            val = default(TValue);
            return false;
        }

        public void Add(TKey key, TValue val)
        {
            if (key==null)
            {
                throw new ArgumentException("Key can`t be null");
            }
            for (Node x = _first; x != null; x = x.Next)
            {
                if (_comparer.Equals(key, x.Key))
                {
                    val = x.Value;
                    return;
                }
            }
            _first = new Node(key,val,_first);
            Count++;
        }

        public bool Contains(TKey key)
        {
            for (Node x = _first; x != null; x = x.Next)
            {
                if (_comparer.Equals(key, x.Key))
                {
                    return true;
                }
            }
            return false;
        }

        public IEnumerable<TKey> Keys() //возвращение набор ключей в таблице
        {
            for (Node x = _first; x != null; x = x.Next)
            {
                  yield  return x.Key;
            }
        }
        public bool Remove(TKey key)
        {
            if (key == null)
            {
                throw new ArgumentException("Key can`t be null");
            }
            if (Count==1 && _comparer.Equals(_first.Key, key)) //если в цепочке только один узел и он должен быть удален
            {
                _first = null;
                Count--;
            return true;
            }
            Node prev = null;
            Node current = _first;
            while (current != null)
            {
                if (_comparer.Equals( current.Key, key))
                {
                    if (prev == null) //если удаляемый узел первый
                    {
                        _first = current.Next;
                    }
                    else
                    {
                        prev.Next = current.Next;
                    }
                    Count--;
                    return true;
                }
                prev = current; //сдвиг узла
                current = current.Next; 
            }
            return false;
        }

    }
}
