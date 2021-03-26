using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
namespace ShadeControll.Commands
{
    class Webpage_Command : Command
    {
        public Webpage_Command()
        {
            CommandPrompt = "/web";
            Name = "Web";
            Description = "Open browser page";
            Help = "Example /web www.google.pl";
        }

        public override void Execute(string[] args)
        {
            Program.telegramClient.SendMessage("dziala");
            if(args.Length > 0)
            {
                Process.Start("cmd", "/C start" + " " + args[0]);
            }
            else
            {
                Process.Start("cmd", "/C start" + " " + "http://google.com");
            }
            base.Execute(args);
        }
    }
}
