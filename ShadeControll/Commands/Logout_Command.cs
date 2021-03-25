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
            Name = "/logout";
            Description = "Just Logout current user";
        }

        public override void Execute(string[] args)
        {
            Thread.Sleep(5000);
            Process.Start("shutdown", "/l");

            base.Execute(args);
        }
    }
}
