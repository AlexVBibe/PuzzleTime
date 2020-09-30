/*
 Given a string s, find the longest palindromic substring in s. You may assume that the maximum length of s is 1000.
Example 1:
Input: "babad"
Output: "bab"
Note: "aba" is also a valid answer.

Example 2:
Input: "cbbd"
Output: "bb"
 */

using System;
using System.Linq;

namespace LongestPalindromicSubstring
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
        public string LongestPalindrome(string s)
        {
            var letters = s.ToArray();
            var size = letters.Length;
            var max = string.Empty;
            for (var i = 0; i < size; i++)
            {
                var palindrome = ReturnPolindrom(letters, i, i, size);
                var nextToI = i + 1;
                if (nextToI < s.Length && s[i] == s[nextToI])
                {
                    var palindrome2 = ReturnPolindrom(letters, i, nextToI, size);
                    if (palindrome.Length < palindrome2.Length)
                        palindrome = palindrome2;
                }

                if (palindrome.Length >= max.Length)
                    max = palindrome;
            }

            return max;
        }

        private string ReturnPolindrom(char[] letters, int left, int right, int size)
        {
            while (left >= 0 && right < size && letters[left] == letters[right])
            {
                left--;
                right++;
            }

            return new string(letters.Skip(left + 1).Take(right - left - 1).ToArray());

        }
    }
}
