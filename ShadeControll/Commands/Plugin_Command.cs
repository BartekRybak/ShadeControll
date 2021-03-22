using System;
using System.Collections.Generic;
using System.Text;

namespace ShadeControll.Commands
{
    class Plugin_Command : Command
    {
        public Plugin_Command()
        {
            Name = "/plugin";
            Description = "Obsługa pluginów";
        }

        public override void Execute(string[] args)
        {
            // /plugin list
            // /plugin download [plugin name]
            // /plugin update [plugin name]
            // /plugin del [plugin name]
            base.Execute(args);
        }
    }
}
