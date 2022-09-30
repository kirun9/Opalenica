namespace Pulpit.Logger;

using Microsoft.Extensions.DependencyInjection;

using System.Text;

public class Logger : ILogger
{
    private readonly string fileLocation = "";
    private readonly string logDirectory = "logs";

    public Logger()
    {
        var fileName = DateTime.Now.ToString("yyyy-MM-dd-HH_mm_ss") + ".log";
        fileLocation = Path.Combine(logDirectory, fileName);
        if (!Directory.Exists(logDirectory))
        {
            Directory.CreateDirectory(logDirectory);
        }
        var file = File.Create(fileLocation);
        file.Dispose();
    }

    private static string AppendDateTime(string message)
    {
        StringBuilder builder = new StringBuilder();
        builder.Append('[');
        builder.Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
        builder.Append("] ");
        builder.Append(message);
        return builder.ToString();
    }

    public void Log(string message)
    {
        File.AppendAllText(fileLocation, AppendDateTime(message) + '\n');
    }

    public void Log(object obj)
    {
        string message = obj?.ToString() ?? "<null>";
        Log(message);
    }
}