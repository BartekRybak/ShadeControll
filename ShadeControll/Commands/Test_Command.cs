using System;
using System.Collections.Generic;
using System.Text;

namespace ShadeControll.Commands
{
    class Test_Command : Command
    {
        public Test_Command()
        {
            Name = "/test";
            Description = "Test";
        }

        public override void Execute(string[] args)
        {
            base.Execute(args);
        }
    }
}
