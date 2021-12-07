using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode.Day2;

namespace UnitTestProject
{
    [TestClass]
    public class Day2Test
    {
        [TestMethod]
        public void TestExamplePart1()
        {
            var result = Day2.ExecutePart1(@"..\..\example2.txt");
            Assert.AreEqual(150, result);
        }

        [TestMethod]
        public void TestExamplePart2()
        {
            var result = Day2.ExecutePart2(@"..\..\example2.txt");
            Assert.AreEqual(900, result);
        }

        [TestMethod]
        public void TestActualPart1()
        {
            var result = Day2.ExecutePart1(@"..\..\..\AdventOfCode\Day2\input.txt");
            Assert.AreEqual(1250395, result);
        }

        [TestMethod]
        public void TestActualPart2()
        {
            var result = Day2.ExecutePart2(@"..\..\..\AdventOfCode\Day2\input.txt");
            Assert.AreEqual(1451210346, result);
        }
    }
}
