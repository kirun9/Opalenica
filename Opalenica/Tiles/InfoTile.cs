namespace Opalenica.Tiles;

public class InfoTile : Tile
{
    private static List<(int id, string message, Color color, Color colorPulsing)> InfoLines = new List<(int, string, Color, Color)>();
    private new Font Font;

    public InfoTile(int pos) : base(pos)
    {
        Initialize();
    }

    public InfoTile(int position, Size sizeOnGrid) : base(position, sizeOnGrid)
    {
        Initialize();
    }

    public InfoTile(Grid parent, int position, Size sizeOnGrid) : base(parent, position, sizeOnGrid)
    {
        Initialize();
    }

    private void Initialize()
    {
        /*InfoLines.Add((1, "Sample Error", Colors.Red, Colors.White));
        InfoLines.Add((2, "Sample Information", Colors.Yellow, Colors.Yellow));
        InfoLines.Add((3, "Sample Help info", Colors.White, Colors.White));*/
        Font = new Font(base.Font.FontFamily, 12F, FontStyle.Bold, base.Font.Unit);
    }

    protected override void Paint(Graphics g)
    {
        using Pen p = new Pen(Colors.White, 2);
        p.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
        g.DrawRectangle(p, 0, 0, Width, Height);

        float prevHeight = 5;
        foreach (var line in InfoLines)
        {
            g.DrawString(line.message, Font, new SolidBrush(Parent.Pulse ? line.colorPulsing : line.color), 5, prevHeight);
            var size = g.MeasureString(line.message, Font);
            prevHeight += size.Height + 2;
        }
    }

    public static int AddInfo(string message, InfoType type)
    {
        var color = type switch
        {
            InfoType.Error => Colors.Red,
            InfoType.Warning => Colors.Yellow,
            InfoType.Help => Colors.White,
            _ => Colors.White
        };
        var pulsing = type switch
        {
            InfoType.Error => Colors.White,
            InfoType.Warning => Colors.Yellow,
            InfoType.Help => Colors.White,
            _ => Colors.White
        };
        return AddInfo(message, color, pulsing);
    }

    private static int AddInfo(string message, Color color, Color colorPulsing)
    {
        var id = InfoLines.Count == 0 ? 0 : InfoLines.Last().id;
        InfoLines.Add((id + 1, message, color, colorPulsing));
        return id + 1;
    }

    public static void RemoveInfo(int id)
    {
        InfoLines.RemoveAll(x => x.id == id);
    }
}

public enum InfoType
{
    Help,
    Warning,
    Error,
}