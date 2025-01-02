using System.Diagnostics;

namespace Fucker.Fucker;

public class Fucker : IFucker
{
    public string? procName { get; set; }
    public bool isDebugging { get; set; }
    public bool isInfinity { get; set; }

    public List<string>? processes { get; set; }

    public void Start()
    {
        Console.Title = "Fucker | by lvd.";
        Console.WriteLine("Добро пожаловать в Process Fucker!");

        Console.Write("Показывать сводку об убитых процессах? Y/N");
        switch (Console.ReadKey().KeyChar)
        {
            case 'Y': isDebugging = true; break;
            
            case 'y': isDebugging = true; break;
            
            default: isDebugging = false; break;
        }
        
        Console.Write("\nСделать процесс автономным? Y/N");
        switch (Console.ReadKey().KeyChar)
        {
            case 'Y': isInfinity = true; break;
            
            case 'y': isInfinity = true; break;
            
            default: isInfinity = false; break;
        }

        Console.Write("\nНапишите процесс или список процессов через запятую, которые будем убивать: ");
        procName = Console.ReadLine(); // Получаем строку процессов пользователя

        processes = new List<string>(); // Выделяем память
        string[] procList = procName.Split(','); // Пробуем разделить строку на процессы, если их несколько
        if (procList.Length > 1) // Если список выполняем перегрузку
        {
            for (int i = 0; i < procList.Length; i++)
            {
                processes.Add(procList[i]);
            }

            Console.WriteLine("Вы выбрали несколько процессов. Начинаем работу");
            Killer(processes, isDebugging, isInfinity);
        }
        else // Если процесс 1 выполняем другое условие
        {
            Console.WriteLine("Вы выбрали 1 процесс. Начинаем работу");
            Killer(procName, isDebugging, isInfinity);
        }
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
                        Console.WriteLine(
                            $"Найден подходящий процесс: {p.ProcessName}. ID Процесса: {p.Id} | Процесс успешно устранен!");
                    }
                }

                Thread.Sleep(1500);
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

    public void Killer(List<string> proc, bool debug, bool isinfinity)
    {
        if (isinfinity)
        {
            while (true)
            {
                for (int i = 0; i < proc.Count; i++)
                {
                    Process[] processes = Process.GetProcessesByName(proc[i]);
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
                            Console.WriteLine(
                                $"Найден подходящий процесс: {p.ProcessName}. ID Процесса: {p.Id} | Процесс успешно устранен!");
                        }
                    }
                }

                Thread.Sleep(1500);
            }
        }
        else
        {
            for (int i = 0; i < proc.Count; i++)
            {
                Process[] processes = Process.GetProcessesByName(proc[i]);
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
                        Console.WriteLine(
                            $"Найден подходящий процесс: {p.ProcessName}. ID Процесса: {p.Id} | Процесс успешно устранен!");
                    }
                }
            }
        }
    }
}