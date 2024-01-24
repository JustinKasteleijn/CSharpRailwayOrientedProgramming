using System.Threading.Tasks;
using Functional;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tests
{
    [TestClass]
    public partial class MaybeTest
    {

        [TestMethod]
        public void CreateEmptyMaybe()
        {
            Maybe<int> result = Maybe<int>.None();
            Maybe<int> expected = Maybe<int>.None();
            Maybe<int> notExpected = Maybe<int>.Some(1);

            Assert.AreEqual(result, expected);
            Assert.AreNotEqual(result, notExpected);
        }

        [TestMethod]
        public void CreateFilledMaybe()
        {
            int testValue = 1;

            Maybe<int> result = Maybe<int>.Some(testValue);
            Maybe<int> expected = Maybe<int>.Some(1);
            Maybe<int> notExpected = Maybe<int>.None();

            Assert.AreEqual(result, expected);
            Assert.AreNotEqual(result, notExpected);
        }

        [TestMethod]
        public void IsSomeReturnsTrueForSome()
        {
            int testValue = 1;

            Maybe<int> result = Maybe<int>.Some(testValue);

            Assert.IsTrue(result.IsSome());
        }

        [TestMethod]
        public void IsSomeReturnsFalseForNone()
        {
            Maybe<int> result = Maybe<int>.None();

            Assert.IsFalse(result.IsSome());
        }

        [TestMethod]
        public void IsNoneReturnsFalseForSome()
        {
            int testValue = 1;

            Maybe<int> result = Maybe<int>.Some(testValue);

            Assert.IsFalse(result.IsNone());
        }

        [TestMethod]
        public void IsNoneReturnsTrueForNone()
        {
            Maybe<int> result = Maybe<int>.None();

            Assert.IsTrue(result.IsNone());
        }

        [TestMethod]
        public void UnwrapPanicsWhenNone()
        {
            Maybe<int> result = Maybe<int>.None();

            Assert.ThrowsException<Panic>(() => result.Unwrap());
        }

        [TestMethod]
        public void UnwrapReturnsValueWhenSome()
        {
            int expected = 1;

            Maybe<int> result = Maybe<int>.Some(expected);

            Assert.AreEqual(expected, result.Unwrap());
        }
    }
}