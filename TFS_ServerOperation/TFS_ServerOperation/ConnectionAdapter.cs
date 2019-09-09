using System;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;

namespace TFS_ServerOperation
{
    public class ConnectionAdapter : IConnection
    {
        public WorkItemStore WorkItemStore { get; private set; }
        public Project TeamProject { get; private set; }

        private Uri connUri;
        private TfsTeamProjectCollection tpc;
        private Logger log;

        /// <summary>
        ///  Connection constructor.
        /// </summary>
        /// <param name="TfsConnection">The server URL, where we would like to connect</param>
        /// <param name="TeamProjectName">The Project name on the server, where we would like to do something</param>
        /// <param name="log">Custom logger class</param>
        public ConnectionAdapter(string TfsConnection, string TeamProjectName, Logger log)
        {
            this.log = log;
            Connection(TfsConnection, TeamProjectName);           
        }

        /// <summary>
        /// Based on the App.config file this method will connect to the TFS server.
        /// </summary>
        /// <param name="TfsConnection">The server URL, where we would like to connect</param>
        /// <param name="TeamProjectName">The Project name on the server, where we would like to do something</param>
        public void Connection(string TfsConnection, string TeamProjectName)
        {
            if (!(TfsConnection == null || TeamProjectName == null))
            {
                connUri = new Uri(TfsConnection);
                tpc = new TfsTeamProjectCollection(connUri);
                WorkItemStore = tpc.GetService<WorkItemStore>();
                TeamProject = WorkItemStore.Projects[TeamProjectName];
                string message = string.Format("Connection was successful to {0} and the ProjectName is {1}", TfsConnection, TeamProjectName);
                log.Info(message);
                log.Flush();
            }
            else
            {
                log.Error("ConnectionException in the ConnectionAdapter class");
                log.Flush();
                throw new ConnectionException();
            }
        }
    }
}
