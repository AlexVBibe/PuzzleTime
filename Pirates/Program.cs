using System;
using System.Collections.Generic;
using System.Linq;

namespace Pirates
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Write("----Input, like: (1 3 0 1 3): ");
                var input = Console.ReadLine();
                var path = input.
                    Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).
                    Select(number => Int32.Parse(number)).
                    ToArray();

                var result = PathFinder(path).ToList();

                Console.WriteLine(string.Format("Cycled Items: ({0})", string.Join(", ", result)));
                Console.WriteLine(string.Format("Result: {0}", result.Count()));
                Console.WriteLine("Again, y/n?");
            } while (Console.ReadLine() == "y");
        }

        public static IEnumerable<int> PathFinder(int[] path)
        {
            if (path.Length > 2)
            {
                var checkPoints = new int[5000];
                checkPoints[0] = 1;

                for (int i = 0; i < path.Length; i++)
                {
                    var address = path[i];
                    if (checkPoints[address] == 0)
                        checkPoints[address] = i + 1;
                    else
                    {
                        var startOfTheLoop = checkPoints[address] - 1;
                        return path.Skip(startOfTheLoop).Take(i - startOfTheLoop);
                    }
                }
            }
            return path;
        }
    }
}
