using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace MentorshipProgram.Session1
{
    [TestClass]
    public class MySetProgram
    {
        [TestMethod]
        public void test_my_set()
        {
            var set1 = new MySet<string>();
            set1.Add("a");
            set1.Add("b");
            set1.Add("c");
            set1.Add("c");
            set1.Remove("a");
        }

        public class MySet<T>
        {
            Dictionary<T, Object> keys;
            public MySet()
            {
                keys = new Dictionary<T, Object>();
            }

            public void Add(T key)
            {
                keys[key] = new object();
            }

            public void Remove(T key)
            {
                keys.Remove(key);
            }
        }
    }
}
