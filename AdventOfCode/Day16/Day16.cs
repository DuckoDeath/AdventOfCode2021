using System;
using System.IO;
using System.Linq;

namespace AdventOfCode.Day16
{
    public class Day16
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

            Packet p = Packet.CreatePacketFromHex(lines.First());

            var result = part==1 ? SumVersion(p) : p.Value;
            Console.WriteLine("Answer: " + result);
            Console.WriteLine();
            return result;
        }

        public static long SumVersion(Packet p)
        {
            var sum = p.Version;
            foreach (var sp in p.SubPackets)
            {
                sum += SumVersion(sp);
            }
            return sum;
        }

    }
}
