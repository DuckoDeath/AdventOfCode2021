using System;

namespace AdventOfCodeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var day = 5;
            var debug = false;

            Type type = Type.GetType($"AdventOfCode.Day{day}.Day{day}, AdventOfCode");
            var mi = type.GetMethod("ExecutePart1");
            mi.Invoke(null, new object[] { $@"..\..\..\AdventOfCode\Day{day}\input.txt", debug });
            mi = type.GetMethod("ExecutePart2");
            mi.Invoke(null, new object[] { $@"..\..\..\AdventOfCode\Day{day}\input.txt", debug });

            Console.WriteLine("Press any key");
            Console.ReadKey();
        }
    }
}
