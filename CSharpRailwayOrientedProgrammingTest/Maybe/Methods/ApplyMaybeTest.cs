using Functional;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace tests
{
    [TestClass]
    public partial class ApplyMaybeTest
    {
        [TestMethod]
        public void ApplyMaybeReturnsIdenticalValues()
        {
            int expected = 5;
            var sut = Maybe<int>.Some(expected);

            Assert.AreEqual(expected, sut.Apply(x => Math.Sqrt(x)).Unwrap());
        }

        [TestMethod]
        public void ApplyMaybeInvokesMethod()
        {
            string testvalue = "works!";
            string _global = "test ";
            string expected = _global + testvalue;
            var sut = Maybe<string>.Some(testvalue);

            _ = sut.Apply(x => _global += x);

            Assert.AreEqual(expected, _global);
        }

        [TestMethod]
        public void ApplyMaybeIgnoresApplyForNone()
        {
            int expected = 5;
            string _global = "test ";
            var sut = Maybe<string>.None();

            sut.Apply(x => _global += x);

            Assert.AreNotEqual(expected, _global);
        }
    }
}