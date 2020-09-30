/*
Given a column title as appear in an Excel sheet, return its corresponding column number.
For example:
    A -> 1
    B -> 2
    C -> 3
    ...
    Z -> 26
    AA -> 27
    AB -> 28 
    ...
Example 1:
Input: "A"
Output: 1

Example 2:
Input: "AB"
Output: 28

Example 3:
Input: "ZY"
Output: 701
 
Constraints:

1 <= s.length <= 7
s consists only of uppercase English letters.
s is between "A" and "FXSHRXW".
*/

using System;
using System.Linq;

namespace ExcelSheetColumnNumber
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
        public int TitleToNumber(string s)
        {
            var result = 0;
            var order = 0;
            foreach (char ch in s.Reverse())
            {
                result += (int)(ch - 'A' + 1) * (int)Math.Pow(26, order);
                order++;
            }

            return result;
        }
    }
}
