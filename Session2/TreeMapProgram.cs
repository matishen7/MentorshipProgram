using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace MentorshipProgram.Session2
{
    /// <summary>
    /// Tree map is implemented wuth Red-Black binary search tree
    /// </summary>
    [TestClass]
    public class TreeMapProgram
    {
        [TestMethod]
        public void TestMethod1()
        {
            TreeMap treeMap = new TreeMap();
            for (int i = 0; i < 10; i++)
            {
                treeMap.Insert(i, i);
            }
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(treeMap.Get(i));
            }

            treeMap.Print();
        }

        public class TreeMap
        {
            private SortedDictionary<int, int> keyValuePairs = new SortedDictionary<int, int>();

            public void Insert(int key, int val) // O(log(N))
            {
                keyValuePairs.Add(key, val);
            }
            public void Remove(int key)// O(log(N))
            {
                keyValuePairs.Remove(key);
            }

            public int Get(int key)// O(log(N))
            {
                return keyValuePairs[key];
            }

            public void Clear()
            {
                keyValuePairs =  new SortedDictionary<int, int>();
            }

            public bool Contains(int key)
            {
                return keyValuePairs.ContainsKey(key);
            }

            public void Print()
            {
                keyValuePairs.PrintSortedDictionary();
            }
        }

        class SortedDictionary<TKey, TValue> where TKey : IComparable<TKey>
        {
            private class Node
            {
                public TKey Key { get; set; }
                public TValue Value { get; set; }
                public Node Left { get; set; }
                public Node Right { get; set; }

                public Node(TKey key, TValue value)
                {
                    Key = key;
                    Value = value;
                }
            }

            private Node root;

            public void Add(TKey key, TValue value)
            {
                root = Add(root, key, value);
            }

            private Node Add(Node node, TKey key, TValue value)
            {
                if (node == null)
                    return new Node(key, value);

                int cmp = key.CompareTo(node.Key);
                if (cmp < 0)
                    node.Left = Add(node.Left, key, value);
                else if (cmp > 0)
                    node.Right = Add(node.Right, key, value);
                else
                    node.Value = value;

                return node;
            }

            public bool Remove(TKey key)
            {
                if (!ContainsKey(key))
                    return false;

                root = Remove(root, key);
                return true;
            }

            private Node Remove(Node node, TKey key)
            {
                if (node == null)
                    return null;

                int cmp = key.CompareTo(node.Key);
                if (cmp < 0)
                    node.Left = Remove(node.Left, key);
                else if (cmp > 0)
                    node.Right = Remove(node.Right, key);
                else
                {
                    if (node.Left == null)
                        return node.Right;
                    if (node.Right == null)
                        return node.Left;

                    Node minNode = FindMinNode(node.Right);
                    node.Key = minNode.Key;
                    node.Value = minNode.Value;
                    node.Right = Remove(node.Right, minNode.Key);
                }

                return node;
            }

            private Node FindMinNode(Node node)
            {
                while (node.Left != null)
                    node = node.Left;
                return node;
            }

            public bool ContainsKey(TKey key)
            {
                return Find(root, key) != null;
            }

            private Node Find(Node node, TKey key)
            {
                while (node != null)
                {
                    int cmp = key.CompareTo(node.Key);
                    if (cmp < 0)
                        node = node.Left;
                    else if (cmp > 0)
                        node = node.Right;
                    else
                        return node;
                }
                return null;
            }

            public TValue this[TKey key]
            {
                get
                {
                    Node node = Find(root, key);
                    if (node == null)
                        throw new KeyNotFoundException($"Key '{key}' not found.");

                    return node.Value;
                }
                set
                {
                    Add(key, value);
                }
            }

            public void PrintSortedDictionary()
            {
                PrintInOrder(root);
            }

            private void PrintInOrder(Node node)
            {
                if (node == null)
                    return;

                PrintInOrder(node.Left);
                Console.WriteLine($"Key: {node.Key}, Value: {node.Value}");
                PrintInOrder(node.Right);
            }
        }

    }
}
