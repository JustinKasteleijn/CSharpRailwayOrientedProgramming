using Functional;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tests
{
    [TestClass]
    public partial class OrResultTest
    {
        [TestMethod]
        public void OrReturnsOtherOnErr()
        {
            var res = Result<int, string>.Err("what!");
            var other = Result<int, string>.Ok(5);
            var expected = other;

            Assert.AreEqual(expected, res.Or(other));
        }

        [TestMethod]
        public void OrReturnsSelf()
        {
            var res = Result<int, string>.Ok(1);
            var other = Result<int, string>.Ok(5);
            var expected = res;

            Assert.AreEqual(expected, res.Or(other));
        }

        [TestMethod]
        public void OrReturnsSelfOnErr()
        {
            var res = Result<int, string>.Ok(1);
            var other = Result<int, string>.Err("What!");
            var expected = res;

            Assert.AreEqual(expected, res.Or(other));
        }
    }
}