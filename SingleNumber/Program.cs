/*
Given a non-empty array of integers, every element appears twice except for one. Find that single one.

Note:
Your algorithm should have a linear runtime complexity. Could you implement it without using extra memory?

Example 1:
Input: [2,2,1]
Output: 1

Example 2:
Input: [4,1,2,1,2]
Output: 4 
 */

using System;

namespace SingleNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();
            Console.WriteLine(solution.SingleNumber(new[] {4, 1, 2, 1, 2}));
        }
    }

    public class Solution
    {
        public int SingleNumber(int[] nums)
        {
            var size = nums.Length;
            Array.Sort(nums, 0, size);
            var index = 0;
            while (index < size)
            {
                if (index == size - 1 || nums[index] != nums[index + 1])
                    return nums[index];
                index += 2;
            }

            return nums[size - 1];
        }
    }
}
