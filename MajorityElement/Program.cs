/*
Given an array of size n, find the majority element. The majority element is the element that appears more than ⌊ n/2 ⌋ times.
You may assume that the array is non-empty and the majority element always exist in the array.

Example 1:
Input: [3,2,3]
Output: 3

Example 2:
Input: [2,2,1,1,1,2,2]
Output: 2
*/

using System;

namespace MajorityElement
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
        public int MajorityElement(int[] nums)
        {
            var size = nums.Length;
            if (size == 1)
                return nums[0];

            Array.Sort(nums, 0, size);
            var middle = size / 2;

            if (middle + 1 < size && nums[middle] == nums[middle + 1])
                return nums[middle];

            if (middle - 1 >= 0 && nums[middle - 1] == nums[middle])
                return nums[middle];

            return 0;
        }
    }
}
