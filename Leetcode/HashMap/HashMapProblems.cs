﻿using BenchmarkDotNet.Reports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

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

        [TestMethod]
        public void FindMatrix()
        {
            int[] nums = { 1, 3, 4, 1, 2, 3, 1 };
            IList<IList<int>> arr = new List<IList<int>>();
            var dic = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {

                if (dic.ContainsKey(nums[i]))
                {
                    var count = dic[nums[i]];
                    dic[nums[i]] = ++count;
                }
                else
                    dic.Add(nums[i], 1);

            }

            while (dic.Count > 0)
            {
                var row = new List<int>();
                for (int i = dic.Count - 1; i >= 0; i--)
                {
                    KeyValuePair<int, int> KeyValue = dic.ElementAt(i);
                    var count = KeyValue.Value;
                    if (count > 0) row.Add(KeyValue.Key);
                    count = count - 1;
                    if (count == 0) dic.Remove(KeyValue.Key);
                    else dic[KeyValue.Key] = count;
                }
                arr.Add(row);
            }
            Console.WriteLine(arr);
        }
    }
}
