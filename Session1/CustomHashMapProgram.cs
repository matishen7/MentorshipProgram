using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            var my_dictionary = new MyDictionary<string, string>();
            my_dictionary.Add("key1", "val1");
            my_dictionary.Add("key1" + (char)(0 + 65), "val1");
            my_dictionary.Add("key2", "val2");
            my_dictionary.Add("key2", "val3");
            my_dictionary.Add("key3", "val3");
            my_dictionary.Add("key4", "val4");
            my_dictionary.Add("key5", "val3");
            my_dictionary.Add("key5", "val5");
            my_dictionary.Add("key5", "val6");
            Console.WriteLine(my_dictionary.GetValue("key1"));
            Console.WriteLine(my_dictionary.GetValue("key2"));
            Console.WriteLine(my_dictionary.GetValue("key4"));
            Console.WriteLine(my_dictionary.GetValue("key5"));
            Console.WriteLine(my_dictionary.GetValue("key5"));

        }

        public class MyDictionary<TKey, TValue>
        {
            private TKey[] keys;
            private TValue[] values;
            private int count;

            public MyDictionary()
            {
                keys = new TKey[10];
                values = new TValue[10];
                count = 0;
            }

            public void Add(TKey key, TValue value)
            {
                if (ContainsKey(key))
                {
                    int index = Array.IndexOf(keys, key, 0, count);
                    values[index] = value;
                }
                else
                {
                    if (count == keys.Length)
                    {
                        ResizeArrays();
                    }
                    keys[count] = key;
                    values[count] = value;
                    count++;
                }
            }

            public bool ContainsKey(TKey key)
            {
                for (int i = 0; i < count; i++)
                {
                    if (keys[i].Equals(key))
                    {
                        return true;
                    }
                }
                return false;
            }

            public TValue GetValue(TKey key)
            {
                for (int i = 0; i < count; i++)
                {
                    if (keys[i].Equals(key))
                    {
                        return values[i];
                    }
                }
                throw new KeyNotFoundException("Key not found in the dictionary.");
            }

            private void ResizeArrays()
            {
                int newLength = keys.Length * 2;
                TKey[] newKeys = new TKey[newLength];
                TValue[] newValues = new TValue[newLength];
                Array.Copy(keys, newKeys, count);
                Array.Copy(values, newValues, count);
                keys = newKeys;
                values = newValues;
            }
        }

    }
}


