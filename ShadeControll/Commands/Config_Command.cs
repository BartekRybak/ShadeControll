using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ShadeControll.Commands
{
    class Config_Command : Command
    {
        public Config_Command()
        {
            Name = "/config";
            Description = "Config File";
        }

        public override void Execute(string[] args)
        {
            if(args.Length == 0)
            {
                string configFile = File.ReadAllText(Program.configFileName);
                Program.telegramClient.SendMessage(configFile);
            }

            base.Execute(args);
        }
    }
}
