using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Security.Policy;
using static MentorshipProgram.Session1.CustomSetProgram;

namespace MentorshipProgram.Session1
{
    [TestClass]
    public class CustomHashMapProgram
    {
        [TestMethod]
        public void Test_CustomHashMap()
        {
            string key = "key";
            string val = "value";

            Dictionary<string, string> map = new Dictionary<string, string>();
            map.Add(key, val);

            Console.WriteLine("Dictionary object created. Its key hashcode = " + key.GetHashCode());
            // the hashcode is 106079
            Console.WriteLine("Dictionary object value for key = " + map[key]);

            // Let's store using a key with the same hashcode
            int intkey = key.GetHashCode();
            val = "value2";
            map[intkey.ToString()] = val;
            Console.WriteLine("Dictionary object created. Its intkey hashcode = " + intkey.GetHashCode());
            // this returns 106079 once again. So both key and intkey have the same hashcode

            // Let's get the values
            Console.WriteLine("Dictionary object value for intkey = " + map[intkey.ToString()]);
            Console.WriteLine("Dictionary object value for key = " + map[key]);

            Console.WriteLine("-----------------");
            var mymap = new MyHashMap<string, string>();
            mymap.Add("key1", "val1");
            mymap.Add("key2", "val2");
            mymap.Add("key3", "val3");

        }

        public class MyHashMap<TKey, TValue>
        {
            private TKey Key { get; set; }
            private TValue Value { get; set; }

            private TValue[] Elements { get; set; }

            private int size = 2;

            private int currentIndex = 0;


            public MyHashMap(int size)
            {
                Elements = new TValue[size];
            }

            public MyHashMap()
            {
                Elements = new TValue[size];
            }

            public void Add(TKey key, TValue value)
            {
                int hashcode = key.GetHashCode();
                if (currentIndex < Elements.Length)
                {
                    int index = Math.Abs(hashcode) % Elements.Length;
                    Elements[index] = value;
                }
                else
                {

                    var newElements = new TValue[size * 2];
                    Array.Copy(Elements, newElements, size);
                    int index = Math.Abs(hashcode) % newElements.Length;
                    newElements[index] = value;
                    Elements = newElements;
                }
                currentIndex++;
            }
        }

        private class Node<TKey, TValue>
        {
            int hashCode;
            TValue value;
            TKey key;
            Node<TKey, TValue> next;

            public Node(TKey key, TValue value)
            {
                this.key = key;
                this.value = value;

            }
        }
    }
}


