using System.Diagnostics;

namespace Fucker.Fucker;

public class Fucker : IFucker
{
    public string? procName { get; set; }
    public static int delay { get; set; }
    public static bool isDebugging { get; set; }
    public static bool isInfinity { get; set; }

    public List<string>? processes { get; set; }
    public void Start()
    {
        Console.Title = "Fucker | by lvd.";
        Console.WriteLine("Добро пожаловать в Process Fucker!");
        Saver.Saver JSON = new Saver.Saver(delay, isInfinity, isDebugging);
        Console.Write("\nНапишите процесс или список процессов через запятую, которые будем убивать: ");
        procName = Console.ReadLine() ?? "";

        processes = new List<string>();
        string[] procList = procName.Split(',');
        if (procList.Length > 1)
        {
            for (int i = 0; i < procList.Length; i++)
            {
                processes.Add(procList[i]);
            }

            Console.WriteLine("Вы выбрали несколько процессов. Начинаем работу");
            Killer(processes, JSON.IsDebugging, JSON.IsInfinity, JSON.Delay);
        }
        else
        {
            Console.WriteLine("Вы выбрали 1 процесс. Начинаем работу");
            Killer(procName, JSON.IsDebugging, JSON.IsInfinity, JSON.Delay);
        }
    }

    public void Killer(string proc, bool debug, bool isinfinity, int delay)
    {
        if (isinfinity)
        {
            while (true)
            {
                Process cur = Process.GetCurrentProcess();
                Console.Title = $"Memory usage: {cur.WorkingSet64 / 1024.0 / 1024.0}MB | Launch: {cur.StartTime}";
                Process[] processes = Process.GetProcessesByName(proc);
                foreach (Process p in processes)
                {
                    p.Kill();

                    if (debug)
                    {
                        Console.WriteLine($"Найден подходящий процесс: {p.ProcessName}. ID Процесса: {p.Id} | Процесс успешно устранен!");
                    }
                }
                if (cur.WorkingSet64 / 1024.0 / 1024.00 >= 350)
                {
                    Console.WriteLine("Collecting Memory");
                    GC.Collect();
                    Console.WriteLine("Waiting clear Memory");
                    GC.WaitForPendingFinalizers();
                    Console.WriteLine("Last Checks");
                    GC.Collect();
                }
                Thread.Sleep(delay);
            }
        }
        else
        {
            Process[] processes = Process.GetProcessesByName(proc);
            foreach (Process p in processes)
            {
                p.Kill();

                if (debug)
                {
                    Console.WriteLine($"Найден подходящий процесс: {p.ProcessName}. ID Процесса: {p.Id}");
                    Console.WriteLine("Процесс успешно устранен!");
                }
            }
        }
    }

    public void Killer(List<string> proc, bool debug, bool isinfinity, int delay)
    {
        if (isinfinity)
        {
            while (true)
            {
                Process cur = Process.GetCurrentProcess();
                Console.Title = $"Memory usage: {cur.WorkingSet64 / 1024.0 / 1024.0}MB | Launch: {cur.StartTime}";
                for (int i = 0; i < proc.Count; i++)
                {
                    Process[] processes = Process.GetProcessesByName(proc[i]);
                    foreach (Process p in processes)
                    {
                        p.Kill();
                        
                        if (debug)
                        {
                            Console.WriteLine($"Найден подходящий процесс: {p.ProcessName}. ID Процесса: {p.Id} | Процесс успешно устранен!");
                        }
                    }
                }

                if (cur.WorkingSet64 / 1024.0 / 1024.00 >= 350)
                {
                    Console.WriteLine("Collecting Memory");
                    GC.Collect();
                    Console.WriteLine("Waiting clear Memory");
                    GC.WaitForPendingFinalizers();
                    Console.WriteLine("Last Checks");
                    GC.Collect();
                }
                Thread.Sleep(delay);
            }
        }
        else
        {
            for (int i = 0; i < proc.Count; i++)
            {
                Process[] processes = Process.GetProcessesByName(proc[i]);
                foreach (Process p in processes)
                {
                    p.Kill();

                    if (debug)
                    {
                        Console.WriteLine($"Найден подходящий процесс: {p.ProcessName}. ID Процесса: {p.Id} | Процесс успешно устранен!");
                    }
                }
            }
        }
    }
}