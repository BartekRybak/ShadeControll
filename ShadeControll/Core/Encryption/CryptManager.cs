using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ShadeControll.Core.Encryption
{
    class CryptManager
    {
        public static byte[] Encrypt(string text, byte[] key, byte[] IV)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = IV;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(text);
                        }
                        return msEncrypt.ToArray();
                    }
                }
            }
        }

        public static string Decrypt(byte[] data, byte[] key, byte[] IV)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = IV;

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream msDecrypt = new MemoryStream(data))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }

        public static byte[] CreateKey(string password, byte[] salt)
        {
            using (var key = new Rfc2898DeriveBytes(password, salt, 1200000))
            {
                return key.GetBytes(32);
            }
        }

        public static byte[] GenerateIV()
        {
            using (Aes aes = Aes.Create())
            {
                aes.GenerateIV();
                return aes.IV;
            }
        }

        public static byte[] GenerateSalt()
        {
            List<byte> Salt = new List<byte>();
            Random rand = new Random();

            for (int i = 0; i <= 256; i++)
            {
                Salt.Add(Convert.ToByte(rand.Next(1, 128)));
            }

            return Salt.ToArray();
        }

        public static byte[] GetHMAC(byte[] data, byte[] key)
        {
            HMACSHA512 hmac = new HMACSHA512();
            hmac.Key = key;
            return hmac.ComputeHash(data);
        }

        public static bool CompareHMAC(byte[] HMAC, byte[] HMAC2)
        {
            int i = 0;

            foreach (byte b in HMAC)
            {
                if (b != HMAC2[i])
                {
                    return false;
                }
                else
                {
                    i++;
                }
            }
            return true;
        }
    }
}