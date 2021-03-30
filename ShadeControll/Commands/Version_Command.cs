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
            CommandPrompt = "/version";
            Name = "Version";
            Description = "Check App Version";
        }

        public override void Execute(string[] args)
        {
            Program.telegramClient.SendMessage(
                "App Version - " + Program.config.GetValue("info", "version") + "\n /update"
                );
            base.Execute(args);
        }
    }
}
