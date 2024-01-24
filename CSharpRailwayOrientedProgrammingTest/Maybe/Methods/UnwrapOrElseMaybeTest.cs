using Functional;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tests
{
    [TestClass]
    public partial class UnwrapOrElseMaybeTest
    {
        [TestMethod]
        public void UnwrapOrElseReturnsFallbackFunctionOnNone()
        {
            string expected = "This is the fallback";
            var sut = Maybe<object>.None();
            string fallback() => expected;

            Assert.AreEqual(expected, sut.UnwrapOrElse(fallback));
        }

        [TestMethod]
        public void UnwrapOrElseReturnValueOnSome()
        {
            int expected = -1;
            var sut = Maybe<object>.Some(expected);
            string fallback() => "This does not matter";

            Assert.AreEqual(expected, sut.UnwrapOrElse(fallback));
        }
    }
}