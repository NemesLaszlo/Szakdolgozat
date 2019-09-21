using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using TFS_ServerOperation.CustomConfigSetup;

namespace TFS_ServerOperation
{
    public class InformationParser
    {
        private Dictionary<string, string> connection_data = new Dictionary<string, string>();
        private Dictionary<string, string> mail_data = new Dictionary<string, string>();
        public string ToMailAddress { get; private set; }
        public string CurrentTfsCollectionName { get; private set; }
        public string CurrentTeamProjectName { get; private set; }

        /// <summary>
        /// Initialize the Custom Logging System Path
        /// </summary>
        /// <returns>Costom Logger class</returns>
        public Logger Init_Log()
        {
            string initializeData = string.Empty;
            ConfigurationSection diagnosticsSection = (ConfigurationSection)ConfigurationManager.GetSection("system.diagnostics");
            ConfigurationElement traceSection = diagnosticsSection.ElementInformation.Properties["trace"].Value as ConfigurationElement;
            ConfigurationElementCollection listeners = traceSection.ElementInformation.Properties["listeners"].Value as ConfigurationElementCollection;
            foreach (ConfigurationElement listener in listeners)
            {

                initializeData = listener.ElementInformation.Properties["initializeData"].Value.ToString();

            }
            Logger log = new Logger(initializeData);
            return log;
        }

        /// <summary>
        /// Initialize the ServerOperation and ConnectionAdapter
        /// </summary>
        /// <returns></returns>
        public ServerOperationManager Init_ServerOperation(Logger log)
        {
            var connection_section = ConfigurationManager.GetSection("Connection") as NameValueCollection;
            foreach (var part in connection_section.AllKeys)
            {
                connection_data.Add(part, connection_section[part]);
            }

            ConnectionAdapter ConnectionAdapter = new ConnectionAdapter(connection_data["TfsCollection"], connection_data["TeamProjectName"], log);
            ServerOperationManager ServerOperationManager = new ServerOperationManager(ConnectionAdapter, connection_data["AreaPath"], connection_data["Iteration"], log);

            CurrentTfsCollectionName = connection_data["TfsCollection"];
            CurrentTeamProjectName = connection_data["TeamProjectName"];

            return ServerOperationManager;
        }

        /// <summary>
        /// Initialize the MailSender System
        /// </summary>
        /// <returns></returns>
        public MailSender Init_MailSender(Logger log)
        {
            var mail_section = ConfigurationManager.GetSection("MailInformation") as NameValueCollection;
            foreach (var part in mail_section.AllKeys)
            {
                mail_data.Add(part, mail_section[part]);
            }

            ToMailAddress = mail_data["mail_address"];
            MailSender MailSender = new MailSender(mail_data["smtp_host"], mail_data["port"], log);
            return MailSender;
        }

        /// <summary>
        /// Get the path to the up to date Month .csv file, to attach to the email (teamProject's file) or open.
        /// </summary>
        /// <returns></returns>
        public string GetUpToDateFileCSV(string currentTeamProject)
        {
            string currentMonth = string.Empty;
            DateTime today = DateTime.Today;
            string upToDateMonth = today.Month.ToString();

            string[] files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.csv", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                if (file.Contains(upToDateMonth) && file.Contains(currentTeamProject))
                {
                    currentMonth = file;
                }
            }
            return currentMonth;
        }

        /// <summary>
        /// Get the current file content.
        /// </summary>
        /// <param name="path">File access path</param>
        /// <returns></returns>
        public string GetFileContent(string path)
        {
            string result = string.Empty;
            try
            {
                using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (var sr = new StreamReader(fs, Encoding.Default))
                {
                    result = sr.ReadToEnd();
                    sr.Close();
                    fs.Close();
                }
                return result;
            }
            catch (Exception)
            {
                return result;
            }
        }

        /// <summary>
        /// Running from console.
        /// </summary>
        /// <param name="array">Console parameters</param>
        public void ConsoleRun(string[] array)
        {
            var log = Init_Log();
            try
            {
                if (array.Contains(@"/config") && File.Exists(array[Array.IndexOf(array, @"/config") + 1]))
                {
                    var ServerOperation = Init_ServerOperation(log);
                    var MailSender = Init_MailSender(log);

                    Upload_Process(false, ServerOperation, MailSender, log);
                    FileOperations writer = new FileOperations(log);
                    writer.WriteInCSV(CurrentTeamProjectName, ServerOperation.datasForFileModification);
                    MailSender.SendEmail(ToMailAddress, "Scheduled Month Uploaded File Period", "You can find the Result file in the Attachments.", GetUpToDateFileCSV(CurrentTeamProjectName));
                }
                else
                {
                    log.Error("Wrong parameter list!");
                    log.Flush();
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
                log.Flush();
            }
        }

        /// <summary>
        /// Upload the configuration data to the server. Return True if its done with no problem.
        /// </summary>
        /// <param name="ServerOperation">ServerOperationManager object</param>
        /// <param name="MailSender">MailSender object</param>
        /// <param name="log">Custom Logger object</param>
        public bool Upload_Process(bool isUIRun,ServerOperationManager ServerOperation, MailSender MailSender, Logger log)
        {
            try
            {
                ServerOperation.datasForFileModification.Clear();
                ServerOperation.Archive(isUIRun, CurrentTeamProjectName);
                FileOperations writer = new FileOperations(log);
                PbisConfigSection myPBISection = ConfigurationManager.GetSection("PBICollectionSection") as PbisConfigSection;
                for (int i = 0; i < myPBISection.Members.Count; i++)
                {
                    PBI pbi = myPBISection.Members[i];
                    ServerOperation.Upload(isUIRun, pbi, ServerOperation.AreaPath);
                }  

                return true;
            }
            catch (Exception ex)
            {
                log.Error(ex);
                log.Flush();
                return false;
            }
        }

        /// <summary>
        /// Send a mail.
        /// </summary>
        /// <param name="MailSender">MailSender object</param>
        /// <param name="log">Custom Logger object</param>
        /// <param name="subject">Subject of the mail</param>
        /// <param name="body">Mail content</param>
        /// <param name="attachment">Mail attachment</param>
        /// <returns></returns>
        public bool SendMail(MailSender MailSender, Logger log, string subject, string body, string attachment)
        {
            bool result = MailSender.SendEmail(ToMailAddress, subject, body, null);

            return result;
        }

        /// <summary>
        /// Delete datas from the server about the file, and send a mail about it.
        /// </summary>
        /// <param name="fileName">Name of the file for the delete section</param>
        /// <param name="ServerOperation">ServerOperationManager object</param>
        /// <param name="MailSender">MailSender object</param>
        /// <returns></returns>
        public bool DeleteFromFile_Process(string fileName, ServerOperationManager ServerOperation, MailSender MailSender)
        {
            bool result = ServerOperation.DeleteFromFile(fileName);
            if (result)
            {
                MailSender.SendEmail(ToMailAddress, "Delete From File on the Server", "Delete method ran on the server. File Name: " + fileName, null);
            }
           
            return result;
        }

        /// <summary>
        /// Delete datas from the server about the ids, and send a mail about it.
        /// </summary>
        /// <param name="ids">List of string ids, what we would like to delete</param>
        /// <param name="ServerOperation">ServerOperationManager object</param>
        /// <param name="MailSender">MailSender object</param>
        /// <returns></returns>
        public bool DeleteByIds_Process(List<string> ids, ServerOperationManager ServerOperation, MailSender MailSender)
        {
            string deletedIds = string.Join(",", ids);
            bool result = ServerOperation.DeleteByIds(ids);
            if (result)
            {
                MailSender.SendEmail(ToMailAddress, "Delete From Ids on the Server", "Delete method ran on the server. Deleted workItem ids: " + deletedIds, null);
            }

            return result;
        }

        /// <summary>
        /// Comlete server reset (datas).
        /// </summary>
        /// <param name="ServerOperation">ServerOperationManager object</param>
        /// <param name="MailSender">MailSender object</param>
        public void ServerContentDelete_Process(ServerOperationManager ServerOperation, MailSender MailSender)
        {
            ServerOperation.ServerContentDelete();
            MailSender.SendEmail(ToMailAddress, "All server data is gone", "Everything has been deleted from the server", null);
        }
    }
}
