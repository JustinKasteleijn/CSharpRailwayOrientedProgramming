using Functional;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tests
{
    [TestClass]
    public partial class FlattenResultTest
    {

        [TestMethod]
        public void FlattensSingleLayerOk()
        {
            var expected = Result<Result<int, string>, string>.Ok(Result<int, string>.Ok(1));
            var sut = Result<Result<Result<int, string>, string>, string>.Ok(Result<Result<int, string>, string>.Ok(Result<int, string>.Ok(1)));
            Assert.AreEqual(expected, sut.Flatten());
        }

        [TestMethod]
        public void FlattensDoubleLayerOk()
        {
            var expected = Result<int, string>.Ok(1);
            var sut = Result<Result<Result<int, string>, string>, string>.Ok(Result<Result<int, string>, string>.Ok(Result<int, string>.Ok(1)));
            Assert.AreEqual(expected, sut.Flatten().Flatten());
        }

        [TestMethod]
        public void FlattensSingleLayerErr()
        {
            Result<Result<int, string>, string> expected = Result<Result<int, string>, string>.Ok(Result<int, string>.Err("Err"));
            var sut = Result<Result<Result<int, string>, string>, string>.Ok(Result<Result<int, string>, string>.Ok(Result<int, string>.Err("Err")));
            Assert.AreEqual(expected, sut.Flatten());
        }

        [TestMethod]
        public void FlattensDoubleLayerErr()
        {
            var expected = Result<int, string>.Err("Err");
            var sut = Result<Result<Result<int, string>, string>, string>.Ok(Result<Result<int, string>, string>.Ok(Result<int, string>.Err("Err")));
            Assert.AreEqual(expected, sut.Flatten().Flatten());
        }
    }
}