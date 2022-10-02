using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortorovki
{
    public class DoublyLinkedList<T>
    {
        public DoublyLinkNode<T> Head { get; private set; }
        public DoublyLinkNode<T> Tail { get; private set; }
        public bool IsEmpty => Count == 0;
        public int Count { get; private set; }



        public void AddFirst(T value)
        {
            AddFfirst(new DoublyLinkNode<T>(value));
        }

        private void AddFfirst(DoublyLinkNode<T> node)
        {
            //сохраняем головной узел
            DoublyLinkNode<T> temp = Head;
            //Head указывает на node
            Head = node;

            Head.Next = temp;
            if (IsEmpty)
            {
                Tail = Head;
            }
            else
            {
                temp.Previous = Head;
            }
            Count++;
        }

        private void AddLast(T value)
        {
            AddLast(new DoublyLinkNode<T>(value));
        }
        private void AddLast(DoublyLinkNode<T> node)
        {
            if (IsEmpty)
                 Head = node;
            else
            {
                Tail.Next = node;
                node.Previous = Tail;
            }
            Tail = node;
            Count++;
        }
        public void RemoveFirst()
        {
            if (IsEmpty)
                throw new InvalidOperationException();

            Head = Head.Next;
            
            Count--;
            if (IsEmpty)
                Tail = null;
            else
                Head.Previous = null;
        }

        private void RemoveLast()//Временная сложность константа, не линейная
        {
            if (IsEmpty)
                throw new InvalidOperationException();
            if (Count == 1)
            {
                Tail = Head = null;
            }
            else
            {
                Tail.Previous.Next = null;
                Tail = Tail.Previous;
            }
            Count--;
        }
    }
}
