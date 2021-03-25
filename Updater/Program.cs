using System;
using System.Net;
using System.Web;
using System.IO;
using System.IO.Compression;
using System.Diagnostics;
using System.Threading;
using ShadeControll;

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
        static string[] exceptionDirectories = { "Updater" };

        static void Main(string[] args)
        {
            Ninja.Hide();
            string packUrl = args[0]; //"http://localhost/ShadeControll.zip";
            string motherProcess = args[1]; //"ShadeControll";
            string motherDirectory = args[2]; //@"C:/Users/Jan/source/repos/ShadeControll/ShadeControll/bin/Debug/netcoreapp3.1/";
            Console.WriteLine("Zamykam " + motherProcess);
            if (KillMotherPorcess(motherProcess))
            {

                Thread.Sleep(2000);
                Console.WriteLine("Pobieram " + Path.GetFileName(packUrl));
                if (DownloadZip(packUrl))
                {
                    Console.WriteLine("Rozpakowywuje");
                    if (UnpackZip(Path.GetFileName(packUrl),motherDirectory))
                    {
                        Thread.Sleep(2000);
                        Console.WriteLine("Uruchamian " + motherProcess);
                        if(StartMotherProcess(motherProcess,motherDirectory))
                        { Environment.Exit(0); } else { Environment.Exit(4); }
                    }
                    else
                    { Environment.Exit(2); }
                }
                else
                { Environment.Exit(1); }
            }
            else
            { Environment.Exit(3); }
        }

        /// <summary>
        /// Start Mother process
        /// </summary>
        /// <param name="motherProcess">Mother process name</param>
        /// <param name="motherDirectory">Mother file directory</param>
        /// <returns></returns>
        static bool StartMotherProcess(string motherProcess,string motherDirectory)
        {
            string motherFileName = motherDirectory + "/" + motherProcess + ".exe";
            Console.WriteLine(motherFileName);
            if (File.Exists(motherFileName))
            {
                try
                {
                    Process p = new Process();
                    p.StartInfo = new ProcessStartInfo()
                    {
                        FileName = motherFileName
                    };
                    p.Start();
                
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

        /// <summary>
        /// Kill mother process
        /// </summary>
        /// <param name="motherProcess">Mother process name</param>
        /// <returns></returns>
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

        /// <summary>
        /// Unpack zip with update
        /// </summary>
        /// <param name="archiveFile">Zip fileName</param>
        /// <param name="destinationDirectory">Destination folder</param>
        /// <returns></returns>
        static bool UnpackZip(string archiveFile,string destinationDirectory)
        {
            DirectoryInfo di = new DirectoryInfo(destinationDirectory);
            foreach (FileInfo file in di.GetFiles())
            {
                if(file.Name != archiveFile)
                {
                    file.Delete();
                }
                
            }

            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                foreach(string exception in exceptionDirectories)
                {
                   if ((dir.Name != exception))
                   {
                       dir.Delete(true);
                   }
                }                
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

        /// <summary>
        /// Download zip with update form url
        /// </summary>
        /// <param name="url">archive file url</param>
        /// <returns></returns>
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
                        return false;
                    }
                }
                    Console.WriteLine("3");
                return false;
            }
        }
    }
}
