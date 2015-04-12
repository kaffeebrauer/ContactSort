using System.Linq;
using GlobalX.Console.ContactSort.Common.Console;
using GlobalX.Console.ContactSort.Services;

namespace GlobalX.Console.ContactSort.Application
{
    public class ContactManager : IApplication
    {
        private readonly IFileService _fileService;
        private readonly IContactService _contactService;
        private readonly IOutputWriter _outputWriter;

        public ContactManager(
            IFileService fileService, 
            IContactService contactService,
            IOutputWriter outputWriter)
        {
            _fileService = fileService;
            _contactService = contactService;
            _outputWriter = outputWriter;
        }

        public void RunApplication(string filePath)
        {
            var fileMetadata = _fileService.GenerateFileMetadata(filePath);
            var fileContent = _fileService.LoadFile(filePath);
            var rawContactList = _fileService.ArrangeLineItems(fileContent);
            var contacts = rawContactList.Select(rawContact => _contactService.LoadRawContact(rawContact)).ToList();
            var arrangedRawContacts = _contactService.ArrangeContact(contacts);
            var arrangedContacts = arrangedRawContacts.Select(rawContacts => _contactService.LoadContact(rawContacts)).ToList();
            var newFileName = _fileService.WriteFile(fileMetadata, arrangedContacts.ToList());
            _outputWriter.WriteLine(string.Format("{0} {1}", Resources.ConsoleMessage.CONSOLE_PROCESS_COMPLETED, newFileName));
        }
    }
}
