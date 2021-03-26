using System;
using System.Collections.Generic;
using System.Text;

namespace ShadeControll.Commands
{
    class Help_Command : Command
    {
        public Help_Command()
        {
            CommandPrompt = "/help";
            Name = "Help";
            Description = "Show the Help";
        }

        public override void Execute(string[] args)
        {
            if (args.Length == 0)
            { 
                foreach(Command command in AvailableCommands)
                {
                    Program.telegramClient.SendMessage(command.CommandPrompt + " : " + command.Description);
                }
            }

            if (args.Length == 1)
            {
                foreach (Command command in AvailableCommands)
                {
                    if(command.CommandPrompt == args[0])
                    {
                        Program.telegramClient.SendMessage(command.Name + " : \n" + command.Description + "\n" + command.Help);
                    }
                    
                }
            }

            base.Execute(args);
        }
    }
}
