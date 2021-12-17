using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day16
{
    public class LiteralPacket : Packet
    {
        public List<string> Parts { get; set; } = new List<string>();

        public LiteralPacket(int type, long version, string binaryStr) : base(type, version, binaryStr)
        {
            var theRest = binaryStr.Substring(6);
            var fullBinaryStr = binaryStr.Substring(0, 6);

            var done = false;
            while (!done)
            {
                var next = theRest.Substring(0,5);
                fullBinaryStr += next;
                done = next.First()=='0';
                var numStr = theRest.Substring(1,4);
                Parts.Add(numStr);
                theRest = theRest.Substring(5);
            }
            Value = Convert.ToInt64(string.Join(string.Empty, Parts), 2);
            BinaryStr = fullBinaryStr;
        }
    }
}
