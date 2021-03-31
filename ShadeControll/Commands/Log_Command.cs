using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;

namespace ShadeControll.Commands
{
    class Log_Command : Command
    {
        public Log_Command()
        {
            CommandPrompt = "/log";
            Name = "Log";
            Description = "Manage log files";
            Help = "Example: /log 2021-23-04 [year-day-month]";
        }

        public override void Execute(string[] args)
        {
            if(args.Length == 0)
            {
                string fileName = Program.loger.CreateLogFileName(DateTime.Now, ".txt");
                File.WriteAllText("today log.txt",Program.loger.GetLogFile(DateTime.Now));
                Program.telegramClient.UploadFile("today log.txt", "Today Log File");
                Thread.Sleep(1000);
                File.Delete("today log.txt");
            }
            
            if(args.Length == 1)
            {
                string fileName = Program.loger.CreateLogFileName(args[0], ".txt");

                if(!File.Exists(fileName))
                {
                    string _fileName = args[0] + "_log.txt";
                    File.WriteAllText(_fileName, Program.loger.GetLogFile(args[0]));
                    Program.telegramClient.UploadFile(_fileName, "Today Log File");
                    Thread.Sleep(1000);
                    File.Delete(_fileName);

                    Program.telegramClient.UploadFile(_fileName, args[0] + " Log file");
                }
                else
                {
                    Program.telegramClient.SendMessage("I can't find log from this day :( ");
                }
            }

            base.Execute(args);
        }

        private void GetLogFile(string date)
        {

        }
    }
}
