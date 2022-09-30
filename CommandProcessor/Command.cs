namespace CommandProcessor;

using System.Diagnostics;

[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public class Command
{
    public static readonly Command Empty = new Command("", (string[] _) => { return false; }) { IsEmpty = true };

    public bool IsEmpty { get; private set; } = false;

    public string Name { get; private set; }
    public Func<string[], bool>? Function { get; private set; }
    public Func<CommandContext, bool>? Function2 { get; private set; }

    public Command(string name, Func<string[], bool>? function)
    {
        Name = name;
        Function = function;
    }

    public Command(string name, Func<CommandContext, bool>? function)
    {
        Name = name;
        Function2 = function;
    }

    public Command(string name, Func<bool> function)
    {
        Name = name;
        Function = (string[] _) => { return function(); };
    }

    internal string GetDebuggerDisplay()
    {
        return "Command: " + Name;
    }
}