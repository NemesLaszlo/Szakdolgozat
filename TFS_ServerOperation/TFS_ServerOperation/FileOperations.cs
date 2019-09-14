using System;
using System.Collections.Generic;
using System.IO;

namespace TFS_ServerOperation
{
    public class FileOperations : IFileInteraction
    {
        private Logger log;

        /// <summary>
        /// Constructor of FileOperation
        /// </summary>
        /// <param name="log">Custom logger class, for logging</param>
        public FileOperations(Logger log)
        {
            this.log = log;
        }

        /// <summary>
        /// Reading method from a file, we only read the ids into a list.
        /// </summary>
        /// <param name="filename">The FileName from where we would like to read</param>
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
                log.Info("The Read was succesful from the file.");
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

        /// <summary>
        /// This method write the Upload datas into a file.
        /// </summary>
        /// <param name="datas"> Upload datas in string list </param>
        public void WriteInCSV(List<string> datas)
        {
            try
            {
                DateTime date = DateTime.Today;
                string dateMonth = date.Month.ToString();

                using (var fileStream = new FileStream("UploadedDatas_" + dateMonth + ".csv", FileMode.Create))
                using (var streamWriter = new StreamWriter(fileStream))
                {
                    streamWriter.WriteLine("Id;Title;AssignedTo;State");
                    foreach (var item in datas)
                    {
                        streamWriter.WriteLine(item);
                    }
                    streamWriter.Flush();
                    streamWriter.Close();
                    log.Info("File period fine!");
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
