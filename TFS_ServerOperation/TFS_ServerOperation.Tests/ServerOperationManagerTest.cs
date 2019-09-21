using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TFS_ServerOperation.Tests
{
    [TestClass]
    public class ServerOperationManagerTest
    {
        [TestMethod]
        public void DeleteFromFile_Fail_FileDoesNotExist()
        {
            // Arrange
            Logger log = new Logger("Test_OperationManager1.log");
            ConnectionAdapter conn = new ConnectionAdapter("http://localhost:8080/tfs/SzakdolgozatCollection", "Test_Project", log);
            ServerOperationManager serverOperation = new ServerOperationManager(conn, "Test_Project", "Test_Project", log);

            // Act
            bool result = serverOperation.DeleteFromFile("Something.csv");

            // Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void DeleteFromFile_Fail_NoFileOnTheServer()
        {
            // Arrange
            Logger log = new Logger("Test_OperationManager2.log");
            ConnectionAdapter conn = new ConnectionAdapter("http://localhost:8080/tfs/SzakdolgozatCollection", "Test_Project", log);
            ServerOperationManager serverOperation = new ServerOperationManager(conn, "Test_Project", "Test_Project", log);

            // Act
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            string fileName = "DeleteFromFileNoElemOnTheServer.csv";
            string path = Path.Combine(projectDirectory, @"TestFiles\", fileName);
            bool result = serverOperation.DeleteFromFile(path);

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void DeleteByIds_NoIds()
        {
            // Arrange
            Logger log = new Logger("Test_OperationManager3.log");
            ConnectionAdapter conn = new ConnectionAdapter("http://localhost:8080/tfs/SzakdolgozatCollection", "Test_Project", log);
            ServerOperationManager serverOperation = new ServerOperationManager(conn, "Test_Project", "Test_Project", log);
            List<string> datas = new List<string>();

            // Act
            bool result = serverOperation.DeleteByIds(datas);

            // Assert
            Assert.AreEqual(true, result);
        }

        // This ids does not exists on the server, but the process able to run with that, and create special file about the result (extra file, with the information (can't delete that))
        // You can check this file, Check the extra file on the log section (path)
        [TestMethod]
        public void DeleteByIds_Ids_ButNoItemsOnTheServer()
        {
            // Arrange
            Logger log = new Logger("Test_OperationManager4.log");
            ConnectionAdapter conn = new ConnectionAdapter("http://localhost:8080/tfs/SzakdolgozatCollection", "Test_Project", log);
            ServerOperationManager serverOperation = new ServerOperationManager(conn, "Test_Project", "Test_Project", log);
            List<string> datas = new List<string>() {"1", "2"};

            // Act
            bool result = serverOperation.DeleteByIds(datas);

            // Assert
            Assert.AreEqual(true, result);
        }

    }
}
