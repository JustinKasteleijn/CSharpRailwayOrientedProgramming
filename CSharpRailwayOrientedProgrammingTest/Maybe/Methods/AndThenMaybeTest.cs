using Functional;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace tests
{

    [TestClass]
    public partial class AndThenMaybeTest
    {

        private Maybe<string> SqaureThenToString(int x)
        {
            return Maybe<string>.Try(() => { if (x >= 0) { return Math.Sqrt(x).ToString(); } else { throw new Exception("Invalid digit"); } });
        }

        [TestMethod]
        public void AndThenCallsMethodOnSome()
        {
            int value = 5;
            string expected = Math.Sqrt(value).ToString();

            Assert.AreEqual(expected, Maybe<int>.Some(value).AndThen(x => SqaureThenToString(x)).Unwrap());
        }

        [TestMethod]
        public void AndThenDoesNotCallMethodOnNone()
        {
            var expected = Maybe<string>.None();

            Assert.AreEqual(expected.IsNone(), Maybe<int>.None().AndThen(x => SqaureThenToString(x)).IsNone());
        }

        [TestMethod]
        public void AndThenDoesNotCallMethodOnException()
        {
            var expected = Maybe<string>.None();

            Assert.AreEqual(expected.IsNone(), Maybe<int>.Some(-5).AndThen(x => SqaureThenToString(x)).IsNone());
        }
    }
}