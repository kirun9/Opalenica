namespace Opalenica;

using CommandProcessor;
using System.Collections.Generic;
using System.Linq;

public class Signal
{
    private static List<Signal> RegisteredSignals = new List<Signal>();

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

    public Track Track { get; set; }

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

    public Color SignalSecondPulsingColor
    {
        get
        {
            return Colors.Gray;
        }
    }

    public bool SignalPulsingSignal
    {
        get
        {
            return Data switch
            {
                SignalData.UszkodzonaZarowkaCzerwona => true,
                SignalData.SygnalZastepczy => true,
                _ => false
            };
        }
    }

    public Color SignalActualColor
    {
        get
        {
            switch (Type)
            {
                case SignalType.TarczaOstrzegawcza:
                case SignalType.Powtarzajacy:
                    return Data switch
                    {
                        SignalData.ZezwalajacyOstrzegawczy => Colors.Gray,
                        SignalData.ZezwalajacyPociagowy => Colors.Green,
                        SignalData.BrakDanych => Colors.White,
                        _ => Colors.White
                    };
                default:
                {
                    return Data switch
                    {
                        SignalData.Podstawowy => Colors.Gray,
                        SignalData.LokalneNastawianie => Colors.Cyan,
                        SignalData.RejonManewrowy => Colors.LightCyan,
                        SignalData.ZamknietyIndywidualny => Colors.Pink,
                        SignalData.UszkodzonaZarowkaCzerwona => Colors.DarkRed, //Miganie
                        SignalData.OchronaBoczna => Colors.DarkRed,
                        SignalData.PoczatowyKoncowyPrzebiegu => Colors.Red,
                        SignalData.ZezwalajacyManewrowy => Colors.Yellow,
                        SignalData.ZezwalajacyPociagowy => Colors.Green,
                        SignalData.SygnalZastepczy => Colors.White, //Miganie
                        SignalData.BrakDanych => Colors.White,
                        _ => Colors.White
                    };
                }
            }
        }
    }

    public SolidBrush GetBrush(bool pulse)
    {
        return new SolidBrush(SignalPulsingSignal ? pulse ? SignalActualColor : SignalSecondPulsingColor : SignalActualColor);
    }

    public static Signal GetSignal(string name, TriangleDirection SignalDirection, Track track = null, SignalType type = SignalType.Pociagowy)
    {
        var signal = RegisteredSignals.FirstOrDefault(e => e?.Name == name, null);
        if (signal is not null) return signal;

        signal = new Signal();
        signal.Name = name;
        signal.Type = type;
        signal.SignalDirection = SignalDirection;
        signal.Track = track;
        RegisteredSignals.Add(signal);

        ChainedCommand chain = new ChainedCommand(signal.Name, (CommandContext context) =>
        {
            if (context.Args is null || context.Args.Length != 1) return false;
            string signalCommand = (context.GetArgAs<string>(0) ?? "").ToLower();
            switch(signalCommand)
            {
                case "sz":
                    break;

                case "nsz":
                    break;

                case "ozmk":
                    if (signal.Data is SignalData.ZamknietyIndywidualny)
                        signal.Data = SignalData.Podstawowy;
                    return CommandProcessor.BreakChainCommand();

                case "zmk":
                    signal.Data = SignalData.ZamknietyIndywidualny;
                    return CommandProcessor.BreakChainCommand();

                case "osz":
                    signal.Data = SignalData.Podstawowy;
                    return CommandProcessor.BreakChainCommand();

                case "stop":
                    if (signal.Data is SignalData.ZezwalajacyPociagowy or SignalData.ZezwalajacyManewrowy)
                        signal.Data = SignalData.Podstawowy;
                    signal.Stop = true;
                    return CommandProcessor.BreakChainCommand();

                case "ostop":
                    signal.Stop = false;
                    return CommandProcessor.BreakChainCommand();

                case "stój":
                case "stoj":
                    signal.Data = SignalData.Podstawowy;
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
            return true;
        });

        Command command = new Command(signal.Name, (context) => {
            return SetSZ(context);
        });
        chain.NextCommand = command;
        CommandProcessor.RegisterCommand(chain);
        return signal;
    }

    private static bool SetSZ(CommandContext context)
    {
        if (context is not null and ChainedCommandContext ccc && ccc.Args.Length == 0)
        {
            var signal = RegisteredSignals.FirstOrDefault(e => e.Name == ccc.CommandName);
            if (signal is null) return false;
            if (ccc.PrevArgs is not null && ccc.PrevArgs.Length == 1)
            {
                var s = ccc.GetPrevArgAs<string>(0);
                switch (s)
                {
                    case "sz":
                        signal.Data = SignalData.SygnalZastepczy;
                        return true;
                    case "nsz":
                        signal.Data = SignalData.SygnalZastepczy;
                        return true;
                }
            }
        }
        return false;
    }
}

public enum SignalAspect
{
    Sr1,
    Sr2,
    Sr3,
    S1,
    S2,
    S3,
    S4,
    S5,
    S6,
    S7,
    S8,
    S9,
    S10,
    S10a,
    S11,
    S11a,
    S12,
    S12A,
    S13,
    S13a,
    Sz,
    Sp1,
    Sp2,
    Sp3,
    Sp4,
    Od1,
    Od2,
    Ot1,
    Ot2,
    Ot3,
    Os1,
    Os2,
    Os3,
    Os4,
    Osp1,
    Osp2,
    M1,
    M2,
    Ms1,
    Ms2,
    Rt1,
    Rt2,
    Rt3,
    Rt4,
    Rt5,
    S1a,
}

public enum SignalType
{
    Pociagowy,
    PociagowyManewrowy,
    Manewrowy,
    Czerwony,
    CzerwonyManewrowy,
    PociagowyPrzebiegowy,
    TarczaOstrzegawcza,
    Powtarzajacy
}

public enum SignalData
{
    Podstawowy                = 0,
    LokalneNastawianie        = 1,
    RejonManewrowy            = 2,
    ZamknietyIndywidualny     = 3,
    UszkodzonaZarowkaCzerwona = 4,
    OchronaBoczna             = 5,
    PoczatowyKoncowyPrzebiegu = 6,
    ZezwalajacyManewrowy      = 7,
    ZezwalajacyPociagowy      = 8,
    SygnalZastepczy           = 9,
    BrakDanych                = 10,
    ZezwalajacyOstrzegawczy   = 7
}