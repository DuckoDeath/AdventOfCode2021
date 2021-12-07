using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode.Day7;

namespace UnitTestProject
{
    [TestClass]
    public class Day7Test
    {
        private int day = 7;

        [TestMethod]
        public void TestExamplePart1()
        {
            var result = Day7.ExecutePart1($@"..\..\example{day}.txt", true);
            Assert.AreEqual(37, result);
        }

        [TestMethod]
        public void TestExamplePart2()
        {
            var result = Day7.ExecutePart2($@"..\..\example{day}.txt", true);
            Assert.AreEqual(168, result);
        }

        [TestMethod] 
        public void TestActualPart1()
        {
            var result = Day7.ExecutePart1($@"..\..\..\AdventOfCode\Day{day}\input.txt");
            Assert.AreEqual(355521, result);
        }

        [TestMethod]
        public void TestActualPart2()
        {
            var result = Day7.ExecutePart2($@"..\..\..\AdventOfCode\Day{day}\input.txt");
            Assert.AreEqual(100148777, result);
        }
    }
}
