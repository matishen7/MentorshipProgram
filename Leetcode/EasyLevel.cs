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

        [TestMethod]
        public int[] AsteroidCollision(int[] asteroids)
        {
            Stack<int> stack = new Stack<int>();

            foreach (int asteroid in asteroids)
            {
                bool collision = true;
                while (stack.Count > 0 && asteroid < 0 && stack.Peek() > 0)
                {
                    if (Math.Abs(asteroid) > stack.Peek())
                    {
                        stack.Pop();
                    }
                    else if (Math.Abs(asteroid) == stack.Peek())
                    {
                        stack.Pop();
                        collision = false;
                        break;
                    }
                    else
                    {
                        collision = false;
                        break;
                    }
                }

                if (collision)
                {
                    stack.Push(asteroid);
                }
            }

            int[] result = stack.ToArray();
            Array.Reverse(result);
            return result;
        }

        public bool WordBreak(string s, IList<string> wordDict)
        {
            var wordSet = new HashSet<string>(wordDict);

            var dp = new bool[s.Length + 1];
            dp[0] = true;

            for (int i = 1; i <= s.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (dp[j] && wordSet.Contains(s.Substring(j, i - j)))
                    {
                        dp[i] = true;
                        break;
                    }
                }
            }

            return dp[s.Length];
        }

        public string LongestPalindrome(string s)
        {
            int n = s.Length;
            if (n == 0)
            {
                return "";
            }

            bool[,] dp = new bool[n, n];
            int start = 0;
            int maxLength = 1;

            // All substrings of length 1 are palindromic
            for (int i = 0; i < n; i++)
            {
                dp[i, i] = true;
            }

            // Check for palindromic substrings of length 2
            for (int i = 0; i < n - 1; i++)
            {
                if (s[i] == s[i + 1])
                {
                    dp[i, i + 1] = true;
                    start = i;
                    maxLength = 2;
                }
            }

            // Check for palindromic substrings of length >= 3
            for (int length = 3; length <= n; length++)
            {
                for (int i = 0; i <= n - length; i++)
                {
                    int j = i + length - 1;

                    if (dp[i + 1, j - 1] && s[i] == s[j])
                    {
                        dp[i, j] = true;

                        if (length > maxLength)
                        {
                            start = i;
                            maxLength = length;
                        }
                    }
                }
            }

            return s.Substring(start, maxLength);
        }
    }
}
