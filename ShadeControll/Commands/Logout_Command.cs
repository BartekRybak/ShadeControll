using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Threading;

namespace ShadeControll.Commands
{
    class Logout_Command : Command
    {
        public Logout_Command()
        {
            CommandPrompt = "/logout";
            Name = "Logout";
            Description = "Just Logout";
        }

        public override void Execute(string[] args)
        {
            Program.IsLogged = false;
            Program.telegramClient.SendMessage("Logged Out");

            base.Execute(args);
        }
    }
}
