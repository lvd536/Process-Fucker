﻿using System.Diagnostics;

namespace Fucker.Fucker;

public class Fucker : IFucker
{
    public string? procName { get; set; }
    
    public void Start()
    {
        Console.Title = "Fucker | by lvd.";
        Console.WriteLine("Добро пожаловать в Process Fucker!");
        Console.Write("Выберите название процесса, который будем убивать: ");
        
        procName = Console.ReadLine();

        Killer(procName, true, true);
    }

    public void Killer(string proc, bool debug, bool isinfinity)
    {
        if (isinfinity)
        {
            while (true)
            {
                Process[] processes = Process.GetProcessesByName(proc);
                foreach (Process p in processes)
                {
                    try
                    {
                        p.Kill();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }

                    if (debug)
                    {
                        Console.WriteLine($"Найден подходящий процесс: {p.ProcessName}. ID Процесса: {p.Id} | Процесс успешно устранен!");
                    }
                }
                Thread.Sleep(3000);
            }
        }
        else
        {
            Process[] processes = Process.GetProcessesByName(proc);
            foreach (Process p in processes)
            {
                try
                {
                    p.Kill();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

                if (debug)
                {
                    Console.WriteLine($"Найден подходящий процесс: {p.ProcessName}. ID Процесса: {p.Id}");
                    Console.WriteLine("Процесс успешно устранен!");
                }
            }
        }
    }
}