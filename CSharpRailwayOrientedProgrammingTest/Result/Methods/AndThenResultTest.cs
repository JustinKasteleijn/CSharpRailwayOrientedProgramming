using System;
using System.Threading.Tasks;
using Functional;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tests
{
    [TestClass]
    public partial class AndThenResultTest
    {

        [TestMethod]
        public void AndThenCallsMethodOnOk()
        {
            int value = 200;
            double expected = Math.Sqrt(value);
            var sut = Result<double, string>.Ok(value);

            Assert.AreEqual(expected, sut.AndThen(x => Result<double, string>.Ok(Math.Sqrt(x))).Unwrap());
        }

        [TestMethod]
        public void AndThenDoesNotCallMethodOnErr()
        {
            string expected = "Scary";
            var sut = Result<double, string>.Err(expected);

            Assert.AreEqual(expected, sut.AndThen(x => Result<double, string>.Err(Math.Sqrt(x).ToString())).Err());
        }

        [TestMethod]
        public void AndThenReturnsErrWhenFunctionPanics()
        {
            string expected = "Scary";
            var sut = Result<double, string>.Ok(2000);

            Assert.AreEqual(expected, sut.AndThen(x => Result<double, string>.Err(expected)).Err());
        }
    }
}