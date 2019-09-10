
namespace TFS_ServerOperation
{
    class Program
    {
        static void Main(string[] args)
        {
            InformationParser informationParser = new InformationParser();
            Logger log = informationParser.Init_Log();
            informationParser.ConsoleRun(args, log);
            //ServerOperationManager oSm = informationParser.Init_ServerOperation(log);
            //oSm.ServerContentDelete();
        }
    }
}
