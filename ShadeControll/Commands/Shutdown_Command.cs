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
            Name = "/shutdown";
            Description = "Wyłączenie komputera po 5 sekundach.";
        }

        public override void Execute()
        {
            Thread.Sleep(5000);
            Console.WriteLine("WYŁĄCZANIE");
            Process.Start("shutdown", "/s /t 0");
            base.Execute();
        }
    }
}
