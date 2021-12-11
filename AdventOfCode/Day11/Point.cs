using System;

namespace AdventOfCode.Day11
{
    public class Point
    {
        public Point(int num)
        {
            Num = num;
        }

        public int Num { get; set; }
        public int Flashed { get; set; }

    }
}
