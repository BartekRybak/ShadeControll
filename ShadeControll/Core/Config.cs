using System;
using System.Collections.Generic;
using System.Text;
using Salaros.Configuration;
using System.IO;
using ShadeControll.Core;

namespace ShadeControll.Core
{
    public class Config
    {
        private ConfigParser configParser;

        public static readonly string _DEFAULT_CONFIG =
        @"
        [info]
        version=1.9
        id=Home_PC
        first_run=true
        key=1774037430:AAHnjjeOUNvn-ZpyCCo_6mIhztp_GkagsVg
        password=1234

        [directories]
        logs=Logs/
        ";
        /*
        public Config(string configFileName,EncryptionCridentials cridential)
        {
            if(!File.Exists(configFileName))
            {
                RestoreConfigFile(configFileName);
            }

            configParser = new ConfigParser(configFileName);
        }

        public void RestoreConfigFile(string fileName)
        {
            if(File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            File.WriteAllText(fileName, _DEFAULT_CONFIG);
        }



        public string GetValue(string section, string key, string defaultValue = null)
        {
            string decryptedFile = CryptManager.FileEncryption.
            // deszyfrowanie
            // pobieranie wartosci
            // szyfrowanie
             return configParser.GetValue(section, key, defaultValue);
           
        }
         
        public void SetValue(string section,string key,string newValue)
        {
            configParser.SetValue(section, key, newValue);
        }
        */
    }
}
