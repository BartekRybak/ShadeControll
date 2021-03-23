using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Test
{
    class Program
    {
        [DllImport("user32.dll")]
        public static extern int GetAsyncKeyState(Int32 i);

        static void Main(string[] args)
        {
            using (var api = new KeystrokeAPI())
            {
                api.CreateKeyboardHook((character) => { Console.Write(character); });

            }
        }
}
