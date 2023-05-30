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
            arrList.Put(0, 2);
            arrList.Remove(2);
            arrList.Add(5);
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

            public void Put(int index, int value)
            {
                if (index >= elements.Length) throw new IndexOutOfRangeException("Index is out of range!");

                elements[index] = value;
            }

            public void Remove(int value)
            {
                int index = Array.IndexOf(elements, value);
                if (index != -1)
                {
                    var newElements = new int[elements.Length - 1];
                    newElements = Copy(elements, newElements, index);
                    elements = newElements;
                    size = elements.Length;
                    this.index = size;
                }
            }

            private int[] Copy(int[] source, int[] target, int index)
            {
                int t = 0;
                for (int i = 0; i < source.Length; i++)
                {
                    if (i == index) continue;
                    target[t] = source[i];
                    t++;
                }
                return target;
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
