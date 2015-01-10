using System;
using System.Runtime.Serialization;

namespace KMorcinek.TheCityCardGame
{
    public class CannotPlayCardException : Exception
    {
        public CannotPlayCardException()
        {
        }

        public CannotPlayCardException(string message)
            : base(message)
        {
        }

        public CannotPlayCardException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected CannotPlayCardException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}