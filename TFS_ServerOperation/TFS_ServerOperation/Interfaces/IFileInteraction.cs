using System.Collections.Generic;

namespace TFS_ServerOperation
{
    public interface IFileInteraction
    {
        void WriteInCSV(string serverName, List<string> datas);
        List<int> ReadCSV(string fileName);
    }
}
