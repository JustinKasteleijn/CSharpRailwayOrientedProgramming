using System;

namespace Functional
{
    public partial class Panic : Exception
    {

        public Panic()
        {
        }

        public Panic(string message) : base(message)
        {
        }

        public Panic(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}