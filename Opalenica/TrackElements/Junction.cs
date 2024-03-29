﻿namespace Opalenica;

using CommandProcessor;

using Opalenica.Interfaces;
using Opalenica.Tiles;

using System.Drawing;
using System.Drawing.Drawing2D;

public class Junction : Element, IHasOwnData<JunctionDataZ>, IHasMenuStrip
{
    internal static List<Junction> RegisteredJunctions = new List<Junction>();
    private JunctionSet direction = JunctionSet.AB;

    public string[] CoupledJunctionNames { get; private set; }

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

    public Color GetColor(JunctionDataZ data, bool pulse = false)
    {
        return data switch
        {
            JunctionDataZ.BrakDanych                            => Colors.White,
            JunctionDataZ.Rozprucie when !pulse                 => Colors.Red,
            JunctionDataZ.Rozprucie when pulse                  => Colors.Gray,
            JunctionDataZ.NieoczekiwanyBrakKontroli when !pulse => Colors.White,
            JunctionDataZ.NieoczekiwanyBrakKontroli when pulse  => Colors.Gray,
            JunctionDataZ.BrakKontroli                          => Colors.Black, // (Niewidoczny)
            JunctionDataZ.Zajety                                => Colors.Red,
            JunctionDataZ.ZwalnianyCzasowo                      => Colors.Pink,
            JunctionDataZ.PrzebiegPociagowy                     => Colors.Green,
            JunctionDataZ.PrzebiegManewrowy                     => Colors.Yellow,
            JunctionDataZ.OchronaPrzebiegu                      => Colors.Yellow,
            JunctionDataZ.OchronaBoczna                         => Colors.Yellow,
            JunctionDataZ.StopPolozenie                         => Colors.Pink,
            JunctionDataZ.RejonManewrowy                        => Colors.LightCyan,
            JunctionDataZ.StanPodstawowy                        => Colors.Gray,
            _ => Colors.None
        };
    }

    public float Width => 4;
    public float[] CompoundArray => new float[] { 0, 1 };
    public float[] DashPattern => new float[] { 1f };

    public static Junction GetJunction(string name)
    {
        var j = RegisteredJunctions.FirstOrDefault(e => e?.Name == name, null);
        if (j is not null)
            return j;
        else
        {
            InfoTile.AddInfo("Rozjazd " + name + " nie istnieje", MessageSeverity.Warning, "Junction", "Warning", "NotExist");
            return null;
        }
    }

    public static Junction GetJunction(string name, Track a, Track c, string[] coupledJunctionNames = null) => GetJunction(name, a, a, c, coupledJunctionNames);
    public static Junction GetJunction(string name, Track a, Track b, Track c, string[] coupledJunctionNames = null) => GetJunction(name, JunctionDirection.JunctionL_Right, a, b, c, coupledJunctionNames);
    public static Junction GetJunction(string name, JunctionDirection direction, Track a, Track c, string[] coupledJunctionNames = null) => GetJunction(name, direction, a, a, c, coupledJunctionNames);
    public static Junction GetJunction(string name, JunctionDirection direction, Track a, Track b, Track c, string[] coupledJunctionNames = null)
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
            CoupledJunctionNames = coupledJunctionNames
        };
        RegisteredJunctions.Add(junction);

        ChainedCommand chain = new ChainedCommand("zwr", (context) => {
            {
                Unselect();
                if (context.Args is null || context.Args.Length != 2) return false;
                string junctionId = (context.GetArg<string>(0) ?? "").ToLower();
                string junctionCommand = (context.GetArg<string>(1) ?? "").ToLower();
                var junction = GetJunction(junctionId);
                if (junction is null) return false;
                return ExecJunctionCommand(junction, junctionCommand);
            }
        });

        ChainedCommand chain2 = new ChainedCommand("zwr" + name.ToLower(), (context) => {
            {
                Unselect();
                if (context.Args is null || context.Args.Length != 1) return false;
                string junctionCommand = (context.GetArg<string>(0) ?? "").ToLower();
                var junction = GetJunction(context.CommandName.Substring("zwr".Length));
                if (junction is null) return false;
                return ExecJunctionCommand(junction, junctionCommand);
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

        chain.NextCommand.Add(command);
        chain2.NextCommand.Add(command);
        CommandProcessor.RegisterCommand(chain);
        CommandProcessor.RegisterCommand(chain2);
        return junction;
    }

    public static bool ExecJunctionCommand(Junction junction, string junctionCommand)
    {
        switch (junctionCommand)
        {
            case "+":
            case "plus":
                junction.ThrowJunction(true, junction.GetMainDirection());
                SerialManager.SendCommand("zwr " + junction.Name.ToLower() + " +");
                JunctionCoupling.ExecuteRules(junction, true);
                return CommandProcessor.BreakChainCommand();

            case "-":
            case "minus":
                junction.ThrowJunction(false, junction.GetMainDirection());
                SerialManager.SendCommand("zwr " + junction.Name.ToLower() + " -");
                JunctionCoupling.ExecuteRules(junction, false);
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
        return new Pen(GetColor(Data, pulse))
        {
            DashStyle = DashStyle.Custom,
            Width = 2,
            CompoundArray = CompoundArray,
            DashPattern = DashPattern
        };
    }

    public ContextMenuStrip GetMenuStrip()
    {
        ContextMenuStrip strip = new ContextMenuStrip();

        ToolStripMenuItem title = new ToolStripMenuItem($"Rozjazd {Name}");
        title.Enabled = false;
        strip.Items.Add(title);

        ToolStripMenuItem nastawa = new ToolStripMenuItem(Direction == JunctionSet.AB ? "Nastaw - (minus)" : "Nastaw + (plus)");
        nastawa.Click += (_, _) => { CommandProcessor.ExecuteCommand("zwr " + Name + (Direction == JunctionSet.AB ? " -" : " +")); };

        strip.Items.Add(nastawa);
        return strip;
    }
}