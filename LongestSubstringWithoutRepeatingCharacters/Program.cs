/*
Given a string s, find the length of the longest substring without repeating characters.

Example 1:

Input: s = "abcabcbb"
Output: 3
Explanation: The answer is "abc", with the length of 3.
Example 2:

Input: s = "bbbbb"
Output: 1
Explanation: The answer is "b", with the length of 1.
Example 3:

Input: s = "pwwkew"
Output: 3
Explanation: The answer is "wke", with the length of 3.
Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.
Example 4:

Input: s = ""
Output: 0
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace LongestSubstringWithoutRepeatingCharacters
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
        public int LengthOfLongestSubstring(string s)
        {
            var letters = s.ToArray();
            var hashTable = new Dictionary<char, int>();
            var index = 0;
            var max = 0;
            var start = 0;
            while (index < letters.Length)
            {
                var letter = letters[index];
                if (!hashTable.ContainsKey(letter))
                    hashTable[letter] = index;
                else
                {
                    var prevPosition = hashTable[letter];
                    for (var k = start; k <= prevPosition; k++)
                        hashTable.Remove(letters[k]);
                    start = prevPosition + 1;
                    hashTable[letter] = index;
                }

                index++;
                if (max < hashTable.Keys.Count)
                    max = hashTable.Keys.Count;
            }
            return max;
        }
    }

    /**
     * @param {string} s
     * @return {number}
     */
    /*
    var lengthOfLongestSubstring = function(s)
    {
        let sequence = [...s];
        let size = sequence.length;
            if (size == 0)
        return 0;
        if (size == 1)
        return 1;
        
        let maxLength = 1;
        let index = 1;
        let length = 1;
        let start = 0;
            while(index<size) {
            let currSymbol = sequence[index];
            let jindex = index - 1;
            while(jindex >= start && sequence[jindex] !== currSymbol) jindex--;
            if (jindex<start) { // we walked whole string no dups
                length++;
                if (maxLength<length) {
                    maxLength = length;
                }
            } else {
                let oldStart = start
                start = jindex + 1;
                length = length - (start - oldStart) + 1;
            }
            index++;
        }
        return maxLength;
    };
    */
}
