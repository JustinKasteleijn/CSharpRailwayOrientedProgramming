using Functional;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tests
{
    [TestClass]
    public partial class OnErrResultTest
    {
        [TestMethod]
        public void OnErrDoesNotCallActionOnOk()
        {
            int _global = 0;
            int testValue = 5;
            int expected = _global;
            var sut = Result<int, string>.Ok(-1);

            sut.OnErr(err => _global += testValue);

            Assert.AreEqual(expected, _global);
        }

        [TestMethod]
        public void OnErrDoesCallActionOnErr()
        {
            int _global = 0;
            int testValue = 5;
            int expected = _global + testValue;
            var sut = Result<int, string>.Err("What!");

            sut.OnErr(err => _global += testValue);

            Assert.AreEqual(expected, _global);
        }
    }
}