using Functional;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tests
{
    [TestClass]
    public partial class MatchResultTest
    {
        [TestMethod]
        public void MatchReturnsValueOnOk()
        {
            int expected = 1002;
            Assert.AreEqual(expected, Result<int, string>.Ok(expected).Match(x => x, err => -1));
        }

        [TestMethod]
        public void MatchReturnsValueOnErr()
        {
            int expected = 1002;
            Assert.AreEqual(expected, Result<int, string>.Err("Some error").Match(x => x, err => expected));
        }

        [TestMethod]
        public void MatchReturnsValueOnErrInChain()
        {
            int expected = 1002;
            Assert.AreEqual(expected, Result<int, string>.Ok(-1).Assert(x => x > 0, err => err.ToString()).Match(x => x, err => expected));
        }

        [TestMethod]
        public void MatchExecutesActionOnOk()
        {
            int expected = 1002;
            int _global = 0;

            Result<int, string>.Ok(expected).Match(x => _global = x, err => _global = -1);

            Assert.AreEqual(expected, _global);
        }

        [TestMethod]
        public void MatchExecutesActionOnErr()
        {
            int expected = -1;
            int _global = 0;

            Result<int, string>.Err("").Match(x => _global = x, err => _global = -1);

            Assert.AreEqual(expected, _global);
        }

        [TestMethod]
        public void MatchExecutesActionOnErrChain()
        {
            int expected = -1;
            int _global = 0;

            Result<int, string>.Ok(expected).Assert((int x) => expected < 0, err => err.ToString()).Match(x => _global = x, err => _global = -1);

            Assert.AreEqual(expected, _global);
        }
    }
}