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
            string key = "key";
            string val = "value";

            Dictionary<string, string> map = new Dictionary<string, string>();
            map.Add(key, val);

            Console.WriteLine("Dictionary object created. Its key hashcode = " + key.GetHashCode());
            // the hashcode is 106079
            Console.WriteLine("Dictionary object value for key = " + map[key]);

            // Let's store using a key with the same hashcode
            int intkey = 106079;
            val = "value2";
            map[intkey.ToString()] = val;
            Console.WriteLine("Dictionary object created. Its intkey hashcode = " + intkey.GetHashCode());
            // this returns 106079 once again. So both key and intkey have the same hashcode

            // Let's get the values
            Console.WriteLine("Dictionary object value for intkey = " + map[intkey.ToString()]);
            Console.WriteLine("Dictionary object value for key = " + map[key]);

        }


    }
}
