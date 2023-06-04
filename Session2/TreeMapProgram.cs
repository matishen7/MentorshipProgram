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
            treeMap.Insert(1, 2);
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
