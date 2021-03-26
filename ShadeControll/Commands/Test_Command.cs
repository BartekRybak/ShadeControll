using System;
using System.Collections.Generic;
using System.Text;

namespace ShadeControll.Commands
{
    class Test_Command : Command
    {
        public Test_Command()
        {
            CommandPrompt = "/test";
            Name = "Test";
            Description = "Command for testing features";
        }

        public override void Execute(string[] args)
        {
            base.Execute(args);
        }
    }
}
