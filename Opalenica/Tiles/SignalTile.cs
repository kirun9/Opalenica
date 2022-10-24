namespace Opalenica.Tiles;

using CommandProcessor;

using Opalenica.Interfaces;
using Opalenica.Render;
using Opalenica.Tiles.Interfaces;

using System;
using System.Drawing;

public class SignalTile : Tile, IMouseEvent, IHasMenuStrip
{
    private Signal Signal { get; set; }
    private TriangleDirection Direction { get => Signal.SignalDirection; }
    public override bool IsSelected => Signal.IsSelected;

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
        if (Signal.Track is not null)
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
        }
        if (Signal.Type is SignalType.Pociagowy)
        {
            using SolidBrush brush = Signal.GetBrush(Parent.Pulse);
            g.FillTriangle(brush, new RectangleF(Size.Width * 0.2f, Size.Height * 0.2f, Size.Width * 0.6f, Size.Height * 0.6f), Signal.SignalDirection);
        }
        else if (Signal.Type is SignalType.Czerwony)
        {
            using SolidBrush brush = Signal.GetBrush(Parent.Pulse);
            g.FillRectangle(brush, new RectangleF(Size.Width * 0.4f, Size.Height * 0.2F, Size.Width * 0.2f, Size.Height * 0.6f));
        }
    }

    void IMouseEvent.OnMouseClick(MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left && e.Clicks == 1)
        {
            if (Signal.IsSelected)
            {
                CommandProcessor.ExecuteCommand($"{Signal.Name}");
            }
            else
            {
                CommandProcessor.ExecuteCommand($"{Signal.Name} sz");
            }
        }
    }

    public ContextMenuStrip GetMenuStrip()
    {
        return Signal.GetMenuStrip();
    }
}