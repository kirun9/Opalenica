namespace Opalenica.Tiles;

using Opalenica.Interfaces;
using Opalenica.Tiles.Interfaces;

using System.Drawing;
using System.Windows.Forms;

public class TrackTile : Tile, IMouseEvent, IHasMenuStrip
{
    public Track Track { get; set; }

    public override bool IsSelected => Track.IsSelected;

    public DrawingDirection Drawing { get; set; } = DrawingDirection.Start_Left | DrawingDirection.End_Right;

    public TrackTile(Int32 pos, Track track) : base(pos)
    {
        Track = track;
    }

    public TrackTile(Int32 position, Size sizeOnGrid, Track track) : base(position, sizeOnGrid)
    {
        Track = track;
    }

    public TrackTile(Grid parent, Int32 position, Size sizeOnGrid, Track track) : base(parent, position, sizeOnGrid)
    {
        Track = track;
    }

    protected override void Paint(Graphics g)
    {
        using Pen pen = Track.GetPenWithColor(Parent.Pulse);

        Point startPoint = new Point(Drawing switch
        {
            var t when t.HasFlag(DrawingDirection.Start_Left) => 0,
            var t when t.HasFlag(DrawingDirection.Start_Right) => Size.Width,
            _ => Size.Width / 2
        },
        Drawing switch
        {
            var t when t.HasFlag(DrawingDirection.Start_Top) => 0,
            var t when t.HasFlag(DrawingDirection.Start_Bottom) => Size.Height,
            _ => Size.Height / 2
        });
        Point endPoint = new Point(Drawing switch
        {
            var t when t.HasFlag(DrawingDirection.End_Left) => 0,
            var t when t.HasFlag(DrawingDirection.End_Right) => Size.Width,
            _ => Size.Width / 2
        },
        Drawing switch
        {
            var t when t.HasFlag(DrawingDirection.End_Top) => 0,
            var t when t.HasFlag(DrawingDirection.End_Bottom) => Size.Height,
            _ => Size.Height / 2
        });

        g.DrawLine(pen, startPoint, endPoint);
    }

    void IMouseEvent.OnMouseClick(MouseEventArgs e)
    {
        if (IsSelected)
        {
            Track.Unselect();
        }
        else
        {
            Track.Select();
        }
    }

    public ContextMenuStrip GetMenuStrip()
    {
        return Track.GetMenuStrip();
    }
}

[Flags]
public enum DrawingDirection
{
    End_Top      = 0b_0000_0001,
    End_Bottom   = 0b_0000_0010,
    End_Left     = 0b_0000_0100,
    End_Right    = 0b_0000_1000,

    Start_Top    = 0b_0001_0000,
    Start_Bottom = 0b_0010_0000,
    Start_Left   = 0b_0100_0000,
    Start_Right  = 0b_1000_0000,
}