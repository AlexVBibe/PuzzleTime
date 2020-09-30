/*
 Given a sorted array and a target value, return the index if the target is found. If not, return the index where it would be if it were inserted in order.

You may assume no duplicates in the array.

Example 1:

Input: [1,3,5,6], 5
Output: 2
Example 2:

Input: [1,3,5,6], 2
Output: 1
Example 3:

Input: [1,3,5,6], 7
Output: 4
Example 4:

Input: [1,3,5,6], 0
Output: 0

 */
using System;

namespace SearchInsertPosition
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
        public int SearchInsert(int[] nums, int target)
        {
            return QuickIndex(nums, 0, nums.Length - 1, target);
        }

        private int QuickIndex(int[] nums, int left, int right, int number)
        {
            if (left > right)
                return left;
            if (right < left)
                return right >= 0 ? right : 0;

            var middle = (right + left) / 2;

            var middleValue = nums[middle];
            if (middleValue < number)
            {
                return QuickIndex(nums, middle + 1, right, number);
            }

            if (middleValue > number)
            {
                return QuickIndex(nums, left, middle - 1, number);
            }

            return middle;
        }
    }
}
