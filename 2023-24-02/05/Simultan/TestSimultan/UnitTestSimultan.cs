using static Simultan.Program;

namespace TestSimultan
{
    [TestClass]
    public class UnitTestSimultan
    {
        [TestMethod]
        public void EmptyFileThrowsException()
        {
            Assert.ThrowsException<EmptyFileException>(() =>
                Computing("test0.txt", out bool allEven, out int greatest));
        }

        [TestMethod]
        public void EmptyFileIsAllEven()
        {
            bool allEven = false;
            try
            {
                Computing("test0.txt", out allEven, out int greatest);
            }
            catch (EmptyFileException)
            {
                Assert.IsTrue(allEven);
            }
        }

        [TestMethod]
        public void TestFileTest23()
        {
            Computing("test23.txt", out bool allEven, out int greatest);
            Assert.IsFalse(allEven);
            Assert.AreEqual(3, greatest);
        }
        
        [TestMethod]
        public void TestFileTest21()
        {
            Computing("test21.txt", out bool allEven, out int greatest);
            Assert.IsTrue(allEven);
            Assert.AreEqual(3, greatest);
        }
    }
}
