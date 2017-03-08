using MarvinEde.CoreExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CoreExtensionsTest
{
    [TestClass]
    public class PresenceAndBlankness
    {
        protected IEnumerable<string> presentEnum = new List<string>() { "Present" };
        protected IEnumerable<string> blankEnum = new List<string>() { };

        protected IEnumerable<string> presentStrings = "All of those words are actually present".Split(' ');
        protected IEnumerable<string> blankStrings = new List<string>() { null, "", "  ", "\t", "\n", "\r", "0", "{}" };


        [TestMethod]
        public void TestEnumerable()
        {
            Assert.IsTrue(presentEnum.IsPresent(), "Should be present");
            Assert.IsFalse(presentEnum.IsBlank(), "Should not be blank");

        }

        [TestMethod]
        public void TestString()
        {
            foreach (var present in presentStrings)
            {
                Assert.IsTrue(present.IsPresent(), present + " should be present");
                Assert.IsFalse(present.IsBlank(), present + " should not be blank");
            }

            foreach (var blank in blankStrings)
            {
                Assert.IsTrue(blank.IsBlank(), blank + " should be blank");
                Assert.IsFalse(blank.IsPresent(), blank + " should not be present");
            }
        }
    }
}
