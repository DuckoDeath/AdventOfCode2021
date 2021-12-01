using System;
using System.IO;
using System.Linq;

namespace Puzzle1
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines(@"..\..\input.txt").Select(x=>int.Parse(x));
            Console.WriteLine("Lines: " + lines.Count());

            var count = lines.SelectWithPrevious((prev, curr) => {
                return curr > prev ? 1 : 0;
            }).Sum();
            Console.WriteLine("Part One");
            Console.WriteLine("Answer:" + count);

            count = lines.SelectWithPreviousQuad((one, two, three, four) => {
                return two + three + four > one + two + three ? 1 : 0;
            }).Sum();
            Console.WriteLine("Part Two");
            Console.WriteLine("Answer:" + count);

            Console.WriteLine("Press any key");
            Console.ReadKey();
        }
    }
}
