using System.Collections.Generic;
using GlobalX.Console.ContactSort.BusinessLogic.File;
using GlobalX.Console.ContactSort.Common.Domain;
using log4net;

namespace GlobalX.Console.ContactSort.Services
{
    public class FileService : IFileService
    {
        private readonly IFileBusinessLogic _fileBusinessLogic;

        public FileService(IFileBusinessLogic fileBusinessLogic)
        {
            _fileBusinessLogic = fileBusinessLogic;
        }
        public string LoadFile(string filePath)
        {
            return _fileBusinessLogic.LoadFile(filePath);
        }

        public IList<string> ArrangeLineItems(string fileContent)
        {
            return _fileBusinessLogic.ArrangeLineItems(fileContent);
        }

        public string WriteFile(File file, List<Contact> orderedContacts)
        {
           return _fileBusinessLogic.WriteFile(file, orderedContacts);
        }

        public File GenerateFileMetadata(string filePath)
        {
            return _fileBusinessLogic.GenerateFileMetadata(filePath);
        }

    }
}
