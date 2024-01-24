using System;
using Functional;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tests
{
    [TestClass]
    public partial class TryMaybeTest
    {
        [TestMethod]
        public void TryMaybeReturnsValueOnNoException()
        {
            string expected = "WWhoooooo!";

            Assert.AreEqual(Maybe<string>.Some(expected), Maybe<string>.Try(() => expected));
        }

        [TestMethod]
        public void TryMaybeReturnsValueOnException()
        {
            string message = "What!";
            var expected = Maybe<string>.None();

            Assert.AreEqual(expected.IsNone(), Maybe<string>.Try<int>(() => throw new Exception(message)).IsNone());
        }
    }
}