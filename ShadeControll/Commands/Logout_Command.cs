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
        }

        public override void Execute()
        {
            Thread.Sleep(5000);
            Console.WriteLine("WYLOGOWYWANIE");
            Process.Start("shutdown", "/l");

            base.Execute();
        }
    }
}
