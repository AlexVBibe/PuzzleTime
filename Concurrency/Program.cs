﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concurrency
{
    class Program
    {
        static void Main(string[] args)
        {
            var bag = new ConcurrentBag<int>();
        }
    }
}
