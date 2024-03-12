using Microsoft.VisualStudio.TestTools.UnitTesting;
using FishingContest;
using System;
using System.Globalization;
using System.Threading;

namespace TestFishingContest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestSum0()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Assert.AreEqual(Infile.Sum(Array.Empty<string>()), 0.0);
        }

        [TestMethod]
        public void TestSum1()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            string[] tokens = new string[] { "09:34", "keszeg", "0.7", "2.0"};
            Assert.AreEqual(Infile.Sum(tokens), 0.0);
        }

        [TestMethod]
        public void TestSum2()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            string[] tokens = new string[] { "09:34", "keszeg", "0.7", "2.0"};
            Assert.AreEqual(Infile.Sum(tokens), 0.0);
        }

        [TestMethod]
        public void TestSum3()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            string[] tokens = new string[] { "józsi", "09:34", "keszeg", "0.7", "2.0",
                                                      "10:02", "ponty",  "1.7", "5.7" };
            Assert.AreEqual(Infile.Sum(tokens), 5.7);
        }

        [TestMethod]
        public void TestSearch0()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Fisher fisher = Program.Search(new Infile("input0.txt"));
            Assert.AreEqual(fisher, null);
        }
   
        [TestMethod]
        public void TestSearch1()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Fisher fisher = Program.Search(new Infile("input1.txt"));
            Assert.AreEqual(fisher, null);
        }

        [TestMethod]
        public void TestSearch2()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Fisher fisher = Program.Search(new Infile("input2.txt"));
            Assert.AreEqual(fisher.Name, "Józsi");
        }

    }
}
