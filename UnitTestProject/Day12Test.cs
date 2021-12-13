using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class Day12Test : AbstractTest
    {
        private int day = 12;

        [TestMethod]
        public void TestExamplePart1a()
        {
            var result = GetMethod(day, 1).Invoke(null, new object[] { $@"..\..\example{day}a.txt", true });
            Assert.AreEqual(10L, result);
        }

        [TestMethod]
        public void TestExamplePart1b()
        {
            var result = GetMethod(day, 1).Invoke(null, new object[] { $@"..\..\example{day}b.txt", true });
            Assert.AreEqual(19L, result);
        }

        [TestMethod]
        public void TestExamplePart1c()
        {
            var result = GetMethod(day, 1).Invoke(null, new object[] { $@"..\..\example{day}c.txt", true });
            Assert.AreEqual(226L, result);
        }

        [TestMethod]
        public void TestExamplePart2a()
        {
            var result = GetMethod(day, 2).Invoke(null, new object[] { $@"..\..\example{day}a.txt", true });
            Assert.AreEqual(36L, result);
        }

        [TestMethod]
        public void TestExamplePart2b()
        {
            var result = GetMethod(day, 2).Invoke(null, new object[] { $@"..\..\example{day}b.txt", true });
            Assert.AreEqual(103L, result);
        }

        [TestMethod]
        public void TestExamplePart2c()
        {
            var result = GetMethod(day, 2).Invoke(null, new object[] { $@"..\..\example{day}c.txt", true });
            Assert.AreEqual(3509L, result);
        }

        [TestMethod] 
        public void TestActualPart1()
        {
            var result = GetMethod(day, 1).Invoke(null, new object[] { $@"..\..\..\AdventOfCode\Day{day}\input.txt", true });
            Assert.AreEqual(3887L, result);
        }

        [TestMethod]
        public void TestActualPart2()
        {
            var result = GetMethod(day, 2).Invoke(null, new object[] { $@"..\..\..\AdventOfCode\Day{day}\input.txt", true });
            Assert.AreEqual(104834L, result);
        }
    }
}
