using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortorovki
{
    public class DoublyLinkNode<T>
    {
        public DoublyLinkNode(T value)
        {
            Value = value;
        }

        public DoublyLinkNode<T> Next { get; internal set; }
        public DoublyLinkNode<T> Previous { get; internal set; }
        public T Value { get; set; }

    }
}
