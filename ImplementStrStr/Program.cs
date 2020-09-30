/*
Implement strStr().

Return the index of the first occurrence of needle in haystack, or -1 if needle is not part of haystack.

Example 1:

Input: haystack = "hello", needle = "ll"
Output: 2
Example 2:

Input: haystack = "aaaaa", needle = "bba"
Output: -1
Clarification:

What should we return when needle is an empty string? This is a great question to ask during an interview.

For the purpose of this problem, we will return 0 when needle is an empty string. This is consistent to C's strstr() and Java's indexOf().

 

Constraints:

haystack and needle consist only of lowercase English characters.
 */

using System;

namespace ImplementStrStr
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
        public int StrStr(string haystack, string needle)
        {
            if (string.IsNullOrEmpty(needle))
                return 0;

            if (string.IsNullOrEmpty(haystack))
                return -1;

            var size = haystack.Length - needle.Length;
            if (size < 0)
                return -1;
            else if (size == 0)
                return haystack == needle ? 0 : -1;

            for (var i = 0; i <= size; i++)
            {
                var j = 0;
                var match = haystack[i + j] == needle[j++];
                while (match && j < needle.Length)
                    match &= (haystack[i + j] == needle[j++]);

                if (match)
                    return i;
            }

            return -1;
        }
    }
}
