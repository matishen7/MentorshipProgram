using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using static MentorshipProgram.Session1.CustomSetProgram;

namespace MentorshipProgram.Session1
{
    [TestClass]
    public class CustomHashMapProgram
    {
        [TestMethod]
        public void Test_CustomHashMap()
        {
            var dict = new CustomHashMap<string, string> { };
            //dict["1"] = "1";
            Console.WriteLine(dict["1"]);
        }

        private class CustomHashMap<K, V>
        {
            private K[] keys;
            private V[] values;
            private int size = 0;

            public CustomHashMap()
            {
                keys = new K[size];
                values = new V[size];
            }

            public V this[K key]
            {
                get
                {
                    int index = KeyExists(key);
                    if (index != -1)
                        return values[index];
                    throw new Exception("Key does not exist!");
                }
                set
                {
                    int index = KeyExists(key);
                    if (index != -1)
                        values[index] = value;
                    else
                    {
                        var newKeys = new K[keys.Length + 1];
                    }

                }
            }

            //public void Add()

            private int KeyExists(K key)
            {
                for (int i = 0; i < keys.Length; i++)
                {
                    if (keys[i].Equals(key)) return i;
                }
                return -1;
            }

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
