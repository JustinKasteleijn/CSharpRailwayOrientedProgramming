using System;
using System.Linq;
using System.Threading.Tasks;
using Functional;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tests
{
    [TestClass]
    public partial class ApplyResultTest
    {
        [TestMethod]
        public void ApplyRetunsAppliedIdenticalValues()
        {
            int expected = 5;
            var sut = Result<int, string>.Ok(expected);

            Assert.AreEqual(expected, sut.Apply(x => Math.Sqrt(x)).Unwrap());
        }

        [TestMethod]
        public void ApplyResultInvokesMethod()
        {
            string testvalue = "works!";
            string _global = "test ";
            string expected = _global + testvalue;
            var sut = Result<string, string>.Ok(testvalue);

            sut.Apply(x => _global += x);

            Assert.AreEqual(expected, _global);
        }

        [TestMethod]
        public void ApplyResultIgnoresErr()
        {
            int expected = 5;
            string testvalue = "works!";
            string _global = "test ";
            var sut = Result<string, string>.Err(testvalue);

            sut.Apply(x => _global += "Doesn't matter");

            Assert.AreNotEqual(expected, _global);
        }
    }
}