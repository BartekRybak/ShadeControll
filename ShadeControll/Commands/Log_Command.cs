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
            Name = "/log";
            Description = "Manage log files";
        }

        public override void Execute(string[] args)
        {
            if(args.Length == 0)
            {
                string fileName = Program.configFile.GetValue("directories", "logs") + DateTime.Now.ToString("yyyy-dd-MM") + ".txt";
                Program.telegramClient.UploadFile(fileName, "Today Log File");
                
            }
            
            if(args.Length == 1)
            {
                string fileName = Program.configFile.GetValue("directories", "logs") + args[0] + ".txt";

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
