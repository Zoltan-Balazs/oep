using Map;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace TestMap
{
    [TestClass]
    public class UnitTestMap
    {
        [TestMethod]
        public void TestSetEmpty()
        {
            Map.Map map = new();
            Assert.AreEqual(map.ToString(), "[]");

            map.Insert(new Map.Map.Item(1, "barack"));
            Assert.AreEqual(map.ToString(), "[(1:barack)]");
            Assert.AreEqual(1, map.Count());

            map.SetEmpty();
            Assert.AreEqual(map.ToString(), "[]");
            Assert.AreEqual(0, map.Count());
        }

        [TestMethod]
        public void TestInsert()
        {
            Map.Map map = new();

            Assert.AreEqual(map.In(1), false);

            map.Insert(new Map.Map.Item(1, "barack"));

            Assert.AreEqual(map.ToString(), "[(1:barack)]");
            Assert.AreEqual(map.In(1), true);

            map.Insert(new Map.Map.Item(2, "eper"));
            Assert.AreEqual(map.Count(), 2);
            Assert.AreEqual(map.ToString(), "[(1:barack)(2:eper)]");
            Assert.AreEqual(map.In(1), true);
            Assert.AreNotEqual(map.In(150), true);
            Assert.AreEqual(map.In(150), false);

            map.Insert(new Map.Map.Item(0, "alma"));
            Assert.AreEqual(map.Count(), 3);
            Assert.AreEqual(map.ToString(), "[(0:alma)(1:barack)(2:eper)]");

            map.Insert(new Map.Map.Item(5, "szilva"));
            map.Insert(new Map.Map.Item(4, "narancs"));
            Assert.AreEqual(map.Count(), 5);
            Assert.AreEqual(map.ToString(), "[(0:alma)(1:barack)(2:eper)(4:narancs)(5:szilva)]");

            Assert.ThrowsException<Map.Map.AlreadyExistingKeyException>(
                () => map.Insert(new Map.Map.Item(4, "mandarin"))
            );
        }

        [TestMethod]
        public void TestRemove()
        {
            Map.Map map = new();
            map.Insert(new Map.Map.Item(1, "barack"));
            map.Insert(new Map.Map.Item(2, "eper"));
            map.Insert(new Map.Map.Item(0, "alma"));
            map.Insert(new Map.Map.Item(5, "szilva"));
            map.Insert(new Map.Map.Item(4, "narancs"));
            Assert.AreEqual(map.ToString(), "[(0:alma)(1:barack)(2:eper)(4:narancs)(5:szilva)]");

            map.Remove(2);
            Assert.AreEqual(map.ToString(), "[(0:alma)(1:barack)(4:narancs)(5:szilva)]");

            map.Remove(0);
            Assert.AreEqual(map.ToString(), "[(1:barack)(4:narancs)(5:szilva)]");

            map.Remove(5);
            Assert.AreEqual(map.ToString(), "[(1:barack)(4:narancs)]");

            Assert.ThrowsException<Map.Map.NonExistingKeyException>(() => map.Remove(5));
        }

        [TestMethod]
        public void TestSelect()
        {
            Map.Map map = new();

            map.Insert(new Map.Map.Item(1, "barack"));
            map.Insert(new Map.Map.Item(2, "eper"));
            map.Insert(new Map.Map.Item(0, "alma"));
            Assert.AreEqual(map.Select(2), "eper");
            Assert.ThrowsException<Map.Map.NonExistingKeyException>(() => map.Select(5));
        }

        [TestMethod]
        public void TestCount()
        {
            Map.Map map = new();
            Assert.AreEqual(map.Count(), 0);

            map.Insert(new Map.Map.Item(1, "barack"));
            map.Insert(new Map.Map.Item(2, "eper"));
            map.Insert(new Map.Map.Item(0, "alma"));
            Assert.AreEqual(map.Count(), 3);

            map.SetEmpty();
            Assert.AreEqual(map.Count(), 0);
        }

        [TestMethod]
        public void TestIn()
        {
            Map.Map map = new();
            Assert.AreEqual(map.In(2), false);

            map.Insert(new Map.Map.Item(1, "barack"));
            map.Insert(new Map.Map.Item(2, "eper"));
            map.Insert(new Map.Map.Item(0, "alma"));
            Assert.AreEqual(map.In(2), true);
            Assert.AreEqual(map.In(5), false);
        }
    }
}
