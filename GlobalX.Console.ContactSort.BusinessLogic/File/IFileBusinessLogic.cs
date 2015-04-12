using System;
using System.Collections.Generic;

namespace GlobalX.Console.ContactSort.BusinessLogic.File
{
    public interface IFileBusinessLogic
    {
        string LoadFile(string filePath);
        IList<string> ArrangeLineItems(string fileContent);
    }
}
