using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class Day8Test : AbstractTest
    {
        private int day = 8;

        [TestMethod]
        public void TestExamplePart1()
        {
            var result = GetMethod(day, 1).Invoke(null, new object[] { $@"..\..\example{day}.txt", true });
            Assert.AreEqual(26L, result);
        }

        [TestMethod]
        public void TestExamplePart2()
        {
            var result = GetMethod(day, 2).Invoke(null, new object[] { $@"..\..\example{day}.txt", true });
            Assert.AreEqual(61229L, result);
        }

        [TestMethod] 
        public void TestActualPart1()
        {
            var result = GetMethod(day, 1).Invoke(null, new object[] { $@"..\..\..\AdventOfCode\Day{day}\input.txt", true });
            Assert.AreEqual(470L, result);
        }

        [TestMethod]
        public void TestActualPart2()
        {
            var result = GetMethod(day, 2).Invoke(null, new object[] { $@"..\..\..\AdventOfCode\Day{day}\input.txt", true });
            Assert.AreEqual(989396L, result);
        }
    }
}
