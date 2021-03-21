using System;
using System.Collections.Generic;
using System.Text;

namespace ShadeControll.Commands
{
    class Command
    {
        public string Name;
        public string Description;

        public static Command[] AvailableCommands = {
            new Help_Command(),new Logout_Command(),new Screenshot_Command(),
            new ShutDown_Command(),new Test_Command(), new Webpage_Command()
        };

        public Command() { }

        public virtual void Execute(string[] args)
        {
            
        }
    }
}
