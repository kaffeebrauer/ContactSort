using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
