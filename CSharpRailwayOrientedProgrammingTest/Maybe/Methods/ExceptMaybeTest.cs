using System;
using Functional;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tests
{

    [TestClass]
    public partial class ExceptMaybeTest
    {
        private const string Message = "Should throw this message";

        [TestMethod]
        public void ExpectThrowsExceptionWhenNone()
        {
            Assert.ThrowsException<ExpectException>(() => Maybe<object>.None().Expect(Message));
        }

        [TestMethod]
        public void ExpectThrowsExceptionWhenNoneWithCorrectMessage()
        {
            object value = null;
            try
            {
                Maybe<object>.None().Expect(Message);
            }
            catch (Exception ex)
            {
                value = ex.Message;
            }
            Assert.AreEqual(Message, value);
        }

        [TestMethod]
        public void ExpectReturnValueOnSome()
        {
            int expected = 10;
            Assert.AreEqual(expected, Maybe<int>.Some(expected).Expect(Message));
        }
    }
}