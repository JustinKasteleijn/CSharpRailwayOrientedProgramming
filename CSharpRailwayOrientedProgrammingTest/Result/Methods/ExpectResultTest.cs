using System;
using Functional;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tests
{
    [TestClass]
    public partial class ExpectResultTest
    {
        [TestMethod]
        public void ExpectReturnsValOnOkResult()
        {
            int expected = 32;
            var sut = Result<int, string>.Ok(expected);

            Assert.AreEqual(expected, sut.Expect("Must contain a value"));
        }

        [TestMethod]
        public void ExpectThrowsOnErrResult()
        {
            var sut = Result<int, string>.Err("Err");
            string message = "Does not contain a value";
            string getMessage()
            {
                try
                {
                    sut.Expect(message);
                }
                catch (Exception)
                {
                    return message;
                }
                return "";
            }

            Assert.ThrowsException<ExpectException>(() => sut.Expect(message));
            Assert.AreEqual(message, getMessage());
        }
    }
}