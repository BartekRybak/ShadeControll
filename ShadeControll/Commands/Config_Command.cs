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
            CommandPrompt = "/config";
            Name = "Config";
            Description = "Manage config file";
            Help = "Exmaple: /config someSection someKey someValue";
        }

        public override void Execute(string[] args)
        {
            Console.WriteLine(args.Length);
            if(args.Length == 0)
            {
                string configFile = Program.config.GetConfigFile();
                Program.telegramClient.SendMessage(configFile);
            }

            if(args.Length == 3)
            {
                Program.config.SetValue(args[0], args[1],args[2]);
                Program.telegramClient.SendMessage("Done!");
            }
            base.Execute(args);
        }
    }
}
