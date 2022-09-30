namespace Opalenica.Tiles;

using System;
using System.Drawing;

public class SignalTile : Tile
{
    private Signal Signal { get; set; }
    private TriangleDirection Direction { get => Signal.SignalDirection; }

    public SignalTile(int pos, Signal signal) : base(pos)
    {
        Signal = signal;
    }

    public SignalTile(int position, Size sizeOnGrid, Signal signal) : base(position, sizeOnGrid)
    {
        Signal = signal;
    }

    public SignalTile(Grid parent, int position, Size sizeOnGrid, Signal signal) : base(parent, position, sizeOnGrid)
    {
        Signal = signal;
    }

    protected override void Paint(Graphics g)
    {
        using Pen pen = Signal.Track.GetPenWithColor(Parent.Pulse);

        switch (Direction)
        {
            case TriangleDirection.Up:
            case TriangleDirection.Down:
                g.DrawLine(pen, Size.Width / 2, 0, Size.Width / 2, Size.Height);
                break;
            case TriangleDirection.Left:
            case TriangleDirection.Right:
                g.DrawLine(pen, 0, Size.Height / 2, Size.Width, Size.Height / 2);
                break;
        }

        using SolidBrush brush = Signal.GetBrush(Parent.Pulse);
        g.FillTriangle(brush, new RectangleF(Size.Width * 0.2f, Size.Height * 0.2f, Size.Width * 0.6f, Size.Height * 0.6f), Signal.SignalDirection);
    }
}