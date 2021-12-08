using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Day8
{
    public class Day8
    {
        public static long ExecutePart1(string filename, bool debug = false)
        {
            Console.WriteLine("Part One");

            var lines = File.ReadAllLines(filename);
            Console.WriteLine("Lines: " + lines.Count());

            var parsedLines = new List<Line>();
            foreach (var l in lines)
            {
                var parts = l.Split('|');
                var line = new Line();
                line.Input = parts[0].Split(' ').ToList();
                line.Output = parts[1].Split(' ').ToList();
                parsedLines.Add(line);
            }
            Dictionary<int, int> count = new Dictionary<int, int>();
            count.Add(1, 0);
            count.Add(4, 0);
            count.Add(7, 0);
            count.Add(8, 0);
            foreach (var line in parsedLines)
            {
                foreach (var o in line.Output)
                {
                    switch (o.Length)
                    {
                        case 2:
                            count[1]++;
                            break;
                        case 3:
                            count[7]++;
                            break;
                        case 4:
                            count[4]++;
                            break;
                        case 7:
                            count[8]++;
                            break;
                    }
                }
            }

            var result = count.Values.Sum();
            Console.WriteLine("Answer: " + result);
            Console.WriteLine();
            return result;
        }

        public static long ExecutePart2(string filename, bool debug = false)
        {
            Console.WriteLine("Part Two");

            var lines = File.ReadAllLines(filename);
            Console.WriteLine("Lines: " + lines.Count());

            var result = 0;
            foreach (var l in lines)
            {
                var parts = l.Split('|');
                var line = new Line();
                line.Input = parts[0].Split(' ').Where(x=>x!="").ToList();

                var one = line.Input.First(x => x.Length == 2);
                var four = line.Input.First(x => x.Length == 4);
                var seven = line.Input.First(x => x.Length == 3);
                var eight = line.Input.First(x => x.Length == 7);

                var nine = line.Input.First(x => x.Length == 6 && four.ToCharArray().ToList().All(c=>x.ToCharArray().ToList().Contains(c)));
                var zero = line.Input.First(x => x.Length == 6 && x!=nine && seven.ToCharArray().ToList().All(c => x.ToCharArray().ToList().Contains(c)));
                var six = line.Input.First(x => x.Length == 6 && x != zero && x!= nine);

                var three = line.Input.First(x=>x.Length==5 && seven.ToCharArray().ToList().All(c => x.ToCharArray().ToList().Contains(c)));
                var five = line.Input.First(x => x.Length == 5 && x.ToCharArray().ToList().All(c => six.ToCharArray().ToList().Contains(c)));
                var two = line.Input.First(x => x.Length == 5 && x!=three && x!=five);

                Dictionary<string, int> translate = new Dictionary<string, int>();
                translate.Add(zero, 0);
                translate.Add(one, 1);
                translate.Add(two, 2);
                translate.Add(three, 3);
                translate.Add(four, 4);
                translate.Add(five, 5);
                translate.Add(six, 6);
                translate.Add(seven, 7);
                translate.Add(eight, 8);
                translate.Add(nine, 9);
                line.Output = parts[1].Split(' ').Where(x => x != "").ToList();
                var str = "";
                foreach (var o in line.Output)
                {
                    var oc = o.ToCharArray().ToList();
                    foreach (var t in translate.Keys)
                    {
                        if (t.ToCharArray().Length==oc.Count && oc.All(x=>t.ToCharArray().ToList().Contains(x))) {
                            str += translate[t].ToString();
                            break;
                        }
                    }
                }
                result += int.Parse(str);
            }

            Console.WriteLine("Answer: " + result);
            Console.WriteLine();
            return result;
        }
    }
}
