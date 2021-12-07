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

    }
}
