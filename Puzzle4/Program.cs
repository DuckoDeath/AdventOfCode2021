using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Puzzle4
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Puzzle 4");
            Console.WriteLine();
            ExecutePart1(@"..\..\input.txt");
            ExecutePart2(@"..\..\input.txt");

            Console.WriteLine("Press any key");
            Console.ReadKey();
        }

        public static int ExecutePart1(string filename)
        {
            Console.WriteLine("Part One");
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
            foreach (var num in numbers)
            {
                foreach (var card in cards)
                {
                    card.MarkNum(num);
                    if (card.HasBingo())
                    {
                        winner = card;
                        lastNum = num;
                        break;
                    }
                }
                if (winner != null) break;
            }
            var result = winner.CalcResult() * lastNum;
            Console.WriteLine("Winner: " + winner.CardNum);
            Console.WriteLine("On Num: " + lastNum);
            winner.PrintCard();
            Console.WriteLine("Answer: " + result);
            Console.WriteLine();
            return result;
        }

        public static int ExecutePart2(string filename)
        {
            Console.WriteLine("Part Two");
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
                        if (cards.Count==1)
                        {
                            winner = cards.First();
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
            Console.WriteLine("On Num: " +  lastNum);
            winner.PrintCard();
            Console.WriteLine("Answer: " + result);
            Console.WriteLine();
            return result;
        }

    }
}
