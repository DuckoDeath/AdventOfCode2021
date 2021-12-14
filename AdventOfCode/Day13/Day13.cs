using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Day13
{
    public class Day13
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
            var coords = lines.Where(x => x != "" && !x.StartsWith("fold"));
            var maxY = coords.Max(x => int.Parse(x.Split(',')[0])) + 1;
            var maxX = coords.Max(x => int.Parse(x.Split(',')[1])) + 1;

            int[,] points = new int[maxX, maxY];
            {
                foreach (var c in coords)
                {
                    var y = int.Parse(c.Split(',')[0]);
                    var x = int.Parse(c.Split(',')[1]);
                    points[x, y] = 1;
                }
            }
            List<Fold> folds = new List<Fold>();
            foreach (var l in lines.Where(x=>x.StartsWith("fold")))
            {
                var parts = l.Replace("fold along ", string.Empty).Split('=');
                var fold = new Fold { XorY = parts[0], Val = int.Parse(parts[1]) };
                folds.Add(fold);
                if (part==1) break;
            }

            //Print(points);

            foreach (var fold in folds)
            {
                points = DoFold(fold, points);
                //Print(points);
            }

            var result = 0;

            maxX = points.GetLength(1);
            maxY = points.GetLength(0);
            for (int y = 0; y < maxY; y++)
            {
                for (int x = 0; x < maxX; x++)
                {
                    var currP = points[y, x];
                    result += currP;
                }
            }
            Print(points);

            Console.WriteLine("Answer: " + result);
            Console.WriteLine();
            return result;
        }

        private static int[,] DoFold(Fold fold, int[,] points)
        {
            var maxX = points.GetLength(1);
            var maxY = points.GetLength(0);
            Console.WriteLine();
            Console.WriteLine("Y: " + maxY + ", X: " + maxX);
            Console.WriteLine("Folding " + fold.XorY + "=" + fold.Val);
            var newMaxY = maxY;
            var newMaxX = maxX;
            if (fold.XorY=="y")
            {
                newMaxY = fold.Val;
            } else
            {
                newMaxX = fold.Val;
            }
            var newPoints = new int[newMaxY, newMaxX];

            for (int y = 0; y < maxY; y++)
            {
                for (int x = 0; x < maxX; x++)
                {
                    if ((fold.XorY=="y" && y < newMaxY) || (fold.XorY=="x" && x < newMaxX)) {
                        newPoints[y,x] = points[y,x];
                    } else if ((fold.XorY == "y" && y == newMaxY) || (fold.XorY=="x" && x==newMaxX))
                    {
                        // nothing
                    } else
                    {
                        var newP = points[y, x];
                        if (newP==1)
                        {
                            var newY = fold.XorY=="y" ? fold.Val - (y - fold.Val) : y;
                            var newX = fold.XorY=="y" ? x : fold.Val - (x - fold.Val);
                            newPoints[newY, newX] = 1;
                        }
                    }
                }
            }
            return newPoints;
        }

        private static void Print(int[,] points)
        {
            Console.WriteLine();
            var maxX = points.GetLength(1);
            var maxY = points.GetLength(0);

            for (int y = 0; y < maxY; y++)
            {
                for (int x = 0; x < maxX; x++)
                {
                    var currP = points[y, x];
                    Console.Write(currP==1 ? "#" : " ");
                }
                Console.WriteLine();
            }
        }
    }
}
