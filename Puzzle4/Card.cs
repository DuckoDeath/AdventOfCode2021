using System;

namespace Puzzle4
{
    public class Card
    {
        public Card(int cardNum)
        {
            CardNum = cardNum;
        }

        public int CardNum { get; set; }
        public Space[,] Spaces { get; set; } = new Space[5, 5];

        public void MarkNum(int num)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    var space = Spaces[i, j];
                    if (space.Num==num)
                    {
                        space.Marked = true;
                        return;
                    }
                }
            }
        }
        public bool HasBingo()
        {
            for (int i = 0; i < 5; i++)
            {
                if (Spaces[i, 0].Marked && Spaces[i, 1].Marked && Spaces[i, 2].Marked && Spaces[i, 3].Marked && Spaces[i, 4].Marked)
                {
                    return true;
                }
            }
            for (int i = 0; i < 5; i++)
            {
                if (Spaces[0, i].Marked && Spaces[1, i].Marked && Spaces[2, i].Marked && Spaces[3, i].Marked && Spaces[4, i].Marked)
                {
                    return true;
                }
            }
            return false;
        }

        public int CalcResult()
        {
            int result = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    var space = Spaces[i, j];
                    if (!space.Marked) result += space.Num;
                }
            }
            return result;
        }

        internal void PrintCard()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    var space = Spaces[i, j];
                    Console.Write(space.Marked ? "X" : space.Num.ToString());
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
    }
}
