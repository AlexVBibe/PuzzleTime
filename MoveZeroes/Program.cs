/*
Given an array nums, write a function to move all 0's to the end of it while maintaining the relative order of the non-zero elements.

Example:

Input: [0,1,0,3,12]
Output: [1,3,12,0,0]
Note:

You must do this in-place without making a copy of the array.
Minimize the total number of operations.
*/

using System;

namespace MoveZeroes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public class Solution
        {
            public void MoveZeroes(int[] nums)
            {
                var size = nums.Length;
                var index = 0;
                for (var i = 0; i < size; i++)
                {
                    if (nums[i] == 0)
                        continue;
                    nums[index++] = nums[i];
                }

                for (var i = index; i < size; i++)
                    nums[i] = 0;
            }
        }
    }
}
