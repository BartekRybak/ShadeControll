using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace ShadeControll.Commands
{
    class ShutDown_Command : Command
    {
        public ShutDown_Command()
        {
            CommandPrompt = "/shutdown";
            Name = "Shutdown";
            Description = "Just shutdown a computer";
        }

        public override void Execute(string[] args)
        {
            Thread.Sleep(5000);
            Process.Start("shutdown", "/s /t 0");
            base.Execute(args);
        }
    }
}
