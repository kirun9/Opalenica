namespace CommandProcessor;

using System.Reflection;

public class CommandProcessor
{
    public static bool IGNORE_CASE = true;
    public static bool JOINED_COMMANDS = true;
    public static List<Command> Commands { get; private set; } = new List<Command>();
    public static Command? prevCommand;
    public static CommandContext? prevCommandContext;

    public static bool BreakChainCommand()
    {
        prevCommand = null;
        prevCommandContext = null;
        return true;
    }

    public static bool ExecuteCommand(string command)
    {
        if (command.Equals(string.Empty) || command.Equals("")) return false;
        if (IGNORE_CASE)
            command = command.ToLower();
        string[] commands;
        if (JOINED_COMMANDS)
            commands = command.Split('|', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
        else
            commands = new[] { command };
        bool result = true;
        foreach (var comm in commands)
        {
            string commandName = comm.Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).First();
            string[] commandArgs = comm.Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).Skip(1).ToArray();
            if (prevCommand is not null and ChainedCommand chained)
            {
                if (chained.NextCommand is not null && (chained.NextCommand.Name.Equals(commandName) || chained.NextCommand.Name.ToLower().Equals(commandName.ToLower()) && IGNORE_CASE ))
                {
                    prevCommand = chained.NextCommand;
                    ChainedCommandContext context = new ChainedCommandContext(chained.NextCommand.Name, commandArgs, prevCommandContext);
                    prevCommandContext = context;
                    if (chained.NextCommand.Function is not null)
                        result = chained.NextCommand.Function.Invoke(commandArgs) && result;
                    else if (chained.NextCommand.Function2 is not null)
                        result = chained.NextCommand.Function2.Invoke(context) && result;
                    else
                        result = false;
                    continue;
                }
                else
                {
                    prevCommand = null;
                    prevCommandContext = null;
                }
            }
            foreach (var c in Commands)
            {
                if (c.Name.Equals(commandName) || (c.Name.ToLower().Equals(commandName.ToLower()) && IGNORE_CASE))
                {
                    CommandContext context = new CommandContext(c.Name, commandArgs);
                    if (c is ChainedCommand chainedCommand)
                    {
                        prevCommand = c;
                        prevCommandContext = context;
                    }
                    if (c.Function is not null)
                        result = c.Function.Invoke(commandArgs) && result;
                    else if (c.Function2 is not null)
                        result = c.Function2.Invoke(context) && result;
                    else
                        result = false;
                    break;
                }
            }
        }
        return result;
    }

    public static void RegisterCommands(Assembly assembly)
    {
        foreach (var type in assembly.GetTypes())
        {
            foreach (var method in type.GetMethods())
            {
                var attributes = method.GetCustomAttributes(typeof(RegisterCommandAttribute), false);
                foreach (var attribute in attributes)
                {
                    if (attribute is RegisterCommandAttribute rca)
                    {
                        var function = ParseFunction(method);
                        var function2 = ParseContextFunction(method);
                        Command command = function is not null ? new Command(rca.Name, function) : new Command(rca.Name, function2);
                        if (rca.NeedConfirm)
                        {
                            ChainedCommand chainedCommand = new ChainedCommand(rca.Name, (string[] _) => true);
                            chainedCommand.NextCommand = command;
                            RegisterCommand(chainedCommand);
                        }
                        else
                        {
                            RegisterCommand(command);
                        }
                    }
                }
            }
        }
    }

    private static Func<CommandContext, bool>? ParseContextFunction(MethodInfo methodInfo)
    {
        if (methodInfo.IsStatic && !methodInfo.IsConstructor && methodInfo.ReturnType == typeof(bool))
        {
            var parameters = methodInfo.GetParameters();
            if (parameters.Length == 1 && parameters[0].ParameterType == typeof(CommandContext))
                return (Func<CommandContext, bool>)Delegate.CreateDelegate(typeof(Func<CommandContext, bool>), methodInfo);
        }
        return null;
    }

    private static Func<string[], bool>? ParseFunction(MethodInfo methodInfo)
    {
        if (methodInfo.IsStatic && !methodInfo.IsConstructor)
        {
            if (methodInfo.ReturnType == typeof(bool))
            {
                var parameters = methodInfo.GetParameters();
                if (parameters.Length == 1 && parameters[0].ParameterType == typeof(string[]))
                {
                    return (Func<string[], bool>)Delegate.CreateDelegate(typeof(Func<string[], bool>), methodInfo);
                }
                else if (parameters.Length == 0)
                {
                    return _ =>
                    {
                        return ((Func<bool>)Delegate.CreateDelegate(typeof(Func<bool>), methodInfo)).Invoke();
                    };
                }
            }
        }
        return null;
    }

    public static void RegisterCommand(Command command)
    {
        Commands.Add(command);
    }
}