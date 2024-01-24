using Functional;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tests
{
    [TestClass]
    public partial class IsErrAndResultTest
    {
        [TestMethod]
        public void IsErrAndReturnTrue()
        {
            Assert.IsTrue(Result<int, string>.Err("").IsErrAnd((_) => true));
        }

        [TestMethod]
        public void IsErrAndReturnFalseOnPredicate()
        {
            Assert.IsFalse(Result<int, string>.Err("").IsErrAnd((_) => false));
        }

        [TestMethod]
        public void IsErrAndReturnFalseOnOk()
        {
            Assert.IsFalse(Result<int, string>.Ok(1).IsErrAnd((_) => true));
        }
    }
}