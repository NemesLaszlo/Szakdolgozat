using Microsoft.TeamFoundation.WorkItemTracking.Client;

namespace TFS_ServerOperation
{
    interface IConnection
    {
        void Connection(string TfsConnection, string TeamProjectName);
    }
}
