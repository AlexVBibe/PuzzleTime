/*
Given two sorted arrays nums1 and nums2 of size m and n respectively, return the median of the two sorted arrays.
The overall run time complexity should be O(log (m+n)).


Example 1:

Input: nums1 = [1,3], nums2 = [2]
Output: 2.00000
Explanation: merged array = [1,2,3] and median is 2.
Example 2:

Input: nums1 = [1,2], nums2 = [3,4]
Output: 2.50000
Explanation: merged array = [1,2,3,4] and median is (2 + 3) / 2 = 2.5
*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace MedianOfTwoSortedArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Hello World!: {Solution.FindMedianSortedArrays(new int[0] , new[] { 1, 2, 3, 4, 5 })}");
        }
    }

    public class Solution
    {
        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            var result = new List<int>();
            var index1 = 0;
            var index2 = 0;
            while ((index1 < nums1.Length) && (index2 < nums2.Length))
            {
                if (nums1[index1] < nums2[index2])
                {
                    result.Add(nums1[index1++]);
                }
                else if (nums1[index1] > nums2[index2])
                {
                    result.Add(nums2[index2++]);
                }
                else
                {
                    result.Add(nums1[index1++]);
                    result.Add(nums2[index2++]);
                }
            }
            if (index1 >= nums1.Length) result.AddRange(nums2.Skip(index2));
            else if (index2 >= nums2.Length) result.AddRange(nums1.Skip(index1));

            if (result.Count == 1)
                return result[0];
            if (result.Count == 2)
                return (result[0] + result[1]) / 2.0;

            if (result.Count % 2 != 0)
                return result[result.Count / 2];
            
            var middle = result.Count / 2;
            return (result[middle - 1] + result[middle]) / 2.0;
        }
    }
}
