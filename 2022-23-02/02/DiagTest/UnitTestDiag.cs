using Diagonal;

namespace DiagTest
{
    [TestClass]
    public class DiagTest
    {
        [TestMethod]
        public void Create()
        {
            Diag c = new(3);

            Assert.AreEqual(c[0, 1], 0);
            Assert.AreEqual(c[1, 1], 0);
        }

        [TestMethod]
        public void Change()
        {
            Diag c = new(3);
            c[0, 0] = 1;
            c[1, 1] = 1;
            c[2, 2] = 1;

            Assert.ThrowsException<Diag.ReferenceToNullPartException>(() => c[1, 0] = 3);
            Assert.AreEqual(c[0, 1], 0);
            Assert.AreEqual(c[1, 1], 1);
        }

        [TestMethod]
        public void Add()
        {
            Diag a = new(3);
            Diag b = new(3);
            Diag d = new(2);
            Diag c;

            a[0, 0] = 1;
            a[1, 1] = 1;
            a[2, 2] = 1;

            b[0, 0] = 42;
            b[1, 1] = 0;
            b[2, 2] = 0;

            c = a + b;

            Assert.AreEqual(c[0, 0], 43);
            Assert.AreEqual(c[1, 1], 1);

            Assert.ThrowsException<Diag.DifferentSizeException>(() => a + d);
        }

        [TestMethod]
        public void Mul()
        {
            Diag a = new(3);
            Diag b = new(3);
            Diag d = new(2);
            Diag c;

            a[0, 0] = 1;
            a[1, 1] = 1;
            a[2, 2] = 1;

            b[0, 0] = 42;
            b[1, 1] = 0;
            b[2, 2] = 0;

            c = a * b;

            Assert.AreEqual(c[0, 0], 42);
            Assert.AreEqual(c[1, 1], 0);

            Assert.ThrowsException<Diag.DifferentSizeException>(() => a * d);
        }
    }
}
