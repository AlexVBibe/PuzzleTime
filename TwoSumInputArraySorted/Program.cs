/*
Given an array of integers that is already sorted in ascending order, find two numbers such that they add up to a specific target number.
The function twoSum should return indices of the two numbers such that they add up to the target, where index1 must be less than index2.

Note:
Your returned answers (both index1 and index2) are not zero-based.
You may assume that each input would have exactly one solution and you may not use the same element twice.
 
Example 1:
Input: numbers = [2,7,11,15], target = 9
Output: [1,2]
Explanation: The sum of 2 and 7 is 9. Therefore index1 = 1, index2 = 2.

Example 2:
Input: numbers = [2,3,4], target = 6
Output: [1,3]

Example 3:
Input: numbers = [-1,0], target = -1
Output: [1,2]
 
Constraints:
2 <= nums.length <= 3 * 104
-1000 <= nums[i] <= 1000
nums is sorted in increasing order.
-1000 <= target <= 1000
*/

using System;

namespace TwoSumInputArraySorted
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
        public int[] TwoSum(int[] numbers, int target)
        {
            var size = numbers.Length;
            var index1 = 0;
            while (index1 < size)
            {
                var number1 = numbers[index1];
                var delta = target - number1;
                if (delta < number1)
                    return null;

                var index2 = index1 + 1;
                while (index2 < size)
                {
                    var number2 = numbers[index2];
                    if (delta == number2)
                        return new int[] { index1 + 1, index2 + 1 };
                    if (number1 + number2 > target)
                        break;
                    index2++;
                }

                index1++;
            }

            return null;
        }
    }

    public class Solution2
    {
        public int[] TwoSum(int[] numbers, int target)
        {
            var size = numbers.Length;
            var index1 = 0;
            var index2 = size - 1;
            while (index1 < index2 && index2 > 0)
            {
                var sum = numbers[index1] + numbers[index2];
                if (sum > target)
                    index2--;
                else if (sum < target)
                    index1++;
                else if (sum == target)
                    return new int[] { index1 + 1, index2 + 1 };
            }

            return null;
        }
    }
}
