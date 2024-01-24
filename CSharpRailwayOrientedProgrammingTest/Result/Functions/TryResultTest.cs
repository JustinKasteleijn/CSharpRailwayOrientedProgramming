using System;
using Functional;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tests
{
    [TestClass]
    public partial class TryResultTest
    {

        private const string expectedMessage = "Can not sqrt negative integers";

        public double CustomSqrt(int x)
        {
            if (x < 0)
            {
                throw new Exception(expectedMessage);
            }
            else
            {
                return Math.Sqrt(x);
            }
        }

        [TestMethod]
        public void ExampleNoException()
        {
            int value = 15;
            Result<double, string> expected = Result<double, string>.Ok(value: CustomSqrt(value));
            Result<double, string> res = Result<double, string>.Try(() => CustomSqrt(value), exception => exception.Message);

            Assert.AreEqual(expected, res);
        }

        [TestMethod]
        public void ExampleCatchException()
        {
            int value = -1;
            Result<double, string> expected = Result<double, string>.Err(errorValue: expectedMessage);

            Result<double, string> res = Result<double, string>.Try(() => CustomSqrt(value), exception => exception.Message);

            Assert.AreEqual(expected, res);
        }
    }
}