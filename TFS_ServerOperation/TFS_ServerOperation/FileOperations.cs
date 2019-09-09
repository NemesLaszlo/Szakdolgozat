using System;
using System.Collections.Generic;
using System.IO;

namespace TFS_ServerOperation
{
    public class FileOperations : IFileInteraction
    {
        private Logger log;

        public FileOperations(string initLogData)
        {
            log = new Logger(initLogData);
        }

        public List<int> ReadCSV(string fileName)
        {
            try
            {
                List<int> pbi_ids = new List<int>();
                StreamReader sr = new StreamReader(fileName);
                string line = "";
                string[] values = null;

                string headerLine = sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    values = line.Split(';');
                    int id = int.Parse(values[0]);
                    pbi_ids.Add(id);
                }
                sr.Close();
                log.Info("The Read was succesful from the file into the Delete method.");
                log.Flush();
                return pbi_ids;
            }
            catch (Exception ex)
            {
                log.Error(ex);
                log.Flush();
                return default(List<int>);
            }
        }

        public void WriteInCSV(List<string> datas)
        {
            try
            {
                using (var fileStream = new FileStream("UploadedDatas.csv", FileMode.OpenOrCreate))
                using (var streamWriter = new StreamWriter(fileStream))
                {
                    streamWriter.WriteLine("Id;Title;AssignedTo;State");
                    foreach (var item in datas)
                    {
                        streamWriter.WriteLine(item);
                    }
                    streamWriter.Flush();
                    streamWriter.Close();
                    log.Info(" The Upload write was successful to the UploadedDatas.csv file");
                    log.Flush();
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
                log.Flush();
            }
        }
    }
}
