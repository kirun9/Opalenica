namespace Opalenica;

using CommandProcessor;
using Opalenica.Tiles;
using System.Drawing.Drawing2D;

public class Track
{
    public VirtualData Occupied;
    public VirtualData Established;

    private static List<Track> RegisteredTracks = new List<Track>();
    public string Name { get; set; } = "TrackElement";
    public TrackData Data { get; set; } = TrackData.StanPodstawowy;
    public TrackType Type { get; set; }

    public float Width => Type is TrackType.KontrolaZamkniety or TrackType.BrakKontroliZamkniety? 4 : 4;
    public float[] CompoundArray => Type is TrackType.KontrolaZamkniety or TrackType.BrakKontroliZamkniety? new float[] { 0f, 1f / 5f, 4f / 5f, 1f } : new float[] { 0, 1 };
    public float[] DashPattern => Type is TrackType.BrakKontroli ? new float[] { 1f, 2f, 1f } : Type is TrackType.BrakKontroliZamkniety ? new float[] { 1f, 2f, 1f } : new float[] { 1 };

    public Color SecondPulsingColor
    {
        get
        {
            return GetColor(Data, true);
        }
    }

    public bool PulsingSignal
    {
        get
        {
            return Data switch
            {
                TrackData.PotwierdzenieZerowania => true,
                TrackData.UszkodzenieKontroli => true,
                _ => false
            };
        }
    }

    public Color ActualColor
    {
        get
        {
            return GetColor(Data);
        }
    }

    public Pen GetPenWithColor(bool pulse)
    {
        return new Pen(GetColor(this.Data, PulsingSignal && pulse))
        {
            DashStyle = DashStyle.Custom,
            Width = Width,
            CompoundArray = CompoundArray,
            DashPattern = DashPattern
        };
    }

    public Pen GetPenWithColor(bool pulse, TrackData data)
    {
        return new Pen(GetColor(data, PulsingSignal && pulse))
        {
            DashStyle = DashStyle.Custom,
            Width = Width,
            CompoundArray = CompoundArray,
            DashPattern = DashPattern
        };
    }

    public static Color GetColor(TrackData data, bool pulse = false)
    {
        return pulse ?
            data switch
            {
                TrackData.PotwierdzenieZerowania => Colors.Gray,
                TrackData.UszkodzenieKontroli => Colors.Red,
                _ => Colors.None,
            } :
                data switch
            {
                TrackData.StanPodstawowy => Colors.Gray,
                TrackData.RejonManewrowy => Colors.LightCyan,
                TrackData.OchronaPrzebiegu => Colors.Yellow,
                TrackData.PrzebiegManewrowy => Colors.Yellow,
                TrackData.ZwalnianyCzasowo => Colors.Pink,
                TrackData.Zajety => Colors.Red,
                TrackData.PierwszyPrzejazd => Colors.DarkRed,
                TrackData.PotwierdzenieZerowania => Colors.Red, //Migający
                TrackData.UszkodzenieKontroli => Colors.White, // Migający
                TrackData.BrakDanych => Colors.White,
                _ => Colors.None
            };
    }

    public Pen GetPen()
    {
        return new Pen(Colors.None)
        {
            DashStyle = DashStyle.Custom,
            Width = Width,
            CompoundArray = CompoundArray,
            DashPattern = DashPattern
        };
    }

    public void TrackOccupied(object? _, DataChangedEventArgs e)
    {
        if (!e.DataChanged) return;
        if (Occupied) Data = TrackData.Zajety;
    }

    public static Track GetTrack(string name, TrackType type = TrackType.Kontrola)
    {
        var track = RegisteredTracks.FirstOrDefault(e => e?.Name == name, null);
        if (track is not null) return track;
        track = new Track();
        track.Name = name;
        track.Type = type;
        track.Occupied = VirtualData.GetData(track.Name + ".Occupied");
        track.Established = VirtualData.GetData(track.Name + ".Established");
        track.Occupied.DataChanged += track.TrackOccupied;
        RegisteredTracks.Add(track);

        ChainedCommand chainedcommand = new ChainedCommand(track.Name, (CommandContext context) =>
        {
            if (context.Args is null || context.Args.Length != 1) return false;
            string trackCommand = (context.GetArgAs<string>(0) ?? "").ToLower();
            var track = RegisteredTracks.FirstOrDefault(e => e.Name == context.CommandName);
            if (track is null) return false;
            switch (trackCommand)
            {
                case "zmk":
                    track.Type = (track.Type is TrackType.Kontrola or TrackType.KontrolaZamkniety) ? TrackType.KontrolaZamkniety : TrackType.BrakKontroliZamkniety;
                    CommandProcessor.BreakChainCommand();
                    return true;
                case "ozmk":
                    track.Type = (track.Type is TrackType.Kontrola or TrackType.KontrolaZamkniety) ? TrackType.Kontrola : TrackType.BrakKontroli;
                    CommandProcessor.BreakChainCommand();
                    return true;
                case "zlo":
                case "zerolo":

                    return true;
                default:
                    CommandProcessor.BreakChainCommand();
                    return true;
            }
        });

        Command command = new Command(track.Name, (context) =>
        {
            if (context is not null and ChainedCommandContext ccc && ccc.Args.Length == 0)
            {
                var track = RegisteredTracks.FirstOrDefault(e => e.Name == ccc.CommandName);
                if (track is null) return false;
                track.Data = TrackData.PierwszyPrzejazd;
                return true;
            }
            return false;
        });
        chainedcommand.NextCommand = command;
        CommandProcessor.RegisterCommand(chainedcommand);
        return track;
    }
}