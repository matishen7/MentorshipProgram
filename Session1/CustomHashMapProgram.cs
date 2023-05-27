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
            mymap.Add("key2", "val3");
            mymap.Add("key3", "val3");
            mymap.Add("key4", "val4");
            //mymap.Add("key3", "val3");
            // mymap.Add("key3", "val3");
            //mymap.Add("key3", "val3");
            Console.WriteLine(mymap.Get("key1"));
            //Console.WriteLine(mymap.Get("key2"));
            //Console.WriteLine(mymap.Get("key4"));
            //Console.WriteLine(mymap.Get("key5"));
            //Console.WriteLine(mymap.Get("key6"));

        }

        public class MyHashMap<TKey, TValue>
        {
            private TKey Key { get; set; }
            private TValue Value { get; set; }

            private Node<TKey, TValue>[] Elements { get; set; }

            private int size = 1;

            private int currentIndex = 0;


            public MyHashMap(int size)
            {
                Elements = new Node<TKey, TValue>[size];
            }

            public MyHashMap()
            {
                Elements = new Node<TKey, TValue>[size];
            }

            public void Put(TKey key, TValue value)
            {
                int hashcode = key.GetHashCode();
                int index = Math.Abs(hashcode) % Elements.Length;
                // Elements[index] = value;
            }

            public TValue Get(TKey key)
            {
                int hashcode = key.GetHashCode();
                int index = Math.Abs(hashcode) % Elements.Length;
                var node = findKey(key, Elements[index]);
                return (node != null) ? node.value : default(TValue);
            }

            public void Add(TKey key, TValue value)
            {
                int hashcode = key.GetHashCode();
                int index = Math.Abs(hashcode) % Elements.Length;
                var node = new Node<TKey, TValue>(key, value, hashcode);
                if (currentIndex < Elements.Length)
                {
                    if (Elements[index] == null)
                        Elements[index] = node;
                    else
                    {
                        var head = Elements[index];
                        var exisingNode = findKey(key, head);
                        if (exisingNode == null)
                            head.next = node;
                    }
                }
                else
                {
                    var newElements = new Node<TKey, TValue>[Elements.Length * 2];
                    Array.Copy(Elements, newElements, Elements.Length);
                    index = Math.Abs(hashcode) % newElements.Length;
                    if (newElements[index] == null)
                        newElements[index] = node;
                    Elements = newElements;
                }
                currentIndex++;
            }

            private Node<TKey, TValue> findKey(TKey key, Node<TKey, TValue> head)
            {
                var current = head;
                while (current != null)
                {
                    if (current.key.Equals(key)) return current;
                    current = current.next;
                }
                return null;
            }
        }

        private class Node<TKey, TValue>
        {
            int hashCode;
            public TValue value;
            public TKey key;
            public Node<TKey, TValue> next;

            public Node(TKey key, TValue value, int hashCode)
            {
                this.key = key;
                this.value = value;
                this.hashCode = hashCode;
            }
        }
    }
}


