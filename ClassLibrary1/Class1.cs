using NUnit.Framework;
using Sortorovki;

namespace ClassLibrary1
{
    [TestFixture]
    public class SortingTests
    {
        private int[][] Samples()
        {
            int[][] samples = new int[9][];
            samples[0] = new[] { 1 };
            samples[1] = new[] { 2, 1 };
            samples[2] = new[] { 2, 1, 3 };
            samples[3] = new[] { 1, 1, 1 };
            samples[4] = new[] { 2, -1, 3, 3 };
            samples[5] = new[] { 4, -5, 3, 3 };
            samples[6] = new[] { 0, -5, 3, 0 };
            samples[7] = new[] { 0, -5, 3, 6 };
            samples[8] = new[] { 1, 0, -5, 3, 0 };
            return samples;
        }
        private void RunTest(Action<int[]> sort)
        {
            foreach (var item in Samples())
            {
                sort(item);
                CollectionAssert.IsOrdered(item);
                PrintOut(item);
            }
        }

        private void PrintOut(int[] array)
        {
            TestContext.WriteLine("---TRACE---\n");
            foreach (var item in array)
            {
                TestContext.Write(item + " ");
            }
            TestContext.WriteLine("-----------\n");
        }

        [Test]
        public void BubbleSort_Valid()
        {
            RunTest(Sorting.BubbleSort);
        }
        [Test]
        public void SelectionSortValid()
        {
            RunTest(Sorting.SelectionSort);
        }

        [Test]
        public void InsrtionSortValid()
        {
            RunTest(Sorting.IsertionSort);
        }

        [Test]
        public void ShellSort()
        {
            RunTest(Sorting.ShellSort);
        }

        [Test]
        public void MergeSort()
        {
            RunTest(Sorting.MergeSort);
        }

        [Test]
        public void quickSort()
        {
            RunTest(Sorting.QuickSort);
        }

        private SinglyLinkedList<int> _list; //инициализация, которая будет запускаться при каждом тесте
        [SetUp]
        public void Init()
        {
            _list = new SinglyLinkedList<int>();
        }

        [Test]
        public void CreatEmptyList_CorrectionState()
        {
            Assert.IsTrue(_list.IsEmpty);
            Assert.IsNull(_list.Head);
            Assert.IsNull(_list.Tail);
        }
        [Test]
        public void AddFirstAndAddLast()
        {
            _list.AddFirst(1);
            CheckStateWithSingleNode(_list);
            _list.RemoveFirst();
            _list.AddLast(1);
            CheckStateWithSingleNode(_list);
        }
      
        public void CheckStateWithSingleNode(SinglyLinkedList<int> list)
        {
            Assert.AreEqual(1, list.Count);
            Assert.IsFalse(list.IsEmpty);
            Assert.AreSame(list.Head, list.Tail);
        }

        [Test]
        public void AddRemoveToGetStateWithSingleNode()
        {
            _list.AddFirst(1);
            _list.AddFirst(2);
            _list.RemoveFirst();
            CheckStateWithSingleNode(_list);
            _list.AddFirst(2);
            _list.RemoveLast();
            CheckStateWithSingleNode(_list);
        }
        [Test]
        public void AddItemsCorrectOrder()
        {
            _list.AddFirst(1);
            _list.AddFirst(2);
            Assert.AreEqual(2, _list.Head.Value);
            Assert.AreEqual(1, _list.Tail.Value);
            _list.AddLast(3);
            Assert.AreEqual(3, _list.Tail.Value);

        }

        [Test]
        public void RemoveFirstEmptyListThrow()
        {
            Assert.Throws<InvalidOperationException>(() => _list.RemoveFirst());
        }

        [Test]
        public void RemoveLastEmptyListThrow()
        {
            Assert.Throws<InvalidOperationException>(() => _list.RemoveLast());
        }

        [Test]
        public void RemoveFirst_RemoveLast_CorrectState()
        {
            _list.AddFirst(1);
            _list.AddFirst(2);
            _list.AddFirst(3);
            _list.AddFirst(4);
            _list.RemoveFirst();
            _list.RemoveLast();
            Assert.AreEqual(3, _list.Head.Value);
            Assert.AreEqual(2, _list.Tail.Value);
        }

        [Test]
        public void IsEmpty_EmptyStack_returnTrue() //проверка на созданный стэк
        {
            var stack = new ArrayStack<int>();
            Assert.IsTrue(stack.IsEmpty);
        }
        [Test]
        public void Count_PushOneItem_ReturnOne() 
        {
            var stack = new ArrayStack<int>();
            stack.Push(1);

            Assert.AreEqual(1, stack.Count);
            Assert.IsFalse(stack.IsEmpty);
        }
        [Test]
        public void Pop_EmptyStack_ThrowsException()
        {
            var stack = new ArrayStack<int>();
            Assert.Throws<InvalidOperationException>(() =>
            {
                stack.Pop();
            });
        }

        [Test]
        public void Peek_PushTwoItems_ReturnsHeadItem()
        {
            var stack = new ArrayStack<int>();
            stack.Push(1);
            stack.Push(2);
            Assert.AreEqual(2, stack.Peek());
        }

       [Test]
        public void Peek_PushTwoItemsAndPop_ReturnsHeadElement()
        {
            var stack = new ArrayStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Pop();
            Assert.AreEqual(1, stack.Peek());
        }
        [Test]
        public void IsEmpty_EmptyLinkedStack_ReturnTrue() //проверка на созданный стэк
        {
            var stack = new LinkedStack<int>();
            Assert.IsTrue(stack.IsEmpty);
        }
        [Test]
        public void Count_PushOneItemLinkedStack_ReturnOne()
        {
            var stack = new LinkedStack<int>();
            stack.Push(1);

            Assert.AreEqual(1, stack.Count);
            Assert.IsFalse(stack.IsEmpty);
        }
        [Test]
        public void Pop_EmptyLinkedStack_ThrowsException()
        {
            var stack = new LinkedStack<int>();
            Assert.Throws<InvalidOperationException>(() =>
            {
                stack.Pop();
            });
        }
        [Test]
        public void Peek_PushTwoItemsLinkedStack_ReturnsHeadItem()
        {
            var stack = new LinkedStack<int>();
            stack.Push(1);
            stack.Push(2);
            Assert.AreEqual(2, stack.Peek());
        }
        [Test]
        public void Peek_PushTwoItemsAndPopLinkedStack_ReturnsHeadElement()
        {
            var stack = new LinkedStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Pop();
            Assert.AreEqual(1, stack.Peek());
        }

        [Test]
        public void Capacity_EnqueueManyItems_DoubledCapacity()
        {
            var queue = new ArrayQueue<int>();
            queue.EnQueue(1);
            queue.EnQueue(2);
            queue.EnQueue(3);
            queue.EnQueue(4);
            queue.EnQueue(5);
            Assert.AreEqual(8, queue.Capacity);
        }
        [Test]
        public void IsEmpty_EmptyQueue_ReturnsTrue()
        {
            var queue = new ArrayQueue<int>();
            Assert.IsTrue(queue.IsEmpty);
        }
        [Test]
        public void Count_EnqueueOneItem_ReturnsOne()
        {
            var queue = new ArrayQueue<int>();
            queue.EnQueue(1);

            Assert.AreEqual(1, queue.Count);
            Assert.IsFalse(queue.IsEmpty);
        }
        [Test]
        public void Dequeue_EmptyQueue_ThrowsExeption()
        {
            var queue = new ArrayQueue<int>();
            Assert.Throws<InvalidOperationException>(() => { queue.DeQueue(); });
        }

        [Test]
        public void Peek_EnqueueTwoItems_ReturnHeadElement()
        {
            var queue = new ArrayQueue<int>();
            queue.EnQueue(1);
            queue.EnQueue(2);
          
            Assert.AreEqual(1, queue.Peek());
        }
        [Test]
        public void Peek_EnqueueTwoItemsAndDequeue_ReturnHeadElement()
        {
            var queue = new ArrayQueue<int>();
            queue.EnQueue(1);
            queue.EnQueue(2);
            queue.DeQueue();
            Assert.AreEqual(2, queue.Peek());
         }

        [Test]
        public void BinerySearch_SortedInput_ReturnsCorrectIndex()
        {
            int[] input = {0,3,4,7,8,12,15,22};
            Assert.AreEqual(2,SearchAlgorithm.BinarySearch(input,4));
            Assert.AreEqual(4, SearchAlgorithm.BinarySearch(input, 8));
            Assert.AreEqual(6, SearchAlgorithm.BinarySearch(input, 15));
            Assert.AreEqual(7, SearchAlgorithm.BinarySearch(input, 22));

            Assert.AreEqual(2, SearchAlgorithm.RecursiveBinarySearch(input, 4));
            Assert.AreEqual(4, SearchAlgorithm.RecursiveBinarySearch(input, 8));
            Assert.AreEqual(6, SearchAlgorithm.RecursiveBinarySearch(input, 15));
            Assert.AreEqual(7, SearchAlgorithm.RecursiveBinarySearch(input, 22));
        }

    }
}