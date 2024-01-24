using Functional;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tests
{
    [TestClass]
    public partial class AndResultTest
    {

        [TestMethod]
        public void AndReturnsEarlyError()
        {
            string expected = "Early error";
            var x = Result<int, string>.Err(expected);
            var y = Result<int, string>.Ok(10);

            Assert.AreEqual(expected, x.And(y).Err());
        }

        [TestMethod]
        public void AndReturnsLateError()
        {
            string expected = "Late error";
            var x = Result<int, string>.Err(expected);
            var y = Result<int, string>.Ok(10);

            Assert.AreEqual(expected, y.And(x).Err());
        }

        [TestMethod]
        public void AndReturnsLateErrorForDoubleErr()
        {
            string expected = "Late error";
            var x = Result<int, string>.Err("Early error");
            var y = Result<int, string>.Err(expected);

            Assert.IsTrue(y.IsErr());
            Assert.AreEqual(expected, x.And(y).Err());
        }

        [TestMethod]
        public void AndReturnsLateValueForDoubleOk()
        {
            int expected = 1;
            var x = Result<int, string>.Ok(100);
            var y = Result<int, string>.Ok(expected);

            Assert.AreEqual(expected, x.And(y).Unwrap());
        }
    }
}