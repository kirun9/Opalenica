namespace CommandProcessor;

public class CommandResult
{
    public static readonly CommandResult Empty = new CommandResult() { IsEmpty = true };

    public bool IsEmpty { get; private set; } = false;

    public bool Found { get; internal set; } = false;
    public bool IsSucess { get; internal set; } = false;
    public Command Command { get; internal set; } = Command.Empty;
    internal CommandResult() { }
}
