using System;
using System.IO;
using System.Text;
using System.Configuration;



namespace Demo.Utility
{
    /// <summary>
    /// This class is used to log error in server
    /// </summary>
    public sealed class ErrorLog: ILog
    {
        private ErrorLog()
        {

        }
        private static readonly Lazy<ErrorLog> instance = new Lazy<ErrorLog>(()=>new ErrorLog());

        public static ErrorLog GetInstance
        {
            get { return instance.Value; }
        }
        /// <summary>
        /// The Error Log Folder Path
        /// </summary>
        public static string errorLogFolderPath = string.Empty; 
        
        /// <summary>
        /// The Error Count
        /// </summary>
        public static long ErrorCount
        {
            get;
            private set;
        }

        static string errorFilePath = string.Empty;

        /// <summary>
        /// Generate Error File Name
        /// </summary>
        private static void GenerateErrorFileName()
        {
            if (string.IsNullOrEmpty(errorLogFolderPath))
            {
                errorLogFolderPath = AppDomain.CurrentDomain.BaseDirectory + "logs\\";
            }

            if (string.IsNullOrEmpty(errorFilePath))
            {
                errorFilePath = ErrorLog.errorLogFolderPath + string.Format("log_{0}.html", DateTime.Now.ToString("MMM_dd_yyyy_hhmmtt"));
            }
        }
        
       
        /// <summary>
        /// Write Log into file
        /// </summary>
        /// <param name="className"></param>
        /// <param name="eventName"></param>
        /// <param name="shortMessage"></param>
        /// <param name="errorDescription"></param>
        /// <param name="queryCondtions"></param>       
       public void WriteLogInServer(string errorDescription)
        {
            ErrorCount = ErrorCount + 1;
            if (ErrorCount >= long.MaxValue)
            {
                ErrorCount = 1;
            }

            GenerateErrorFileName();

            bool isNew = false;

            if (!System.IO.Directory.Exists(ErrorLog.errorLogFolderPath))
            {
                System.IO.Directory.CreateDirectory(errorLogFolderPath);
            }

            if (!System.IO.File.Exists(errorFilePath))
            {
                isNew = true;
            }

            using (System.IO.StreamWriter oSW = new System.IO.StreamWriter(new System.IO.FileStream(errorFilePath, System.IO.FileMode.Append, System.IO.FileAccess.Write)))
            {
                StringBuilder strMessage = new StringBuilder();

                if (isNew)
                {
                    strMessage.Append("<table border='1' cellspacing='1' width='100%'>");
                    strMessage.Append("<tr>");
                    strMessage.AppendFormat("<td>{0}</td>", "Date");
                    strMessage.AppendFormat("<td>{0}</td>", "Time");
                    strMessage.AppendFormat("<td>{0}</td>", "Message");
                    strMessage.Append("</tr>");
                }
                strMessage.Append("<tr>");
                strMessage.AppendFormat("<td valign=\"top\">{0}&#160;</td>", DateTime.Now.ToShortDateString());
                strMessage.AppendFormat("<td valign=\"top\">{0}&#160;</td>", DateTime.Now.ToLongTimeString());
                strMessage.AppendFormat("<td valign=\"top\">{0}&#160;</td>", errorDescription);
                strMessage.Append("</tr>");
                //strMessage.Append("\"" + DateTime.Now.ToShortDateString() + "\",\"" + DateTime.Now.ToLongTimeString() + "\",\"" + className + "\",\"" + shortMessage + "\",\"" + errorDescription + "\",\"" + queryCondtions + "\"");
                oSW.WriteLine("");
                oSW.WriteLine(strMessage);
                oSW.Flush();
                oSW.Close();
            }
        }
    }
    }

