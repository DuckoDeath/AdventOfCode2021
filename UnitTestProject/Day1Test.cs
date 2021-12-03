using Microsoft.VisualStudio.TestTools.UnitTesting;
using Puzzle1;

namespace UnitTestProject
{
    [TestClass]
    public class Day1Test
    {
        [TestMethod]
        public void TestExamplePart1()
        {
            var result = Program.ExecutePart1(@"..\..\input1.txt");
            Assert.AreEqual(7, result);
        }

        [TestMethod]
        public void TestExamplePart2()
        {
            var result = Program.ExecutePart2(@"..\..\input1.txt");
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void TestActualPart1()
        {
            var result = Program.ExecutePart1(@"..\..\..\Puzzle1\input.txt");
            Assert.AreEqual(1559, result);
        }

        [TestMethod]
        public void TestActualPart2()
        {
            var result = Program.ExecutePart2(@"..\..\..\Puzzle1\input.txt");
            Assert.AreEqual(1600, result);
        }
    }
}
