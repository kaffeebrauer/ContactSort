using System;
using GlobalX.Console.ContactSort.Common.Exceptions;

namespace GlobalX.Console.ContactSort.Exceptions
{
    [Serializable]
    public class GlobalXConsoleException : GlobalXException
    {
        public GlobalXConsoleException()
        {

        }

        public GlobalXConsoleException(string message)
            : base(message)
        {

        }
    }
}
