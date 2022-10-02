using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortorovki
{
    public class TreeNode<T> where T : IComparable<T> //ограничимаем Т с помщью конструкции
    {     //это означает, что используемый тип в качестве значения узла обязан реализовывать интерфейс
        public TreeNode(T value)
        {
            Value = value;
        }

        public T Value { get; set; }
        public TreeNode<T> Left { get; set; }
        public TreeNode<T> Right { get; set; }

        public void Insert(T newValue)
        {
            int compare = newValue.CompareTo(Value);
            if (compare == 0)
                return;
            if (compare < 0)
            {
                if(Left==null)
                {
                Left = new TreeNode<T>(newValue);
                }
                else
                {
                    Left.Insert(newValue);
                }
                   
            }
            else
            {
                if (Right == null)
                {
                    Right = new TreeNode<T>(newValue);
                }
                else
                {
                    Right.Insert(newValue);
                }
            }
        }

        public TreeNode<T> Get(T value)
        {
            int compare = value.CompareTo(Value);
            if (compare == 0)
                return this;
            if (compare < 0)
            {
                if (Left != null)
                    return Left.Get(value);
            }
            else
            {
                if (Right != null)
                    return Right.Get(value);
            }
            return null;

        }

        public IEnumerable<T> TraverseOrder()
        {
            var list = new List<T>();
            InnerTraverse(list);
            return list;
        }

        private void InnerTraverse(List<T> list)
        {
            if (Left != null)
                Left.InnerTraverse(list);

            list.Add(Value);

            if (Right != null)
                Right.InnerTraverse(list);
        }

        public T Min()
        {
            if (Left != null)
               return Left.Min();
            return Value;
        }
        public T Max()
        {
            if (Right != null)
                return Right.Max();
            return Value;
        }


    }
}
