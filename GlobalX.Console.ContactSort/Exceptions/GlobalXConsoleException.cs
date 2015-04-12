using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
