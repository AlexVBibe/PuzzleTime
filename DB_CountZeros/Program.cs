using System;
using System.Collections.Generic;
using System.Linq;

namespace DB_CountZeros
{
    class Program
    {
        static void Main(string[] args)
        {
            CountZeros();
        }

        private static int CountZeros()
        {
            var list = new List<int[]>();
            list.Add(new[] { 0, 0, 0, 0, 1 });
            list.Add(new[] { 0, 0, 0, 0, 1 });
            list.Add(new[] { 0, 1, 1, 1, 1 });
            list.Add(new[] { 0, 0, 0, 0, 1 });

            if (list.Count == 0)
                return -1;

            var result = -1;
            var startIndex = list.First().Length - 1;
            var rowsCount = list.Count - 1;
            for (var j = rowsCount; j >= 0; j--)
            {
                var row = list[j];
                for (var i = startIndex; i >= 0; i--)
                {
                    if (row[i] == 1)
                    {
                        result = i;
                        startIndex = i - 1;
                    }
                    else
                        break;
                }
            }


            return result;
        }
    }
}
