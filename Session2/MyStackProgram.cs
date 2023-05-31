using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MentorshipProgram.Session2
{
    [TestClass]
    public class MyStackProgram
    {
        [TestMethod]
        public void TestMethod1()
        {
            var stack = new MyStack();
            stack.Push(1);
            stack.Push(2);
            Console.WriteLine(stack.Pop());
            stack.Push(3);
            //stack.Push(4);
            Console.WriteLine(stack.Peek());
            Console.WriteLine(stack.Size());
            stack.Set(0,2);
            //Console.WriteLine(stack.Pop());
            //Console.WriteLine(stack.Size());
        }

        public class MyStack
        {
            private int[] elements = new int[] { };
            private int index = 0;
            public MyStack()
            {
                elements = new int[] { };
            }

            public MyStack(int[] elements)
            {
                this.elements = elements;
                index = elements.Length;
            }

            public MyStack(int size)
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

            public void Set(int ind, int value)
            {
                if (ind < index) elements[ind] = value;
                else throw new IndexOutOfRangeException("No such index found!");
            }

            public int Pop()
            {
                if (!IsEmpty())
                {
                    int last = elements[index - 1];

                    Reorganize();

                    return last;
                }

                throw new Exception("Stack is empty!");
            }

            public int Peek()
            {
                if (!IsEmpty())
                {
                    return elements[elements.Length - 1];
                }

                throw new Exception("Stack is empty!");
            }

            private void Reorganize()
            {
                var newElements = new int[index - 1];
                int t = 0;
                for (int i = 0; i < index - 1; i++)
                    newElements[t++] = elements[i];
                elements = newElements;
                index = elements.Length;
            }

            public bool IsEmpty()
            {
                return index == 0;
            }

            public int Size()
            {
                return index;
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
