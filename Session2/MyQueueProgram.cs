using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MentorshipProgram.Session2
{
    [TestClass]
    public class MyQueueProgram
    {
        [TestMethod]
        public void TestMethod1()
        {
            var queue = new MyQueue();
            queue.Push(1);
            queue.Push(2);
            queue.Push(3);
            queue.Push(4);
            Console.WriteLine(queue.Pop());
            Console.WriteLine(queue.Pop());
            Console.WriteLine(queue.Pop());
            Console.WriteLine(queue.Pop());
            queue.Push(6);
            //Console.WriteLine(queue.Pop());
            Console.WriteLine(queue.Peek());
        }

        public class MyQueue
        {
            private int[] elements = new int[] { };
            private int index = 0;

            public MyQueue()
            {
                elements = new int[] { };
            }

            public MyQueue(int[] elements)
            {
                this.elements = elements;
                index = elements.Length;
            }

            public MyQueue(int size)
            {
                elements = new int[size];
            }

            public void Push(int value)
            {
                if (index >= elements.Length)
                {
                    Resize();
                }
                elements[index++] = value;
            }

            public int Pop()
            {
                if (!IsEmpty())
                {
                    int first = elements[0];

                    Reorganize();

                    return first;
                }

                throw new Exception("Queue is empty!");
            }

            public int Peek()
            {
                if (!IsEmpty())
                {
                    return elements[0];
                }

                throw new Exception("Queue is empty!");
            }

            private void Reorganize()
            {
                var newElements = new int[elements.Length - 1];
                int t = 0;
                for (int i = 1; i < elements.Length; i++)
                    newElements[t++] = elements[i];
                elements = newElements;
                index = elements.Length;
            }

            public bool IsEmpty()
            {
                return elements.Length == 0;
            }

            private void Resize()
            {
                if (elements.Length != 0)
                {
                    var newElements = new int[elements.Length * 2];
                    Array.Copy(elements, newElements, elements.Length);
                    elements = newElements;
                }
                else
                {
                    elements = new int[1];
                    index = 0;
                }
            }
        }
    }
}
