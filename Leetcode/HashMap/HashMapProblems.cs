using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MentorshipProgram.Leetcode.HashMap
{
    [TestClass]
    public class HashMapProblems
    {
        [TestMethod]
        public void NumIdenticalPairs()
        {
            int[] nums = { 1, 2, 3, 1, 1, 3 };
            int result = 0;
            for (int i = 0; i < nums.Length - 1; i++)
                for (int j = 1; j < nums.Length; j++)
                    if (nums[i] == nums[j] && i < j)
                    {
                        Console.Write("(" + i + "," + j + ")");
                        result++;
                    }

            Console.WriteLine(result);
        }
    }
}
