using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using GlobalX.Console.ContactSort.BusinessLogic.Resources;
using GlobalX.Console.ContactSort.Common.Exceptions;
using GlobalX.Console.ContactSort.Common.Resources;

namespace GlobalX.Console.ContactSort.BusinessLogic.File
{
    public class FileBusinessLogic : IFileBusinessLogic
    {
        public FileBusinessLogic()
        {
            
        }

        public string LoadFile(string filePath)
        {
            var sb = new StringBuilder();
            using (var sr = new StreamReader(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    sb.AppendLine(line);
                }
            }
            return sb.ToString();
        }

        public IList<string> ArrangeLineItems(string fileContent)
        {
            var result = fileContent.Split(FileConstants.CarriageReturn, StringSplitOptions.RemoveEmptyEntries);
            return result;
        }

        public string WriteFile(Common.Domain.File file, List<Common.Domain.Contact> orderedContacts)
        {
            var fileName = string.Format("{0}-sorted.txt", file.FileName);
            using (var writer = new StreamWriter(fileName))
            {
                foreach (var contact in orderedContacts)
                {
                    writer.WriteLine("{0}, {1}", contact.LastName, contact.FirstName);  
                }      
            }
            return fileName;
        }

        public Common.Domain.File GenerateFileMetadata(string filePath)
        {
            var fileInfo = new FileInfo(filePath);
            var contentType = Path.GetExtension(filePath);
            if (contentType == null)
            {
                throw new GlobalXException(Exceptions.FILE_EXTENSION_EXPECTED);
            }
            var fileMetadata = new Common.Domain.File
            {
                FileSize = Convert.ToInt32(fileInfo.Length),
                ContentType = Path.GetExtension(filePath),
                FileName = fileInfo.Name.Replace(contentType, "")
            };
            return fileMetadata;
        }
    }
}
