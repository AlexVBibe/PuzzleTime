using System;
using System.Collections.Generic;
using System.Linq;

namespace SpecialString
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = SubstrCount(0, "aaaa");
            Console.WriteLine(result);
        }

        // Complete the substrCount function below.
        static long SubstrCount(int n, string s)
        {
            var length = s.Length;
            var result = 0;
            var size = 2;
            var index = 0;
            while (size <= length)
            {
                var start = index;
                while (start + size <= length)
                {
                    if (IsSpecialString(start, size, s))
                        result++;
                    start++;
                }

                size++;
            }

            return result + length;
        }

        private static bool IsSpecialString(int start, int size, string subStr)
        {
            if (size == 1)
                return true;
            var count = size % 2;
            if (count == 0)
            {
                var ch = subStr[start];
                var counter = 0;
                while (counter < size && ch == subStr[counter]) counter++;
                return counter == size;
            }

            var s = subStr.Skip(start).Take(size);
            var d = s.Distinct().Count();
            if (d == 1)
                return true;
            if (d != 2)
                return false;
            var middle = subStr[size / 2];
            return subStr[0] != middle;
        }
    }
}
