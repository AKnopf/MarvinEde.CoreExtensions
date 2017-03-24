using MarvinEde.CoreExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoreExtensionsTest
{
    [TestClass]
    public class Stream
    {
        [TestMethod]
        public void TestRead()
        {
            byte[] bytes;
            using(var file = System.IO.File.OpenRead("Files/TestFile.txt"))
            {
                bytes = file.ReadBytes();
            }
            Assert.AreEqual(33, bytes.Length);
            Assert.AreEqual("﻿This is for testing streams.\r\n", System.Text.Encoding.UTF8.GetString(bytes));
        }
    }
}
