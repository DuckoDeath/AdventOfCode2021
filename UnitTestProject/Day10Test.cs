using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class Day10Test : AbstractTest
    {
        private int day = 10;

        [TestMethod]
        public void TestExamplePart1()
        {
            var result = GetMethod(day, 1).Invoke(null, new object[] { $@"..\..\example{day}.txt", true });
            Assert.AreEqual(26397L, result);
        }

        [TestMethod]
        public void TestExamplePart2()
        {
            var result = GetMethod(day, 2).Invoke(null, new object[] { $@"..\..\example{day}.txt", true });
            Assert.AreEqual(288957L, result);
        }

        [TestMethod] 
        public void TestActualPart1()
        {
            var result = GetMethod(day, 1).Invoke(null, new object[] { $@"..\..\..\AdventOfCode\Day{day}\input.txt", true });
            Assert.AreEqual(266301L, result);
        }

        [TestMethod]
        public void TestActualPart2()
        {
            var result = GetMethod(day, 2).Invoke(null, new object[] { $@"..\..\..\AdventOfCode\Day{day}\input.txt", true });
            Assert.AreEqual(3404870164L, result);
        }
    }
}
