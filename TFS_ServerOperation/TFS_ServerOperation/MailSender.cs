﻿using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using MailMessage = System.Net.Mail.MailMessage;

namespace TFS_ServerOperation
{
    public class MailSender : IMailInteraction
    {
        public string MailSmtpHost { get; private set; }
        public int MailSmtpPort { get; private set; }
        private const string MailFrom = "tfs.serveroperation@gmail.com";
        private const string MailSmtpUsername = "tfs.serveroperation@gmail.com";
        private const string MailSmtpPassword = "Szakdolgozat";

        private Logger log;

        public MailSender(string MailSmtpHost, string MailSmtpPort, Logger log )
        {
            this.log = log;
            this.MailSmtpHost = MailSmtpHost;
            try
            {
                this.MailSmtpPort = int.Parse(MailSmtpPort);
            }
            catch(FormatException ex)
            {
                log.Error(ex);
                log.Flush();
            }
        }

        /// <summary>
        /// Mail sender method.
        /// </summary>
        /// <param name="to">Mail address where we would like to send a message/email.</param>
        /// <param name="subject">Mail subject.</param>
        /// <param name="body">Mail body message.</param>
        /// <param name="attachmentFilename">Mail attachment file name.</param>
        /// <returns></returns>
        public bool SendEmail(string to, string subject, string body, string attachmentFilename)
        {
            MailMessage mail = new MailMessage(MailFrom, to, subject, body);
            var alternameView = AlternateView.CreateAlternateViewFromString(body, new ContentType("text/html"));
            mail.AlternateViews.Add(alternameView);

            if (attachmentFilename != null)
            {
                Attachment attachment = new Attachment(attachmentFilename, MediaTypeNames.Application.Octet);
                ContentDisposition disposition = attachment.ContentDisposition;
                disposition.CreationDate = File.GetCreationTime(attachmentFilename);
                disposition.ModificationDate = File.GetLastWriteTime(attachmentFilename);
                disposition.ReadDate = File.GetLastAccessTime(attachmentFilename);
                disposition.FileName = Path.GetFileName(attachmentFilename);
                disposition.Size = new FileInfo(attachmentFilename).Length;
                disposition.DispositionType = DispositionTypeNames.Attachment;
                mail.Attachments.Add(attachment);
            }

            var smtpClient = new SmtpClient(MailSmtpHost, MailSmtpPort);
            smtpClient.EnableSsl = true;
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
