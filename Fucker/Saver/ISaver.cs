namespace Fucker.Saver;

public interface ISaver
{
    protected int Delay { get; set; }
    protected bool IsDebugging { get; set; }
    protected bool IsInfinity { get; set; }

    protected void Checks();
}