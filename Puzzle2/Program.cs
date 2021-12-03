using System;
using System.IO;
using System.Linq;

namespace Puzzle2
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Puzzle 2");
            Console.WriteLine();
            ExecutePart1(@"..\..\input.txt");
            ExecutePart2(@"..\..\input.txt");

            Console.WriteLine("Press any key");
            Console.ReadKey();
        }


        public static int ExecutePart1(string filename)
        {
            var lines = File.ReadAllLines(filename);
            Console.WriteLine("Lines: " + lines.Count());
            var instructions = lines.Select(x =>
            {
                var parts = x.Split(' ');
                return new Instruction { Direction = (DirectionEnum)Enum.Parse(typeof(DirectionEnum), parts[0]), Amount = int.Parse(parts[1]) };
            }).ToList();
            int pos = 0;
            int depth = 0;
            foreach (var i in instructions)
            {
                switch (i.Direction)
                {
                    case DirectionEnum.forward:
                        pos += i.Amount;
                        break;
                    case DirectionEnum.up:
                        depth -= i.Amount;
                        break;
                    case DirectionEnum.down:
                        depth += i.Amount;
                        break;
                }
            }
            Console.WriteLine("Part One");
            Console.WriteLine("Position: " + pos);
            Console.WriteLine("Depth: " + depth);
            var result = pos * depth;
            Console.WriteLine("Answer: " + result);
            return result;
        }

        public static int ExecutePart2(string filename)
        {
            Console.WriteLine("Puzzle 2");
            Console.WriteLine();

            var lines = File.ReadAllLines(filename);
            Console.WriteLine("Lines: " + lines.Count());
            var instructions = lines.Select(x =>
            {
                var parts = x.Split(' ');
                return new Instruction { Direction = (DirectionEnum)Enum.Parse(typeof(DirectionEnum), parts[0]), Amount = int.Parse(parts[1]) };
            }).ToList();
            var pos = 0;
            var depth = 0;
            var aim = 0;
            foreach (var i in instructions)
            {
                switch (i.Direction)
                {
                    case DirectionEnum.forward:
                        pos += i.Amount;
                        depth += (aim * i.Amount);
                        break;
                    case DirectionEnum.up:
                        aim -= i.Amount;
                        break;
                    case DirectionEnum.down:
                        aim += i.Amount;
                        break;
                }
            }
            Console.WriteLine("Part Two");
            Console.WriteLine("Position: " + pos);
            Console.WriteLine("Depth: " + depth);
            Console.WriteLine("Aim: " + aim);
            var result = pos * depth;
            Console.WriteLine("Answer: " + result);
            Console.WriteLine();
            return result;
        }
    }
}
