using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Day6
{
    public class Day6
    {
        public static long ExecutePart1(string filename, bool debug = false)
        {
            Console.WriteLine("Part One");
            return Execute(filename, 80, debug);
        }

        public static long ExecutePart2(string filename, bool debug = false)
        {
            Console.WriteLine("Part Two");
            return Execute(filename, 256, debug);
        }

        public static long Execute(string filename, int numOfDays, bool debug)
        {
            var lines = File.ReadAllLines(filename);
            Console.WriteLine("Lines: " + lines.Count());
            var fish = lines.First().Split(',').Select(x => int.Parse(x)).ToList();
            Dictionary<int, long> fishes = CreateFishes();
            foreach (var f in fish)
            {
                fishes[f]++;
            }

            for (int i = 0; i < numOfDays; i++)
            {
                Dictionary<int, long> newFishes = new Dictionary<int, long>();
                foreach (var f in fishes.Keys.OrderByDescending(x => x))
                {
                    var cnt = fishes[f];
                    if (f == 0)
                    {
                        newFishes[8] = cnt;
                        newFishes[6] += cnt;
                    }
                    else
                    {
                        newFishes[f - 1] = cnt;
                    }
                }
                fishes = newFishes;
            }

            long result = 0;
            foreach (var f in fishes)
            {
                result += f.Value;
            }
            Console.WriteLine("Answer: " + result);
            Console.WriteLine();
            return result;
        }

        private static Dictionary<int, long> CreateFishes()
        {
            Dictionary<int, long> fishes = new Dictionary<int, long>();
            for (int i = 0; i <= 8; i++)
            {
                fishes.Add(i, 0);
            }
            return fishes;
        }
    }
}
