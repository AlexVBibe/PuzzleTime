/*
You are given a sorted unique integer array nums.

Return the smallest sorted list of ranges that cover all the numbers in the array exactly. That is, each element of nums is covered by exactly 
one of the ranges, and there is no integer x such that x is in one of the ranges but not in nums.

Each range [a,b] in the list should be output as:

"a->b" if a != b
"a" if a == b

Example 1:

Input: nums = [0,1,2,4,5,7]
Output: ["0->2","4->5","7"]
Explanation: The ranges are:
[0,2] --> "0->2"
[4,5] --> "4->5"
[7,7] --> "7"

Example 2:
Input: nums = [0,2,3,4,6,8,9]
Output: ["0","2->4","6","8->9"]
Explanation: The ranges are:
[0,0] --> "0"
[2,4] --> "2->4"
[6,6] --> "6"
[8,9] --> "8->9"
Example 3:

Input: nums = []
Output: []
Example 4:

Input: nums = [-1]
Output: ["-1"]
Example 5:

Input: nums = [0]
Output: ["0"]
*/

using System;
using System.Collections.Generic;

namespace SummaryRanges
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
        public IList<string> SummaryRanges(int[] nums)
        {
            var result = new List<string>();
            var size = nums.Length;
            if (size == 0)
                return result;
            else if (size == 1)
            {
                result.Add(nums[0].ToString());
                return result;
            }

            var start = nums[0];
            var count = 0;
            for (var i = 1; i < size; i++)
            {
                var expected = start + count + 1;
                var number = nums[i];
                if (expected == number)
                    count++;
                else
                {
                    if (count == 0)
                        result.Add(start.ToString());
                    else
                        result.Add($"{start}->{start + count}");
                    start = number;
                    count = 0;
                }

                if (i + 1 == size)
                {
                    if (count == 0)
                        result.Add(number.ToString());
                    else
                        result.Add($"{start}->{start + count}");
                }
            }

            return result;
        }
    }
}
