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
            Description = "Wyświetlenie Pomocy.";
        }

        public override void Execute()
        {
            foreach (Command cmd in Command.AvailableCommands)
            {
                Program.Client.SendMessage(cmd.Name);
            }
            base.Execute();
        }
    }
}
