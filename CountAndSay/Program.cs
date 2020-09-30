/*
The count-and-say sequence is the sequence of integers with the first five terms as following:

1.     1
2.     11
3.     21
4.     1211
5.     111221
1 is read off as "one 1" or 11.
11 is read off as "two 1s" or 21.
21 is read off as "one 2, then one 1" or 1211.

Given an integer n where 1 ≤ n ≤ 30, generate the nth term of the count-and-say sequence. You can do so recursively, in other words from the previous member read off the digits, counting the number of digits in groups of the same digit.

Note: Each term of the sequence of integers will be represented as a string.


Example 1:

Input: 1
Output: "1"
Explanation: This is the base case.
Example 2:

Input: 4
Output: "1211"
Explanation: For n = 3 the term was "21" in which we have two groups "2" and "1", "2" can be read as "12" which means frequency = 1 and value = 2, the same way "1" is read as "11", so the answer is the concatenation of "12" and "11" which is "1211".

 */

using System;
using System.Collections.Generic;

namespace CountAndSay
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class Solution
    {
        public string CountAndSay(int n)
        {
            var result = string.Empty;
            var index = 1;
            while (index <= n)
            {
                if (index == 1)
                    result = "1";
                else
                {
                    var newResult = string.Empty;
                    var groups = Count(result);
                    foreach (var gr in groups)
                    {
                        newResult += $"{gr.Value}{gr.Key}";
                    }
                    result = newResult;
                }
                index++;
            }

            return result;
        }

        private class Group
        {
            public Char Key;
            public int Value;
        }

        private IEnumerable<Group> Count(string str)
        {
            var index = 0;
            while (index < str.Length)
            {
                var counter = 1;
                var ch = str[index++];
                while (index < str.Length && ch == str[index]) { index++; counter++; }
                yield return new Group { Key = ch, Value = counter };
            }
        }
    }
}
