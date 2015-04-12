using System;

namespace GlobalX.Console.ContactSort.Common.Exceptions
{
    public class GlobalXException : Exception
    {
        public GlobalXException()
        {
        }

        public GlobalXException(string message)
            : base(message)
        {

        }
    }
}
