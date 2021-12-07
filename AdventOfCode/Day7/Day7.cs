using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Day7
{
    public class Day7
    {
        public static long ExecutePart1(string filename, bool debug = false)
        {
            Console.WriteLine("Part One");
            return Execute(filename, false, debug);
        }

        public static long ExecutePart2(string filename, bool debug = false)
        {
            Console.WriteLine("Part Two");
            return Execute(filename, true, debug);
        }

        public static long Execute(string filename, bool stepped, bool debug)
        {
            var lines = File.ReadAllLines(filename);
            Console.WriteLine("Lines: " + lines.Count());
            var crabs = lines.First().Split(',').Select(x => int.Parse(x)).ToList();

            var max = crabs.Max();

            Dictionary<int, int> cost = new Dictionary<int, int>();
            for (int i=0; i<=max; i++)
            {
                var sum = 0;
                foreach (var c in crabs)
                {
                    if (stepped)
                    {
                        for (int j = 1; j <= Math.Abs(c - i); j++)
                        {
                            sum += j;
                        }
                    } else
                    {
                        sum += Math.Abs(c - i);
                    }
                }
                cost[i] = sum;
            }

            var result = cost.Values.Min();
            Console.WriteLine("Answer: " + result);
            Console.WriteLine();
            return result;
        }
    }
}
