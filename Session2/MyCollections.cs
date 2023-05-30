using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.ComponentModel;
using System.Reflection;

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

            var my_linked_list = new LinkedList();
            Console.WriteLine(my_linked_list.isEmpty());

            my_linked_list.Add(1);
            my_linked_list.Add(2);
            Console.WriteLine(my_linked_list.Contains(2));
            Console.WriteLine(my_linked_list.Contains(3));
            Console.WriteLine(my_linked_list.Size());
            my_linked_list.Add(3);
            Console.WriteLine(my_linked_list.Size());
            Console.WriteLine(my_linked_list.isEmpty());

            my_linked_list.Remove(2);
            Console.WriteLine(my_linked_list.Size());
            Console.WriteLine(my_linked_list.isEmpty());

            var my_set = new MySet(2);
            for (int i = 0; i <= 11; i++)
            {
                my_set.Add(i);
            }

            my_set.Remove(2);
            Console.WriteLine(my_set.Size());

            var my_hash_map = new MyDictionary();
            my_hash_map.Add("key1", "val1");
            my_hash_map.Add("key2", "val2");
            my_hash_map.Add("key3", "val3");
            my_hash_map.Add("key3", "val3");

        }

        #region array list

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
        #endregion

        #region linked list

        public class LinkedList
        {
            private Node head;

            public void Add(int value)
            {
                var newNode = new Node(value);
                if (head == null) head = newNode;
                else
                {
                    var currentNode = head;
                    while (currentNode.next != null)
                    {
                        currentNode = currentNode.next;
                    }
                    currentNode.next = newNode;
                }
            }

            public void Remove(int value)
            {
                Node curr = head;
                Node prev = null;
                while (curr != null)
                {
                    if (curr.value == value)
                    {
                        if (curr == head)
                        {
                            head = head.next;
                        }
                        else
                        {
                            prev.next = curr.next;
                            curr = head;
                        }

                    }
                    prev = curr;
                    curr = curr.next;
                }
            }

            public bool Contains(int value)
            {
                if (head == null) return false;
                var currentNode = head;
                while (currentNode != null)
                {
                    if (currentNode.value == value) return true;
                    currentNode = currentNode.next;
                }
                return false;
            }

            public int Size()
            {
                var size = 0;
                if (head == null) return size;
                var currentNode = head;
                while (currentNode != null)
                {
                    size++;
                    currentNode = currentNode.next;
                }
                return size;
            }

            public bool isEmpty()
            {
                return (head == null);
            }
        }

        public class Node
        {
            public int value;
            public Node next;
            public Node(int value, Node node)
            {
                this.value = value;
                this.next = node;
            }

            public Node(int value) { this.value = value; }

            public Node()
            {

            }
        }

        #endregion

        #region sets

        public class MySet
        {
            private int[] elements;
            private int index = 0;

            public MySet()
            {
                elements = new int[10];
            }

            public MySet(int[] elements)
            {
                this.elements = elements;
            }

            public MySet(int size)
            {
                elements = new int[size];
            }

            public bool Contains(int value)
            {
                return Array.IndexOf(elements, value) != -1;
            }

            public bool IsEmpty()
            {
                return index == 0;
            }

            public int Size()
            {
                return index;
            }

            public void Add(int value)
            {
                if (Array.IndexOf(elements, value) == -1)
                {
                    if (index == elements.Length)
                        Resize();
                    elements[index] = value;
                    index++;
                }
            }

            public void Remove(int value)
            {
                int index = Array.IndexOf(elements, value);
                if (index != -1)
                {
                    var newElements = new int[elements.Length - 1];
                    newElements = Copy(elements, newElements, index);
                    elements = newElements;
                    this.index--;
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
            }
        }
        #endregion

        #region hash maps, dictionaries

        public class MyDictionary
        {
            private string[] keys = new string[10];
            private string[] values = new string[10];
            private int index = 0;
            public MyDictionary() { }

            public void Add(string key, string value)
            {
                var foundIndex = Array.IndexOf(keys, key);
                if (foundIndex == -1)
                {
                    if (index >= keys.Length)
                        Resize();
                    keys[index] = key;
                    values[index] = value;
                    index++;
                }
            }

            private void Resize()
            {
                var newKeys = new string[keys.Length * 2];
                Array.Copy(keys, newKeys, keys.Length);
                keys = newKeys;

                var newValues = new string[values.Length * 2];
                Array.Copy(values, newValues, keys.Length);
                values = newValues;
            }

            public void Clear()
            {
                keys = new string[0];
                values = new string[0];
            }

            public bool IsEmpty()
            {
                return keys.Length == 0;
            }

            public void Remove(string key)
            {
                var foundIndex= Array.IndexOf(keys, key);
                if (foundIndex != -1)
                {
                    var newKeys = new string[keys.Length - 1];
                    newKeys = Copy(keys, newKeys, foundIndex);
                    keys = newKeys;

                    var newValues = new string[values.Length - 1];
                    newValues = Copy(values, newValues, foundIndex);
                    values = newValues;
                    index--;
                }
            }

            private string[] Copy(string[] source, string[] target, int indexToDelete)
            {
                int t = 0;
                for (int i = 0; i < source.Length; i++)
                {
                    if (i == indexToDelete) continue;
                    target[t] = source[i];
                    t++;
                }
                return target;
            }

        }

        #endregion
    }
}
