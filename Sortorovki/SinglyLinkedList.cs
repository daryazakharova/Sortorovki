using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortorovki
{
    public class SinglyLinkedList<T> : IEnumerable<T>
    {
        //односвязные списки
        public Node<T> Head { get; private set; }
        public Node<T> Tail { get; private set; }  
        public int Count { get; private set; }
        public bool IsEmpty => Count == 0;
        public void AddFirst(T value)
        {
            AddFfirst(new Node<T>(value));
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        private void AddFfirst(Node<T> node)
        {
            //сохранение текущего Head
            Node<T> tmp = Head;
            Head = node;
            // сдвиг головной ноды
            Head.Next = tmp; 
            Count ++;
            if (Count==1)
            {
                Tail = Head;
            }
        }

        public void AddLast(T value)
        {
            AddLast(new Node<T>(value));
        }
        private void AddLast(Node<T> node)
        {
            if (IsEmpty)
                Head = node;
            else
                Tail.Next = node;

            Tail = node;
            Count++;
        }
        public void RemoveFirst()
        {
            if (IsEmpty)
                throw new InvalidOperationException();
            Head = Head.Next;
            if (Count==1)
            {
                Tail = null;
            }
            Count--;
        }
        public void RemoveLast()//линейная временная сложность
        {
            if (IsEmpty)
                throw new InvalidOperationException();
            if (Count == 1)
            {
               Head = Tail = null;
            }
            else
            {
                var current = Head;
                while (current.Next != Tail)
                {
                    current = current.Next;
                }
                current.Next = null;
                Tail = current;
            }
            Count--;
        }

      

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
