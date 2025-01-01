namespace Fucker.Fucker;

public interface IFucker
{
    public string? procName { get; set; }
    
    public bool isDebugging { get; set; }
    
    public bool isInfinity { get; set; }
    
    public void Start();
    public void Killer(string proc, bool debug, bool isinfinity);
}