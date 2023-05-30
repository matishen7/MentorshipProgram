using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MentorshipProgram.Session2
{
    [TestClass]
    public class MyCollections
    {
        [TestMethod]
        public void test_my_array_list()
        {
            var arrList = new MyArrayList(2);
            arrList.Add(1);
            arrList.Add(2);
            arrList.Add(3); 
            arrList.Add(2);
        }

        public class MyArrayList
        {
            private int[] elements;
            private int size = 10;
            private int index = 0;
            public MyArrayList()
            {
                elements = new int[size];
            }

            public MyArrayList(int[] elements, int size)
            {
                this.elements = elements;
                this.size = size;
            }

            public MyArrayList(int size)
            {
                elements = new int[size];
            }

            public bool Contains(int value)
            {
                return Array.IndexOf(elements, value) != -1;
            }

            public bool IsEmpty()
            {
                return elements.Length == 0;
            }

            public int Size()
            {
                return elements.Length;
            }

            public void Add(int value)
            {
                if (index == elements.Length)
                    Resize();
                elements[index] = value;
                index++;
            }

            private void Resize()
            {
                var newElements = new int[elements.Length * 2];
                Array.Copy(elements, newElements, elements.Length);
                elements = newElements;
                size = newElements.Length;
            }
        }
    }
}
