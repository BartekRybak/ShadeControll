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
            Description = "Help";
        }

        public override void Execute(string[] args)
        {
            if(args.Length > 0)
            {
                foreach(Command cmd in Command.AvailableCommands)
                {
                    if(args[0] == cmd.Name)
                    {
                        Program.telegramClient.SendMessage(cmd.Name + " : " + cmd.Description);
                    }
                }
            }
            else
            {
                foreach(Command cmd in Command.AvailableCommands)
                {
                    Program.telegramClient.SendMessage(cmd.Name);
                }
            }

            base.Execute(args);
        }
    }
}
