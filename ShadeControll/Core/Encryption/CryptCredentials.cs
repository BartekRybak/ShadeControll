using System;
using System.Collections.Generic;
using System.Text;

namespace ShadeControll.Core.Encryption
{
    class CryptCredentials
    {
        public byte[] key;
        public byte[] salt;
        public byte[] iv;

        public static CryptCredentials FromPassword(string _password,string _salt, string _iv)
        {
            byte[] _bSalt = Convert.FromBase64String(_salt);
            return new CryptCredentials()
            {
                key = CryptManager.CreateKey(_password, _bSalt),
                salt = _bSalt,
                iv = Convert.FromBase64String(_iv)
            };
        }

        public CryptCredentials(string _key, string _salt, string _iv)
        {
            key = Convert.FromBase64String(_key);
            salt = Convert.FromBase64String(_salt);
            iv = Convert.FromBase64String(_iv);
        }

        public CryptCredentials(byte[] _key, byte[] _salt, byte[] _iv)
        {
            key = _key;
            salt = _salt;
            iv = _iv;
        }

        public CryptCredentials() { }
    }
}
