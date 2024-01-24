using Functional;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tests
{
    [TestClass]
    public partial class MapMaybeTest
    {
        [TestMethod]
        public void MapReturnsNoneOnNone()
        {
            Assert.AreEqual(Maybe<int>.None(), Maybe<int>.None().Map(x => x));
        }

        [TestMethod]
        public void MapReturnsSomeOnSome()
        {
            int value = 1;
            Assert.AreEqual(Maybe<int>.Some(value), Maybe<int>.Some(value).Map(x => x));
        }

        [TestMethod]
        public void MapReturnsMappedSomeOnSome()
        {
            int value = 1;
            Assert.AreEqual(Maybe<string>.Some(value.ToString()), Maybe<int>.Some(value).Map(x => x.ToString()));
        }

        [TestMethod]
        public void MapReturnsMappedSomeOnSomeInChain()
        {
            int value = 1;
            Assert.AreEqual(Maybe<string>.Some((value * value).ToString()), Maybe<int>.Some(value).Map(x => x * x).Map(x => x.ToString()));
        }
    }
}