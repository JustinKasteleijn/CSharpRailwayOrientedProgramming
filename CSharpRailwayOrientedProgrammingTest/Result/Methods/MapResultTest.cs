using System;
using System.Threading.Tasks;
using Functional;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tests
{
    [TestClass]
    public partial class MapResultTest
    {
        [TestMethod]
        public void MapReturnsMappedValueOnOk()
        {
            int value = 4;
            double expected = Math.Sqrt(value);

            Assert.AreEqual(expected, Result<double, string>.Ok(value).Map(x => Math.Sqrt(x)).Unwrap());
        }

        [TestMethod]
        public void MapReturnsMappedValueChainOnOk()
        {
            int value = 4;
            double expected = Math.Sqrt(Math.Sqrt(value));

            Assert.AreEqual(expected, Result<double, string>.Ok(value).Map(x => Math.Sqrt(x)).Map(x => Math.Sqrt(x)).Unwrap());
        }

        [TestMethod]
        public void MapReturnsFirstErrOnChainErr()
        {
            string expected = "This is the earliest error";

            Assert.AreEqual(expected, Result<double, string>.Err(expected).Map(x => Math.Sqrt(x)).Map(x => Math.Sqrt(x)).Err());
        }
    }
}