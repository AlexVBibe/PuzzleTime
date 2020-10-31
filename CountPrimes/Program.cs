using System;
using System.Collections.Generic;
using System.Linq;

namespace CountPrimes
{
    class Program
    {
        static void Main(string[] args)
        {
            var primes = GetPrimeNumbers(100);
            var countPrimes = primes.Count;
            Console.WriteLine(countPrimes);
        }

        private static IList<int> GetPrimeNumbers(int n)
        {
            var isPrime = new int[n];

            for (var i = 2; i * i < n; i++)
            {
                if (isPrime[i] != 0)
                    continue;

                for (var j = i * i; j < n; j += i)
                {
                    isPrime[j] = 1;
                }
            }

            var position = 1;
            return isPrime.Skip(2)
                          .Select(number =>
                                 {
                                     position++;
                                     return number;
                                 })
                          .Where(number => number == 0)
                          .Select(_ => position)
                          .ToList();
        }
    }
}
