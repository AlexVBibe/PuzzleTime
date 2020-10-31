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
