namespace CommandProcessor;

using System.Diagnostics;

[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public class ChainedCommand : Command
{
    public Command? NextCommand { get; set; } = null;
    public ChainedCommand(String name, Func<String[], Boolean> function) : base(name, function)
    {
    }

    public ChainedCommand(string name, Func<CommandContext, bool> function) : base(name, function)
    {
    }

    public ChainedCommand(string name) : base(name, (string[] e) => false)
    {
    }

    public ChainedCommand(string name, Func<bool> function) : base(name, function)
    {
    }

    private string GetDebuggerDisplay()
    {
        return NextCommand is not null ? "Chained: " + Name + " -> " + NextCommand.GetDebuggerDisplay() : "Chained: " + Name;
    }
}