using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalX.Console.ContactSort.BusinessLogic.Core
{
    public abstract class ModelFactory<T>
    {
        public abstract T Create(params object[] args);
    }
}
