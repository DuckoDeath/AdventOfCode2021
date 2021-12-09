using System;

namespace AdventOfCode.Day9
{
    public class Point
    {
        public Point(int num)
        {
            Num = num;
        }

        public int? Basin { get; set; }
        public int Num { get; set; }
        public bool IsLow { get; set; }

    }
}
