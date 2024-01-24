using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Functional;

namespace tests
{
    [TestClass]
    public partial class ZipMaybeTest
    {
        [TestMethod]
        public void ZipsSomeValues()
        {
            var expected_item1 = Maybe<int>.Some(10);
            var expected_item2 = Maybe<string>.Some("Hello");

            Assert.AreEqual(Maybe<Tuple<int, string>>.Some(new Tuple<int, string>(expected_item1.Unwrap(), expected_item2.Unwrap())), expected_item1.Zip(expected_item2));
        }

        [TestMethod]
        public void ZipsNoneValues()
        {
            var expected_item1 = Maybe<int>.None();
            var expected_item2 = Maybe<string>.None();

            Assert.AreEqual(Maybe<Tuple<int, string>>.None(), expected_item1.Zip(expected_item2));
        }
    }
}