using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MentorshipProgram.Session1
{
    [TestClass]
    public class CustomHashMapProgram
    {
        [TestMethod]
        public void Test_CustomHashMap()
        {
        }

        private class CustomHashMap<K,V>
        {
            public K key;
            public V value;

            public CustomHashMap() { }

        }
    }
}
