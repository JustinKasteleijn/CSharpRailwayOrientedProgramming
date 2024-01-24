using Functional;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tests {
    [TestClass]
    public partial class AndMaybeTest
    {

        [TestMethod]
        public void AndReturnsEarlyNone()
        {
            var expected = Maybe<int>.None();
            var x = Maybe<int>.None();
            var y = Maybe<int>.None();

            Assert.AreEqual(expected, x.And(y));
        }

        [TestMethod]
        public void AndReturnsLateNone()
        {
            int testValue = 1;
            var expected = Maybe<int>.None();
            var x = Maybe<int>.None();
            var y = Maybe<int>.Some(testValue);

            Assert.AreEqual(expected, y.And(x));
        }

        [TestMethod]
        public void AndReturnsLateNoneForDoubleNone()
        {
            var expected = Maybe<int>.None();
            var x = Maybe<int>.None();
            var y = Maybe<int>.None();

            Assert.AreEqual(expected, y.And(x));
        }

        [TestMethod]
        public void AndReturnsLateSomeForDoubleSome()
        {
            int testValue = 1;
            var expected = Maybe<int>.Some(testValue);
            var x = Maybe<int>.Some(-1);
            var y = Maybe<int>.Some(testValue);

            Assert.AreEqual(expected, x.And(y));
        }
    }
}