﻿using System.Diagnostics;
using System.Net;

namespace Fucker.Watcher;

class WatcherProcess
{
    static void Main(string[] args)
    {
        string mainProcessPath = @"C:\Users\lvd\RiderProjects\ProcessFucker\Fucker\bin\Debug\net9.0\Fucker.exe";

        bool protectProcess;
        Process mainProcess = StartMainProcess(mainProcessPath);

        Console.WriteLine("Включить слежку за основным процессом? Y/N");
        switch (Console.ReadKey().KeyChar)
        {
            case 'Y': protectProcess = true; break;
            
            case 'y': protectProcess = true; break;
            
            default: protectProcess = false; break;
        }
        if (protectProcess)
        {
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
    }

    static Process StartMainProcess(string path)
    {
        ProcessStartInfo startInfo = new ProcessStartInfo
        {
            FileName = path,
            UseShellExecute = true
        };

        Process? process = Process.Start(startInfo);
        Console.WriteLine("Основной процесс запущен.");
        return process ?? throw new NullReferenceException();
    }
}