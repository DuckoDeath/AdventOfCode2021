using Microsoft.VisualStudio.TestTools.UnitTesting;
using Puzzle2;

namespace UnitTestProject
{
    [TestClass]
    public class Day2Test
    {
        [TestMethod]
        public void TestDay2()
        {
            var result = Program.ExecutePart1(@"..\..\input2.txt");
            Assert.AreEqual(150, result);
            result = Program.ExecutePart2(@"..\..\input2.txt");
            Assert.AreEqual(900, result);
        }
    }
}
