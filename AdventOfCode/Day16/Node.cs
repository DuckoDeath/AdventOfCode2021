namespace AdventOfCode.Day15
{
    public class Node
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsStart => X == 0 && Y == 0;
        public bool IsEnd { get; set; }
        public int RiskLevel { get; set; }
        public int ParentDistance { get; set; }
        public Node Parent { get; set; }

        public Node(int y, int x)
        {
            Y = y;
            X = x;
        }

        public Node(int y, int x, int riskLevel) : this(y, x)
        {            
            RiskLevel = riskLevel;
        }

        public override int GetHashCode()
        {
            return (Y * 10000) + X;
        }

        public override bool Equals(object obj)
        {
            return obj is Node coord &&
                   X == coord.X &&
                   Y == coord.Y;
        }

        public override string ToString()
        {
            return X + "/" + Y;
        }
    }
}
