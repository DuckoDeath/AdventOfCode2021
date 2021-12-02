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
            var lines = File.ReadAllLines(@"..\..\input.txt");
            Console.WriteLine("Lines: " + lines.Count());
            var instructions = lines.Select(x => {
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
            Console.WriteLine("Answer: " + pos * depth);
            Console.WriteLine();


            pos = 0;
            depth = 0;
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
            Console.WriteLine("Answer: " + pos * depth);
            Console.WriteLine();
            Console.WriteLine("Press any key");
            Console.ReadKey();
        }
    }
}
