using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MentorshipProgram
{
    [TestClass]
    public class MyCustomArrayList
    {
        [TestMethod]
        public void MyArrayList()
        {
            CustomArrayList my_array_list = new CustomArrayList();
            my_array_list.Set(0, 1);
            Console.WriteLine(my_array_list.Get(0));
            my_array_list.Add(2);
            Console.WriteLine(my_array_list.Get(0));
            Console.WriteLine(my_array_list.Get(1));
            my_array_list.remove(1); //
            Console.WriteLine(my_array_list.Get(0));
            Console.WriteLine(my_array_list.Size());
            my_array_list.Add(2);
            my_array_list.Add(2);
            my_array_list.Add(2);
            Console.WriteLine(my_array_list.Size());
        }

        public class CustomArrayList
        {
            private int[] elements;
            private int defaultSize = 1;

            public CustomArrayList()
            {
                elements = new int[defaultSize];
            }

            public void Add(int value)
            {
                int[] newElements = new int[this.elements.Length + 1];
                newElements = CopyValues(elements, newElements, -1);
                newElements[newElements.Length - 1] = value;
                this.elements = new int[newElements.Length];
                elements = CopyValues(newElements, elements, -1);
            }

            public void remove(int index)
            {
                int[] newElements = new int[this.elements.Length - 1];
                newElements = CopyValues(elements, newElements, index);
                this.elements = new int[newElements.Length];
                elements = CopyValues(newElements, elements, -1);
            }

            private int[] CopyValues(int[] source, int[] target, int skipIndex)
            {
                for (int i = 0; i < source.Length; i++)
                {
                    if (skipIndex == i) continue;
                    target[i] = source[i];
                }
                return target;
            }

            public int Size()
            {
                return elements.Length;
            }

            public bool IsEmpty()
            {
                return elements.Length == 0;
            }

            public void Set(int index, int value)
            {
                if (elements.Length > index)
                    elements[index] = value;
                else throw new Exception("Index out of bound");
            }

            public int Get(int index)
            {
                if (elements.Length > index) return elements[index];
                else throw new Exception("Index out of bound");
            }
        }
    }
}
