using System;
using System.Collections.Generic;
using System.Text;

namespace ShadeControll.Commands
{
    class Help_Command : Command
    {
        public Help_Command()
        {
            Name = "/help";
        }

        public override void Execute()
        {
            Program.Client.SendMessage("/help /shutdown /logout /screenshot");
            base.Execute();
        }
    }
}
