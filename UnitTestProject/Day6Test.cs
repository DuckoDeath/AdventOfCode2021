using Microsoft.VisualStudio.TestTools.UnitTesting;
using Puzzle6;

namespace UnitTestProject
{
    [TestClass]
    public class Day6Test
    {
        [TestMethod]
        public void TestExamplePart1()
        {
            var result = Program.ExecutePart1(@"..\..\example6.txt", true);
            Assert.AreEqual(5934, result);
        }

        [TestMethod]
        public void TestExamplePart2()
        {
            var result = Program.ExecutePart2(@"..\..\example6.txt", true);
            Assert.AreEqual(26984457539, result);
        }

        [TestMethod]
        public void TestActualPart1()
        {
            var result = Program.ExecutePart1(@"..\..\..\Puzzle6\input.txt");
            Assert.AreEqual(353274, result);
        }

        [TestMethod]
        public void TestActualPart2()
        {
            var result = Program.ExecutePart2(@"..\..\..\Puzzle6\input.txt");
            Assert.AreEqual(1609314870967, result);
        }
    }
}
