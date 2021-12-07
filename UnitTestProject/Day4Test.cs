using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode.Day4;

namespace UnitTestProject
{
    [TestClass]
    public class Day4Test
    {
        [TestMethod]
        public void TestExamplePart1()
        {
            var result = Day4.ExecutePart1(@"..\..\example4.txt");
            Assert.AreEqual(4512, result);
        }

        [TestMethod]
        public void TestExamplePart2()
        {
            var result = Day4.ExecutePart2(@"..\..\example4.txt");
            Assert.AreEqual(1924, result);
        }

        [TestMethod]
        public void TestActualPart1()
        {
            var result = Day4.ExecutePart1(@"..\..\..\AdventOfCode\Day4\input.txt");
            Assert.AreEqual(8580, result);
        }

        [TestMethod]
        public void TestActualPart2()
        {
            var result = Day4.ExecutePart2(@"..\..\..\AdventOfCode\Day4\input.txt");
            Assert.AreEqual(9576, result);
        }
    }
}
