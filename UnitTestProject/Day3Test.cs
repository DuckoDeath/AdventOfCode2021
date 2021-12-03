using Microsoft.VisualStudio.TestTools.UnitTesting;
using Puzzle3;

namespace UnitTestProject
{
    [TestClass]
    public class Day3Test
    {
        [TestMethod]
        public void TestExamplePart1()
        {
            var result = Program.ExecutePart1(@"..\..\example3.txt");
            Assert.AreEqual(198, result);
        }

        [TestMethod]
        public void TestExamplePart2()
        {
            var result = Program.ExecutePart2(@"..\..\example3.txt");
            Assert.AreEqual(230, result);
        }

        [TestMethod]
        public void TestActualPart1()
        {
            var result = Program.ExecutePart1(@"..\..\..\Puzzle3\input.txt");
            Assert.AreEqual(3912944, result);
        }

        [TestMethod]
        public void TestActualPart2()
        {
            var result = Program.ExecutePart2(@"..\..\..\Puzzle3\input.txt");
            Assert.AreEqual(4996233, result);
        }
    }
}
