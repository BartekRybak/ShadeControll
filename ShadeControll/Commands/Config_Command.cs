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
            Description = "Config File \n" +
                "/config [section] [key] [value]";
        }

        public override void Execute(string[] args)
        {
            Console.WriteLine(args.Length);
            if(args.Length == 0)
            {
                string configFile = File.ReadAllText(Program.configFileName);
                Program.telegramClient.SendMessage(configFile);
            }

            if(args.Length == 3)
            {
                Console.WriteLine("elo");
                Program.configFile.SetValue(args[0], args[1],args[2]);
                Program.configFile.Save(Program.configFileName);
            }
            

            base.Execute(args);
        }
    }
}
