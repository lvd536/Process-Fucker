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

                Process killerProcess = FindProcessThatKilled(mainProcess.Id);

                if (killerProcess != null)
                {
                    Console.WriteLine($"Процесс {killerProcess.ProcessName} (ID: {killerProcess.Id}) закрыл основной процесс.");
                    killerProcess.Kill();
                    Console.WriteLine($"Процесс {killerProcess.ProcessName} был закрыт.");
                }

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

    static Process FindProcessThatKilled(int mainProcessId)
    {
        var query = $"SELECT * FROM Win32_Process WHERE ProcessId = {mainProcessId}";
        var searcher = new System.Management.ManagementObjectSearcher(query);

        foreach (var item in searcher.Get())
        {
            var parentProcessId = Convert.ToInt32(item["ParentProcessId"]);
            var parentProcess = Process.GetProcessById(parentProcessId);

            if (parentProcess != null)
            {
                return parentProcess;
            }
        }

        return null;
    }
}