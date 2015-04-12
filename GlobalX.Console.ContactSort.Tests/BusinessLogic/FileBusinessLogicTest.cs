using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using GlobalX.Console.ContactSort.BusinessLogic.File;
using GlobalX.Console.ContactSort.Common.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            var result = _fileBusinessLogic.WriteFile(new File() {FileName = "contact", ContentType = ".txt"},
                new List<Contact>());
            
            //Assert
            Assert.IsTrue(result == "contact-sorted.txt");
        }
        //static string GetTestDataFolder(string testDataFolder)
        //{
        //    string startupPath = Assembly.GetCallingAssembly().assembly.GetManifestResourceStream(resourceName);
        //    var pathItems = startupPath.Split(Path.DirectorySeparatorChar);
        //    string projectPath = String.Join(Path.DirectorySeparatorChar.ToString(), pathItems.Take(pathItems.Length - 3));
        //    return Path.Combine(projectPath, testDataFolder);
        //}

        [Test]
        public void WhenGivenFileWillGenerateProperFileMetadata()
        {
            //Arrange

            //Act
            string path = AppDomain.CurrentDomain.BaseDirectory;
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
