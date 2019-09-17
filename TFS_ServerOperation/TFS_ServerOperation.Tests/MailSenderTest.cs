using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TFS_ServerOperation;

namespace TFS_ServerOperation.Tests
{
    [TestClass]
    public class MailSenderTest
    {

        public class FakeMailSender : IMailInteraction
        {
            private Logger log;
            public string MailSmtpHost { get; private set; }
            public string MailSmtpPort { get; private set; }

            public FakeMailSender(string MailSmtpHost, string Port, Logger log)
            {
                this.log = log;
                this.MailSmtpHost = MailSmtpHost;
                this.MailSmtpPort = Port;
            }

            public bool SendEmail(string to, string subject, string body, string attachmentFilename)
            {
                FakeSmtpClient fakeSmtp = new FakeSmtpClient(MailSmtpHost, MailSmtpPort);
                return fakeSmtp.isUp; // return the smtp status, if it is up we can send a mail otherwise we can't
            }
        }

        public class FakeSmtpClient{

            private string host;
            private int port;
            public bool isUp = false;


            public FakeSmtpClient(string host, string port)
            {
                try
                {
                    this.host = host;
                    this.port = int.Parse(port);
                    this.isUp = true;
                }
                catch (Exception)
                {
                    this.isUp = false;
                }
            }
        }

        [TestMethod]
        public void Test_SendMail_Right()
        {
            Logger log = new Logger("path1.log");
            FakeMailSender sender = new FakeMailSender("MailSmtpHost", "1234", log);

            bool result = sender.SendEmail("test@test.com","testing","testbody",null); // if every value are right, so it can send a mail.
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void Test_SendMail_Smtp_problem()
        {
            Logger log = new Logger("path2.log");
            FakeMailSender sender = new FakeMailSender("MailSmtpHost", "onetwo", log); // smtp is the key, if we can init it, we can send a mail.

            bool result = sender.SendEmail("test@test.com", "testing", "testbody", null); 
            Assert.AreEqual(false, result);
        }
    }
}
