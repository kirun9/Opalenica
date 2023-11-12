namespace CommandProcessor;

using System.Diagnostics;

[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public class ChainedCommand : Command
{
    public List<Command> NextCommand { get; set; } = new List<Command>();

    public ChainedCommand(string name, Func<String[], Boolean> function) : base(name, function)
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

    private new string GetDebuggerDisplay()
    {
        return NextCommand is not null ? "Chained: " + Name + " -> " + (NextCommand.Count > 1 ? "[]" : NextCommand[0].GetDebuggerDisplay()) : "Chained: " + Name;
    }
}