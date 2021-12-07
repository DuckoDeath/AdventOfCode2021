using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode.Day1;

namespace UnitTestProject
{
    [TestClass]
    public class Day1Test
    {
        [TestMethod]
        public void TestExamplePart1()
        {
            var result = Day1.ExecutePart1(@"..\..\example1.txt");
            Assert.AreEqual(7, result);
        }

        [TestMethod]
        public void TestExamplePart2()
        {
            var result = Day1.ExecutePart2(@"..\..\example1.txt");
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void TestActualPart1()
        {
            var result = Day1.ExecutePart1(@"..\..\..\AdventOfCode\Day1\input.txt");
            Assert.AreEqual(1559, result);
        }

        [TestMethod]
        public void TestActualPart2()
        {
            var result = Day1.ExecutePart2(@"..\..\..\AdventOfCode\Day1\input.txt");
            Assert.AreEqual(1600, result);
        }
    }
}
