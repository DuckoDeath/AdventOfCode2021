using AdventOfCode.Day16;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class Day16Test : AbstractTest
    {
        private int day = 16;

        [TestMethod]
        public void TestLiteral()
        {
            var p = Packet.CreatePacketFromHex("D2FE28");
            Assert.IsTrue(p is LiteralPacket);
            Assert.AreEqual("110100101111111000101", p.BinaryStr);
            Assert.AreEqual(6, p.Version);
            Assert.AreEqual(4, p.Type);
            var lp = (LiteralPacket)p;
            var parts = lp.Parts;
            Assert.AreEqual(3, parts.Count);
            Assert.AreEqual("0111", parts[0]);
            Assert.AreEqual("1110", parts[1]);
            Assert.AreEqual("0101", parts[2]);
            Assert.AreEqual(2021, lp.Value);

            Assert.AreEqual(6, Day16.SumVersion(lp));
        }

        [TestMethod]
        public void TestOperator1()
        {
            var p = Packet.CreatePacketFromHex("38006F45291200");
            Assert.IsTrue(p is OperatorPacket);
            Assert.AreEqual("0011100000000000011011110100010100101001000100100", p.BinaryStr);
            Assert.AreEqual(1, p.Version);
            Assert.AreEqual(6, p.Type);
            var op = (OperatorPacket)p;
            Assert.AreEqual(0, op.LengthTypeId);
            Assert.AreEqual(27, op.SubpacketBitLength);
            Assert.AreEqual(null, op.NumberOfSubpackets);
            Assert.AreEqual(2, op.SubPackets.Count);

            var lp = (LiteralPacket)op.SubPackets[0];
            Assert.AreEqual(6, lp.Version);
            var parts = lp.Parts;
            Assert.AreEqual(1, parts.Count);
            Assert.AreEqual("1010", parts[0]);
            Assert.AreEqual(10, lp.Value);

            lp = (LiteralPacket)op.SubPackets[1];
            Assert.AreEqual(2, lp.Version);
            parts = lp.Parts;
            Assert.AreEqual(2, parts.Count);
            Assert.AreEqual("0001", parts[0]);
            Assert.AreEqual("0100", parts[1]);
            Assert.AreEqual(20, lp.Value);

            Assert.AreEqual(9, Day16.SumVersion(p));
        }

        [TestMethod]
        public void TestOperator2()
        {
            var p = Packet.CreatePacketFromHex("EE00D40C823060");
            Assert.IsTrue(p is OperatorPacket);
            Assert.AreEqual("11101110000000001101010000001100100000100011000001100000", p.OriginalBinaryStr);
            Assert.AreEqual("111011100000000011010100000011001000001000110000011", p.BinaryStr);
            Assert.AreEqual(7, p.Version);
            Assert.AreEqual(3, p.Type);
            var op = (OperatorPacket)p;
            Assert.AreEqual(1, op.LengthTypeId);
            Assert.AreEqual(null, op.SubpacketBitLength);
            Assert.AreEqual(3, op.NumberOfSubpackets);
            Assert.AreEqual(3, op.SubPackets.Count);

            var lp = (LiteralPacket)op.SubPackets[0];
            Assert.AreEqual(2, lp.Version);
            var parts = lp.Parts;
            Assert.AreEqual(1, parts.Count);
            Assert.AreEqual("0001", parts[0]);
            Assert.AreEqual(1, lp.Value);

            lp = (LiteralPacket)op.SubPackets[1];
            Assert.AreEqual(4, lp.Version);
            parts = lp.Parts;
            Assert.AreEqual(1, parts.Count);
            Assert.AreEqual("0010", parts[0]);
            Assert.AreEqual(2, lp.Value);

            lp = (LiteralPacket)op.SubPackets[2];
            Assert.AreEqual(1, lp.Version);
            parts = lp.Parts;
            Assert.AreEqual(1, parts.Count);
            Assert.AreEqual("0011", parts[0]);
            Assert.AreEqual(3, lp.Value);

            Assert.AreEqual(14, Day16.SumVersion(p));
        }

        [TestMethod]
        public void TestExamplePart1a()
        {
            var result = GetMethod(day, 1).Invoke(null, new object[] { $@"..\..\example{day}a.txt", false });
            Assert.AreEqual(16L, result);
        }

        [TestMethod]
        public void TestExamplePart1b()
        {
            var result = GetMethod(day, 1).Invoke(null, new object[] { $@"..\..\example{day}b.txt", false });
            Assert.AreEqual(12L, result);
        }

        [TestMethod]
        public void TestExamplePart1c()
        {
            var result = GetMethod(day, 1).Invoke(null, new object[] { $@"..\..\example{day}c.txt", false });
            Assert.AreEqual(23L, result);
        }

        [TestMethod]
        public void TestExamplePart1d()
        {
            var result = GetMethod(day, 1).Invoke(null, new object[] { $@"..\..\example{day}d.txt", false });
            Assert.AreEqual(31L, result);
        }

        [TestMethod]
        public void TestExamplePart2e()
        {
            var result = GetMethod(day, 2).Invoke(null, new object[] { $@"..\..\example{day}e.txt", true });
            Assert.AreEqual(3L, result);
        }

        [TestMethod]
        public void TestExamplePart2f()
        {
            var result = GetMethod(day, 2).Invoke(null, new object[] { $@"..\..\example{day}f.txt", true });
            Assert.AreEqual(54L, result);
        }

        [TestMethod]
        public void TestExamplePart2g()
        {
            var result = GetMethod(day, 2).Invoke(null, new object[] { $@"..\..\example{day}g.txt", true });
            Assert.AreEqual(7L, result);
        }

        [TestMethod]
        public void TestExamplePart2h()
        {
            var result = GetMethod(day, 2).Invoke(null, new object[] { $@"..\..\example{day}h.txt", true });
            Assert.AreEqual(9L, result);
        }

        [TestMethod]
        public void TestExamplePart2i()
        {
            var result = GetMethod(day, 2).Invoke(null, new object[] { $@"..\..\example{day}i.txt", true });
            Assert.AreEqual(1L, result);
        }

        [TestMethod]
        public void TestExamplePart2j()
        {
            var result = GetMethod(day, 2).Invoke(null, new object[] { $@"..\..\example{day}j.txt", true });
            Assert.AreEqual(0L, result);
        }

        [TestMethod]
        public void TestExamplePart2k()
        {
            var result = GetMethod(day, 2).Invoke(null, new object[] { $@"..\..\example{day}k.txt", true });
            Assert.AreEqual(0L, result);
        }

        [TestMethod]
        public void TestExamplePart2l()
        {
            var result = GetMethod(day, 2).Invoke(null, new object[] { $@"..\..\example{day}l.txt", true });
            Assert.AreEqual(1L, result);
        }

        [TestMethod] 
        public void TestActualPart1()
        {
            var result = GetMethod(day, 1).Invoke(null, new object[] { $@"..\..\..\AdventOfCode\Day{day}\input.txt", false });
            Assert.AreEqual(971L, result);
        }

        [TestMethod]
        public void TestActualPart2()
        {
            var result = GetMethod(day, 2).Invoke(null, new object[] { $@"..\..\..\AdventOfCode\Day{day}\input.txt", true });
            Assert.AreEqual(45713593L, result);
        }
    }
}
