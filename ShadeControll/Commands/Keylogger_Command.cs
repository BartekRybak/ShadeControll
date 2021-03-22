using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Threading;

namespace ShadeControll.Commands
{
    class Keylogger_Command : Command
    {
        static BackgroundWorker backgroundWorker = new BackgroundWorker();
        public Keylogger_Command()
        {
            Name = "/keylogger";
            Description = "Przeczwytywanie klawiatury użytkownika.";
        }

        public override void Execute(string[] args)
        {
            if(args.Length > 0)
            {
                switch (args[0])
                {
                    case "start":
                        backgroundWorker.DoWork += BackgroundWorker_DoWork;
                        backgroundWorker.WorkerSupportsCancellation = true;
                        backgroundWorker.RunWorkerAsync();
                        break;

                    case "stop":
                        if(backgroundWorker.IsBusy)
                        {
                            Program.Client.SendMessage("Koniec kurwa");
                            backgroundWorker.CancelAsync();
                            backgroundWorker.Dispose();
                        }
                        break;
                }
            }
            base.Execute(args);
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!backgroundWorker.CancellationPending)
            {
                Program.Client.SendMessage("Wątek napierdala ostro");
                Thread.Sleep(1000);
            }
        }
    }
}
