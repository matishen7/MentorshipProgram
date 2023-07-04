using BenchmarkDotNet.Reports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

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
            var dic = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                var currentNum = nums[i];
                var currentIndex = i;
                if (dic.ContainsKey(currentNum))
                {
                    var count = dic[currentNum];
                    count++;
                    dic[currentNum] = count;
                }
                else
                {
                    dic.Add(currentNum, 1);
                }
            }

            foreach (var item in dic)
            {
                var count = item.Value;
                if (count > 1)
                {
                    var sum = 0;
                    for (int i = 1; i <= count; i++)
                        sum += i;
                    sum = sum - item.Value;
                    result += sum;
                }
            }

            Console.WriteLine(result);
        }
    }
}
