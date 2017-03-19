using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using MarvinEde.CoreExtensions;
using System.Linq;

namespace CoreExtensionsTest
{
    [TestClass]
    public class String
    {
        private enum Fruit {  Apple, Peach, Melon }
        private enum Characters { Mario, Bowser, Peach }
        [TestMethod]
        public void TestToEnum()
        {
            Assert.AreEqual(Fruit.Peach, "Peach".ToEnum<Fruit>());
            Assert.AreEqual(Characters.Peach, "Peach".ToEnum<Characters>());
        }

        [TestMethod]
        public void TestToEnumDefault()
        {
            Assert.AreEqual(Characters.Mario, "Apple".ToEnum<Characters>());
        }

        [TestMethod]
        public void TestSearchEnum()
        {
            var actual = "r".SearchEnum<Characters>().ToList();
            Assert.AreEqual(Characters.Mario, actual[0]);
            Assert.AreEqual(Characters.Bowser, actual[1]);
        }

        [TestMethod]
        public void TestSearchEnumCaseSensitive()
        {
            Assert.IsTrue("R".SearchEnum<Characters>(true).Any());
            Assert.IsFalse("R".SearchEnum<Characters>(false).Any());
        }
    }
}
