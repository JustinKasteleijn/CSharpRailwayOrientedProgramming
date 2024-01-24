using Functional;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tests
{
    [TestClass]
    public partial class FlattenMaybeTest
    {

        [TestMethod]
        public void FlattensSingleLayerSome()
        {
            var expected = Maybe<Maybe<int>>.Some(Maybe<int>.Some(1));
            var sut = Maybe<Maybe<Maybe<int>>>.Some(Maybe<Maybe<int>>.Some(Maybe<int>.Some(1)));
            Assert.AreEqual(expected, sut.Flatten());
        }

        [TestMethod]
        public void FlattensDoubleLayerSome()
        {
            var expected = Maybe<int>.Some(1);
            var sut = Maybe<Maybe<Maybe<int>>>.Some(Maybe<Maybe<int>>.Some(Maybe<int>.Some(1)));
            Assert.AreEqual(expected, sut.Flatten().Flatten());
        }

        [TestMethod]
        public void FlattensSingleLayerNone()
        {
            var expected = Maybe<Maybe<int>>.None();
            var sut = Maybe<Maybe<Maybe<int>>>.None();
            Assert.AreEqual(expected, sut.Flatten());
        }

        [TestMethod]
        public void FlattensDoubleLayerNone()
        {
            var expected = Maybe<int>.None();
            var sut = Maybe<Maybe<Maybe<int>>>.None();
            Assert.AreEqual(expected, sut.Flatten().Flatten());
        }
    }
}