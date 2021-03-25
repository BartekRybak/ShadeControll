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
            Description = "Wyświetl aktualną wersję aplikacji.";
        }

        public override void Execute(string[] args)
        {
            Program.telegramClient.SendMessage("Wersja Aplikacji - " + Program.configFile.GetValue("info", "version"));
            base.Execute(args);
        }
    }
}
