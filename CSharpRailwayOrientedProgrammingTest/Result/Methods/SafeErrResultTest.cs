using Functional;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tests
{
    [TestClass]
    public partial class SafeErrResultTest
    {
        [TestMethod]
        public void SafeErrReturnSomeOnErr()
        {
            string message = "What!";
            var sut = Result<int, string>.Err(message);
            var expected = Maybe<string>.Some("What!");

            Assert.AreEqual(expected, sut.SafeErr());
        }

        [TestMethod]
        public void SafeErrReturnNoneOnOk()
        {
            var sut = Result<int, string>.Ok(1);
            var expected = Maybe<string>.None();

            Assert.AreEqual(expected, sut.SafeErr());
        }
    }
}