using static CactusAssortment.Program;

namespace TestCactus
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void CactusTest()
        {
            for (int i = 0; i <= 2; ++i)
            {
                string cactus = "cactus" + i + ".txt";
                string red = "red" + i + ".txt";
                string mexico = "mexico" + i + ".txt";

                Assortment(cactus, red, mexico);

                using StreamReader redActual = File.OpenText(red);
                using StreamReader redExpected = File.OpenText("red.txt");
                Assert.AreEqual(redExpected, redActual);

                using StreamReader mexicoActual = File.OpenText(mexico);
                using StreamReader mexicoExpected = File.OpenText("mexico.txt");
                Assert.AreEqual(mexicoExpected, mexicoActual);
            }
        }
    }
}
