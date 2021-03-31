using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ShadeControll.Core.Encryption;

namespace ShadeControll.Core
{
    class Loger
    {
        public static string logsDirectory;
        private CryptCredentials credentials;
        private List<string> logbuffer = new List<string>();
        private int bufferSize = 0;
        public Loger(string _logsDirectory,int bufferSize,CryptCredentials cryptCredentials)
        {
            logsDirectory = _logsDirectory;
            credentials = cryptCredentials;
            if(!Directory.Exists(logsDirectory))
            {
                Directory.CreateDirectory(logsDirectory);
            }
        }

        public void Log(string data)
        {
            string currentLogFile = CreateLogFileName(DateTime.Now, ".txt");
            if (logbuffer.Count > bufferSize)
            {
               if (File.Exists(currentLogFile))
               {
                    CryptFiles.Decrypt(currentLogFile, credentials);
                    File.AppendAllText(currentLogFile,data);
                    CryptFiles.Encrypt(currentLogFile, credentials);
               }
               else
               {
                    File.AppendAllText(currentLogFile, data);
                    CryptFiles.Encrypt(currentLogFile, credentials);
                }
            }
            else
            {
                logbuffer.Add(data);
            }
        }

        public string GetLogFile(DateTime dateTime)
        {
            string file = CreateLogFileName(dateTime, ".txt");
            CryptFiles.Decrypt(file, credentials);
            string fileData = File.ReadAllText(file);
            CryptFiles.Encrypt(file, credentials);
            return fileData;
        }

        public string GetLogFile(string dateTime)
        {
            string file = CreateLogFileName(dateTime, ".txt");
            CryptFiles.Decrypt(file, credentials);
            string fileData = File.ReadAllText(file);
            CryptFiles.Encrypt(file, credentials);
            return fileData;
        }

        public string CreateLogFileName(DateTime dateTime,string extension)
        {
            return logsDirectory + dateTime.ToString("yyyy-dd-MM") + extension;
        }

        public string CreateLogFileName(string date,string extension)
        {
            return logsDirectory + date + extension;
        }
    }
}
