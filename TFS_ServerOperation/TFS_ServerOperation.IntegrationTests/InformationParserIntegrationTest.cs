using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TFS_ServerOperation.IntegrationTests
{
    [TestClass]
    public class InformationParserIntegrationTest
    {
        [TestMethod]
        public void Upload_IntegrationTest_SuccessUploadToTestProject()
        {
            // Arrange
            InformationParser informationParser = new InformationParser();
            Logger logger = new Logger("Upload_IntegrationTest_SuccessUploadToTestProject.log");
            ServerOperationManager operationManager = informationParser.Init_ServerOperation(logger);

            // Act
            bool result = informationParser.Upload_Process(true, operationManager,logger);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Upload_IntegrationTest_Success_NullParameterLog()
        {
            // Arrange
            InformationParser informationParser = new InformationParser();
            Logger logger = new Logger("Upload_IntegrationTest_SuccessUploadToTestProject1.log");
            ServerOperationManager operationManager = informationParser.Init_ServerOperation(logger);

            // Act
            bool result = informationParser.Upload_Process(true, operationManager,null);

            // Assert
            Assert.IsTrue(result);
        }

        // This ids does not exists on the server, but the process able to run with that, and create special file about the result (extra file, with the information (can't delete that))
        // You can check this file, Check the extra file on the log section (path)
        [TestMethod]
        public void DeleteFromFile_Process_IntegrationTest_DeleteSectionTrueButNoItemsSoExtraLogFile()
        {
            // Arrange
            InformationParser informationParser = new InformationParser();
            Logger logger = new Logger("DeleteFromFile_Process_IntegrationTest1.log");
            ServerOperationManager operationManager = informationParser.Init_ServerOperation(logger);

            // Act
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            string fileName = "DeleteFromFileNoElemOnTheServer.csv";
            string path = Path.Combine(projectDirectory, @"TestFiles\", fileName);
            bool result = informationParser.DeleteFromFile_Process(path, operationManager,informationParser.Init_MailSender(logger));

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void DeleteFromFile_Process_IntegrationTest_NoFileFail()
        {
            // Arrange
            InformationParser informationParser = new InformationParser();
            Logger logger = new Logger("DeleteFromFile_Process_IntegrationTest2.log");
            ServerOperationManager operationManager = informationParser.Init_ServerOperation(logger);

            // Act
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            string fileName = "";
            string path = Path.Combine(projectDirectory, @"TestFiles\", fileName);
            bool result = informationParser.DeleteFromFile_Process(path, operationManager, informationParser.Init_MailSender(logger));

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void DeleteByIds_Process_NoIds()
        {
            // Arrange
            InformationParser informationParser = new InformationParser();
            Logger logger = new Logger("DeleteByIds_Process_IntegrationTest3.log");
            ServerOperationManager operationManager = informationParser.Init_ServerOperation(logger);

            // Act
            List<string> datas = new List<string>();
            bool result = informationParser.DeleteByIds_Process(datas, operationManager, informationParser.Init_MailSender(logger));

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void DeleteByIds_Process_NoItemsOnTheServer()
        {
            // Arrange
            InformationParser informationParser = new InformationParser();
            Logger logger = new Logger("DeleteByIds_Process_IntegrationTest4.log");
            ServerOperationManager operationManager = informationParser.Init_ServerOperation(logger);

            // Act
            List<string> datas = new List<string>() {"3", "4"};
            bool result = informationParser.DeleteByIds_Process(datas, operationManager, informationParser.Init_MailSender(logger));

            // Assert
            Assert.IsTrue(result);
        }
    }
}
