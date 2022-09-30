namespace CommandProcessor;

using System.Dynamic;

public class ChainedCommandContext : CommandContext
{
    public string? PrevName => PrevCommand?.CommandName;
    public object[] PrevArgs => PrevCommand?.Args ?? new object[0];
    public CommandContext? PrevCommand { get; private set; }

    [Obsolete("", true)]
    internal ChainedCommandContext(string name, object[] args) : base(name, args)
    {
        PrevCommand = new CommandContext(String.Empty, new object[0]);
    }

    internal ChainedCommandContext(string name, object[] args, CommandContext? prevContext) : base(name, args)
    {
        PrevCommand = prevContext;
    }

    public T? GetPrevArgAs<T>(int argPos)
    {
        return argPos < PrevArgs.Length ? (T?)PrevArgs[argPos] : default;
    }
}