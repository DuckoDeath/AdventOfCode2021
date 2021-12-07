using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode.Day5;

namespace UnitTestProject
{
    [TestClass]
    public class Day5Test
    {
        [TestMethod]
        public void TestExamplePart1()
        {
            var result = Day5.ExecutePart1(@"..\..\example5.txt", true);
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void TestExamplePart2()
        {
            var result = Day5.ExecutePart2(@"..\..\example5.txt", true);
            Assert.AreEqual(12, result);
        }

        [TestMethod]
        public void TestActualPart1()
        {
            var result = Day5.ExecutePart1(@"..\..\..\AdventOfCode\Day5\input.txt");
            Assert.AreEqual(4421, result);
        }

        [TestMethod]
        public void TestActualPart2()
        {
            var result = Day5.ExecutePart2(@"..\..\..\AdventOfCode\Day5\input.txt");
            Assert.AreEqual(18674, result);
        }
    }
}
