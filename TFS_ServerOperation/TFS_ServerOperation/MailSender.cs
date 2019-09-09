using System;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using MailMessage = System.Net.Mail.MailMessage;

namespace TFS_ServerOperation
{
    public class MailSender : IMailInteraction
    {
        public string MailFrom { get; set; }
        public string MailSmtpHost { get; set; }
        public int MailSmtpPort { get; set; }
        private const string MailSmtpUsername = "";
        private const string MailSmtpPassword = "";

        private Logger log;

        public MailSender(string initLogData)
        {
            log = new Logger(initLogData);
        }

        /// <summary>
        /// Mail sender method.
        /// </summary>
        /// <param name="to">Mail address where we would like to send a message/email.</param>
        /// <param name="subject">Mail subject.</param>
        /// <param name="body">Mail body message.</param>
        /// <returns></returns>
        public bool SendEmail(string to, string subject, string body)
        {
            MailMessage mail = new MailMessage(MailFrom, to, subject, body);
            var alternameView = AlternateView.CreateAlternateViewFromString(body, new ContentType("text/html"));
            mail.AlternateViews.Add(alternameView);

            var smtpClient = new SmtpClient(MailSmtpHost, MailSmtpPort);
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(MailSmtpUsername, MailSmtpPassword);
            try
            {
                smtpClient.Send(mail);
                log.Info("Mail has been sent.");
                log.Flush();
            }
            catch (Exception ex)
            {
                log.Error(ex);
                log.Flush();
                return false;
            }
            return true;
        }
    }
}
