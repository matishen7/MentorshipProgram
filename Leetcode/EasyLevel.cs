using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace MentorshipProgram.Leetcode
{
    [TestClass]
    public class EasyLevel
    {
        [TestMethod]
        public void removeDuplicates()
        {
            var nums = new int[] { 0, 0, 1, 1, 1, 1, 2, 3, 3 };
            var list = new List<int>();
            var unique = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
                if (!unique.ContainsKey(nums[i]))
                {
                    unique.Add(nums[i], 1);
                    list.Add(nums[i]);
                }
                else if (unique.ContainsKey(nums[i]))
                {
                    var c = unique[nums[i]];
                    if (c == 1)
                    {
                        unique[nums[i]] = ++c;
                        list.Add(nums[i]);
                    }
                }
            for (int i = 0; i < list.Count; i++)
            {
                nums[i] = list.ElementAt(i);
            }

            Console.WriteLine(list.Count);

        }

        [TestMethod]
        [DataRow(-2147483648)]
        public void Reverse(int x)
        {
            const int INT_MAX = 2147483647;
            const int INT_MIN = -2147483648;

            bool isNegative = false;
            if (x < 0)
            {
                isNegative = true;
                x = Math.Abs(x);
            }

            long reversed = 0;
            while (x != 0)
            {
                int lastDigit = x % 10;
                reversed = reversed * 10 + lastDigit;
                x = x / 10;
            }

            if (isNegative)
            {
                reversed = -reversed;
            }

            if (reversed > INT_MAX || reversed < INT_MIN)
            {
                Console.WriteLine(0);
            }

            Console.WriteLine ((int)reversed);
        }
    }
}
