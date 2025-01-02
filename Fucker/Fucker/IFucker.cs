using System.Diagnostics;

namespace Fucker.Fucker;

public interface IFucker
{
    public string? procName { get; set; }
    
    public bool isDebugging { get; set; }
    
    public bool isInfinity { get; set; }
    
    protected List<string>? processes { get; set; }
    
    public void Start();
    protected void Killer(string proc, bool debug, bool isinfinity);
}