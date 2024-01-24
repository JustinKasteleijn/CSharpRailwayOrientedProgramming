using Functional;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tests
{
    [TestClass]
    public partial class InspectResultTest
    {

        [TestMethod]
        public void InspectsOkResult()
        {
            string glo = "";
            int value = 10000;
            string expected = $"Result contains value of: {value}";

            var sut = Result<int, string>.Ok(value);

            sut.Inspect(x => glo = x);

            Assert.AreEqual(expected, glo);
        }

        [TestMethod]
        public void InspectsErrResult()
        {
            string glo = string.Empty;
            string errMessage = "Scary";
            string expected = $"Result contains error of: {errMessage}";

            var sut = Result<int, string>.Err(errMessage);

            sut.Inspect(x => glo = x);

            Assert.AreEqual(expected, glo);
        }
    }
}