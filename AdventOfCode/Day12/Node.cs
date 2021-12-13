using System.Collections.Generic;

namespace AdventOfCode.Day12
{
    public class Node
    {
        public string Name { get; set; }
        public bool Visited { get; set; }        public bool AllowMultipleVisits => Name.ToUpper()==Name;
        public List<Node> Nodes { get; set; } = new List<Node>();
        public bool IsStart => Name == "start";
        public bool IsEnd => Name == "end";
    }
}
