using Microsoft.VisualStudio.TestTools.UnitTesting;
using Puzzle5;

namespace UnitTestProject
{
    [TestClass]
    public class Day5Test
    {
        [TestMethod]
        public void TestExamplePart1()
        {
            var result = Program.ExecutePart1(@"..\..\example5.txt", true);
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void TestExamplePart2()
        {
            var result = Program.ExecutePart2(@"..\..\example5.txt", true);
            Assert.AreEqual(12, result);
        }

        [TestMethod]
        public void TestActualPart1()
        {
            var result = Program.ExecutePart1(@"..\..\..\Puzzle5\input.txt");
            Assert.AreEqual(4421, result);
        }

        [TestMethod]
        public void TestActualPart2()
        {
            var result = Program.ExecutePart2(@"..\..\..\Puzzle5\input.txt");
            Assert.AreEqual(18674, result);
        }
    }
}
