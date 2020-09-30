/*
Given a string, determine if it is a palindrome, considering only alphanumeric characters and ignoring cases.
Note: For the purpose of this problem, we define empty string as valid palindrome.

Example 1:
Input: "A man, a plan, a canal: Panama"
Output: true

Example 2:
Input: "race a car"
Output: false

Constraints: s consists only of printable ASCII character
 */

using System;
using System.Text;

namespace ValidPalindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();
            Console.WriteLine(solution.IsPalindrome("A man, a plan, a canal: Panama"));
            Console.WriteLine(solution.IsPalindrome(" .a. "));
        }
    }

    public class Solution
    {
        public bool IsPalindrome(string s)
        {
            var result = true;
            var sb = new StringBuilder(s.ToUpper());
            while (sb.Length != 0 && result)
            {
                while (sb.Length != 0 && !Char.IsLetterOrDigit(sb[0])) sb.Remove(0, 1);
                while (sb.Length != 0 && !Char.IsLetterOrDigit(sb[sb.Length - 1])) sb.Remove(sb.Length - 1, 1);

                var size = sb.Length;
                if (size < 2)
                    break;

                var h = sb[0];
                var t = sb[size - 1];
                result = h == t;
                sb.Remove(size - 1, 1);
                sb.Remove(0, 1);
            }

            return result;
        }
    }
}
