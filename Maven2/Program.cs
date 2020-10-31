using System;
using System.Collections.Generic;

namespace Maven2
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new int [100000];
            var result1 = Solution(numbers);
            var result2 = Solution1(numbers);
        }

        private static int Solution(int[] numbers)
        {
            var set = new Dictionary<int, List<int>>
            {
                [0] = new List<int> {-1}
            };

            var size = numbers.Length;
            var sum = 0;
            var result = 0;
            for (var i = 0; i < size; i++)
            {
                var number = numbers[i];
                sum += numbers[i];
                var contains = set.ContainsKey(sum);
                if (number == 0 || sum == 0 || contains)
                {
                    var list = set[sum];
                    result += list.Count;
                    if (result >= 1000000000)
                        return -1;
                }

                if (!contains)
                    set[sum] = new List<int>();
                set[sum].Add(i);
            }

            return result;
        }

        private static int Solution1(int[] numbers)
        {
            // 2 -2 3 0 4 -7
            // 2  0 3 3 7  0

            var size = numbers.Length;
            var result = 0;
            for (var i = 0; i < size; i++)
            {
                var sum = 0;
                for (var j = i; j < size; j++)
                {
                    var number = numbers[j];
                    sum += number;
                    if (sum == 0)
                        result++;
                }
            }

            return result > 1000000000
                ? -1
                : result;
        }
    }
}
