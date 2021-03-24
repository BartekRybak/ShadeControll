using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace ShadeControll.Commands
{
    class Update_Command : Command
    {
        public Update_Command()
        {
            Name = "/update";
            Description = "Aktualizacja Oprogramowania \n" +
                "/update" +
                "";
        }

        public override void Execute(string[] args)
        {

            base.Execute(args);
        }

        private void RunUpdater(string file, string args)
        {

        }
    }
}
