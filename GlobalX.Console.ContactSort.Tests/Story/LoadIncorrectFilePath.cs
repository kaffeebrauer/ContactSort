using GlobalX.Console.ContactSort.Application;
using GlobalX.Console.ContactSort.BusinessLogic.Contact;
using GlobalX.Console.ContactSort.BusinessLogic.Core;
using GlobalX.Console.ContactSort.BusinessLogic.File;
using GlobalX.Console.ContactSort.BusinessLogic.Infrastructure;
using GlobalX.Console.ContactSort.Common.Console;
using GlobalX.Console.ContactSort.Common.Domain.Events;
using GlobalX.Console.ContactSort.Configuration;
using GlobalX.Console.ContactSort.Services;
using Moq;
using NUnit.Framework;
using TestStack.BDDfy;

namespace GlobalX.Console.ContactSort.Tests.Story
{
    [Story(
        Title = "User processes contact file, but fails to process because of inaccessible",
        AsA = "As a User",
        IWant = "To process the contact file",
        SoThat = "It can be arranged alphatically by last name then first name")]
    public class LoadIncorrectFilePath
    {
        private string _filePath;
        private IFileService _fileService;
        private IFileBusinessLogic _fileBusinessLogic;
        private IOutputWriter _outputWriter;
        private IContactService _contactService;
        private IContactBusinessLogic _contactBusinessLogic;
        private IConfigurationSettingProvider _configurationSettingProvider;
        private ContactManager _contactManager;
        private Mock<IEventBroker> _eventBroker;

        [Given("Given user enters a incorrect file path")]
        private void GivenUserEntersFilePath()
        {
            //Arrange
            _filePath = "invalidpath.txt";
            _fileBusinessLogic = new FileBusinessLogic();
            _eventBroker = new Mock<IEventBroker>();
            _contactBusinessLogic = new ContactBusinessLogic(new ContactModelFactory(new MapperService(), _eventBroker.Object));
            _fileService = new FileService(_fileBusinessLogic);
            _contactService = new ContactService(_contactBusinessLogic);
            _outputWriter = new ConsoleOutputWriter();
            _configurationSettingProvider = new ConfigurationSettingProvider();
            _contactManager = new ContactManager(_fileService, _contactService, _outputWriter, _configurationSettingProvider);
            _eventBroker.Setup(x => x.Raise(new ContactRegisteredEvent(_outputWriter)));
        }

        [Then("Not Process File")]
        void ThenNotProcessFile()
        {            
            //Act
            var ex = Assert.Throws<System.IO.FileNotFoundException>(() => _contactManager.RunApplication(_filePath));

            //Assert
            Assert.That(ex.Message, Is.EqualTo("Could not find file 'invalidpath.txt'."));
            Assert.IsTrue(_contactManager.IsFileAccessible == false);
        }

        [Test]
        public void Execute()
        {
            this.BDDfy();
        }
    }
}
