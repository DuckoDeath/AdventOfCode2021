using System;
using System.IO;
using System.Linq;

namespace Puzzle1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Puzzle 1");
            Console.WriteLine();
            ExecutePart1(@"..\..\input.txt");
            ExecutePart2(@"..\..\input.txt");

            Console.WriteLine("Press any key");
            Console.ReadKey();
        }

        public static int ExecutePart1(string filename)
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

        public static int ExecutePart2(string filename)
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
