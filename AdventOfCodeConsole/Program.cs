using System;

namespace AdventOfCodeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var debug = false;
            int day = 7;

            while (true)
            {
                if (day==-1)
                {
                    Console.WriteLine("Pick a day #, or (q)uit");
                    var str = Console.ReadLine();
                    if (str == "Q" || str == "q") return;

                    if (!int.TryParse(str, out day))
                    {
                        throw new Exception(str + " is not a valid number");
                    }
                }

                Type type = Type.GetType($"AdventOfCode.Day{day}.Day{day}, AdventOfCode");
                if (type == null)
                {
                    throw new Exception(day + " is not a valid Day");
                }
                var mi = type.GetMethod("ExecutePart1");
                mi.Invoke(null, new object[] { $@"..\..\..\AdventOfCode\Day{day}\input.txt", debug });
                mi = type.GetMethod("ExecutePart2");
                mi.Invoke(null, new object[] { $@"..\..\..\AdventOfCode\Day{day}\input.txt", debug });

                Console.WriteLine("Press any key");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
