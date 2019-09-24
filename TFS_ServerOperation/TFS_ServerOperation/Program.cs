
using System.Collections.Generic;

namespace TFS_ServerOperation
{
    public class Program
    {
        static void Main(string[] args)
        {
            InformationParser informationParser = new InformationParser();

            informationParser.ConsoleRun(args);

        }
    }
}
