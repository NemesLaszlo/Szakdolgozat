
using System.Collections.Generic;

namespace TFS_ServerOperation
{
    public class Program
    {
        static void Main(string[] args)
        {
            InformationParser informationParser = new InformationParser();
            //Logger log = informationParser.Init_Log();

            informationParser.ConsoleRun(args);

            //ServerOperationManager oSm = informationParser.Init_ServerOperation(log);
            //MailSender mS = informationParser.Init_MailSender(log);

            //List<string> datas = new List<string>() { "73", "74" };

            //informationParser.DeleteByIds_Process(datas, oSm, mS);
            //informationParser.DeleteFromFile_Process("UploadedDatas_9.csv",oSm,mS);
            //informationParser.ServerContentDelete_Process(oSm,mS);
        }
    }
}
