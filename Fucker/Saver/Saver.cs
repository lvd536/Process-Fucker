using Newtonsoft.Json;

namespace Fucker.Saver;

public class Saver : ISaver
{
    public int Delay { get; set; }
    public bool IsDebugging { get; set; }
    public bool IsInfinity { get; set; }

    public void Checks()
    {
        string Patch = Path.GetTempPath() + "settings.json";
        Console.WriteLine(Patch);
        if (!File.Exists(Patch))
        {
            Console.Write("Показывать сводку об убитых процессах? Y/N");
            switch (Console.ReadKey().KeyChar)
            {
                case 'Y': IsDebugging = true; break;

                case 'y': IsDebugging = true; break;

                default: IsDebugging = false; break;
            }

            Console.Write("\nСделать процесс автономным? Y/N");
            switch (Console.ReadKey().KeyChar)
            {
                case 'Y': IsInfinity = true; break;

                case 'y': IsInfinity = true; break;

                default: IsInfinity = false; break;
            }

            Console.Write("\nНапишите задержку между снятиями процессов в миллисекундах: ");
            try
            {
                Delay = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Delay = 1500;
                Console.WriteLine($"Значение введено неверно. Установили базовое значение в {Delay} миллисекунд");
            }
            Saver s = new Saver
            {
                Delay = this.Delay,
                IsDebugging = this.IsDebugging,
                IsInfinity = this.IsInfinity
            };
            string json = JsonConvert.SerializeObject(s);
            File.WriteAllText(Patch, json);
            Console.WriteLine(json);
        }
        else
        {
            Saver decomp = JsonConvert.DeserializeObject<Saver>(File.ReadAllText(Patch)) ?? new Saver();
            this.IsDebugging = decomp.IsDebugging;
            this.IsInfinity = decomp.IsInfinity;
            this.Delay = decomp.Delay;
        }
    }
    public Saver() { }

    public Saver(int delay, bool isDebugging, bool isInfinity)
    {
        Checks();
        delay = this.Delay;
        isDebugging = this.IsDebugging;
        isInfinity = this.IsInfinity;
    }
}