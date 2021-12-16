using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day16
{
    public abstract class Packet
    {
        public long Value { get; protected set; }
        public long Version { get; set; }
        public int Type { get; set; }
        public string OriginalBinaryStr { get; set; }
        public string BinaryStr { get; set; }
        public List<Packet> SubPackets { get; set; } = new List<Packet>();

        public static Packet CreatePacketFromHex(string hexStr)
        {
            string binaryStr = string.Join(string.Empty, hexStr.Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')));
            return CreatePacketFromBinary(binaryStr);
        }

        public static Packet CreatePacketFromBinary(string binaryStr)
        {
            var version = Convert.ToInt64(binaryStr.Substring(0, 3), 2);
            var type = Convert.ToInt32(binaryStr.Substring(3, 3), 2);
            if (type == 4)
            {
                return new LiteralPacket(type, version, binaryStr);
            }
            return new OperatorPacket(type, version, binaryStr);
        }

        protected Packet(int type, long version, string binaryStr)
        {
            Type = type;
            Version = version;
            OriginalBinaryStr = binaryStr;
        }
    }
}
