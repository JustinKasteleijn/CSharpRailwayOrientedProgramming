using System.Threading.Tasks;
using Functional;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tests
{
    [TestClass]
    public partial class FinallyResultTest
    {

        [TestMethod]
        public void FinallyGetsCalledOnOkResult()
        {
            var sut = Result<int, string>.Ok(1);

            Assert.AreEqual(0, sut.Finally(x => x.Unwrap() - 1));
        }

        [TestMethod]
        public void FinallyGetsCalledOnOkResultOnChain()
        {
            int testValue = 30;
            var sut = Result<int, string>.Ok(testValue);

            Assert.AreEqual(testValue * 2 - 1, sut.Map((x) => x * 2).Finally(x => x.Unwrap() - 1)); ; ;
        }

        [TestMethod]
        public void FinallyGetsCalledOnErrResultOnChain()
        {
            var sut = Result<int, string>.Err("Scary");

            Assert.AreEqual("Scary".Length, sut.Map((_) => 1 - 1).Finally(x => x.Err().Length));
        }
    }
}