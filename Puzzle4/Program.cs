using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Puzzle4
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

        public static int ExecutePart1(string filename)
        {
            Console.WriteLine("Part One");
            var lines = File.ReadAllLines(filename);
            Console.WriteLine("Lines: " + lines.Count());

            var result = 0;
            Console.WriteLine("Answer: " + result);
            Console.WriteLine();
            throw new NotImplementedException();
            //return result;
        }

        public static int ExecutePart2(string filename)
        {
            Console.WriteLine("Part Two");
            var lines = File.ReadAllLines(filename);
            Console.WriteLine("Lines: " + lines.Count());

            var result = 0;
            Console.WriteLine("Answer: " + result);
            Console.WriteLine();
            throw new NotImplementedException();
            //return result;
        }

    }
}
