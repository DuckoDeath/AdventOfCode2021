using Microsoft.VisualStudio.TestTools.UnitTesting;
using Puzzle1;

namespace UnitTestProject
{
    [TestClass]
    public class Day1Test
    {
        [TestMethod]
        public void TestDay1()
        {
            var result = Program.ExecutePart1(@"..\..\input1.txt");
            Assert.AreEqual(7, result);
            result = Program.ExecutePart2(@"..\..\input1.txt");
            Assert.AreEqual(5, result);
        }
    }
}
