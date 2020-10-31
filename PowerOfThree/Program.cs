/*
Given an integer n, return true if it is a power of three. Otherwise, return false.
An integer n is a power of three, if there exists an integer x such that n == 3x.

Example 1:
Input: n = 27
Output: true

Example 2:

Input: n = 0
Output: false

Example 3:
Input: n = 9
Output: true

 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace PowerOfThree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public class Solution
        {
            public bool IsPowerOfThree(int n)
            {
                if (n < 0)
                    return false;

                var digits = new List<int>();
                while (n > 2)
                {
                    digits.Add(n % 3);
                    n = n / 3;
                }
                digits.Add(n);

                return !digits.Any(d => d == 2) &&
                       digits.Count(d => d == 1) == 1;
            }
        }
    }
}
