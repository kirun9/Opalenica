namespace Opalenica;

using CommandProcessor;

using Opalenica.Interfaces;
using Opalenica.Render;
using Opalenica.Tiles;

using System.Collections.Generic;
using System.Linq;

using Timer = System.Timers.Timer;

public class Signal : Element, IHasOwnData<SignalData>, IHasMenuStrip
{
    private static List<Signal> RegisteredSignals = new List<Signal>();

    private static ChainedCommand chainedCommand;

    public Data Komora1;
    public Data Komora2;
    public Data Komora3;
    public Data Komora4;
    public Data Komora5;

    /*public Data Podstawowy;
    public Data LokalneNastawianie;
    public Data RejonManewrowy;
    public Data ZamknietyIndywidualny;
    public Data UszkodzonaZarowkaCzerwona;
    public Data OchronaBoczna;
    public Data PoczatowyKoncowyPrzebiegu;
    public Data ZezwalajacyManewrowy;
    public Data ZezwalajacyPociagowy;
    public Data SygnalZastepczy;
    public Data BrakDanych;
    public Data ZezwalajacyOstrzegawczy;

    public Track(string name)
    {
        Podstawowy                = new Data();
        LokalneNastawianie        = new Data();
        RejonManewrowy            = new Data();
        ZamknietyIndywidualny     = new Data();
        UszkodzonaZarowkaCzerwona = new Data();
        OchronaBoczna             = new Data();
        PoczatowyKoncowyPrzebiegu = new Data();
        ZezwalajacyManewrowy      = new Data();
        ZezwalajacyPociagowy      = new Data();
        SygnalZastepczy           = new Data();
        BrakDanych                = new Data();
        ZezwalajacyOstrzegawczy   = new Data();

        Komora1 = new Data() { Direction = DataDirection.InputOutput };
        Komora2 = new Data() { Direction = DataDirection.InputOutput };
        Komora3 = new Data() { Direction = DataDirection.InputOutput };
        Komora4 = new Data() { Direction = DataDirection.InputOutput };
        Komora5 = new Data() { Direction = DataDirection.InputOutput };
    }*/

    public Track? Track { get; set; }

    public string Name { get; set; } = "SignalElement";

    private SignalData data = SignalData.Podstawowy;

    public SignalData Data {
        get => data;
        set
        {
            data = value;
        }
    }
    public SignalType Type { get; set; } = SignalType.Pociagowy;
    public TriangleDirection SignalDirection { get; set; } = TriangleDirection.Left;

    private bool Stop = false;

    public Color GetColor(SignalData data, bool pulse = false)
    {
        switch (Type)
        {
            case SignalType.TarczaOstrzegawcza:
            case SignalType.Powtarzajacy:
                return Data switch
                {
                    SignalData.ZezwalajacyOstrzegawczy => Colors.Gray,
                    SignalData.ZezwalajacyPociagowy    => Colors.Green,
                    SignalData.BrakDanych              => Colors.White,
                    _                                  => Colors.White
                };
            default:
            {
                return data switch
                {
                    SignalData.Podstawowy                            => Colors.Gray,
                    SignalData.LokalneNastawianie                    => Colors.Cyan,
                    SignalData.RejonManewrowy                        => Colors.LightCyan,
                    SignalData.ZamknietyIndywidualny                 => Colors.Pink,
                    SignalData.UszkodzonaZarowkaCzerwona when !pulse => Colors.DarkRed,
                    SignalData.UszkodzonaZarowkaCzerwona when pulse  => Colors.Gray,
                    SignalData.OchronaBoczna                         => Colors.DarkRed,
                    SignalData.PoczatowyKoncowyPrzebiegu             => Colors.Red,
                    SignalData.ZezwalajacyManewrowy                  => Colors.Yellow,
                    SignalData.ZezwalajacyPociagowy                  => Colors.Green,
                    SignalData.SygnalZastepczy when pulse            => Colors.White,
                    SignalData.SygnalZastepczy when !pulse           => Colors.Gray,
                    SignalData.BrakDanych                            => Colors.White,
                    _                                                => Colors.White
                };
            }
        }
    }

    public SolidBrush GetBrush(bool pulse)
    {
        return new SolidBrush(GetColor(Data, pulse));
        //return new SolidBrush(SignalPulsingSignal ? pulse ? SignalActualColor : SignalSecondPulsingColor : SignalActualColor);
    }

    public static Signal GetSignal(string name)
    {
        var s = RegisteredSignals.FirstOrDefault(e => e?.Name.ToLower() == name.ToLower(), null);
        if (s is not null)
            return s;
        else
        {
            InfoTile.AddInfo("Semafor " + name + " nie istnieje", MessageSeverity.Warning, "Signal", "Warning", "NotExist");
            return null;
        }
    }

    static Signal()
    {
        chainedCommand = new ChainedCommand("sem", (CommandContext context) =>
        {
            Unselect();
            if (context.Args is null || context.Args.Length != 2) return false;
            string signalId = (context.GetArg<string>(0) ?? "").ToLower();
            var signal = GetSignal(signalId);
            string signalCommand = (context.GetArg<string>(1) ?? "").ToLower();
            return ExecSignalCommand(signal, signalCommand);
        });
        CommandProcessor.RegisterCommand(chainedCommand);
    }

    public static Signal GetSignal(string name, TriangleDirection SignalDirection, Track? track = null, SignalType type = SignalType.Pociagowy)
    {
        var signal = RegisteredSignals.FirstOrDefault(e => e?.Name == name, null);
        if (signal is not null) return signal;

        signal = new Signal();
        signal.Name = name;
        signal.Type = type;
        signal.SignalDirection = SignalDirection;
        signal.Track = track;
        RegisteredSignals.Add(signal);

        ChainedCommand chain = new ChainedCommand("sem" + signal.Name, (context) =>
        {
            Unselect();
            if (context.Args is null || context.Args.Length != 1) return false;
            var signal = GetSignal(context.CommandName.Substring("sem".Length));
            string signalCommand = (context.GetArg<string>(0) ?? "").ToLower();
            return ExecSignalCommand(signal, signalCommand);
        });

        Command command = new Command(signal.Name, (context) =>
        {
            Unselect();
            return SetSZ(context);
        });

        chainedCommand.NextCommand.Add(command);
        chain.NextCommand.Add(command);
        CommandProcessor.RegisterCommand(chain);
        return signal;
    }

    private static bool ExecSignalCommand(Signal signal, string signalCommand)
    {
        if (signal is null) return false;
        switch (signalCommand)
        {
            case "sz":
                signal.Select();
                return true;

            case "nsz":
                signal.Select();
                return true;

            case "ozmk":
                if (signal.Data is SignalData.ZamknietyIndywidualny)
                    signal.Data = SignalData.Podstawowy;
                return CommandProcessor.BreakChainCommand();

            case "zmk":
                signal.Data = SignalData.ZamknietyIndywidualny;
                return CommandProcessor.BreakChainCommand();

            case "osz":
                signal.Data = SignalData.Podstawowy;
                SerialManager.SendCommand("sem " + signal.Name + " osz");
                return CommandProcessor.BreakChainCommand();

            case "stop":
                if (signal.Data is SignalData.ZezwalajacyPociagowy or SignalData.ZezwalajacyManewrowy)
                    signal.Data = SignalData.Podstawowy;
                signal.Stop = true;
                SerialManager.SendCommand("sem " + signal.Name + " osz");
                return CommandProcessor.BreakChainCommand();

            case "ostop":
                signal.Stop = false;
                return CommandProcessor.BreakChainCommand();

            case "stój":
            case "stoj":
                signal.Data = SignalData.Podstawowy;
                SerialManager.SendCommand("sem " + signal.Name + " osz");
                return CommandProcessor.BreakChainCommand();

            case "lok":
                signal.Data = SignalData.LokalneNastawianie;
                return CommandProcessor.BreakChainCommand();
            case "olok":
                if (signal.Data == SignalData.LokalneNastawianie)
                    signal.Data = SignalData.Podstawowy;
                return CommandProcessor.BreakChainCommand();
            case "poc":
            /**
                * TODO:
                * Utwierdzenie przebiegu :)
                */
            case "man":
            /**
                * TODO:
                * Utwierdzenie przebiegu :)
                */

            default:
                return CommandProcessor.BreakChainCommand();
        }
    }

    private static bool SetSZ(CommandContext context)
    {
        if (context is not null and ChainedCommandContext ccc && ccc.Args.Length == 0)
        {
            var signal = RegisteredSignals.FirstOrDefault(e => e.Name == ccc.CommandName);
            if (signal is null) return false;
            if (ccc.PrevArgs is not null && ccc.PrevArgs.Length == 1)
            {
                var s = ccc.GetPrevArg<string>(0);
                switch (s)
                {
                    case "sz":
                        signal.Data = SignalData.SygnalZastepczy;
                        SerialManager.SendCommand("sem " + signal.Name + " sz");
                        signal.WaitAndSendOSZCommand();
                        return true;
                    case "nsz":
                        signal.Data = SignalData.Podstawowy;
                        return true;
                }
            }
            else if (ccc.PrevArgs is not null && ccc.PrevArgs.Length == 2)
            {
                var s = ccc.GetPrevArg<string>(1);
                switch (s)
                {
                    case "sz":
                        signal.Data = SignalData.SygnalZastepczy;
                        SerialManager.SendCommand("sem " + signal.Name + " sz");
                        signal.WaitAndSendOSZCommand();
                        return true;
                    case "nsz":
                        signal.Data = SignalData.Podstawowy;
                        return true;
                }
            }
        }
        return false;
    }

    private void WaitAndSendOSZCommand()
    {
        Timer timer = new Timer(10000);
        timer.AutoReset = false;
        timer.Elapsed += (s, e) =>
        {
            ExecSignalCommand(this, "osz");
            timer.Dispose();
        };
        timer.Start();
    }

    public ContextMenuStrip GetMenuStrip()
    {
        ContextMenuStrip strip = new ContextMenuStrip();

        ToolStripMenuItem title = new ToolStripMenuItem($"Semafor {Name}");
        title.Enabled = false;
        strip.Items.Add(title);

        if (Track is not null)
        {
            ToolStripMenuItem trackItem = new ToolStripMenuItem($"Tor {Track.Name}");
            trackItem.DropDownItems.AddRange(Track.GetMenuStrip().Items);
            strip.Items.Add(trackItem);
        }
        var zamkniety = Data is SignalData.ZamknietyIndywidualny;
        ToolStripMenuItem zmk = new ToolStripMenuItem(zamkniety ? "Odwołaj Zamknięcie (ozmk)" : "Zamknij (zmk)");
        zmk.Click += (_, _) => CommandProcessor.ExecuteCommand($"sem {Name} {(zamkniety ? "ozmk" : "zmk")}");
        ToolStripMenuItem stoj = new ToolStripMenuItem("Stój");
        stoj.Click += (_, _) => CommandProcessor.ExecuteCommand($"sem {Name} stoj");
        ToolStripMenuItem sz = new ToolStripMenuItem("Zastępczy");
        sz.Click += (_, _) =>
        {
            if (IsSelected)
                CommandProcessor.ExecuteCommand(Name);
            else
                CommandProcessor.ExecuteCommand($"sem {Name} sz");
        };
        strip.Items.Add(zmk);
        strip.Items.Add(stoj);
        strip.Items.Add(sz);
        return strip;
    }
}