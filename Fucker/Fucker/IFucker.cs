using System.Diagnostics;

namespace Fucker.Fucker;

public interface IFucker
{
    protected string? procName { get; set; }
    
    protected bool isDebugging { get; set; }
    
    protected bool isInfinity { get; set; }

    protected int Delay { get; set; }
    
    protected List<string>? processes { get; set; }
    
    public void Start();
    protected void Killer(string proc, bool debug, bool isinfinity);
}