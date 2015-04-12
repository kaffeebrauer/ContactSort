using System.Collections.Generic;
using GlobalX.Console.ContactSort.Common.Domain;

namespace GlobalX.Console.ContactSort.Services
{
    public interface IFileService
    {
        string LoadFile(string filePath);
        IList<string> ArrangeLineItems(string fileContent);
        string WriteFile(File file, List<Contact> orderedContacts);
        File GenerateFileMetadata(string filePath);

    }
}
