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

    [Obsolete("Use GetPrevArg<T> instead")]
    public T? GetPrevArgAs<T>(int argPos)
    {
        return argPos < PrevArgs.Length ? (T?)PrevArgs[argPos] : default;
    }

    public CastResult<T> GetPrevArg<T>(int argPos)
    {
        if (PrevArgs.Length > argPos)
        {
            var prevArg = PrevArgs[argPos];
            return prevArg switch
            {
                var _ when prevArg is IConvertible c => new CastResult<T>((T)c.ToType(typeof(T), null), true),
                var _ when prevArg is T castedArg => new CastResult<T>(castedArg, true),
                _ => new CastResult<T>(default, false)
            };
        }
        else
        {
            return new CastResult<T>(default, false);
        }
    }
}