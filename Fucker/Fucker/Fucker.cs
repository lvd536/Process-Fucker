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
        if (Console.ReadKey().KeyChar == 'y' || Console.ReadKey().KeyChar == 'Y')
        {
            isDebugging = true;
        }
        else{ isDebugging = false; }
        
        Console.Write("\nСделать процесс автономным? Y/N");
        if (Console.ReadKey().KeyChar == 'y' || Console.ReadKey().KeyChar == 'Y')
        {
            isInfinity = true;
        }
        else{ isInfinity = false; }
        
        Console.Write("\nНапишите список процессов через запятую, которые будем убивать: ");
        procName = Console.ReadLine();
        
        processes = new List<string>();
        try
        {
            string[] procList = procName.Split(',');

            for (int i = 0; i < procList.Length; i++)
            {
                processes.Add(procList[i]);
            }
            
            Killer(processes, isDebugging, isInfinity);
        }
        finally
        {
            
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
                        Console.WriteLine($"Найден подходящий процесс: {p.ProcessName}. ID Процесса: {p.Id} | Процесс успешно устранен!");
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
                            Console.WriteLine($"Найден подходящий процесс: {p.ProcessName}. ID Процесса: {p.Id} | Процесс успешно устранен!");
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