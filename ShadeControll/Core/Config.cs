using System;
using System.Collections.Generic;
using System.Text;
using Salaros.Configuration;
using System.IO;
using ShadeControll.Core;
using ShadeControll.Core.Encryption;

namespace ShadeControll.Core
{
    class Config
    {
        private string configFile; 
        private ConfigParser configParser;
        private CryptCredentials cryptCredentials;

        public static string _DEFAULT_CONFIG
        { 
            get
            {
                return @"
                [info]
                version=1.9
                id=Home_PC
                first_run=true
                key=1774037430:AAHnjjeOUNvn-ZpyCCo_6mIhztp_GkagsVg
                password=1234

                [directories]
                logs=Logs/
                ".Trim();
            }
            set
            {

            }
        }

        public Config(string configFile,CryptCredentials credentials)
        {
            if(!File.Exists(configFile))
            {
                File.WriteAllText(configFile, _DEFAULT_CONFIG);
                CryptFiles.Encrypt(configFile, credentials);
            }
            this.configFile = configFile;
            cryptCredentials = credentials;
            
        }

        public void SetValue(string section,string key,string value)
        {
            CryptFiles.Decrypt(configFile, cryptCredentials);
            configParser = new ConfigParser(configFile);
            configParser.SetValue(section, key, value);
            configParser.Save(configFile);
            CryptFiles.Encrypt(configFile, cryptCredentials);
        }

        public string GetValue(string section,string key)
        {
            string file = CryptFiles.Decrypt(configFile, cryptCredentials);
            configParser = new ConfigParser(configFile);
            string value = configParser.GetValue(section, key);
            CryptFiles.Encrypt(configFile, cryptCredentials);
            return value;
        }

        public string GetConfigFile()
        {
            string confiFileData = CryptFiles.Decrypt(configFile, cryptCredentials);
            CryptFiles.Encrypt(configFile, cryptCredentials);
            return confiFileData;
        }
    }
}
