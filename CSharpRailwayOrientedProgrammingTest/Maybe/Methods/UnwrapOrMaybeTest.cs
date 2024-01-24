using Functional;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tests
{
    [TestClass]
    public partial class UnwrapOrMaybeTest
    {
        [TestMethod]
        public void UnwrapOrReturnsFallbackValueOnNone()
        {
            string expected = "This is the fallback";
            var sut = Maybe<object>.None();
            string fallback = expected;

            Assert.AreEqual(expected, sut.UnwrapOr(fallback));
        }

        [TestMethod]
        public void UnwrapOrReturnValueOnSome()
        {
            int expected = 1;
            var sut = Maybe<int>.Some(expected);
            int fallback = -1;

            Assert.AreEqual(expected, sut.UnwrapOr(fallback));
        }
    }
}