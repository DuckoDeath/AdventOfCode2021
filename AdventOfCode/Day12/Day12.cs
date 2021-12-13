using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Day12
{
    public class Day12
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

            Dictionary<string,Node> nodesByName = new Dictionary<string, Node>();
            var pairs = new List<KeyValuePair<Node,Node>>();
            // first create all the unique nodes
            foreach (var l in lines)
            {
                var parts = l.Split('-');
                
                if (!nodesByName.TryGetValue(parts[0], out var from))
                {
                    from = new Node { Name = parts[0] };
                    nodesByName.Add(from.Name, from);
                }
                if (!nodesByName.TryGetValue(parts[1], out var to))
                {
                    to = new Node { Name = parts[1] };
                    nodesByName.Add(to.Name, to);
                }
                from.Nodes.Add(to);
                to.Nodes.Add(from);
                pairs.Add(new KeyValuePair<Node, Node>(from, to));
            }

            var start = nodesByName["start"];
            start.Visited = true;
            var completedPaths = new List<List<Node>>();
            foreach (var n in start.Nodes)
            {
                var path = new List<Node>() { start };
                Traverse(part, n, path, completedPaths);
            }

            var result = completedPaths.Count;
            Console.WriteLine("Answer: " + result);
            Console.WriteLine();
            return result;
        }

        private static void Traverse(int part, Node node, List<Node> path, List<List<Node>> completedPaths)
        {
            if (node.IsStart) return;
            if (node.IsEnd)
            {
                completedPaths.Add(path);
                return;
            }
            if (node.AllowMultipleVisits || !path.Contains(node)
                || (part==2 && !HasMultipleSmall(path)))
            {
                path.Add(node);
                foreach (var n in node.Nodes)
                {
                    Traverse(part, n, new List<Node>(path), completedPaths);
                }
            }
        }

        private static bool HasMultipleSmall(List<Node> path)
        {
            HashSet<Node> nodes = new HashSet<Node>();
            foreach (var n in path)
            {
                if (n.IsStart || n.IsEnd || n.AllowMultipleVisits) continue;
                if (nodes.Contains(n)) return true;
                nodes.Add(n);
            }
            return false;
        }

    }
}
