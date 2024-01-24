using Functional;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tests
{
    [TestClass]
    public partial class MatchMaybeTest
    {
        [TestMethod]
        public void MatchCallsOnNoneWhenNone()
        {
            int expected = -1;
            Assert.AreEqual(expected, Maybe<int>.None().Match(x => x, () => -1));
        }

        [TestMethod]
        public void MatchCallsOnSomeWhenSome()
        {
            int expected = 1;
            Assert.AreEqual(expected, Maybe<int>.Some(expected).Match(x => x, () => -1));
        }
    }
}