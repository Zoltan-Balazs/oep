using static EvenNumbers.Program;

namespace TestEvenNumbers
{
    [TestClass]
    public class UnitEvenNumbers
    {
        [TestMethod]
        public void TestFileTest01()
        {
            Counting("test01.txt", out int countBegin, out int countEnd);
            Assert.AreEqual(0, countBegin);
            Assert.AreEqual(1, countEnd);
        }

        [TestMethod]
        public void TestFileTest10()
        {
            Counting("test10.txt", out int countBegin, out int countEnd);
            Assert.AreEqual(1, countBegin);
            Assert.AreEqual(0, countEnd);
        }

        [TestMethod]
        public void TestFileTest11()
        {
            Counting("test11.txt", out int countBegin, out int countEnd);
            Assert.AreEqual(1, countBegin);
            Assert.AreEqual(1, countEnd);
        }
    }
}
