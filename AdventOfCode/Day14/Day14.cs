using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Day14
{
    public class Day14
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

            HashSet<string> unique = new HashSet<string>();
            Dictionary<string,string> polyRules = new Dictionary<string, string>();
            var poly = lines[0];
            for (int i=2;i<lines.Count;i++)
            {
                var line = lines[i];
                var parts = line.Split(new[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
                polyRules.Add(parts[0], parts[1]);
                unique.Add(parts[0].ToCharArray()[0].ToString());
                unique.Add(parts[0].ToCharArray()[1].ToString());
                unique.Add(parts[1]);
            }

            var maxSteps = part == 1 ? 10 : 40;
            for (int step = 1; step <= maxSteps; step++)
            {
                int idx = 1;
                while (idx < poly.Length)
                {
                    var sub = poly.Substring(idx - 1, 2);
                    if (polyRules.TryGetValue(sub, out var val))
                    {
                        poly = poly.Substring(0, idx) + val + poly.Substring(idx);
                        idx++;
                    }
                    idx++;
                }
                //Console.WriteLine(poly);
            }

            var min = int.MaxValue;
            var max = int.MinValue;
            foreach (var u in unique)
            {
                var count = poly.Count(x => x.ToString() == u);
                if (count < min) min = count;
                if (count > max) max = count;
            }

            var result = max - min;
            Console.WriteLine("Answer: " + result);
            Console.WriteLine();
            return result;
        }

    }
}
