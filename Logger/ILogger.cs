namespace Pulpit.Logger;

public interface ILogger
{
    public void Log(string message);
    public void Log(object obj);
}
