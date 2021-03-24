using System;
using System.Net;
using System.Web;
using System.IO;
using System.IO.Compression;
using System.Diagnostics;
using System.Threading;

namespace Updater
{
    /* 
     * Commands:
     * Updater.exe /update [mother process name] [motherdirectory] [url]
     * 
     * Exit Codes:
     * 1 - nie mozna pobrac paczki
     * 2 - nie udalo sie rozpakowac paczki
     * 3 - nie udalo sie zamknac procesu matki
     * 4 - nie udalo sie uruchomic ponownie procesu matki
     */
    class Program
    {
        static void Log(string text)
        {
            File.AppendAllText("log.txt", text);
        }

        static void Main(string[] args)
        {
            File.Delete("log.txt");
            string packUrl = "http://localhost/ShadeControll.zip";
            string motherProcess = "ShadeControll";
            string motherDirectory = @"C:/Users/Jan/source/repos/ShadeControll/ShadeControll/bin/Debug/netcoreapp3.1/";

            if (KillMotherPorcess(motherProcess))
            {
                Thread.Sleep(2000);
                if (DownloadZip(packUrl))
                {
                    if (UnpackZip(Path.GetFileName(packUrl),motherDirectory))
                    {
                        Thread.Sleep(2000);
                        if(StartMotherProcess(motherProcess,motherDirectory))
                        {
                            Environment.Exit(0);
                            Log("Gotowe");
                        }
                        else
                        {
                            Environment.Exit(4);
                        }
                    }
                    else
                    {
                        Environment.Exit(2);
                    }
                }
                else
                {
                    Environment.Exit(1);
                }
            }
            else
            {
                Environment.Exit(3);
            }
            Console.ReadLine();
        }
        static bool StartMotherProcess(string motherProcess,string motherDirectory)
        {
            string motherFileName = motherDirectory + motherProcess + ".exe";
            Console.WriteLine(motherFileName);
            if (File.Exists(motherFileName))
            {
               // try
                //{
                    Process p = new Process();
                    p.StartInfo = new ProcessStartInfo()
                    {
                        FileName = motherFileName
                    };
                    p.Start();
                    return true;
                // }
                // catch
                // {
                //    return false;
                // }
            }
            else
            {
                return false;
            }
        }

        static bool KillMotherPorcess(string motherProcess)
        {
            foreach (var process in Process.GetProcesses())
            {
                if(process.ProcessName == motherProcess)
                {
                    try
                    {
                        process.Kill();
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        static bool UnpackZip(string archiveFile,string destinationDirectory)
        {
            DirectoryInfo di = new DirectoryInfo(destinationDirectory);

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }

            Thread.Sleep(2000);

            if (File.Exists(archiveFile))
            {
                ZipArchive archive = ZipFile.Open(archiveFile, ZipArchiveMode.Read);
                try
                {
                    archive.ExtractToDirectory(destinationDirectory);
                      return true;
                   }
                 catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        static bool DownloadZip(string url)
        {
            using(WebClient client = new WebClient())
            {
                Uri uri = new Uri(url);

                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        client.DownloadFile(url, Path.GetFileName(uri.LocalPath));
                        return true;
                    }
                    catch
                    {
                    }
                }
                    Console.WriteLine("3");
                return false;
            }
        }
    }
}
