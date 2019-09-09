using Microsoft.TeamFoundation.WorkItemTracking.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TFS_ServerOperation.CustomConfigSetup;

namespace TFS_ServerOperation
{
    public class ServerOperationManager : IServerInteraction
    {
        private ConnectionAdapter conn;
        private WorkItemType PBIType;
        private WorkItemType TaskType;
        private Logger log;
        private MailSender mailSender;

        private string AreaPath;
        private string Iteration;

        private string Mail_address_toSend;
        private string Smtp_host;
        private string Port;
        private string initLogData;

        public List<string> datasForFileModification = new List<string>();

        /// <summary>
        /// ServerOperationManager constructor.
        /// </summary>
        /// <param name="conn">ConnectionAdapter calss parameter, whitch makes the connection with the server.</param>
        /// <param name="Mail_address_toSend">Mail address where we would like to send a message / email.</param>
        /// <param name="Smtp_host">Mail smtp server host.</param>
        /// <param name="Port">Mail smtp server port.</param>
        /// <param name="initLogData">Path for the logging.</param>
        public ServerOperationManager(ConnectionAdapter conn, string AreaPath, string Iteration, string Mail_address_toSend, string Smtp_host, string Port, string initLogData)
        {
            this.AreaPath = AreaPath;
            this.Iteration = Iteration;
            this.Mail_address_toSend = Mail_address_toSend;
            this.Smtp_host = Smtp_host;
            this.Port = Port;
            this.initLogData = initLogData;
            log = new Logger(initLogData);
            mailSender = new MailSender(initLogData, Smtp_host, Port);

            if (conn != null)
            {
                this.conn = conn;
                log.Info("ServerOperationManager is Up!");
                log.Flush();
            }
            else
            {
                log.Error("ArgumentNullException in the ServerOperationManager class!");
                log.Flush();
                throw new ArgumentNullException(nameof(conn));

            }
        }

        /// <summary>
        /// Get the current Month period (firstday to lastday) for the WorkItem.
        /// </summary>
        /// <returns></returns>
        private string RunDatePeriod()
        {
            StringBuilder sb = new StringBuilder(" (");

            DateTime date = DateTime.Today;
            var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

            sb.Append(date.Year + "." + date.Month + "." + firstDayOfMonth);
            sb.Append(" - ");
            sb.Append(date.Year + "." + date.Month + "." + lastDayOfMonth);
            sb.Append(")");

            return sb.ToString();
        }

        /// <summary>
        /// Check the active WorkItems and change the states to "Done" before the next Month period creation run.
        /// </summary>
        public void Archive()
        {
            FileOperations fOp = new FileOperations(initLogData);
            string lastMonthFile = string.Empty;

            DateTime today = DateTime.Today;
            DateTime month = new DateTime(today.Year, today.Month, 1);
            string lastMonth = month.AddDays(-1).Month.ToString();

            string[] files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.csv", SearchOption.AllDirectories);
            foreach(var file in files)
            {
                if (file.Contains(lastMonth))
                {
                    lastMonthFile += file;
                }
            }

            if (String.IsNullOrEmpty(lastMonthFile))
            {
                List<int> LastMonthWorkItems = new List<int>();
                log.Error("Archive failure!");
                log.Flush();
                return;
            }
            else
            {
                List<int> LastMonthWorkItems = fOp.ReadCSV(lastMonthFile);
                foreach(int id in LastMonthWorkItems)
                {
                    WorkItem current = conn.WorkItemStore.GetWorkItem(id);
                    if (current.Fields["State"].Value.Equals("Active"))
                    {
                        current.Fields["State"].Value = "Closed";
                        if (current.Validate().Count == 0)
                        {
                            current.Save();
                        }
                        else
                        {
                            log.Error("Archive failure! WorkItem State Change / Save Problem!");
                            log.Flush();
                            return;
                        }
                    }
                    else
                    {
                        continue;
                    }  
                }
            }
        }

        /// <summary>
        /// PBI / User Story configuration Creator and Uploader to the Server.
        /// </summary>
        /// <param name="pbi"> Parameter is a PBI / User Story, what we would like to upload to the server.</param>
        /// <returns></returns>
        public bool Upload(PBI pbi)
        {
            try
            {
                string PBI_AssignedTo = string.Empty;

                PBIType = conn.TeamProject.WorkItemTypes["User Story"];
                TaskType = conn.TeamProject.WorkItemTypes["Task"];

                // Create actual PBI / User Story
                WorkItem TFSpbi = new WorkItem(PBIType);
                // Set the Title and Tags to the PBI / User Stroy
                TFSpbi.Title = pbi.Title + RunDatePeriod();
                TFSpbi.Fields["Tags"].Value = "Created_By_Program" + ";" + "Szakdolgozat";

                //Run a query for check this WorkItem with this title already exist or not
                Query query = new Query(conn.WorkItemStore, string.Format("SELECT Id FROM WorkItems WHERE  System.Title = '{0}'", TFSpbi.Title));
                WorkItemCollection workItemCollection = query.RunQuery();
                if (workItemCollection.Count == 0)
                {
                    Console.WriteLine(pbi.Title);
                    // WorkItem Parent Query
                    Query queryParent = new Query(conn.WorkItemStore, string.Format("SELECT Id FROM WorkItems WHERE  System.Id = '{0}'", pbi.ParentID));
                    WorkItemCollection workItemCollectionParent = queryParent.RunQuery();
                    if (workItemCollectionParent.Count == 1)
                    {
                        // Link to the Parent
                        TFSpbi.Links.Add(new RelatedLink(conn.WorkItemStore.WorkItemLinkTypes.LinkTypeEnds["Parent"], int.Parse(pbi.ParentID)));
                    }
                    else
                    {
                        log.Error("There is no Parent!");
                        log.Flush();
                    }

                    // PBI / User Story Configuration
                    TFSpbi.Fields["System.AssignedTo"].Value = pbi.AssignedTo;
                    TFSpbi.Fields["System.AreaPath"].Value = AreaPath;
                    TFSpbi.Fields["System.IterationPath"].Value = Iteration;
                    // validation check (ready for save)
                    if (TFSpbi.Validate().Count == 0)
                    {
                        TFSpbi.Save();
                    }   
                    // State Change and Validation check before Save again
                    TFSpbi.Fields["State"].Value = "Active";
                    if (TFSpbi.Validate().Count == 0)
                    {
                        TFSpbi.Save();
                    }
                    PBI_AssignedTo = pbi.AssignedTo;
                    // file writing init part
                    datasForFileModification.Add(string.Format("{0};{1};{2};{3}", TFSpbi.Id, TFSpbi.Title, PBI_AssignedTo, TFSpbi.State, Environment.NewLine));

                    // PBI / User Stroy Task Configuration period
                    foreach (ConfigTask task in pbi.Tasks)
                    {
                        ConfigTaskConfigurator(task,TFSpbi);
                    }

                    log.Info("Upload was successful" + "  " + TFSpbi.Title);
                    log.Flush();
                    return true;
                }
                else
                {
                    Console.WriteLine("Already Exist!");
                    log.Error("PBI already exist! Fail to Upload");
                    log.Flush();
                    return false;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
                log.Flush();
            }
            return false;
        }

        /// <summary>
        /// Task configuration for the PBI / User Story
        /// </summary>
        /// <param name="task">PBI / User stroy current task from the config</param>
        /// <param name="TFSpbi">Parent of this task</param>
        private void ConfigTaskConfigurator(ConfigTask task, WorkItem TFSpbi)
        {
            // Task creation for the PBI / User Story
            WorkItem Task = new WorkItem(TaskType);
            // Task Configuration
            Task.Title = task.Title;
            Task.Fields["Tags"].Value = "Created_By_Program_Task" + ";" + "Szakdolgozat";
            Task.Fields["System.AssignedTo"].Value = task.AssingTo;
            Task.Fields["System.AreaPath"].Value = AreaPath;
            Task.Fields["System.IterationPath"].Value = Iteration;
            var AssignedTo_String = task.AssingTo;
            Console.WriteLine(task.AssingTo);

            // Link to the PBI / User Stroy
            Task.Links.Add(new RelatedLink(conn.WorkItemStore.WorkItemLinkTypes.LinkTypeEnds["Parent"], TFSpbi.Id));

            if (Task.Validate().Count == 0)
            {
                Task.Save();
            }
            // State Change and Validation check before Save again
            Task.Fields["State"].Value = "Active";
            if (Task.Validate().Count == 0)
            {
                Task.Save();
            }
            // file writing init part
            var newLine = string.Format("{0};{1};{2};{3}", Task.Id, Task.Title, AssignedTo_String, Task.State, Environment.NewLine);
            datasForFileModification.Add(newLine);
        }

        /// <summary>
        /// Delete PBIs or User Stories/ Tasks by Ids from the server.
        /// </summary>
        /// <param name="fileName">File, which contains the Ids for the delete</param>
        /// <returns></returns>
        public bool DeleteFromFile(string fileName)
        {
            try
            {
                FileOperations reader = new FileOperations(initLogData);
                var pbi_ids = reader.ReadCSV(fileName);
                conn.WorkItemStore.DestroyWorkItems(pbi_ids);
                log.Info("Delete was successful!");
                log.Flush();
                return true;
            }
            catch (Exception ex)
            {
                log.Error(ex);
                log.Flush();
            }
            return false;
        }

        /// <summary>
        /// Delete PBIs or User Stories/ Tasks by Ids from the server.
        /// </summary>
        /// <param name="ids">List of ids for delete</param>
        /// <returns></returns>
        public bool DeleteByIds(List<string> ids)
        {
            try
            {
                List<int> IdsWithRightType = ids.Select(int.Parse).ToList();
                conn.WorkItemStore.DestroyWorkItems(IdsWithRightType);
                log.Info("Delete was successful!");
                log.Flush();
                return true;
            }
            catch (Exception ex)
            {
                log.Error(ex);
                log.Flush();
            }
            return false;
        }

        /// <summary>
        /// Delete everything from the server.
        /// </summary>
        public void ServerContentDelete()
        {
            List<int> dellist = new List<int>();
            Query queryID = new Query(conn.WorkItemStore, string.Format("Select ID from WorkItems"));
            if (queryID != null)
            {
                WorkItemCollection workItemCollection = queryID.RunQuery();
                foreach (WorkItem item in workItemCollection)
                {
                    dellist.Add(item.Id);
                }
            }
            conn.WorkItemStore.DestroyWorkItems(dellist);
        }
    }
}
