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

        public override void Execute(string[] args)
        {
            if(args.Length > 0)
            {
                foreach(Command cmd in Command.AvailableCommands)
                {
                    if(args[0] == cmd.Name)
                    {
                        Program.Client.SendMessage(cmd.Name + " : " + cmd.Description);
                    }
                }
            }
            else
            {
                foreach(Command cmd in Command.AvailableCommands)
                {
                    Program.Client.SendMessage(cmd.Name);
                }
            }

            base.Execute(args);
        }
    }
}
