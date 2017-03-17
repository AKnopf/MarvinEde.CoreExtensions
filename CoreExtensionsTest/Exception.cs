using MarvinEde.CoreExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SysEx = System.Exception;

namespace MarvinEde.CoreExtensionsTest
{
    [TestClass]
    public class Exception
    {
        private class AException : SysEx
        {
            public AException(string message, SysEx inner) : base(message, inner) { }
            public AException(string message) : base(message) { }
        }
        private class BException : SysEx
        {
            public BException(string message, SysEx inner) : base(message, inner) { }
        }
        private class UnusedException : SysEx { }

        SysEx nestedException = new SysEx("1", new SysEx("2", new SysEx("3")));
        SysEx emptyException = new SysEx("empty");
        SysEx differentTypeException = new SysEx("System.Exception", new AException("a1", new BException("b", new AException("a2"))));

        [TestMethod]
        public void TestGetInnermostException()
        {
            Assert.AreEqual("3", nestedException.GetInnermostException().Message);
        }

        [TestMethod]
        public void TestGetInnermostExceptionIdempotent()
        {
            Assert.AreEqual("3", nestedException.GetInnermostException().GetInnermostException().GetInnermostException().Message);
        }

        [TestMethod]
        public void TestGetInnermostExceptionEmpty()
        {
            Assert.AreEqual("empty", emptyException.GetInnermostException().Message);
        }

        [TestMethod]
        public void TestGetFirstInnerException()
        {
            Assert.AreEqual("a1", differentTypeException.GetFirstInnerException<AException>().Message);
            Assert.AreEqual("b", differentTypeException.GetFirstInnerException<BException>().Message);
        }

        [TestMethod]
        public void TestGetFirstInnerExceptionReturnsSelfWhenMatching()
        {
            Assert.AreEqual("a1", differentTypeException.GetFirstInnerException<AException>().GetFirstInnerException<AException>().Message);
        }

        [TestMethod]
        public void TestGetFirstInnerExceptionReturnsNull()
        {
            Assert.IsNull(differentTypeException.GetFirstInnerException<UnusedException>());
        }

        [TestMethod]
        public void TestGetLastInnerException()
        {
            Assert.AreEqual("a2", differentTypeException.GetLastInnerException<AException>().Message);
            Assert.AreEqual("b", differentTypeException.GetLastInnerException<BException>().Message);
        }

        [TestMethod]
        public void TestGetLastInnerExceptionReturnsSelfWhenNoMoreMatchesLater()
        {
            Assert.AreEqual("a2", differentTypeException.GetLastInnerException<AException>().GetLastInnerException<AException>().Message);
        }

        [TestMethod]
        public void TestGetLastInnerExceptionReturnsNull()
        {
            Assert.IsNull(differentTypeException.GetLastInnerException<UnusedException>());
        }
    }
}
