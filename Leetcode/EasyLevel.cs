using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
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
            int[] nums = new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            List<int> unique = new List<int>();
            for (int i = 0; i < nums.Length; i++)
                if (!unique.Contains(nums[i]))
                    unique.Add(nums[i]);
            for (int i = 0; i < unique.Count; i++)
            {
                nums[i] = unique.ElementAt(i);
                //System.out.println(nums[i]);
            }

            Console.Write(unique.Count);
        }
    }
}
