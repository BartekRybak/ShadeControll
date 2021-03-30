using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

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
                string fileName = Program.config.GetValue("directories", "logs") + DateTime.Now.ToString("yyyy-dd-MM") + ".txt";
                Program.telegramClient.UploadFile(fileName, "Today Log File");
                
            }
            
            if(args.Length == 1)
            {
                string fileName = Program.config.GetValue("directories", "logs") + args[0] + ".txt";

                if(!File.Exists(fileName))
                {
                    Program.telegramClient.UploadFile(fileName, args[0] + " Log file");
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
