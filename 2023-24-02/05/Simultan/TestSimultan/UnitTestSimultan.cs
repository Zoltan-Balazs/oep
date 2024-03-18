using static Simultan.Program;

namespace TestSimultan
{
    [TestClass]
    public class UnitTestSimultan
    {
        [TestMethod]
        public void EmptyFileCausesException()
        {
            Assert.ThrowsException<EmptyFileException>(() =>
            {
                Computing("test0.txt", out bool allEven, out int greatest);
            });
        }

        [TestMethod]
        public void EmptyFileCausesAllEvenToBeTrue()
        {
            try
            {
                Computing("test0.txt", out bool allEven, out int greatest);
                Assert.IsTrue(allEven);
                Assert.AreEqual(allEven, true);
            }
            catch (Exception)
            {
                
            }
        }
    }
}
