using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Day4
{
    public class Day4
    {
        public static int ExecutePart1(string filename, bool debug = false)
        {
            Console.WriteLine("Part One");
            return Execute(filename, false);
        }

        public static int ExecutePart2(string filename, bool debug = false)
        {
            Console.WriteLine("Part Two");
            return Execute(filename, true);
        }

        public static int Execute(string filename, bool lastWinner)
        {
            var lines = File.ReadAllLines(filename);
            Console.WriteLine("Lines: " + lines.Count());
            var firstLine = lines.First();
            var numbers = firstLine.Split(',').Select(x => int.Parse(x.ToString())).ToList();
            var otherLines = lines.Skip(1).ToList();
            var cards = new List<Card>();
            int idx = 1;
            while (otherLines.Any())
            {
                otherLines = otherLines.Skip(1).ToList();
                var card = new Card(idx++);
                cards.Add(card);
                for (int row = 0; row < 5; row++)
                {
                    var line = otherLines[row];
                    var cols = line.Split(' ').Where(x => x != "").ToList();
                    for (int i = 0; i < 5; i++)
                    {
                        card.Spaces[row, i] = new Space(int.Parse(cols[i]));
                    }
                }
                otherLines = otherLines.Skip(5).ToList();
            }

            Card winner = null;
            int lastNum = 0;
            var toRemove = new List<Card>();
            foreach (var num in numbers)
            {
                foreach (var card in cards)
                {
                    card.MarkNum(num);
                    if (card.HasBingo())
                    {
                        if (!lastWinner || cards.Count == 1)
                        {
                            winner = card;
                            lastNum = num;
                            break;
                        }
                        toRemove.Add(card);
                    }
                }
                if (winner != null) break;
                cards = cards.Where(x => !toRemove.Contains(x)).ToList();
                toRemove.Clear();
            }
            var result = winner.CalcResult() * lastNum;
            Console.WriteLine("Last Winner: " + winner.CardNum);
            Console.WriteLine("On Num: " + lastNum);
            winner.PrintCard();
            Console.WriteLine("Answer: " + result);
            Console.WriteLine();
            return result;
        }
    }
}
