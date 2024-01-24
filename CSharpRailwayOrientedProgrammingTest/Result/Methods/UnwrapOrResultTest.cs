using Functional;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tests
{
    [TestClass]
    public partial class UnwrapOrResultTest
    {
        [TestMethod]
        public void UnwrapOrReturnsFallbackValueOnErr()
        {
            int expected = 0;
            var sut = Result<int, string>.Err("SCARY!");
            int fallback = expected;

            Assert.AreEqual(expected, sut.UnwrapOr(fallback));
        }

        [TestMethod]
        public void UnwrapOrReturnValueOnOk()
        {
            int expected = 1;
            var sut = Result<int, string>.Ok(expected);
            int fallback = -1;

            Assert.AreEqual(expected, sut.UnwrapOr(fallback));
        }
    }
}