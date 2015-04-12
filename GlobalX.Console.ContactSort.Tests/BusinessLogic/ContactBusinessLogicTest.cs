using System.Collections.Generic;
using System.Linq;
using GlobalX.Console.ContactSort.BusinessLogic.Contact;
using GlobalX.Console.ContactSort.BusinessLogic.Core;
using GlobalX.Console.ContactSort.BusinessLogic.Infrastructure;
using GlobalX.Console.ContactSort.Common.Console;
using GlobalX.Console.ContactSort.Common.DataTransferObjects;
using GlobalX.Console.ContactSort.Common.Domain;
using GlobalX.Console.ContactSort.Common.Domain.Events;
using Moq;
using NUnit.Framework;

namespace GlobalX.Console.ContactSort.Tests.BusinessLogic
{
    [TestFixture]
    public class ContactBusinessLogicTest
    {
        private Mock<IMapperService> _mapperService;
        private Mock<IEventBroker> _eventBroker;
        private ContactBusinessLogic _contactBusinessLogic;
        //private Mock<ContactModelFactory> _contactModelFactory;
        private List<ContactDataTransferObject> _rawContactData;
        private Mock<IOutputWriter> _outputWriter;

        [SetUp]
        public void Setup()
        {
            _mapperService = new Mock<IMapperService>();
            _eventBroker = new Mock<IEventBroker>();
            _outputWriter = new Mock<IOutputWriter>();
            _contactBusinessLogic = new ContactBusinessLogic(new ContactModelFactory());
        }

        [Test]
        public void WhenGivenRawContactWillCreateContactDomainObject()
        {
            //Arrange
            var dto = new ContactDataTransferObject("SMITH", "JOHN");
            _contactBusinessLogic = new ContactBusinessLogic(new ContactModelFactory(_mapperService.Object, _eventBroker.Object));
            _mapperService.Setup(ms => ms.Map<ContactDataTransferObject, Contact>(dto)).Returns(new Contact() { FirstName = "JOHN", LastName = "SMITH" });
            _eventBroker.Setup(x => x.Raise(new ContactRegisteredEvent(_outputWriter.Object)));
            _outputWriter.Setup(x => x.WriteLine(It.IsAny<string>()));

            //Act
            var result = _contactBusinessLogic.LoadContact(dto);

            //Assert
            Assert.IsTrue(result.FirstName == "JOHN");
            Assert.IsTrue(result.LastName == "SMITH");
        }

        [Test]
        public void WhenGivenUnsortedContactListWillArrangeAlphabeticallyByLastNameThenFirstName()
        {
            //Arrange
            _rawContactData = new List<ContactDataTransferObject>
            {
                new ContactDataTransferObject("THEODORE", "BAKER"),
                new ContactDataTransferObject("MADISON", "KENT"),
                new ContactDataTransferObject("ANDREW", "SMITH"),
                new ContactDataTransferObject("FREDRICK", "SMITH")
            };
            //Act
            var result = _contactBusinessLogic.ArrangeContact(_rawContactData);

            //Assert
            Assert.AreEqual(result.Count(), 4);
            Assert.AreEqual(result[0].FirstName, "THEODORE");
            Assert.AreEqual(result[0].LastName, "BAKER");

            Assert.AreEqual(result[1].FirstName, "MADISON");
            Assert.AreEqual(result[1].LastName, "KENT");

            Assert.AreEqual(result[2].FirstName, "ANDREW");
            Assert.AreEqual(result[2].LastName, "SMITH");

            Assert.AreEqual(result[3].FirstName, "FREDRICK");
            Assert.AreEqual(result[3].LastName, "SMITH");
        }
    }
}
