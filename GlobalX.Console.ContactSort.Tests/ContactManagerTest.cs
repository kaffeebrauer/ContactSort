using System.Collections.Generic;
using GlobalX.Console.ContactSort.Application;
using GlobalX.Console.ContactSort.Common.Console;
using GlobalX.Console.ContactSort.Common.DataTransferObjects;
using GlobalX.Console.ContactSort.Common.Domain;
using GlobalX.Console.ContactSort.Services;
using Moq;
using NUnit.Framework;

namespace GlobalX.Console.ContactSort.Tests
{
    [TestFixture]
    public class ContactManagerTest
    {
        private const string filePath = "contacts.txt"; 
        private Mock<IFileService> _fileService;
        private Mock<IContactService> _contactService;
        private Mock<IOutputWriter> _outputWritter;
        private ContactManager _contactManager;
        private Common.Domain.File contactFile;

        [SetUp]
        public void Setup()
        {
            _fileService = new Mock<IFileService>();
            _contactService = new Mock<IContactService>();
            _outputWritter = new Mock<IOutputWriter>();
            _contactManager = new ContactManager(_fileService.Object, _contactService.Object, _outputWritter.Object);
            contactFile = new Common.Domain.File {ContentType = "txt", FileSize = 55, FileName = "contact"};
        }

        [Test]
        public void WhenGivenEmptyFileContentWillExitProperly()
        {
            //Arrange
            _fileService.Setup(fs => fs.GenerateFileMetadata(filePath)).Returns(contactFile);
            _fileService.Setup(fs => fs.LoadFile(filePath)).Returns("SMITH, JOHN\r\nFRANKLIN, BENJAMIN");
            _fileService.Setup(fs => fs.ArrangeLineItems(It.IsAny<string>())).Returns(new List<string>() {});
            _contactService.Setup(cs => cs.ArrangeContact(It.IsAny<List<ContactDataTransferObject>>()))
                .Returns(new List<ContactDataTransferObject>());
            _fileService.Setup(fs => fs.WriteFile(It.IsAny<Common.Domain.File>(), It.IsAny<List<Contact>>()))
                .Returns("contact-sorted.txt");
            
            //Act
            _contactManager.RunApplication(filePath);

            //Assert
            _outputWritter.Verify(ow => ow.WriteLine(It.IsAny<string>()), Times.Exactly(1));
            _outputWritter.Verify(ow => ow.WriteLine(It.Is<string>(s => s == "Finished: created contact-sorted.txt")), Times.Exactly(1));
        }
    }
}
