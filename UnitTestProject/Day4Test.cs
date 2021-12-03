using Microsoft.VisualStudio.TestTools.UnitTesting;
using Puzzle4;

namespace UnitTestProject
{
    [TestClass]
    public class Day4Test
    {
        [TestMethod]
        public void TestExamplePart1()
        {
            var result = Program.ExecutePart1(@"..\..\example4.txt");
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void TestExamplePart2()
        {
            var result = Program.ExecutePart2(@"..\..\example4.txt");
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void TestActualPart1()
        {
            var result = Program.ExecutePart1(@"..\..\..\Puzzle4\input.txt");
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void TestActualPart2()
        {
            var result = Program.ExecutePart2(@"..\..\..\Puzzle4\input.txt");
            Assert.AreEqual(0, result);
        }
    }
}
