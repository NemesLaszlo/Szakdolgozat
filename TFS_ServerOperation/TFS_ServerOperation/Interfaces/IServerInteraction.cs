using System.Collections.Generic;
using TFS_ServerOperation.CustomConfigSetup;

namespace TFS_ServerOperation
{
    public interface IServerInteraction
    {
        void Archive(bool isUIRun, string currentTeamProject);
        bool Upload(bool isUIRun,PBI pbi, string AreaPath);
        bool DeleteFromFile(string fileName);
        bool DeleteByIds(List<string> ids);
        void ServerContentDelete();
    }
}
