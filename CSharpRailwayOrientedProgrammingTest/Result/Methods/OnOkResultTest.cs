using Functional;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tests
{
    [TestClass]
    public partial class OnOkResultTest
    {
        [TestMethod]
        public void OnOkDoesCallActionOnOk()
        {
            int _global = 0;
            int testValue = 5;
            int expected = _global + testValue;
            var sut = Result<int, string>.Ok(-1);

            sut.OnOk(err => _global += testValue);

            Assert.AreEqual(expected, _global);
        }

        [TestMethod]
        public void OnOkDoesNotCallActionOnErr()
        {
            int _global = 0;
            int testValue = 5;
            int expected = _global;
            var sut = Result<int, string>.Err("What!");

            sut.OnOk(err => _global += testValue);

            Assert.AreEqual(expected, _global);
        }
    }
}