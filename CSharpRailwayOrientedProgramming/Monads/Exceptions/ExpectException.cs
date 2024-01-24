using System;

namespace Functional
{
    public partial class ExpectException : Exception
    {

        public ExpectException()
        {
        }

        public ExpectException(string message) : base(message)
        {
        }

        public ExpectException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}