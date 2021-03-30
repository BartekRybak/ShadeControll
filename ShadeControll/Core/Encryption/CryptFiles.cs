using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ShadeControll.Core.Encryption
{
    class CryptFiles
    {
        public static void Encrypt(string file,CryptCredentials credentials)
        {
            if(File.Exists(file))
            {
                string fileData = File.ReadAllText(file);
                File.Delete(file);
                string fileDataCrypted = Convert.ToBase64String(CryptManager.Encrypt(fileData, credentials.key, credentials.iv));
                File.WriteAllText(file,fileDataCrypted);
            }
        }

        public static string Decrypt(string file, CryptCredentials credentials)
        {
            if(File.Exists(file))
            {
                string fileData = File.ReadAllText(file);
                File.Delete(file);
                string fileDataDecrypted = CryptManager.Decrypt(Convert.FromBase64String(fileData), credentials.key, credentials.iv);
                File.WriteAllText(file, fileDataDecrypted);
                return fileDataDecrypted;
            }
            return string.Empty;
        }
    }
}
