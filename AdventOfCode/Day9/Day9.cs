using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Day9
{
    public class Day9
    {

        public static long ExecutePart1(string filename, bool debug = false)
        {
            Console.WriteLine("Part One");

            var lines = File.ReadAllLines(filename).ToList();
            Console.WriteLine("Lines: " + lines.Count);

            var maxX = lines.First().Length;
            var maxY = lines.Count;
            Point[,] points = new Point[maxX, maxY];
            {
                int y = 0;
                foreach (var l in lines)
                {
                    int x = 0;
                    foreach (var num in l.ToCharArray().Select(n => int.Parse(n.ToString())))
                    {
                        points[x, y] = new Point(num);
                        x++;
                    }
                    y++;
                }
            }
            var result = 0;
            for (int x=0;x < maxX; x++)
            {
                for (int y=0;y < maxY; y++)
                {
                    var currP = points[x, y];
                    var list = new List<int>();
                    if (x > 0)
                    {
                        var p = points[x - 1, y];
                        list.Add(p.Num);
                    }
                    if (x != maxX-1)
                    {
                        var p = points[x + 1, y];
                        list.Add(p.Num);
                    }
                    if (y > 0)
                    {
                        var p = points[x, y - 1];
                        list.Add(p.Num);
                    }
                    if (y < maxY - 1)
                    {
                        var p = points[x, y + 1];
                        list.Add(p.Num);
                    }
                    var min = list.Min();
                    if (currP.Num < min)
                    {
                        currP.IsLow = true;
                        result += (currP.Num + 1);
                    }
                }
            }

            Console.WriteLine("Answer: " + result);
            Console.WriteLine();
            return result;
        }

        public static long ExecutePart2(string filename, bool debug = false)
        {
            Console.WriteLine("Part Two");

            var lines = File.ReadAllLines(filename).ToList();
            Console.WriteLine("Lines: " + lines.Count);

            var maxX = lines.First().Length;
            var maxY = lines.Count;
            Point[,] points = new Point[maxX, maxY];
            {
                int y = 0;
                foreach (var l in lines)
                {
                    int x = 0;
                    foreach (var num in l.ToCharArray().Select(n => int.Parse(n.ToString())))
                    {
                        points[x, y] = new Point(num);
                        x++;
                    }
                    y++;
                }
            }
            var basin = 0;
            for (int x = 0; x < maxX; x++)
            {
                for (int y = 0; y < maxY; y++)
                {
                    var currP = points[x, y];
                    if (currP.Basin==null)
                    {
                        basin++;
                        Recurse(points, x, y, basin);
                    }
                }
            }

            List<int> top3 = new List<int>();
            for (int i=0; i<basin; i++)
            {
                var count = 0;
                for (int x = 0; x < maxX; x++)
                {
                    for (int y = 0; y < maxY; y++)
                    {
                        var currP = points[x, y];
                        if (currP.Basin==i)
                        {
                            count++;
                        }
                    }
                }
                var top3Min = top3.Count==0 ? 0 : top3.Min();
                if (top3.Count < 3)
                {
                    top3.Add(count);
                } else if (top3Min < count)
                {
                    top3.RemoveAt(top3.IndexOf(top3Min));
                    top3.Add(count);
                }
            }

            var result = 1;
            foreach (var n in top3)
            {
                result *= n;
            }
            Console.WriteLine("Answer: " + result);
            Console.WriteLine();
            return result;
        }

        private static void Recurse(Point[,] points, int x, int y, int basin)
        {
            var maxX = points.GetLength(0);
            var maxY = points.GetLength(1);
            var currP = points[x, y];
            if (currP.Num == 9 || currP.Basin!=null) return;
            currP.Basin = basin;

            if (x > 0)
            {
                Recurse(points, x - 1, y, basin);
            }
            if (x != maxX - 1)
            {
                Recurse(points, x + 1, y, basin);
            }
            if (y > 0)
            {
                Recurse(points, x, y - 1, basin);
            }
            if (y < maxY - 1)
            {
                Recurse(points, x, y + 1, basin);
            }
        }
    }
}
