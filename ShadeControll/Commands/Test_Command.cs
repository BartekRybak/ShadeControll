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
            Description = "Komenda Testowa (do testowania nowych funkcji)";
        }

        public override void Execute()
        {
            base.Execute();
        }
    }
}
