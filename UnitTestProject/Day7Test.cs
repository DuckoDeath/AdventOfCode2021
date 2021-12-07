using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode.Day7;

namespace UnitTestProject
{
    [TestClass]
    public class Day7Test
    {
        [TestMethod]
        public void TestExamplePart1()
        {
            var result = Day7.ExecutePart1(@"..\..\example7.txt", true);
            Assert.AreEqual(5934, result);
        }

        [TestMethod]
        public void TestExamplePart2()
        {
            var result = Day7.ExecutePart2(@"..\..\example7.txt", true);
            Assert.AreEqual(26984457539, result);
        }

        [TestMethod]
        public void TestActualPart1()
        {
            var result = Day7.ExecutePart1(@"..\..\..\AdventOfCode\Day6\input.txt");
            Assert.AreEqual(353274, result);
        }

        [TestMethod]
        public void TestActualPart2()
        {
            var result = Day7.ExecutePart2(@"..\..\..\AdventOfCode\Day6\input.txt");
            Assert.AreEqual(1609314870967, result);
        }
    }
}
