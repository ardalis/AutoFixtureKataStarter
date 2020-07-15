using System;

namespace AutoFixtureKataStarter.Exceptions
{
    public class InvalidAddressException : Exception
    {
        public InvalidAddressException() : base()
        {
        }

        public InvalidAddressException(string message) : base(message)
        {
        }

        public InvalidAddressException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
