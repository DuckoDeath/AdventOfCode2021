﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Puzzle3
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Puzzle 3");
            Console.WriteLine();
            ExecutePart1(@"..\..\input.txt");
            ExecutePart2(@"..\..\input.txt");

            Console.WriteLine("Press any key");
            Console.ReadKey();
        }

    }
}
