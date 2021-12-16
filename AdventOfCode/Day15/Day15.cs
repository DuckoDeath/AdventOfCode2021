using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Day15
{
    public class Day15
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

            var maxX = lines.First().Length;
            var maxY = lines.Count;
            var realMaxX = maxX * (part == 2 ? 5 : 1);
            var realMaxY = maxY * (part == 2 ? 5 : 1);

            var unexploredNodes = new List<Node>();
            var map = new Node[realMaxY, realMaxX];
            Node endNode = null;
            for (int yy = 0; yy < (part == 2 ? 5 : 1); yy++)
            {
                for (int y = 0; y < maxY; y++)
                {
                    var realY = (yy * maxY) + y;
                    var l = lines[y];
                    for (int xx = 0; xx < (part == 2 ? 5 : 1); xx++)
                    {
                        for (int x = 0; x < maxX; x++)
                        {
                            var realX = (xx * maxX) + x;
                            var rl = GetRiskLevel(yy, xx, int.Parse(l[x].ToString()));
                            var node = new Node(realY, realX, rl);
                            map[node.Y, node.X] = node;
                            unexploredNodes.Add(node);
                            node.ParentDistance = int.MaxValue;
                            if (node.IsStart)
                            {
                                node.ParentDistance = 0;
                            }
                            else if (realX == realMaxX - 1 && realY == realMaxY - 1)
                            {
                                endNode = node;
                                node.IsEnd = true;
                            }
                        }
                    }
                }
            }

            while (unexploredNodes.Any())
            {
                var curr = unexploredNodes.OrderBy(x => x.ParentDistance).First();
                unexploredNodes.Remove(curr);
                if (!curr.IsEnd)
                {
                    List<Node> adjecent = GetAdjecentNodes(map, curr);
                    foreach (var aNode in adjecent)
                    {
                        var dist = curr.ParentDistance + map[aNode.Y, aNode.X].RiskLevel;
                        if (dist < aNode.ParentDistance)
                        {
                            aNode.ParentDistance = dist;
                            aNode.Parent = curr;
                        }
                    }
                }
            }


            Print(map);
            //Print(map, solution);

            var result = endNode.ParentDistance;
            Console.WriteLine("Answer: " + result);
            Console.WriteLine();
            return result;
        }

        private static int GetRiskLevel(int yy, int xx, int rl)
        {
            for (int y = 0; y < yy; y++)
            {
                rl++;
                if (rl > 9) rl = 1;
            }
            for (int x = 0; x < xx; x++)
            {
                rl++;
                if (rl > 9) rl = 1;
            }
            return rl;
        }

        private static List<Node> GetAdjecentNodes(Node[,] map, Node curr)
        {
            List<Node> results = new List<Node>();
            var maxY = map.GetLength(1);
            var maxX = map.GetLength(0);
            if (curr.Y < maxY - 1)
            {
                // try down
                var down = map[curr.Y + 1, curr.X];
                results.Add(down);
            }
            if (curr.X < maxX - 1)
            {
                // try right
                var right = map[curr.Y, curr.X + 1];
                results.Add(right);
            }
            if (curr.Y > 0)
            {
                // try up
                var up = map[curr.Y - 1, curr.X];
                results.Add(up);
            }
            if (curr.X > 0)
            {
                // try left
                var left = map[curr.Y, curr.X - 1];
                results.Add(left);
            }
            return results;
        }

        private static void Print(Node[,] map)
        {
            Console.WriteLine();
            var maxY = map.GetLength(1);
            var maxX = map.GetLength(0);
            for (int y = 0; y < maxY; y++)
            {
                for (int x = 0; x < maxX; x++)
                {
                    var c = map[y, x];
                    Console.Write(c.RiskLevel);
                }
                Console.WriteLine();
            }
        }

    }
}
