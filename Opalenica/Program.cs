namespace Opalenica;

using System.Globalization;

using CommandProcessor;

/**
 * Potrzeba 158 wyjœæ
 * Mamy 96
 *
 * Potrzeba 55 wejœæ (ewentualnie 21)
 * Mamy 48
 */



internal static class Program
{
    public static bool DebugMode { get; set; } = false;
    public static int CommandHistoryLength = 100;
    private static OpalenicaForm form;
    internal static string startupCommands = "";

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main(string[] args)
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        var c = new CultureInfo(Opalenica.Settings.Default.Language);
        Language.InitializeLanguage(c);

        CommandProcessor.RegisterCommands(typeof(Program).Assembly);

        startupCommands = string.Join(" ", args);

        Func<bool> closeAppFunc = () =>
        {
            Application.Exit();
            Environment.Exit(0);
            return CommandProcessor.BreakChainCommand();
        };

        Func<bool> exitFunc = () =>
        {
            if (DebugMode)
            {
                closeAppFunc.Invoke();
            }
            return true;
        };

        ChainedCommand koniecCommand = new ChainedCommand("koniec", exitFunc);
        koniecCommand.NextCommand = new Command("koniec", closeAppFunc);

        ChainedCommand exitCommand = new ChainedCommand("exit", exitFunc);
        exitCommand.NextCommand = new Command("exit", closeAppFunc);

        CommandProcessor.RegisterCommand(koniecCommand);
        CommandProcessor.RegisterCommand(exitCommand);

        ApplicationConfiguration.Initialize();
        Application.Run(form = new OpalenicaForm());
    }

    [RegisterCommand("debugmode", false)]
    public static bool DebugModeCommand(string[] args)
    {
        if (args.Length == 0)
        {
            Program.DebugMode = !Program.DebugMode;
            return true;
        }
        else
        {
            if (Boolean.TryParse(args[0], out bool value))
            {
                Program.DebugMode = value;
                return true;
            }
        }
        return false;
    }

    [RegisterCommand("fs", false)]
    [RegisterCommand("fullscreen", false)]
    public static bool Fullscreen(string[] args)
    {
        if (!Program.DebugMode) return true;
        if (args.Length == 0)
        {
            form.WindowState = form.WindowState == FormWindowState.Normal ? FormWindowState.Maximized : FormWindowState.Normal;
            return true;
        }
        else
        {
            if (Boolean.TryParse(args[0], out bool value))
            {
                form.WindowState = value ? FormWindowState.Maximized : FormWindowState.Normal;
                return true;
            }
        }
        return false;
    }
}