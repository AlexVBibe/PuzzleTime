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
            Console.WriteLine($"Longest Palindrome {Solution3.LongestPalindrome("babad")}");
        }
    }

    public class Solution3
    {
        public static string LongestPalindrome(string s)
        {
            var letters = s.ToArray();
            var size = letters.Length;
            var result = string.Empty;
            for (var i = 0; i < size; i++)
            {
                var palindrome = IsPalindrome(letters, i, i, size);
                var palindrome2 = IsPalindrome(letters, i, i + 1, size);
                if (palindrome.Length < palindrome2.Length)
                    palindrome = palindrome2;
                if (palindrome.Length > result.Length)
                {
                    result = palindrome;
                }
            }

            return result;
        }

        private static string IsPalindrome(char[] letters, int l, int r, int size)
        {
            while (l >= 0 && r < size && letters[l] == letters[r])
            {
                l--;
                r++;
            }
            return new string(letters.Skip(l + 1).Take(r - l - 1).ToArray());
        }
    }

    public class Solution2
    {
        public static string LongestPalindrome(string s)
        {
            if (IsPalindrome(s)) return s;
            var size = 0;
            var palindrome = "";
            for (var i = 1; i <= s.Length; i++)// asdvsdrabacaba
            {
                for (var j = 0; j < i; j++)
                {
                    if (s[j] != s[i - 1]) continue;
                    var subString = s.Substring(j, i - j);
                    if (!IsPalindrome(subString) || size >= subString.Length) continue;

                    size = subString.Length;
                    palindrome = subString;
                    break; // early exit as longest found
                }
            }

            return palindrome;
        }
        static bool IsPalindrome(string s)
        {
            var reversed = new string(s.Reverse().ToArray());
            return s == reversed;
        }

    }

    public class Solution
    {
        public static string LongestPalindrome(string s)
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

        private static string ReturnPolindrom(char[] letters, int left, int right, int size)
        {
            while (left >= 0 && right < size && letters[left] == letters[right])
            {
                left--;
                right++;
            }

            return new string(letters.Skip(left + 1).Take(right - left - 1).ToArray());

        }
    }

    /**
     * @param {string} s
     * @return {string}
     */
    /*

    var longestPalindrome = function(s) 
    {
        let size = s.length;
        let index = 0;
        let result = '';
        while(index < size) {
            let str1 = poliLength(s, index, index);
            let str2 = poliLength(s, index, index + 1);
            let str = str1.length > str2.length
                ? str1
                : str2;
            
            result = result.length > str.length
                ? result
                : str;
            index++;
        }
        return result;
    };

    var poliLength = function(s, lindex, rindex)
    {
        let size = s.length;
        let start = lindex;
        let length = 1;
        while(lindex >= 0 && 
              rindex < size &&
             s[lindex] == s[rindex]) {
            start = lindex;
            length = Math.max(rindex - lindex + 1, 1);
            lindex--;
            rindex++;
        }

        var result = s.substring(start, start + length);
        return result;
    };
*/
}
