using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using TFS_ServerOperation.CustomConfigSetup;

namespace TFS_ServerOperation
{
    public class InformationParser
    {
        private Dictionary<string, string> connection_data = new Dictionary<string, string>();
        private Dictionary<string, string> mail_data = new Dictionary<string, string>();
        public string ToMailAddress { get; private set; }

        /// <summary>
        /// Initialize the Custom Logging System Path
        /// </summary>
        /// <returns></returns>
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
                Console.WriteLine(part + " " + connection_section[part]);
                connection_data.Add(part, connection_section[part]);
            }

            ConnectionAdapter ConnectionAdapter = new ConnectionAdapter(connection_data["TfsCollection"], connection_data["TeamProjectName"], log);
            ServerOperationManager ServerOperationManager = new ServerOperationManager(ConnectionAdapter, connection_data["AreaPath"], connection_data["Iteration"], log);
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
                Console.WriteLine(part + " " + mail_section[part]);
                mail_data.Add(part, mail_section[part]);
            }

            ToMailAddress = mail_data["mail_address"];
            MailSender MailSender = new MailSender(mail_data["smtp_host"], mail_data["port"], log);
            return MailSender;
        }

        /// <summary>
        /// Get the E-Mail Address Where we would like to send a mail / message.
        /// </summary>
        /// <returns></returns>
        public string GetAddressToMail()
        {
            return ToMailAddress;
        }

        /// <summary>
        /// Running from console. Only Upload and delete from file.
        /// </summary>
        /// <param name="array">Console parameters</param>
        public void ConsoleRun(string[] array, Logger log)
        {
            try
            {
                var ServerOperation = Init_ServerOperation(log);
                if (array.Contains(@"/delete") && File.Exists(array[Array.IndexOf(array, @"/delete") + 1]))
                {
                    ServerOperation.DeleteFromFile(array[Array.IndexOf(array, @"/delete") + 1]);
                }
                else
                {
                    ServerOperation.Archive();
                    FileOperations writer = new FileOperations(log);
                    PbisConfigSection myPBISection = ConfigurationManager.GetSection("PBICollectionSection") as PbisConfigSection;
                    for (int i = 0; i < myPBISection.Members.Count; i++)
                    {
                        PBI pbi = myPBISection.Members[i];
                        ServerOperation.Upload(pbi);
                    }
                    writer.WriteInCSV(ServerOperation.datasForFileModification);
                    Console.WriteLine("Upload was successful!");
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
                log.Flush();
                Console.WriteLine("Something went wrong, check the logFile.");
                Console.ReadLine();
            }
            Console.ReadLine();
        }
    }
}
