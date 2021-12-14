using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class Day14Test : AbstractTest
    {
        private int day = 14;

        [TestMethod]
        public void TestExamplePart1()
        {
            var result = GetMethod(day, 1).Invoke(null, new object[] { $@"..\..\example{day}.txt", true });
            Assert.AreEqual(1588L, result);
        }

        [TestMethod]
        public void TestExamplePart2()
        {
            var result = GetMethod(day, 2).Invoke(null, new object[] { $@"..\..\example{day}.txt", true });
            Assert.AreEqual(2188189693529L, result);
        }

        [TestMethod] 
        public void TestActualPart1()
        {
            var result = GetMethod(day, 1).Invoke(null, new object[] { $@"..\..\..\AdventOfCode\Day{day}\input.txt", true });
            Assert.AreEqual(2712L, result);
        }

        [TestMethod]
        public void TestActualPart2()
        {
            var result = GetMethod(day, 2).Invoke(null, new object[] { $@"..\..\..\AdventOfCode\Day{day}\input.txt", true });
            Assert.AreEqual(96L, result);
        }
    }
}
