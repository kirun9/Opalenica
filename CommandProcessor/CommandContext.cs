namespace CommandProcessor;

using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

public class CommandContext
{
    public string CommandName { get; private set; }
    public object[] Args { get; private set; }

    internal CommandContext(string name, object[] args)
    {
        CommandName = name;
        Args = args;
    }

    [Obsolete("Use GetArg<T> instead")]
    public T? GetArgAs<T>(int argPos)
    {
        return Args.Length > argPos ? (T?)Args[argPos] : default;
    }

    public CastResult<T> GetArg<T>(int argPos)
    {
        if (Args.Length > argPos)
        {
            var arg = Args[argPos];
            return arg switch
            {
                var _ when arg is IConvertible c => new CastResult<T>((T)c.ToType(typeof(T), null), true),
                var _ when arg is T castedArg => new CastResult<T>(castedArg, true),
                _ => new CastResult<T>(default, false)
            };
        }
        else
        {
            return new CastResult<T>(default, false);
        }
    }
}