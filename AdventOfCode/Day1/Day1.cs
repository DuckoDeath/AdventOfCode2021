using System;
using System.IO;
using System.Linq;

namespace AdventOfCode.Day1
{
    public static class Day1
    {
        public static int ExecutePart1(string filename, bool debug = false)
        {
            var lines = File.ReadAllLines(filename).Select(x => int.Parse(x));
            Console.WriteLine("Lines: " + lines.Count());

            var count = lines.SelectWithPrevious((prev, curr) => {
                return curr > prev ? 1 : 0;
            }).Sum();
            Console.WriteLine("Part One");
            Console.WriteLine("Answer:" + count);
            Console.WriteLine();

            return count;
        }

        public static int ExecutePart2(string filename, bool debug = false)
        {
            var lines = File.ReadAllLines(filename).Select(x => int.Parse(x));
            Console.WriteLine("Lines: " + lines.Count());

            var count = lines.SelectWithPreviousQuad((one, two, three, four) => {
                return two + three + four > one + two + three ? 1 : 0;
            }).Sum();
            Console.WriteLine("Part Two");
            Console.WriteLine("Answer:" + count);

            Console.WriteLine();
            return count;
        }
    }
}
