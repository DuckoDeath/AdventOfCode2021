using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode.Day3;

namespace UnitTestProject
{
    [TestClass]
    public class Day3Test
    {
        [TestMethod]
        public void TestExamplePart1()
        {
            var result = Day3.ExecutePart1(@"..\..\example3.txt");
            Assert.AreEqual(198, result);
        }

        [TestMethod]
        public void TestExamplePart2()
        {
            var result = Day3.ExecutePart2(@"..\..\example3.txt");
            Assert.AreEqual(230, result);
        }

        [TestMethod]
        public void TestActualPart1()
        {
            var result = Day3.ExecutePart1(@"..\..\..\AdventOfCode\Day3\input.txt");
            Assert.AreEqual(3912944, result);
        }

        [TestMethod]
        public void TestActualPart2()
        {
            var result = Day3.ExecutePart2(@"..\..\..\AdventOfCode\Day3\input.txt");
            Assert.AreEqual(4996233, result);
        }
    }
}
