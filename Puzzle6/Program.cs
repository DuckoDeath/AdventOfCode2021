using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime;

namespace Puzzle6
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Puzzle 6");
            Console.WriteLine();
            ExecutePart1(@"..\..\input.txt");
            ExecutePart2(@"..\..\input.txt");

            Console.WriteLine("Press any key");
            Console.ReadKey();
        }

        public static long ExecutePart1(string filename, bool debug = false)
        {
            GCSettings.LargeObjectHeapCompactionMode = GCLargeObjectHeapCompactionMode.CompactOnce;
            Console.WriteLine("Part One");
            var lines = File.ReadAllLines(filename);
            Console.WriteLine("Lines: " + lines.Count());
            var fish = lines.First().Split(',').Select(x => int.Parse(x)).ToList();
            Dictionary<int, long> fishes = CreateFishes();
            foreach (var f in fish)
            {
                fishes[f]++;
            }

            for (int i=0; i < 80; i++)
            {
                Dictionary<int, long> newFishes = new Dictionary<int, long>();
                foreach (var f in fishes.Keys.OrderByDescending(x=>x))
                {
                    var cnt = fishes[f];
                    if (f==0)
                    {
                        newFishes[8] = cnt;
                        newFishes[6] += cnt;
                    } else
                    {
                        newFishes[f-1] = cnt;
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

        public static long ExecutePart2(string filename, bool debug = false)
        {
            GCSettings.LargeObjectHeapCompactionMode = GCLargeObjectHeapCompactionMode.CompactOnce;
            Console.WriteLine("Part Two");
            var lines = File.ReadAllLines(filename);
            Console.WriteLine("Lines: " + lines.Count());
            var fish = lines.First().Split(',').Select(x => int.Parse(x)).ToList();
            Dictionary<int, long> fishes = CreateFishes();
            foreach (var f in fish)
            {
                fishes[f]++;
            }

            for (int i = 0; i < 256; i++)
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

        private static Dictionary<int,long> CreateFishes()
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

