using System;

namespace AutoFixtureKataStarter.Exceptions
{
    public class InsufficientCreditException : Exception
    {
        public InsufficientCreditException() : base()
        {
        }

        public InsufficientCreditException(string message) : base(message)
        {
        }

        public InsufficientCreditException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
