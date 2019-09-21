using System;
using System.IO;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TFS_ServerOperation.Tests
{
    [TestClass]
    public class InformationParserTest
    {
        [TestMethod]
        public void Init_Log_Success()
        {
            // Arrange
            InformationParser informationParser = new InformationParser();

            // Act
            Logger result = informationParser.Init_Log();

            // Assert
            Assert.IsTrue(typeof(Object).IsInstanceOfType(result));           
        }

        [TestMethod]
        public void Init_MailSender_Success()
        {
            // Arrange
            InformationParser informationParser = new InformationParser();
            Logger logger = new Logger("TFS_Init_MailSender_Success_ServerOperation.log");

            // Act
            MailSender senderResult = informationParser.Init_MailSender(logger);

            // Assert
            Assert.IsTrue(typeof(Object).IsInstanceOfType(senderResult));
        }

        [TestMethod]
        public void Init_MailSender_Success_NullParameter_WithoutLoggingFeature()
        {
            // Arrange
            InformationParser informationParser = new InformationParser();
            Logger logger = null;

            // Act
            MailSender senderResult = informationParser.Init_MailSender(logger);

            // Assert
            Assert.IsTrue(typeof(Object).IsInstanceOfType(senderResult));
        }

        [TestMethod]
        public void Init_ServerOperation_Success()
        {
            // Arrange
            InformationParser informationParser = new InformationParser();
            Logger logger = new Logger("TFS_Init_ServerOperation_Success_ServerOperation.log");

            // Act
            ServerOperationManager operationResult = informationParser.Init_ServerOperation(logger);

            // Assert
            Assert.IsTrue(typeof(Object).IsInstanceOfType(operationResult));
        }

        [TestMethod]
        public void Init_ServerOperation_Success_CurrentTfsCollectionNameValid()
        {
            // Arrange
            InformationParser informationParser = new InformationParser();
            Logger logger = new Logger("TFS_Init_ServerOperation_Success_CurrentTfsCollectionNameValid_ServerOperation.log");

            // Act
            ServerOperationManager operationResult = informationParser.Init_ServerOperation(logger);

            // Assert
            Assert.AreEqual("http://localhost:8080/tfs/SzakdolgozatCollection",informationParser.CurrentTfsCollectionName);
            Thread.Sleep(3000);
        }

        [TestMethod]
        public void Init_ServerOperation_Success_CurrentTeamProjectNameValid()
        {
            // Arrange
            InformationParser informationParser = new InformationParser();
            Logger logger = new Logger("TFS_Init_ServerOperation_Success_CurrentTeamProjectNameValid_ServerOperation.log");

            // Act
            ServerOperationManager operationResult = informationParser.Init_ServerOperation(logger);

            // Assert
            Assert.AreEqual("Test_Project", informationParser.CurrentTeamProjectName);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Init_ServerOperation_Fail_NullParameter()
        {
            // Arrange
            InformationParser informationParser = new InformationParser();
            Logger logger = null;

            // Act , Assert
            ServerOperationManager operationResult = informationParser.Init_ServerOperation(logger);
        }

        [TestMethod]
        public void GetUpToDateFileCSV_Exist()
        {
            // Arrange
            InformationParser informationParser = new InformationParser();

            // Act
            string resultPath = informationParser.GetUpToDateFileCSV("Test_Project");

            // Assert
            Assert.IsFalse(String.IsNullOrEmpty(resultPath));
        }

        [TestMethod]
        public void GetUpToDateFileCSV_DoesNotExist_TeamProjectNameDoesNotExist()
        {
            // Arrange
            InformationParser informationParser = new InformationParser();

            // Act
            string resultPath = informationParser.GetUpToDateFileCSV("Something");

            // Assert
            Assert.IsTrue(String.IsNullOrEmpty(resultPath));
        }

        [TestMethod]
        public void GetUpToDateFileCSV_DoesNotExist_NoTeamProjectRunFile()
        {
            // Arrange
            InformationParser informationParser = new InformationParser();

            // Act
            string resultPath = informationParser.GetUpToDateFileCSV("Test_Project2");

            // Assert
            Assert.IsTrue(String.IsNullOrEmpty(resultPath));
        }

        [TestMethod]
        public void GetFileContent_ReadSuccess()
        {
            // Arrange
            InformationParser informationParser = new InformationParser();

            // Act
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            string fileName = "ContentForRead.csv";
            string path = Path.Combine(projectDirectory, @"TestFiles\", fileName);
            string result = informationParser.GetFileContent(path);

            // Assert
            Assert.IsFalse(String.IsNullOrEmpty(result));
        }

        [TestMethod]
        public void GetFileContent_NoFileForGetContent()
        {
            // Arrange
            InformationParser informationParser = new InformationParser();

            // Act
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            string fileName = "ContentForReadOther.csv";
            string path = Path.Combine(projectDirectory, @"TestFiles\", fileName);
            string result = informationParser.GetFileContent(path);

            // Assert
            Assert.IsTrue(String.IsNullOrEmpty(result));
        }
    }
}
