using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Puzzle5
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Puzzle 5");
            Console.WriteLine();
            ExecutePart1(@"..\..\input.txt");
            ExecutePart2(@"..\..\input.txt");

            Console.WriteLine("Press any key");
            Console.ReadKey();
        }

        public static int ExecutePart1(string filename, bool debug = false)
        {
            Console.WriteLine("Part One");
            var lines = File.ReadAllLines(filename);
            Console.WriteLine("Lines: " + lines.Count());
            var segments = new List<Segment>();
            foreach (var l in lines)
            {
                var parts = l.Split(new[] { "->" }, StringSplitOptions.RemoveEmptyEntries);
                var x = parts[0];
                var y = parts[1];
                var s = new Segment(int.Parse(x.Split(',')[0]), int.Parse(x.Split(',')[1]), int.Parse(y.Split(',')[0]), int.Parse(y.Split(',')[1]));
                segments.Add(s);
            }
            var maxX = segments.Max(x => x.X1 > x.X2 ? x.X1 : x.X2)+1;
            var maxY = segments.Max(x => x.Y1 > x.Y2 ? x.Y1 : x.Y2)+1;
            int[,] map = new int[maxX,maxY];
            foreach (var s in segments)
            {
                if (s.X1==s.X2)
                {
                    if (debug) Console.WriteLine("Mapping " + s);
                    var done = false;
                    int y = s.Y1;
                    while (!done)
                    {
                        map[s.X1, y]++;
                        if (debug) PrintMap(map);
                        if (y==s.Y2)
                        {
                            done = true;
                        } else
                        {
                            y += (s.Y1 < s.Y2 ? 1 : -1);
                        }
                    }
                } else if (s.Y1==s.Y2)
                {
                    if (debug) Console.WriteLine("Mapping " + s);
                    var done = false;
                    int x = s.X1;
                    while (!done)
                    {
                        map[x, s.Y1]++;
                        if (debug) PrintMap(map);
                        if (x == s.X2)
                        {
                            done = true;
                        }
                        else
                        {
                            x += (s.X1 < s.X2 ? 1 : -1);
                        }
                    }
                } else
                {
                    if (debug) Console.WriteLine("Skipping " + s);
                }
            }
            var result = 0;
            for (int x=0; x<maxX; x++)
            {
                for (int y=0; y<maxY; y++)
                {
                    if (map[x, y] >= 2) result++;
                }
            }
            PrintMap(map);
            Console.WriteLine("Answer: " + result);
            Console.WriteLine();
            return result;
        }

        public static int ExecutePart2(string filename, bool debug = false)
        {
            Console.WriteLine("Part Two");
            var lines = File.ReadAllLines(filename);
            Console.WriteLine("Lines: " + lines.Count());
            var segments = new List<Segment>();
            foreach (var l in lines)
            {
                var parts = l.Split(new[] { "->" }, StringSplitOptions.RemoveEmptyEntries);
                var x = parts[0];
                var y = parts[1];
                var s = new Segment(int.Parse(x.Split(',')[0]), int.Parse(x.Split(',')[1]), int.Parse(y.Split(',')[0]), int.Parse(y.Split(',')[1]));
                segments.Add(s);
            }
            var maxX = segments.Max(x => x.X1 > x.X2 ? x.X1 : x.X2) + 1;
            var maxY = segments.Max(x => x.Y1 > x.Y2 ? x.Y1 : x.Y2) + 1;
            int[,] map = new int[maxX, maxY];
            foreach (var s in segments)
            {
                if (s.X1 == s.X2)
                {
                    if (debug) Console.WriteLine("Mapping " + s);
                    var done = false;
                    int y = s.Y1;
                    while (!done)
                    {
                        map[s.X1, y]++;
                        if (debug) PrintMap(map);
                        if (y == s.Y2)
                        {
                            done = true;
                        }
                        else
                        {
                            y += (s.Y1 < s.Y2 ? 1 : -1);
                        }
                    }
                }
                else if (s.Y1 == s.Y2)
                {
                    if (debug) Console.WriteLine("Mapping " + s);
                    var done = false;
                    int x = s.X1;
                    while (!done)
                    {
                        map[x, s.Y1]++;
                        if (debug) PrintMap(map);
                        if (x == s.X2)
                        {
                            done = true;
                        }
                        else
                        {
                            x += (s.X1 < s.X2 ? 1 : -1);
                        }
                    }
                }
                else if (Math.Abs(s.X1 - s.X2)==Math.Abs(s.Y1 - s.Y2))
                {
                    if (debug) Console.WriteLine("Mapping " + s);
                    var done = false;
                    int x = s.X1;
                    int y = s.Y1;
                    while (!done)
                    {
                        map[x, y]++;
                        if (debug) PrintMap(map);
                        if (x == s.X2)
                        {
                            done = true;
                        }
                        else
                        {
                            x += (s.X1 < s.X2 ? 1 : -1);
                            y += (s.Y1 < s.Y2 ? 1 : -1);
                        }
                    }
                }
                else
                {
                    if (debug) Console.WriteLine("Skipping " + s);
                }
            }
            var result = 0;
            for (int x = 0; x < maxX; x++)
            {
                for (int y = 0; y < maxY; y++)
                {
                    if (map[x, y] >= 2) result++;
                }
            }
            PrintMap(map);
            Console.WriteLine("Answer: " + result);
            Console.WriteLine();
            return result;
        }

        private static void PrintMap(int[,] map)
        {
            for (int x = 0; x <= 9; x++)
            {
                for (int y = 0; y <= 9; y++)
                {
                    Console.Write(map[x, y]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

    }
}
