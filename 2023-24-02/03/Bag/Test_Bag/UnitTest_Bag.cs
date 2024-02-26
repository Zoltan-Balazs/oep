using Bag; 

namespace Test_Bag
{
    [TestClass]
    public class UnitTest_Bag
    {
        [TestMethod]
        public void TestSetEmpty()
        {
            Bag.Bag bag = new();
            Assert.AreEqual(bag.ToString(), "[]");

            bag.Insert("barack");
            Assert.AreEqual(bag.ToString(), "[(barack:1)]");

            bag.SetEmpty();
            Assert.AreEqual(bag.ToString(), "[]");
        }

        [TestMethod]
        public void TestEmpty()
        {
            Bag.Bag bag = new();
            Assert.AreEqual(bag.Empty(), true);

            bag.Insert("barack");
            Assert.AreEqual(bag.Empty(), false);
        }

        [TestMethod]
        public void TestMultipl()
        {
            Bag.Bag bag = new();
            Assert.AreEqual(bag.Multipl("barack"), 0);

            bag.Insert("barack");
            bag.Insert("alma");
            bag.Insert("barack");
            Assert.AreEqual(bag.Multipl("barack"), 2);
        }

        [TestMethod]
        public void TestMax()
        {
            Bag.Bag bag = new();
            // Assert.ThrowsException<Bag.Bag.EmptyBagException>( () => bag.Max() );
            bag.Insert("alma");
            bag.Insert("barack");
            bag.Insert("barack");
            Assert.AreEqual(bag.Max(), "barack");
        }

        [TestMethod]
        public void TestInsert()
        {
            Bag.Bag bag = new();
            Assert.AreEqual(bag.ToString(), "[]");
            bag.Insert("alma");
            Assert.AreEqual(bag.ToString(), "[(alma:1)]");
            bag.Insert("barack");
            Assert.AreEqual(bag.ToString(), "[(alma:1)(barack:1)]");
            bag.Insert("barack");
            Assert.AreEqual(bag.ToString(), "[(alma:1)(barack:2)]");
        }

        [TestMethod]
        public void TestRemove()
        {
            Bag.Bag bag = new();
            bag.Insert("alma");
            bag.Insert("barack");
            bag.Insert("barack");
            Assert.AreEqual(bag.ToString(), "[(alma:1)(barack:2)]");
            bag.Remove("barack");
            Assert.AreEqual(bag.ToString(), "[(alma:1)(barack:1)]");
            bag.Remove("alma");
            Assert.AreEqual(bag.ToString(), "[(barack:1)]");
        }
    }
}