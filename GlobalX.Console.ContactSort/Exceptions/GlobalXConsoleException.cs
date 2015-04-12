using GlobalX.Console.ContactSort.Common.Exceptions;

namespace GlobalX.Console.ContactSort.Exceptions
{
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
