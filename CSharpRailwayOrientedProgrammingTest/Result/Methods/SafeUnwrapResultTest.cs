using Functional;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tests
{
    [TestClass]
    public partial class SafeUnwrapResultTest
    {
        [TestMethod]
        public void SafeUnwrapReturnsSomeValueOnOk()
        {
            int value = 1;
            var sut = Result<int, string>.Ok(value);
            var expected = Maybe<int>.Some(value);

            Assert.AreEqual(expected, sut.SafeUnwrap());
        }

        [TestMethod]
        public void SafeUnwrapReturnsNoneOnErr()
        {
            var sut = Result<int, string>.Err("What!");
            var expected = Maybe<int>.None();

            Assert.AreEqual(expected, sut.SafeUnwrap());
        }
    }
}