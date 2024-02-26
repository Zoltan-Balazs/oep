using AHM;

namespace Test_AHM
{
    [TestClass]
    public class UnitTest_AHM
    {
        [TestMethod]
        public void TestReadWrite()
        {
            AHM.AHM ahm = new(3);
            ahm[1,1] = 1.0;
            ahm[2,1] = 2.0; ahm[2,2] = 2.0;
            ahm[3,1] = 3.0; ahm[3,2] = 3.0; ahm[3,3] = 3.0;
            Assert.AreEqual(ahm[3,1], 3.0);
            Assert.AreEqual(ahm[3,3], 3.0);
            Assert.AreEqual(ahm[2,1], 2.0);
            Assert.ThrowsException<IndexOutOfRangeException>(() => ahm[0,0] = 0.0);
        }

        [TestMethod]
        public void TestAdd()
        {
            AHM.AHM a = new(3);
            a[1, 1] = 1.0;
            a[2, 1] = 2.0; a[2, 2] = 2.0;
            a[3, 1] = 3.0; a[3, 2] = 3.0; a[3, 3] = 3.0;
            AHM.AHM b = new(3);
            b[1, 1] = 1.0;
            b[2, 1] = 2.0; b[2, 2] = 2.0;
            b[3, 1] = 3.0; b[3, 2] = 3.0; b[3, 3] = 3.0;
            AHM.AHM c = a + b;
            Assert.AreEqual(c[1, 1], 2.0);
            Assert.AreEqual(c[2, 2], 4.0);
            Assert.AreEqual(c[3, 1], 6.0);
            c = b + a;
            Assert.AreEqual(c[1, 1], 2.0);
            Assert.AreEqual(c[2, 2], 4.0);
            Assert.AreEqual(c[3, 1], 6.0);
        }

        [TestMethod]
        public void TestMul()
        {
            AHM.AHM a = new(3);
            a[1, 1] = 1.0;
            a[2, 1] = 2.0; a[2, 2] = 2.0;
            a[3, 1] = 3.0; a[3, 2] = 3.0; a[3, 3] = 3.0;
            AHM.AHM b = new(3);
            b[1, 1] = 1.0;
            b[2, 1] = 0.0; b[2, 2] = 1.0;
            b[3, 1] = 0.0; b[3, 2] = 0.0; b[3, 3] = 1.0;
            AHM.AHM c = a * b;
            Assert.AreEqual(c[1, 1], 1.0);
            Assert.AreEqual(c[2, 2], 2.0);
            Assert.AreEqual(c[3, 1], 3.0);
            c = b * a;
            Assert.AreEqual(c[1, 1], 1.0);
            Assert.AreEqual(c[2, 2], 2.0);
            Assert.AreEqual(c[3, 1], 3.0);
        }
    }
}