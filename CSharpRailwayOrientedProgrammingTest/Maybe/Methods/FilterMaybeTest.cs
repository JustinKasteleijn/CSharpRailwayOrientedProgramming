using Functional;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tests
{
    [TestClass]
    public partial class FilterMaybeTest
    {
        [TestMethod]
        public void FilterReturnsNoneWhenNone()
        {
            Assert.AreEqual(Maybe<int>.None(), Maybe<int>.None().Filter(x => x == 0));
        }

        [TestMethod]
        public void FilterReturnsNoneWhenPredicateFalse()
        {
            Assert.AreEqual(Maybe<int>.None(), Maybe<int>.Some(-1).Filter(x => x >= 0));
        }

        [TestMethod]
        public void FilterReturnsSomeWhenPredicateTrue()
        {
            int expected = 1;
            Assert.AreEqual(Maybe<int>.Some(expected), Maybe<int>.Some(expected).Filter(x => x >= 0));
        }
    }
}