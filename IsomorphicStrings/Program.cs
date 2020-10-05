/*
Given two strings s and t, determine if they are isomorphic.

Two strings are isomorphic if the characters in s can be replaced to get t.

All occurrences of a character must be replaced with another character while preserving the order of characters. No two characters may map to the same character but a character may map to itself.

Example 1:

Input: s = "egg", t = "add"
Output: true
Example 2:

Input: s = "foo", t = "bar"
Output: false
Example 3:

Input: s = "paper", t = "title"
Output: true
Note:
You may assume both s and t have the same length.
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace IsomorphicStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public bool IsIsomorphic(string s, string t)
        {
            if (s == null || t == null)
                return false;

            if (s == t)
                return true;

            var size = s.Length;
            if (t.Length != size)
                return false;

            for (var i = 0; i < size; i++)
            {
                var valueS = s[i];
                var valueT = t[i];
                var index = i + 1;
                while (index < size)
                {
                    if (s[index] == valueS)
                    {
                        if (t[index] != valueT)
                            return false;
                    }
                    if (t[index] == valueT)
                    {
                        if (s[index] != valueS)
                            return false;
                    }
                    index++;
                }
            }

            return true;
        }

        public bool IsIsomorphic1(string s, string t)
        {
            var tagsA = new Dictionary<char, int>();
            var tagsB = new Dictionary<char, int>();
            var arrayA = s.ToArray();
            var arrayB = t.ToArray();

            for (var i = 0; i < s.Length; i++)
            {
                var chA = arrayA[i];
                if (!tagsA.ContainsKey(chA))
                    tagsA[chA] = i;
                arrayA[i] = (char)tagsA[chA];

                var chB = arrayB[i];
                if (!tagsB.ContainsKey(chB))
                    tagsB[chB] = i;
                arrayB[i] = (char)tagsB[chB];
            }

            var strA = new string(arrayA);
            var strB = new string(arrayB);
            return strA == strB;
        }
    }
}
