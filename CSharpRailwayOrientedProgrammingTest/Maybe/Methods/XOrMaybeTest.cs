using Functional;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tests
{
    [TestClass]
    public partial class XOrMaybeTest
    {
        [TestMethod]
        public void XOrReturnsNoneWhenBothNone()
        {
            var opt_a = Maybe<int>.None();
            var opt_b = Maybe<int>.None();
            var expected = Maybe<int>.None();

            Assert.AreEqual(expected, opt_a.XOr(opt_b));
        }

        [TestMethod]
        public void XOrReturnsNoneWhenBothSome()
        {
            var opt_a = Maybe<int>.Some(1);
            var opt_b = Maybe<int>.Some(-1);
            var expected = Maybe<int>.None();

            Assert.AreEqual(expected, opt_a.XOr(opt_b));
        }

        [TestMethod]
        public void XOrReturnsOptAWhenSomeOptBNone()
        {
            int value = 1;
            var opt_a = Maybe<int>.Some(value);
            var opt_b = Maybe<int>.None();
            var expected = Maybe<int>.Some(value);

            Assert.AreEqual(expected, opt_a.Or(opt_b));
        }

        [TestMethod]
        public void XOrReturnsOptBWhenSomeOptANone()
        {
            int value = 1;
            var opt_b = Maybe<int>.Some(value);
            var opt_a = Maybe<int>.None();
            var expected = Maybe<int>.Some(value);

            Assert.AreEqual(expected, opt_a.Or(opt_b));
        }
    }
}