/*
Given a positive integer, return its corresponding column title as appear in an Excel sheet.
For example:

    1 -> A
    2 -> B
    3 -> C
    ...
    26 -> Z
    27 -> AA
    28 -> AB 
    ...
Example 1:
Input: 1
Output: "A"

Example 2:
Input: 28
Output: "AB"

Example 3:
Input: 701
Output: "ZY"
*/

using System;
using System.Text;

namespace ExcelSheetColumnTitle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public class Solution
        {
            public string ConvertToTitle(int n)
            {
                var asciiCode = 'A';
                var alphabetSize = 26;
                var result = new StringBuilder();
                while (n > 0)
                {
                    n--;
                    var reminder = n % alphabetSize;
                    n = (int)Math.Floor((double)n / alphabetSize);

                    var symbol = ((char)(asciiCode + reminder)).ToString();
                    result.Insert(0, symbol);
                }
                return result.ToString();
            }
        }
    }
}
