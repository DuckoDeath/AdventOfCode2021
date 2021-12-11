using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Day11
{
    public class Day11
    {
        public static long ExecutePart1(string filename, bool debug = false)
        {
            return DoExecutePart(filename, 1, debug);
        }

        public static long ExecutePart2(string filename, bool debug = false)
        {
            return DoExecutePart(filename, 2, debug);
        }

        private static long DoExecutePart(string filename, int part, bool debug = false)
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

            var keepGoing = true;
            int round = 1;
            while (keepGoing)
            {
                for (int x = 0; x < maxX; x++)
                {
                    for (int y = 0; y < maxY; y++)
                    {
                        var currP = points[x, y];
                        currP.Num++;
                    }
                }

                var hadFlashes = true;
                while (hadFlashes) {
                    hadFlashes = false;
                    for (int x = 0; x < maxX; x++)
                    {
                        for (int y = 0; y < maxY; y++)
                        {
                            var currP = points[x, y];
                            if (currP.Num > 9)
                            {
                                FlashPoint(x, y, currP, points);
                                hadFlashes = true;
                            }
                        }
                    }
                }
                if (part==1)
                {
                    keepGoing = round < 100;
                } else if (part==2)
                {
                    keepGoing = !AllFlashed(points);
                }
                if (keepGoing) round++;
            }

            var result = 0;
            if (part==1)
            {
                for (int x = 0; x < maxX; x++)
                {
                    for (int y = 0; y < maxY; y++)
                    {
                        var currP = points[x, y];
                        result += currP.Flashed;
                    }
                }
            } else if (part==2)
            {
                result = round;
            }

            Console.WriteLine("Answer: " + result);
            Console.WriteLine();
            return result;
        }

        private static bool AllFlashed(Point[,] points)
        {
            var maxX = points.GetLength(0);
            var maxY = points.GetLength(1);

            for (int x = 0; x < maxX; x++)
            {
                for (int y = 0; y < maxY; y++)
                {
                    var currP = points[x, y];
                    if (currP.Num!=0) return false;
                }
            }
            return true;
        }

        private static void FlashPoint(int x, int y, Point currP, Point[,] points)
        {
            var maxX = points.GetLength(0);
            var maxY = points.GetLength(1);
            currP.Flashed++;
            currP.Num = 0;
            if (x > 0)
            {
                if (y > 0)
                {
                    //top left
                    var ptl = points[x - 1,y - 1];
                    if (ptl.Num!=0) ptl.Num++;
                }
                // left
                var pl = points[x - 1, y];
                if (pl.Num!=0) pl.Num++;
                if (y < (maxY-1))
                {
                    // bottom left
                    var pbl = points[x - 1, y + 1];
                    if (pbl.Num!=0) pbl.Num++;
                }
            }
            if (y > 0)
            {
                // middle top
                var pmt = points[x, y - 1];
                if (pmt.Num!=0) pmt.Num++;
            }
            if (y < (maxY - 1))
            {
                // middle bottom
                var pmb = points[x, y + 1];
                if (pmb.Num!=0) pmb.Num++;
            }
            if (x < maxX-1)
            {
                if (y > 0)
                {
                    //top right
                    var ptr = points[x + 1, y - 1];
                    if (ptr.Num!=0) ptr.Num++;
                }
                // right
                var pr = points[x + 1, y];
                if (pr.Num!=0) pr.Num++;
                if (y < (maxY - 1))
                {
                    // bottom right
                    var pbr = points[x + 1, y + 1];
                    if (pbr.Num!=0) pbr.Num++;
                }
            }
        }
    }
}
