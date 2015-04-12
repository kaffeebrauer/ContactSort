using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Threading;
using GlobalX.Console.ContactSort.Common.Console;
using GlobalX.Console.ContactSort.Configuration;
using GlobalX.Console.ContactSort.Resources;
using GlobalX.Console.ContactSort.Services;

namespace GlobalX.Console.ContactSort.Application
{
    public class ContactManager : IApplication
    {
        private readonly IFileService _fileService;
        private readonly IContactService _contactService;
        private readonly IOutputWriter _outputWriter;
        private readonly IConfigurationSettingProvider _configurationSettingProvider;
        public bool IsFileAccessible { get; private set; }
        public bool IsFileSorted { get; private set; }
        public bool IsContactConstructed { get; private set; }
        public bool IsFileWritten { get; private set; }

        public ContactManager(
            IFileService fileService, 
            IContactService contactService,
            IOutputWriter outputWriter,
            IConfigurationSettingProvider configurationSettingProvider)
        {
            _fileService = fileService;
            _contactService = contactService;
            _outputWriter = outputWriter;
            _configurationSettingProvider = configurationSettingProvider;
        }

        public void RunApplication(string filePath)
        {
            var fileMetadata = _fileService.GenerateFileMetadata(filePath);
            var fileContent = _fileService.LoadFile(filePath);

            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(_configurationSettingProvider.DefaultCulture);

            if (fileMetadata == null || fileContent == null) return;
            IsFileAccessible = true;
            var rawContactList = _fileService.ArrangeLineItems(fileContent);
            
            if (rawContactList == null) return;
            IsFileSorted = true;
            var contacts = rawContactList.Select(rawContact => _contactService.LoadRawContact(rawContact)).ToList();
            var arrangedRawContacts = _contactService.ArrangeContact(contacts);
            var arrangedContacts = arrangedRawContacts.Select(rawContacts => _contactService.LoadContact(rawContacts)).ToList();
            IsContactConstructed = true;

            var newFileName = _fileService.WriteFile(fileMetadata, arrangedContacts.ToList());
            _outputWriter.WriteLine(string.Format("{0} {1}", ConsoleMessage.CONSOLE_PROCESS_COMPLETED, newFileName));
            IsFileWritten = true;
        }
    }
}
