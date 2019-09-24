using System;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TFS_ServerOperation.Tests
{
    [TestClass]
    public class ConnectionAdapterTest
    {
        [TestMethod]
        public void Test_Project_Connection_Right()
        {
            // Arrange , Act
            Logger log = new Logger("ConnectionTestRight.log");
            ConnectionAdapter testConn = new ConnectionAdapter(@"http://localhost:8080/tfs/SzakdolgozatCollection", "Test_Project", log);

            // Assert
            Assert.AreEqual(false, String.IsNullOrEmpty(testConn.TeamProject.Name));
        }

        // One parameter is null.
        [TestMethod]
        [ExpectedException(typeof(ConnectionException))]
        public void Test_Project_Connection_Fail_NullParameter()
        {
            //Arrange , Act , Assert
            Logger log = new Logger("ConnectionTestNullParameter.log");
            ConnectionAdapter testConn = new ConnectionAdapter(@"http://localhost:8080/tfs/SzakdolgozatCollection", null, log);
        }

        [TestMethod]
        [ExpectedException(typeof(DeniedOrNotExistException))]
        public void Test_Project_Connection_Fail_WrongParameter()
        {
            //Arrange , Act
            Logger log = new Logger("ConnectionTestWrongParameter.log");
            ConnectionAdapter testConn = new ConnectionAdapter(@"http://localhost:8080/tfs/SzakdolgozatCollection", "Test_Project1", log);

            // Assert
            Assert.AreEqual(true, String.IsNullOrEmpty(testConn.TeamProject.Name)); // Throw the exception, because cant init the connection object.
        }


    }
}
