using System;

namespace GlobalX.Console.ContactSort.Common.Exceptions
{
    [Serializable]
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
