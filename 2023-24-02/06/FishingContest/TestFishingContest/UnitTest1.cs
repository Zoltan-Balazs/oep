using Microsoft.VisualStudio.TestTools.UnitTesting;
using FishingContest;
using System.Globalization;
using System.Threading;

namespace TestFishingContest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestSearch0()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            InFile f = new("input0.txt");
            Fisher fisher = Program.Search(f);
            Assert.AreEqual(fisher, null);
        }
   
        [TestMethod]
        public void TestSearch1()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            InFile f = new("input1.txt");
            Fisher fisher = Program.Search(f);
            Assert.AreEqual(fisher, null);
        }

        [TestMethod]
        public void TestSearch2()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            InFile f = new("input2.txt");
            Fisher fisher = Program.Search(f);
            Assert.AreEqual(fisher.name, "Józsi");
        }
    }
}
