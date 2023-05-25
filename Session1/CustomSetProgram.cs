using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace MentorshipProgram.Session1
{
    [TestClass]
    public class CustomSetProgram
    {
        [TestMethod]
        public void Test_CustomSet()
        {
            var my_set = new CustomSet<string>();
            my_set.Add("a");
            my_set.Add("b");
            my_set.Add("a");
            my_set.Remove("a");
            my_set.Remove("b");
            my_set.Remove("a");
            Console.WriteLine(my_set.Size());
            Console.WriteLine(my_set.IsEmpty());

            var numbers = new CustomSet<int>();
            numbers.Add(1);
            numbers.Add(2);
            numbers.Add(3);
            numbers.Add(3);
            Console.WriteLine(numbers.Size());
            numbers.Remove(3);
            numbers.Remove(3);
            numbers.Remove(3);
            Console.WriteLine(numbers.Size());
            Console.WriteLine(numbers.IsEmpty());
            numbers.Remove(1);
            numbers.Remove(2);
            Console.WriteLine(numbers.Size());
            Console.WriteLine(numbers.IsEmpty());

        }

        public class CustomSet<T> where T : IEquatable<T>
        {
            private T[] elements;
            private int defaultSize = 0;
            public CustomSet()
            {
                elements = new T[defaultSize];
            }

            public void Add(T value)
            {
                var exists = Exists(value);
                if (!exists)
                {
                    var newElements = new T[elements.Length + 1];
                    newElements = CopyValues(elements, newElements);
                    newElements[newElements.Length - 1] = value;
                    elements = new T[newElements.Length];
                    elements = newElements;
                }
            }

            public void Remove(T value)
            {
                var exists = Exists(value);
                if (exists)
                {
                    T[] newElements = new T[this.elements.Length - 1];
                    newElements = CopyValues(elements, newElements, value);
                    elements = new T[newElements.Length];
                    elements = CopyValues(newElements, elements);
                }
            }

            public bool IsEmpty()
            {
                return elements.Length == 0;
            }

            public int Size()
            {
                return elements.Length;
            }

            public bool Exists(T value)
            {
                foreach (var element in elements)
                    if (EqualityComparer<T>.Default.Equals(element, value)) return true;
                return false;
            }

            private T[] CopyValues(T[] source, T[] target, T value)
            {
                int targetIndex = 0;
                for (int i = 0; i < source.Length; i++)
                {
                    if (EqualityComparer<T>.Default.Equals(source[i], value)) continue;
                    else
                    {
                        target[targetIndex] = source[i];
                        targetIndex++;
                    }
                }
                return target;
            }

            private T[] CopyValues(T[] source, T[] target)
            {
                for (int i = 0; i < source.Length; i++)
                    target[i] = source[i];

                return target;
            }
        }
    }


}
