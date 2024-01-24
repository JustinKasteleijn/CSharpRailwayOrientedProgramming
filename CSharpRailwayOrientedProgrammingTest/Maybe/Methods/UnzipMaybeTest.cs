using Microsoft.VisualStudio.TestTools.UnitTesting;
using Functional;
using System;

namespace tests
{
    [TestClass]
    public partial class UnzipMaybeTest
    {
        [TestMethod]
        public void UnzipsMaybeWithTupleSome()
        {
            int expected_item1 = 1;
            string expected_item2 = "one";
            var expected = new Tuple<Maybe<int>, Maybe<string>>(Maybe<int>.Some(expected_item1), Maybe<string>.Some(expected_item2));
            var sut = Maybe<Tuple<int, string>>.Some(new Tuple<int, string>(expected_item1, expected_item2));

            Assert.AreEqual(expected, sut.Unzip());
        }

        [TestMethod]
        public void UnzipsMaybeWithTupleNone()
        {
            var expected = new Tuple<Maybe<int>, Maybe<string>>(Maybe<int>.None(), Maybe<string>.None());
            var sut = Maybe<Tuple<int, string>>.None();

            Assert.AreEqual(expected, sut.Unzip());
        }
    }
}