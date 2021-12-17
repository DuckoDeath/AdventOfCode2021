using System;
using System.Linq;

namespace AdventOfCode.Day16
{
    public class OperatorPacket : Packet
    {
        public int LengthTypeId { get; set; }
        public int? SubpacketBitLength { get; set; }
        public int? NumberOfSubpackets { get; set; }

        public OperatorPacket(int type, long version, string binaryStr) : base(type, version, binaryStr)
        {
            LengthTypeId = int.Parse(binaryStr.Substring(6,1));
            var fullBinaryStr = binaryStr.Substring(0, 7);
            string theRest;
            if (LengthTypeId==0)
            {
                var blStr = binaryStr.Substring(7,15);
                fullBinaryStr += blStr;
                SubpacketBitLength = Convert.ToInt32(blStr, 2);
                theRest = binaryStr.Substring(7 + 15);
            } else
            {
                var blStr = binaryStr.Substring(7, 11);
                fullBinaryStr += blStr;
                NumberOfSubpackets = Convert.ToInt32(blStr, 2);
                theRest = binaryStr.Substring(7 + 11);
            }

            var done = false;
            var num = 0;
            var bl = 0;
            while (!done)
            {
                var p = Packet.CreatePacketFromBinary(theRest);
                SubPackets.Add(p);
                fullBinaryStr += p.BinaryStr;
                bl += p.BinaryStr.Length;
                theRest = theRest.Substring(p.BinaryStr.Length);
                num++;
                if (NumberOfSubpackets!=null && NumberOfSubpackets==num)
                {
                    done = true;
                }
                if (SubpacketBitLength != null && bl ==SubpacketBitLength)
                {
                    done = true;
                }
            }

            BinaryStr = fullBinaryStr;
            Value = CalcValue(this);
        }

        public long CalcValue(Packet p)
        {
            switch (p.Type)
            {
                case 0:
                    return p.SubPackets.Select(sp => sp.Value).Sum();
                case 1:
                    var result = p.SubPackets.First().Value;
                    foreach (var sb in p.SubPackets.Skip(1))
                    {
                        result *= sb.Value;
                    }
                    return result;
                case 2:
                    return p.SubPackets.Select(sp => sp.Value).Min();
                case 3:
                    return p.SubPackets.Select(sp => sp.Value).Max();
                case 5:
                    return p.SubPackets[0].Value > p.SubPackets[1].Value ? 1 : 0;
                case 6:
                    return p.SubPackets[0].Value < p.SubPackets[1].Value ? 1 : 0;
                case 7:
                    return p.SubPackets[0].Value == p.SubPackets[1].Value ? 1 : 0;
            }
            return p.Value;
        }

    }
}
