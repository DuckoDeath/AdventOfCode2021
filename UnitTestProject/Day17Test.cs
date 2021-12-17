using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class Day17Test : AbstractTest
    {
        private int day = 17;

        [TestMethod]
        public void TestExamplePart1()
        {
            var result = GetMethod(day, 1).Invoke(null, new object[] { $@"..\..\example{day}.txt", false });
            Assert.AreEqual(45L, result);
        }

        [TestMethod]
        public void TestExamplePart2()
        {
            var result = GetMethod(day, 2).Invoke(null, new object[] { $@"..\..\example{day}.txt", true });
            Assert.AreEqual(112L, result);
        }

        [TestMethod]
        public void TestActualPart1()
        {
            var result = GetMethod(day, 1).Invoke(null, new object[] { $@"..\..\..\AdventOfCode\Day{day}\input.txt", false });
            Assert.AreEqual(10585L, result);
        }

        [TestMethod]
        public void TestActualPart2()
        {
            var result = GetMethod(day, 2).Invoke(null, new object[] { $@"..\..\..\AdventOfCode\Day{day}\input.txt", true });
            Assert.AreEqual(5247L, result);
        }
    }
}
