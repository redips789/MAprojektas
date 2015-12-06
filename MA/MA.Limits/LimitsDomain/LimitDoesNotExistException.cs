using System;

namespace MA.Limits.LimitsDomain
{
    public class LimitDoesNotExistException : Exception
    {
        public LimitDoesNotExistException()
        {
        }

        public LimitDoesNotExistException(string message)
            : base(message)
        {
        }

        public LimitDoesNotExistException(string message, Exception inner)
            : base(message, inner)
        {
    }
    }
}
