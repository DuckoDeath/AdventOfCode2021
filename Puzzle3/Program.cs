using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Puzzle3
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Puzzle 3");
            var lines = File.ReadAllLines(@"..\..\input.txt");
            Console.WriteLine("Lines: " + lines.Count());
            Console.WriteLine("Part One");

            var lineLen = lines.First().ToCharArray().Length;
            Dictionary<int, int> columns = new Dictionary<int, int>();
            for (int i = 0; i < lineLen; i++) {
                columns.Add(i, 0);
            }
            var lineCount = lines.Count();
            foreach (var l in lines)
            {
                var parts = l.ToCharArray().Select(x => int.Parse(x.ToString())).ToList();
                var len = parts.Count;

                for (int i=0; i < len; i++)
                {
                    var p = parts[i];
                    columns[i] += p;
                }
            }
            var multiplier = 1;
            var gamma = 0;
            var epsilon = 0;
            for (int i=columns.Count - 1; i >=0;i--)
            {
                var val = columns[i];
                if (val > (lineCount / 2))
                {
                    gamma += multiplier;
                } else
                {
                    epsilon += multiplier;
                }
                multiplier *= 2;
            }

            Console.WriteLine("Gamma: " + gamma);
            Console.WriteLine("Epsilon: " + epsilon);
            Console.WriteLine("Answer: " + (gamma * epsilon));
            Console.WriteLine();

            Console.WriteLine("Part Two");

            var idx = 0;
            var oLines = lines.ToList();
            var sLines = lines.ToList();
            while (idx < lineLen)
            {
                var numOfOnes = 0;
                var numOfZeros = 0;
                foreach (var l in oLines)
                {
                    var parts = l.ToCharArray().Select(x => int.Parse(x.ToString())).ToList();
                    numOfOnes += parts[idx];
                    numOfZeros += parts[idx]==1 ? 0 : 1;
                }
                var chr = numOfOnes >= numOfZeros ? '1' : '0';
                oLines = oLines.Where(x => x.ToCharArray()[idx] == chr).ToList();
                idx++;
                if (oLines.Count == 1) break;
            }

            idx = 0;
            while (idx < lineLen)
            {
                var numOfOnes = 0;
                var numOfZeros = 0;
                foreach (var l in sLines)
                {
                    var parts = l.ToCharArray().Select(x => int.Parse(x.ToString())).ToList();
                    numOfOnes += parts[idx];
                    numOfZeros += parts[idx] == 1 ? 0 : 1;
                }
                var chr = numOfZeros <= numOfOnes ? '0' : '1';
                sLines = sLines.Where(x => x.ToCharArray()[idx] == chr).ToList();
                idx++;
                if (sLines.Count == 1) break;
            }

            Console.WriteLine("oLines Count: " + oLines.Count);
            Console.WriteLine("sLines Count: " + sLines.Count);
            var oRating = GetIntFromBinary(oLines.First().ToCharArray());
            var sRating = GetIntFromBinary(sLines.First().ToCharArray());
            Console.WriteLine("oRating binary: " + oLines.First());
            Console.WriteLine("oRating: " + oRating);
            Console.WriteLine("co2Rating binary: " + sLines.First());
            Console.WriteLine("co2Rating: " + sRating);
            Console.WriteLine("Answer: " + (oRating * sRating));
            Console.WriteLine("Press any key");
            Console.ReadKey();
        }

        private static int GetIntFromBinary(char[] parts)
        {
            var multiplier = 1;
            var result = 0;
            for (int i = parts.Length - 1; i >= 0; i--)
            {
                var val = int.Parse(parts[i].ToString());
                result += (multiplier * val);
                multiplier *= 2;
            }
            return result;

        }
    }
}
