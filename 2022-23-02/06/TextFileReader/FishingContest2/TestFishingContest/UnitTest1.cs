using Microsoft.VisualStudio.TestTools.UnitTesting;
using FishingContest;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace TestFishingContest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestOK0()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            string[] tokens = new string[] { "Józsi" };
            Assert.AreEqual(false, Infile.OK(tokens));
        }

        [TestMethod]
        public void TestOK1()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            string[] tokens = new string[] { "Józsi",   "09:55", "harcsa",  "1.0", "1.0",
                                                        "09:55", "harcsa",  "1.0", "1.0",
                                                        "09:55", "harcsa",  "1.0", "1.0",
                                                        "09:55", "harcsa",  "1.0", "1.0"  };
            Assert.AreEqual(false, Infile.OK(tokens));
        }

        [TestMethod]
        public void TestOK2()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            string[] tokens = new string[] { "Józsi",   "09:55", "ponty",   "1.0", "1.0",
                                                        "09:55", "harcsa",  "1.0", "1.0",
                                                        "09:55", "harcsa",  "1.0", "1.0",
                                                        "09:55", "harcsa",  "1.0", "1.0",
                                                        "09:55", "harcsa",  "0.9", "0.9"  };
            Assert.AreEqual(false, Infile.OK(tokens));
        }

        [TestMethod]
        public void TestOK3()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            string[] tokens = new string[] { "Józsi",   "09:55", "ponty",   "1.0", "1.0",
                                                        "09:55", "harcsa",  "1.0", "1.0",
                                                        "09:55", "harcsa",  "1.0", "1.0",
                                                        "09:55", "harcsa",  "1.0", "1.0"  };
            Assert.AreEqual(false, Infile.OK(tokens));
        }

        [TestMethod]
        public void TestOK10()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            string[] tokens = new string[] { "Józsi",   "09:55", "ponty",   "1.0", "1.0",
                                                        "09:55", "harcsa",  "1.0", "1.0",
                                                        "09:55", "harcsa",  "1.0", "1.0",
                                                        "09:55", "harcsa",  "1.0", "1.0",
                                                        "09:55", "harcsa",  "1.0", "1.0"  };
            Assert.AreEqual(true, Infile.OK(tokens));
        }
    }
}
