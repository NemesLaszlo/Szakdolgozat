using System.Collections.Generic;
using TFS_ServerOperation.CustomConfigSetup;

namespace TFS_ServerOperation
{
    interface IServerInteraction
    {
        void Archive();
        bool Upload(PBI pbi);
        bool DeleteFromFile(string fileName);
        bool DeleteByIds(List<string> ids);
        void ServerContentDelete();
    }
}
