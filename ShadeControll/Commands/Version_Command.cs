using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.IO;
using System.Configuration;
using ShadeControll;

namespace ShadeControll.Commands
{
    class Version_Command : Command
    {
        public Version_Command()
        {
            Name = "/version";
            Description = "Check App Version";
        }

        public override void Execute(string[] args)
        {
            Program.telegramClient.SendMessage(
                "App Version - " + Program.configFile.GetValue("info", "version") + "\n /update"
                );
            base.Execute(args);
        }
    }
}
