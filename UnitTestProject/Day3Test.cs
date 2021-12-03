using Microsoft.VisualStudio.TestTools.UnitTesting;
using Puzzle3;

namespace UnitTestProject
{
    [TestClass]
    public class Day3Test
    {
        [TestMethod]
        public void TestDay3()
        {
            var result = Program.ExecutePart1(@"..\..\input3.txt");
            Assert.AreEqual(198, result);
            result = Program.ExecutePart2(@"..\..\input3.txt");
            Assert.AreEqual(230, result);
        }
    }
}
