using System;
using Keystroke.API;

namespace Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var api = new KeystrokeAPI())
            {
                api.CreateKeyboardHook((character) => { Console.Write(character); });
                
            }

            Console.Read();
        }
    }
}
