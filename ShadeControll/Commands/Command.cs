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
            new ShutDown_Command(),new Test_Command(), new Webpage_Command(),
            new Update_Command(),new Version_Command(), new Config_Command(),
            new Log_Command()
        };

        public Command() { }

        public virtual void Execute(string[] args)
        {
            string _args = string.Empty;
            if(args.Length > 0)
            {
                foreach (string arg in args)
                {
                    _args += " " + arg;
                }
                Program.loger.Log("Execute Commmand " + Name + " with args " + _args + Environment.NewLine);
            }
            else
            {
                Program.loger.Log("Execute Command " + Name + Environment.NewLine);
            }
            
        }
    }
}
