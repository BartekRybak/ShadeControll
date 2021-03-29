using System;
using System.Collections.Generic;
using System.Text;

namespace ShadeControll.Commands
{
    class Command
    {
        /// <summary>
        /// Command
        /// </summary>
        public string CommandPrompt = string.Empty;

        /// <summary>
        /// Command Name
        /// </summary>
        public string Name = string.Empty;

        /// <summary>
        /// Command Description
        /// </summary>
        public string Description = string.Empty;

        /// <summary>
        /// Command Help
        /// </summary>
        public string Help = string.Empty;

        /// <summary>
        /// List of Available Commands
        /// </summary>
        public static Command[] AvailableCommands = {
            new Help_Command(),new Logout_Command(),new Screenshot_Command(),
            new ShutDown_Command(),new Test_Command(), new Webpage_Command(),
            new Update_Command(),new Version_Command(), new Config_Command(),
            new Log_Command(),new Login_Command()
        };

        public Command() { }

        public static Command GetCommand(string name)
        {
            foreach(Command _command in AvailableCommands)
            {
                if(_command.Name == name)
                {
                    return _command;
                }
            }
            return new Command();
        }

        /// <summary>
        /// Execute Command with Args
        /// </summary>
        /// <param name="args">Command Arguments</param>
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
