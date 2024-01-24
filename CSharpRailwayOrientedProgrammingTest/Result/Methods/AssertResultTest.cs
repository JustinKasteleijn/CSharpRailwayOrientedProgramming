using System.Threading.Tasks;
using Functional;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tests
{
    [TestClass]
    public partial class AssertResultTest
    {


        [TestMethod]
        public void AssertReturnErrorOnErr()
        {
            int val = 5;
            string expected = $"Scary {val}";
            var sut = Result<int, string>.Err(expected);

            Assert.AreEqual(expected, sut.Assert((_) => true, err => $"Scary {err}").Err());
        }

        [TestMethod]
        public void AssertReturnValueOnTruePredicate()
        {
            int expected = 7;
            var sut = Result<int, string>.Ok(expected);

            Assert.AreEqual(expected, sut.Assert(x => x > 0, err => $"Scary {err}").Unwrap());
        }

        [TestMethod]
        public void AssertReturnErrOnFalsePredicate()
        {
            string expected = "Scary";
            var sut = Result<int, string>.Ok(-1);

            Assert.AreEqual(expected, sut.Assert(x => x > 0, (_) => expected).Err());
        }
    }
}