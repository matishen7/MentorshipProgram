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
    }
}
