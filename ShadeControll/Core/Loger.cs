using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ShadeControll
{
    class Loger
    {
        public static string logsDirectory;
        private List<string> DataToLog = new List<string>();
        public Loger(string _logsDirectory)
        {
            logsDirectory = _logsDirectory;
            if(!Directory.Exists(logsDirectory))
            {
                Directory.CreateDirectory(logsDirectory);
            }
        }

        public void Log(string data)
        {
            DateTime dt = DateTime.Now;
            string logFileName = dt.ToString("yyyy-dd-MM") + ".txt";
            DataToLog.Add(data);
            try
            {
                for (int i = 0; i < DataToLog.Count; i++)
                {
                    File.AppendAllText(logsDirectory + logFileName, "[" + dt.ToString("HH:mm") + "] " + DataToLog[i]);
                    DataToLog.RemoveAt(i);
                }
            }
            catch(Exception e)
            {
                DataToLog.Add(e.Message);
            }
           
        }
    }
}
