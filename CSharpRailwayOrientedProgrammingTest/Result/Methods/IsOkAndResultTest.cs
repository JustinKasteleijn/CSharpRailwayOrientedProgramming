using Functional;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tests
{
    [TestClass]
    public partial class IsOkAndResultTest
    {
        [TestMethod]
        public void IsOkAndReturnsOk()
        {
            Assert.IsTrue(Result<int, string>.Ok(1).IsOkAnd((_) => true));
        }

        [TestMethod]
        public void IsOkAndReturnsFalseOnPredicate()
        {
            Assert.IsFalse(Result<int, string>.Ok(1).IsOkAnd((_) => false));
        }

        [TestMethod]
        public void IsOkAndReturnsFalseOnErr()
        {
            Assert.IsFalse(Result<int, string>.Err("").IsOkAnd((_) => false));
        }
    }
}