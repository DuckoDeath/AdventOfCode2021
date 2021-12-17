using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Day17
{
    public class Day17
    {
        public static long ExecutePart1(string filename, bool debug = false)
        {
            Console.WriteLine("Part One");
            return DoExecutePart(filename, 1, debug);
        }

        public static long ExecutePart2(string filename, bool debug = false)
        {
            Console.WriteLine("Part Two");
            return DoExecutePart(filename, 2, debug);
        }

        private static long DoExecutePart(string filename, int part, bool debug = false)
        {
            var lines = File.ReadAllLines(filename).ToList();
            Console.WriteLine("Lines: " + lines.Count);
            // target area: x=102..157, y=-146..-90
            var line = lines.First();
            line = line.Replace("target area: ", string.Empty);
            var parts = line.Split(',');
            var xp = parts[0];
            var xpParts = xp.Split(new[] { ".." }, StringSplitOptions.None);
            var targetX1 = int.Parse(xpParts[0].Replace("x=", string.Empty));
            var targetX2 = int.Parse(xpParts[1]);
            if (targetX1 > targetX2)
            {
                // reverse
                var temp = targetX2;
                targetX2 = targetX1;
                targetX2 = temp;
            }
            var yp = parts[1];
            var ypParts = yp.Split(new[] { ".." }, StringSplitOptions.None);
            var targetY1 = int.Parse(ypParts[0].Replace("y=", string.Empty));
            var targetY2 = int.Parse(ypParts[1]);
            if (targetY1 > targetY2)
            {
                // reverse
                var temp = targetY2;
                targetY2 = targetY1;
                targetY2 = temp;
            }

            var allSuccess = new List<KeyValuePair<int, int>>();
            var maxY = int.MinValue;
            List<KeyValuePair<int,int>> maxPath = null;

            for (var startVx = 1; startVx < 999; startVx++)
            {
                for (var startVy = -999; startVy < 999; startVy++)
                {
                    var vx = startVx;
                    var vy = startVy;
                    var path = new List<KeyValuePair<int, int>>();
                    var done = false;
                    var success = false;

                    var x = 0;
                    var y = 0;
                    path.Add(new KeyValuePair<int, int>(x, y));
                    while (!done)
                    {
                        x = x + vx;
                        y = y + vy;
                        if (vx != 0)
                        {
                            vx += (vx > 0 ? -1 : 1);
                        }
                        vy -= 1;
                        path.Add(new KeyValuePair<int, int>(x, y));
                        success = (x >= targetX1 && x <= targetX2 && y >= targetY1 && y <= targetY2);
                        if (success)
                        {
                            done = true;
                            allSuccess.Add(new KeyValuePair<int, int>(startVx, startVy));
                        } else
                        {
                            // also done if missed
                            if (x > targetX2 || y < targetY1)
                            {
                                done = true;
                            }
                        }
                    }
                    if (success)
                    {
                        var pathMaxY = path.Select(p => p.Value).Max();
                        if (pathMaxY > maxY)
                        {
                            maxPath = path;
                            maxY = pathMaxY;
                        }
                    }
                }
            }

            var result = part==1 ? maxY : allSuccess.Count;
            Console.WriteLine("Answer: " + result);
            Console.WriteLine();
            return result;
        }

    }
}
