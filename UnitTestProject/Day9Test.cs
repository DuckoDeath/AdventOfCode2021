using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class Day9Test : AbstractTest
    {
        private int day = 9;

        [TestMethod]
        public void TestExamplePart1()
        {
            var result = GetMethod(day, 1).Invoke(null, new object[] { $@"..\..\example{day}.txt", true });
            Assert.AreEqual(15L, result);
        }

        [TestMethod]
        public void TestExamplePart2()
        {
            var result = GetMethod(day, 2).Invoke(null, new object[] { $@"..\..\example{day}.txt", true });
            Assert.AreEqual(1134L, result);
        }

        [TestMethod] 
        public void TestActualPart1()
        {
            var result = GetMethod(day, 1).Invoke(null, new object[] { $@"..\..\..\AdventOfCode\Day{day}\input.txt", true });
            Assert.AreEqual(448L, result);
        }

        [TestMethod]
        public void TestActualPart2()
        {
            var result = GetMethod(day, 2).Invoke(null, new object[] { $@"..\..\..\AdventOfCode\Day{day}\input.txt", true });
            Assert.AreEqual(1417248L, result);
        }
    }
}
