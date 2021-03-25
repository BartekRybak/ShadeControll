using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace ShadeControll.Commands
{
    class Update_Command : Command
    {
        const string updaterDirectory = "Updater/updater.exe";

        public Update_Command()
        {
            Name = "/update";
            Description = "Update app \n" +
                "/update [update url adress]";
        }

        public override void Execute(string[] args)
        {
            if(args.Length > 0)
            {
                RunUpdater(updaterDirectory, args[0] + " ShadeControll " + Directory.GetCurrentDirectory());
            }
            else
            {
                Program.telegramClient.SendMessage(Description);
            }
            
            base.Execute(args);
        }

        private void RunUpdater(string file, string args)
        {
            if(File.Exists(file))
            {
                Program.telegramClient.SendMessage("Updating in progress.");
                Process.Start(file, args);  
            }
            else
            {
                Program.telegramClient.SendMessage("i cant find updater.exe");
            }
        }
    }
}
