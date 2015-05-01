using System.Collections.Generic;
using GlobalX.Console.ContactSort.BusinessLogic.File;
using GlobalX.Console.ContactSort.Common.Domain;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;
using File = GlobalX.Console.ContactSort.Common.Domain.File;

namespace GlobalX.Console.ContactSort.Tests.BusinessLogic
{
    [TestFixture]
    public class FileBusinessLogicTest
    {
        private FileBusinessLogic _fileBusinessLogic;
        
        [SetUp]
        public void Setup()
        {
            _fileBusinessLogic = new FileBusinessLogic();
        }

        [Test]
        public void WhenGivenContentWillReturnCorrectLineItems()
        {
            //Arrange

            //Act
            var result = _fileBusinessLogic.ArrangeLineItems("SMITH, JOHN\r\nSMITH, ANDREW");

            //Assert
            Assert.IsTrue(result.Count == 2);
        }


        [Test]
        public void WhenGivenNoContentWillReturnNoLineItems()
        {
            //Arrange

            //Act
            var result = _fileBusinessLogic.ArrangeLineItems(string.Empty);

            //Assert
            Assert.IsTrue(result.Count == 0);
        }

        [Test]
        public void WhenGivenFileToWriteToDiskSystemWillReturnCorrectFileOuput()
        {
            //Arrange
            
            //Act
            var result = _fileBusinessLogic.WriteFile(new File {FileName = "contact", ContentType = ".txt"},
                new List<Contact>());
            
            //Assert
            Assert.IsTrue(result == "contact-sorted.txt");
        }

        [Test]
        public void WhenGivenFileWillGenerateProperFileMetadata()
        {
            //Arrange

            //Act
            var result = _fileBusinessLogic.GenerateFileMetadata("contact.txt");

            //Assert
            Assert.IsTrue(result.FileName == "contact");
            Assert.IsTrue(result.ContentType == ".txt");
        }

        [Test]
        public void WhenGivenFileAbleToLoadFileContent()
        {
            //Arrange

            //Act
            var result = _fileBusinessLogic.LoadFile("contact.txt");

            //Assert
            Assert.IsTrue(result == "BAKER, THEODORE\r\nSMITH, ANDREW\r\nKENT, MADISON\r\nSMITH, FREDRICK\r\n");

        }
    }
}
