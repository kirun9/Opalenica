namespace Opalenica.Tiles;

public class InfoTile : Tile
{
    private List<(string message, Color color, Color colorPulsing)> InfoLines = new List<(string, Color, Color)>();
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
        InfoLines.Add(("Line 1", Colors.Red, Colors.White));
        InfoLines.Add(("Line 2", Colors.Yellow, Colors.Yellow));
        InfoLines.Add(("Line 3", Colors.White, Colors.White));
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
}
