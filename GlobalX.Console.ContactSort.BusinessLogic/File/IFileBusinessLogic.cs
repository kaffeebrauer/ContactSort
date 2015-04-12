using System.Collections.Generic;

namespace GlobalX.Console.ContactSort.BusinessLogic.File
{
    public interface IFileBusinessLogic
    {
        string LoadFile(string filePath);
        IList<string> ArrangeLineItems(string fileContent);
        string WriteFile(Common.Domain.File file, List<Common.Domain.Contact> orderedContacts);
        Common.Domain.File GenerateFileMetadata(string filePath);
    }
}
