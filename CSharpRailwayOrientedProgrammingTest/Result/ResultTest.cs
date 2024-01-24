using System.Threading.Tasks;
using Functional;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tests
{
    [TestClass]
    public partial class ResultTest
    {

        [TestMethod]
        public void CreateErrResult()
        {
            Result<int, string> expected = Result<int, string>.Err("Paniced!");

            Assert.AreEqual(expected, Result<int, string>.Err("Paniced!"));
            Assert.AreNotEqual(expected, Result<int, string>.Ok(1));
        }

        [TestMethod]
        public void CreateOkResult()
        {
            int testValue = 1;
            Result<int, string> sut = Result<int, string>.Ok(testValue);

            Assert.AreEqual(Result<int, string>.Ok(testValue), sut);
            Assert.AreNotEqual(Result<int, string>.Err("Paniced!"), sut);
        }

        [TestMethod]
        public void IsErrReturnsTrueOnErr()
        {
            Result<int, string> sut = Result<int, string>.Err("Paniced!");

            Assert.IsTrue(sut.IsErr());
        }

        [TestMethod]
        public void IsErrReturnsFalseOnOk()
        {
            Result<int, string> sut = Result<int, string>.Ok(1);

            Assert.IsFalse(sut.IsErr());
        }

        [TestMethod]
        public void IsOkReturnsTrueOnOk()
        {
            Result<int, string> sut = Result<int, string>.Ok(1);

            Assert.IsTrue(sut.IsOk());
        }

        [TestMethod]
        public void IsOkReturnsFalseOnErr()
        {
            Result<int, string> sut = Result<int, string>.Err("Paniced!");

            Assert.IsFalse(sut.IsOk());
        }

        [TestMethod]
        public void ErrReturnsErrOnErr()
        {
            string expected = "Paniced!";
            Result<int, string> sut = Result<int, string>.Err(expected);

            Assert.AreEqual(expected, sut.Err());
        }

        [TestMethod]
        public void ErrPanicsOnOk()
        {
            Result<int, string> sut = Result<int, string>.Ok(1);

            Assert.ThrowsException<Panic>(() => sut.Err());
        }

        [TestMethod]
        public void UnwrapReturnsOkOnOk()
        {
            int expected = 1;
            Result<int, string> sut = Result<int, string>.Ok(expected);

            Assert.AreEqual(expected, sut.Unwrap());
        }

        [TestMethod]
        public void UnwrapPanicsOnErr()
        {
            Result<int, string> sut = Result<int, string>.Err("Panic!");

            Assert.ThrowsException<Panic>(() => sut.Unwrap());
        }
    }
}