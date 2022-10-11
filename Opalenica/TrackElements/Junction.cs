namespace Opalenica;

using CommandProcessor;
using Opalenica.Tiles;
using System.Drawing;
using System.Drawing.Drawing2D;

public class Junction : Element
{
    internal static List<Junction> RegisteredJunctions = new List<Junction>();
    private JunctionSet direction = JunctionSet.AB;
    public string Name { get; set; } = "JunctionElement";

    public Track A { get; set; }
    public Track B { get; set; }
    public Track C { get; set; }

    public JunctionDataZ Data { get; set; } = JunctionDataZ.BrakDanych;

    public JunctionSet MainDirection = JunctionSet.AB;

    public JunctionSet Direction
    {
        get
        {
            return direction;
        }
        set
        {
            if (value is JunctionSet.AB or JunctionSet.AC)
                direction = value;
            else
                throw new ArgumentException("SingleJunction cannot contain \"D\" direction");
        }
    }

    public JunctionDirection DrawDirection { get; internal set; }

    public Color SecondPulsingColor
    {
        get
        {
            return Colors.Gray;
        }
    }

    public bool PulsingSignal
    {
        get
        {
            return Data switch
            {
                JunctionDataZ.Rozprucie => true,
                JunctionDataZ.NieoczekiwanyBrakKontroli => true,
                _ => false
            };
        }
    }

    public Color ActualColor
    {
        get
        {
            return Data switch
            {
                JunctionDataZ.BrakDanych => Colors.White,
                JunctionDataZ.Rozprucie => Colors.Red,   // Migający
                JunctionDataZ.NieoczekiwanyBrakKontroli => Colors.White, // Migający
                JunctionDataZ.BrakKontroli => Colors.Black, // (Niewidoczny)
                JunctionDataZ.Zajety => Colors.Red,
                JunctionDataZ.ZwalnianyCzasowo => Colors.Pink,
                JunctionDataZ.PrzebiegPociagowy => Colors.Green,
                JunctionDataZ.PrzebiegManewrowy => Colors.Yellow,
                JunctionDataZ.OchronaPrzebiegu => Colors.Yellow,
                JunctionDataZ.OchronaBoczna => Colors.Yellow,
                JunctionDataZ.StopPolozenie => Colors.Pink,
                JunctionDataZ.RejonManewrowy => Colors.LightCyan,
                JunctionDataZ.StanPodstawowy => Colors.Gray,
                _ => Colors.None
            };
        }
    }

    public float Width => 4;
    public float[] CompoundArray => new float[] { 0, 1 };
    public float[] DashPattern => new float[] { 1f };


    public static Junction GetJunction(string name)
    {
        var j = RegisteredJunctions.FirstOrDefault(e => e?.Name == name, null);
        if (j is not null)
            return j;
        else throw new ArgumentOutOfRangeException(nameof(name), name, "Junction with provided name does not exist");
    }

    public static Junction GetJunction(string name, Track a, Track c) => GetJunction(name, a, a, c);
    public static Junction GetJunction(string name, Track a, Track b, Track c) => GetJunction(name, JunctionDirection.JunctionL_Right, a, b, c);
    public static Junction GetJunction(string name, JunctionDirection direction, Track a, Track c) => GetJunction(name, direction, a, a, c);
    public static Junction GetJunction(string name, JunctionDirection direction, Track a, Track b, Track c)
    {
        var junction = RegisteredJunctions.FirstOrDefault(e => e?.Name == name, null);
        if (junction is not null) return junction;

        junction = new Junction()
        {
            Name = name,
            A = a,
            B = b,
            C = c,
            DrawDirection = direction,
        };
        RegisteredJunctions.Add(junction);

        ChainedCommand chain = new ChainedCommand("zwr" + name.ToLower(), (context) =>
        {
            Unselect();
            if (context.Args is null || context.Args.Length != 1) return false;
            string junctionCommand = (context.GetArgAs<string>(0) ?? "").ToLower();
            var junction = GetJunction(context.CommandName.Substring("zwr".Length));
            if (junction is null) return false;
            switch (junctionCommand)
            {
                case "+":
                case "plus":
                    junction.ThrowJunction(true, junction.GetMainDirection());
                    return CommandProcessor.BreakChainCommand();

                case "-":
                case "minus":
                    junction.ThrowJunction(false, junction.GetMainDirection());
                    return CommandProcessor.BreakChainCommand();

                case "lok":
                    if (junction.Data is JunctionDataZ.StanPodstawowy)
                        junction.Data = JunctionDataZ.NastawaLokalna;
                    return CommandProcessor.BreakChainCommand();
                case "olok":
                    if (junction.Data is JunctionDataZ.NastawaLokalna)
                        junction.Data = JunctionDataZ.StanPodstawowy;
                    return CommandProcessor.BreakChainCommand();

                case "zmk": // TODO
                    return CommandProcessor.BreakChainCommand();

                case "ozmk": // TODO
                    return CommandProcessor.BreakChainCommand();

                case "ksr":
                case "plusbz":
                case "minbz":
                case "zdsp":
                case "zdsm":
                case "zerolo": // TODO
                    junction.Select();
                    return true;

                default:
                    return CommandProcessor.BreakChainCommand();
            }
        });

        Command command = new Command(junction.Name, (context) =>
        {
            if (context is not null and ChainedCommandContext ccc && ccc.Args.Length == 0)
            {
                Unselect();
                return true;
            }
            return false;
        });

        chain.NextCommand = command;
        CommandProcessor.RegisterCommand(chain);
        return junction;
    }

    public JunctionSet GetMainDirection()
    {
        return MainDirection;
    }

    public void ThrowJunction(bool toMain, JunctionSet mainDirection)
    {
        Direction = toMain ? mainDirection : MainDirection is JunctionSet.AB ? JunctionSet.AC : JunctionSet.AB;
    }

    public Pen GetPenWithColor(bool pulse)
    {
        return new Pen(PulsingSignal ? pulse ? ActualColor : SecondPulsingColor : ActualColor)
        {
            DashStyle = DashStyle.Custom,
            Width = 2,
            CompoundArray = CompoundArray,
            DashPattern = DashPattern
        };
    }
}
