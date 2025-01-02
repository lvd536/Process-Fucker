namespace Fucker.Fucker;

public interface IFucker
{
    protected string? procName { get; set; }
    
    protected static int delay { get; set; }
    protected static bool isDebugging { get; set; }
    protected static bool isInfinity { get; set; }
    
    protected List<string>? processes { get; set; }
    
    public void Start();
    protected void Killer(string proc, bool debug, bool isinfinity, int delay);
}