using Functional;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace tests
{
    [TestClass]
    public partial class InspectMaybeTest
    {
        private const string NoneMessage = "Option is none";
        private readonly Func<Maybe<string>, string> SomeMessage = obj => $"Option contains value {obj.Unwrap()}";

        [TestMethod]
        public void InspectReadsNoneValue()
        {
            string _global = "";
            string expected = NoneMessage;

            Maybe<string>.None().Inspect(x => _global = x);

            Assert.AreEqual(expected, _global);
        }

        [TestMethod]
        public void InspectReadsSomeValue()
        {
            string _global = "";
            string message = "Yaay!";
            string expected = SomeMessage(Maybe<string>.Some(message));

            Maybe<string>.Some(message).Inspect(x => _global = x);

            Assert.AreEqual(expected, _global);
        }
    }
}