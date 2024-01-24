using Functional;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tests
{
    [TestClass]
    public partial class OkOrMaybeTest
    {
        [TestMethod]
        public void OkOrReturnsErrWhenNone()
        {
            string expected = "Maybe does not contain any value, Oops :)";
            Assert.AreEqual(Result<object, string>.Err(expected), Maybe<object>.None().OkOr(expected));
        }

        [TestMethod]
        public void OkOrReturnsOkWhenSome()
        {
            int expected = 1;
            Assert.AreEqual(Result<int, string>.Ok(expected), Maybe<int>.Some(expected).OkOr("Does not matter"));
        }
    }
}