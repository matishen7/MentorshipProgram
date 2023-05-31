using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;

namespace MentorshipProgram.Session2
{
    [TestClass]
    public class HeapProgram
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        public class MyHeap
        {
            private int[] elements = new int[] { };
            private int index = 0;
            public MyHeap()
            {
                elements = new int[] { };
            }

            public MyHeap(int[] elements)
            {
                this.elements = elements;
                index = elements.Length;
            }

            public MyHeap(int size)
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
        }
    }
}
