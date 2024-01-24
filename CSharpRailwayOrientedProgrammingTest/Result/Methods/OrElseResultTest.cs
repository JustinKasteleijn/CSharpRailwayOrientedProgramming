using System.Threading.Tasks;
using Functional;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tests
{
    [TestClass]
    public partial class OrElseResultTest
    {
        [TestMethod]
        public void OrElseResultIgnoresOk()
        {
            int expected = 1;
            Assert.AreEqual(expected, Result<int, string>.Ok(1).OrElse(x => Result<int, string>.Ok(-1)).Unwrap());
        }

        [TestMethod]
        public void OrElseResultCallsErr()
        {
            int expected = 1;
            Assert.AreEqual(
                expected + 1,
                Result<int, int>.
                    Err(1).
                    OrElse(x => Result<int, int>.Ok(expected + x)).Unwrap());
        }
    }
}