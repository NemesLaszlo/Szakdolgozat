using System;

namespace TFS_ServerOperation
{
    public class Logger
    {
        private TextLogTraceListener textLogTraceListener;
        // date pariod for the log file name
        private string dateForLogTitle = string.Empty;
        // path, where we would like to take our created log files
        private string path;

        /// <summary>
        /// Constructor for our custom logger.
        /// </summary>
        /// <param name="path">where we would like to take our created log files</param>
        public Logger(string path)
        {
            this.path = path;
            dateForLogTitle = DateTime.Now.ToString();
            string[] str = path.Split('.');
            textLogTraceListener = new TextLogTraceListener(str[0] + " " + dateForLogTitle + "." + str[1]);
        }

        /// <summary>
        /// Basic log writer method, which gives the format for every line.
        /// </summary>
        /// <param name="message">Message to write to the log file.</param>
        /// <param name="type">We can specify our message type.</param>
        private void WriteEntry(string message, string type)
        {
            textLogTraceListener.WriteLine(string.Format("[{0}] [{1}] [{2}]",
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                type,
                message));
        }

        /// <summary>
        /// Logger closer.
        /// </summary>
        public void CloseWriter()
        {
            textLogTraceListener.Close();
        }

        /// <summary>
        /// Error log message writer with Error specify type.
        /// </summary>
        /// <param name="message">Message to write to the log file.</param>
        public void Error(string message)
        {
            WriteEntry(message, "ERROR");
        }

        /// <summary>
        /// Error log message writer with Error specify type. (Exception variant)
        /// </summary>
        /// <param name="ex">Received exception</param>
        public void Error(Exception ex)
        {
            WriteEntry(ex.Message + Environment.NewLine + ex.StackTrace, "ERROR");
        }

        /// <summary>
        /// Information log writer with Info specity type for basic logging.
        /// </summary>
        /// <param name="message">Message to write to the log file.</param>
        public void Info(string message)
        {
            WriteEntry(message, "INFO");
        }
    }
}
