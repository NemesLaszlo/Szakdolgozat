using Microsoft.TeamFoundation.WorkItemTracking.Client;

namespace TFS_ServerOperation
{
    interface IConnection
    {
         WorkItemStore WorkItemStore { get; set; }
         Project TeamProject { get; set; }

        void Connection(string TfsConnection, string TeamProjectName);
    }
}
