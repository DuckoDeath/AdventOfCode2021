using Microsoft.VisualStudio.TestTools.UnitTesting;
using Puzzle2;

namespace UnitTestProject
{
    [TestClass]
    public class Day2Test
    {
        [TestMethod]
        public void TestExamplePart1()
        {
            var result = Program.ExecutePart1(@"..\..\example2.txt");
            Assert.AreEqual(150, result);
        }

        [TestMethod]
        public void TestExamplePart2()
        {
            var result = Program.ExecutePart2(@"..\..\example2.txt");
            Assert.AreEqual(900, result);
        }

        [TestMethod]
        public void TestActualPart1()
        {
            var result = Program.ExecutePart1(@"..\..\..\Puzzle2\input.txt");
            Assert.AreEqual(1250395, result);
        }

        [TestMethod]
        public void TestActualPart2()
        {
            var result = Program.ExecutePart2(@"..\..\..\Puzzle2\input.txt");
            Assert.AreEqual(1451210346, result);
        }
    }
}
