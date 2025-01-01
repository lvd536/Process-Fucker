using System.Diagnostics;
namespace Fucker.Watcher;

class WatcherProcess
{
    static void Main(string[] args)
    {
        string mainProcessName = "Fucker";
        string mainProcessPath = @"C:\Users\lvd\RiderProjects\ProcessFucker\Fucker\bin\Debug\net9.0\Fucker.exe";

        Process mainProcess = StartMainProcess(mainProcessPath);

        while (true)
        {
            if (mainProcess.HasExited)
            {
                Console.WriteLine("Основной процесс был закрыт.");

                mainProcess = StartMainProcess(mainProcessPath);
            }

            Thread.Sleep(1000);
        }
    }

    static Process StartMainProcess(string path)
    {
        ProcessStartInfo startInfo = new ProcessStartInfo
        {
            FileName = path,
            UseShellExecute = true
        };

        Process process = Process.Start(startInfo);
        Console.WriteLine("Основной процесс запущен.");
        return process;
    }
}