using System;

namespace AutoFixtureKataStarter.Exceptions
{
    public class InvalidOrderException : Exception
    {
        public InvalidOrderException() : base()
        {
        }

        public InvalidOrderException(string message) : base(message)
        {
        }

        public InvalidOrderException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
