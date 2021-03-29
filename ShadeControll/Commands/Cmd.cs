using System;
using System.Collections.Generic;
using System.Text;

namespace ShadeControll.Commands
{
    class Cmd
    {
        public string CommandPrompt;
        public string[] Args;

        public Cmd(string userInput)
        {
            string[] msgSplited = userInput.Split(' ');

            int cmdNameIndex = 0;
            List<string> cmdArgs = new List<string>();

            for (int i = 0; i < msgSplited.Length; i++)
            {
                if (msgSplited[i].Contains('/'))
                {
                    CommandPrompt = msgSplited[i];
                    cmdNameIndex = i;
                    break;
                }
            }

            for (int i = cmdNameIndex + 1; i < msgSplited.Length; i++)
            {
                cmdArgs.Add(msgSplited[i]);
            }
            Args = cmdArgs.ToArray();
        }
    }
}
