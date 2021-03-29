using System;
using System.Collections.Generic;
using System.Text;

namespace ShadeControll.Commands
{
    class Login_Command : Command
    {
        public bool Logged = false;

        public Login_Command()
        {
            CommandPrompt = "/login";
            Name = "Login";
            Description = "Login in to client";
            Help = "Example: \n" +
                "/login [password] - Log in \n" +
                "/login out - Log out";
        }

        public override void Execute(string[] args)
        {
            if(args.Length > 0)
            {
                if (args[0] == "out")
                {
                    Program.IsLogged = false;
                    Program.telegramClient.SendMessage("Logged Out");
                }
                else
                {
                    if(args[0] == Program.configFile.GetValue("info","password"))
                    {
                        Program.IsLogged = true;
                        Program.telegramClient.SendMessage("Logged in successfully");
                        Program.telegramClient.SendMessage(
                        "ShadeControll is running now[" + Program.configFile.GetValue("info", "version") + "] \n" +
                        "MachineName [" + Environment.MachineName + "] \n" +
                        "AppID [" + Program.configFile.GetValue("info", "id") + "] \n" +
                        "UserName [" + Environment.UserName + "] \n" +
                        "/help "
                );
                    }
                    else
                    {
                        Program.telegramClient.SendMessage("Wrong Password");
                    }
                }
            }
            base.Execute(args);
        }
    }
}
