using System.Threading.Tasks;
using Functional;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tests
{
    [TestClass]
    public partial class BindResultTest
    {

        [TestMethod]
        public void BindReturnErrOnErr()
        {
            string expected = "Scary";
            var sut = Result<int, string>.Err(expected);

            Assert.AreEqual(expected, sut.Bind(x => Result<int, string>.Ok(x)).Err());
        }

        [TestMethod]
        public void BindReturnMappedResOnOk()
        {
            int value = 3;
            int expected = value * value;
            var sut = Result<int, string>.Ok(value);

            Assert.AreEqual(expected, sut.Bind(x => Result<int, string>.Ok(x * x)).Unwrap());
        }
    }
}