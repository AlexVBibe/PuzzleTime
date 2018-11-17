using System;
using System.Collections.Generic;
using System.Linq;

namespace Zombit
{
    class Program
    {
        class Interval
        {
            public int Left { get; set; }
            public int Right { get; set; }

            public Interval(int left, int right)
            {
                this.Left = left;
                this.Right = right;
                if (left > right)
                    throw new Exception("Left should be less than or equal to Right");
            }
        };

        public static int solution(int[] A)
        {
            var dictionary = new Dictionary<int, int>();

            A.ForEach(n => dictionary[n] = dictionary[n] + 1);

            return dictionary.Where(pair => pair.Value % 2 != 0).First().Key;
        }

        static void Main(string[] args)
        {
            do
            {
                Console.Write("Input intervals, for instance [1, 3] [5, 6] :");
                var input = Console.ReadLine();
                var numbers = input.
                    Split(new char[] { '[', ']', ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).
                    Select(number => Int32.Parse(number)).
                    ToArray();

                var intervals = new List<Interval>();
                // build intervals
                for (int i = 0; i < numbers.Length; i+=2)
                {
                    intervals.Add(new Interval(numbers[i], numbers[i + 1]));
                }
                var mergedIntervaks = GetMergedIntervals(intervals);
                Console.WriteLine(string.Format("Total Amount of Time: {0} ", mergedIntervaks.Select(r => r.Right - r.Left).Sum()));

                Console.WriteLine("Again, y/n?");
            } while (Console.ReadLine() == "y");
        }

        static IEnumerable<Interval> GetMergedIntervals(IEnumerable<Interval> intervals)
        {
            var result = intervals.ToList();
            result.Sort((x1, x2) => x1.Left - x2.Left);

            var r1 = result[0];
            for (int i = 1; i < result.Count; i++)
            {
                var r2 = result[i];
                if (r1.Right >= r2.Left && r1.Right >= r2.Right)
                {
                    result.RemoveAt(i--);
                }
                else if (r1.Right > r2.Left && r1.Right < r2.Right)
                {
                    r1.Right = r2.Right;
                    result.RemoveAt(i--);
                }
                else
                {
                    r1 = r2;
                }
            }
            return result;
        }
    }
}
