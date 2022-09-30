namespace CommandProcessor;

public class CommandContext
{
    public string CommandName { get; private set; }
    public object[] Args { get; private set; }

    internal CommandContext(string name, object[] args)
    {
        CommandName = name;
        Args = args;
    }
    public T? GetArgAs<T>(int argPos)
    {
        return Args.Length > argPos ? (T?)Args[argPos] : default;
    }
}