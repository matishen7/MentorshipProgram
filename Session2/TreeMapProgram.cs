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
        }

        public class TreeMap
        {
            private SortedDictionary<int, int> keyValuePairs = new SortedDictionary<int, int>();

            public void Insert(int key, int val)
            {
                keyValuePairs.Add(key, val);
            }
            public void Remove(int key)
            {
                keyValuePairs.Remove(key);
            }

            public int Get(int key)
            {
                keyValuePairs.TryGetValue(key, out int result);
                return result;
            }

            public void Clear()
            {
                keyValuePairs.Clear();
            }

            public bool Contains(int key)
            {
                return keyValuePairs.ContainsKey(key);
            }
        }
    }
}
