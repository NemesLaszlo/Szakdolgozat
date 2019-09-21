using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TFS_ServerOperation.Tests
{
    [TestClass]
    public class FileOperationsTest
    {
        [TestMethod]
        public void ReadCSV_Reading_Success()
        {
            // Arrange
            Logger log = new Logger("ReadCSVRightRead.log");
            FileOperations fileOPeration = new FileOperations(log);

            // Act
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            string fileName = "Test_Upload_File.csv";
            string path = Path.Combine(projectDirectory, @"TestFiles\", fileName);
            var result = fileOPeration.ReadCSV(path);

            // Assert
            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public void ReadCSV_ReadingBiggestFileWithSuccess()
        {
            // Arrange
            Logger log = new Logger("ReadCSVRightReadMore.log");
            FileOperations fileOPeration = new FileOperations(log);

            // Act
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            string fileName = "Test_Upload_File1.csv";
            string path = Path.Combine(projectDirectory, @"TestFiles\", fileName);
            var result = fileOPeration.ReadCSV(path);

            // Assert
            Assert.AreEqual(false, String.IsNullOrEmpty(result.Count.ToString()));
        }

        [TestMethod]
        public void ReadCSV_ReadingWrongFileName()
        {
            // Arrange
            Logger log = new Logger("ReadCSVRightReadWrongFileName.log");
            FileOperations fileOPeration = new FileOperations(log);

            // Act
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            string fileName = "Test_Upload_FileWrong.csv";
            string path = Path.Combine(projectDirectory, @"TestFiles\", fileName);
            var result = fileOPeration.ReadCSV(path);

            // Assert
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void WriteInCSV_Writing_Success()
        {
            // Arrange
            Logger log = new Logger("WriteInCSVRight.log");
            FileOperations fileOperation = new FileOperations(log);

            // Act
            List<string> datas = new List<string>() { "testdata1", "testdata2", "testdata3" };
            fileOperation.WriteInCSV("Test_ProjectRun1",datas);

            // Assert
            string filePath = string.Empty;
            string[] files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.csv", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                if (file.Contains("Test_ProjectRun1"))
                {
                    filePath = file;
                }
            }
            Assert.AreEqual(false, String.IsNullOrEmpty(filePath));
        }

        [TestMethod]
        public void WriteInCSV_Writing_SuccessButOnlyHeaderLine()
        {
            // Arrange
            Logger log = new Logger("WriteInCSVRightOnlyHeader.log");
            FileOperations fileOperation = new FileOperations(log);

            // Act
            fileOperation.WriteInCSV("Test_ProjectRun1_OnlyHeaderLine", null);

            // Assert
            string filePath = string.Empty;
            string[] files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.csv", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                if (file.Contains("Test_ProjectRun1"))
                {
                    filePath = file;
                }
            }
            Assert.AreEqual(false, String.IsNullOrEmpty(filePath));
        }
    }
}
