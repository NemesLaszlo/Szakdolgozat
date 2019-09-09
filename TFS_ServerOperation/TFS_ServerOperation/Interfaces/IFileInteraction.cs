using System.Collections.Generic;

namespace TFS_ServerOperation
{
    interface IFileInteraction
    {
        void WriteInCSV(List<string> datas);
        List<int> ReadCSV(string fileName);
    }
}
