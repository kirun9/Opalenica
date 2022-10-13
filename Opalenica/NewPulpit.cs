namespace Opalenica;

using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using Opalenica.Render;
using Opalenica.Tiles;
using Opalenica.Tiles.Interfaces;
using Opalenica.TrackElements;

internal class NewPulpit : Control
{
    private readonly Size designSize = new Size(1366, 768);
    internal static (float horizontal, float vertical) scale { get; set; } = (1, 1);

    private Grid grid { get; set; } = new Grid("34x19", "40x40");

    [Category("Appearance")]
    [Browsable(true)]
    public new Padding Padding { get; set; } = new Padding(3, 3, 3, 3);

    public List<Tile> RegisteredTiles = new List<Tile>();

#if DEBUG
    private Stopwatch watch;
#endif

    public NewPulpit() : base()
    {
#if DEBUG
        watch = new Stopwatch();
        watch.Start();
#endif
        grid.Padding = Padding;
        this.DoubleBuffered = true;
        RegisterElements();
        //tileSize = new Size((designSize.Width - Padding.Vertical) / 38, (designSize.Height - Padding.Horizontal) / 38);
    }

    public NewPulpit(Control parent, String text) : base(parent, text)
    {
        Parent = parent;
        Text = text;

#if DEBUG
        watch = new Stopwatch();
        watch.Start();
#endif
        grid.Padding = Padding;
        this.DoubleBuffered = true;
        RegisterElements();
    }

    public void RegisterTiles()
    {
        /*Track.GetTrack("outR", TrackType.BrakKontroliZamkniety);
        Track.GetTrack("1", TrackType.BrakKontroliZamkniety);
        Track.GetTrack("1a", TrackType.BrakKontroliZamkniety);

        Track.GetTrack("outS", TrackType.BrakKontroli);
        Track.GetTrack("2", TrackType.BrakKontroli);
        Track.GetTrack("2a", TrackType.BrakKontroli);*/

        RegisteredTiles.Add(new TrackTile(grid.CalculatePosition(0, 5), Track.GetTrack("outR")));
        RegisteredTiles.Add(new TrackTile(grid.CalculatePosition(0, 7), Track.GetTrack("outS")));

        RegisteredTiles.Add(new SignalTile(grid.CalculatePosition(1, 5), Signal.GetSignal("R", TriangleDirection.Right, Track.GetTrack("1a"))));
        RegisteredTiles.Add(new SignalTile(grid.CalculatePosition(1, 7), Signal.GetSignal("S", TriangleDirection.Right, Track.GetTrack("2a"))));

        RegisteredTiles.Add(new TrackTile(grid.CalculatePosition(3, 3), new Size(3, 1), Track.GetTrack("3a")));
        RegisteredTiles.Add(new TrackTile(grid.CalculatePosition(2, 5), new Size(2, 1), Track.GetTrack("1a")));
        RegisteredTiles.Add(new TrackTile(grid.CalculatePosition(6, 5), new Size(1, 1), Track.GetTrack("1a")));
        RegisteredTiles.Add(new TrackTile(grid.CalculatePosition(3, 7), new Size(4, 1), Track.GetTrack("2a")));
        RegisteredTiles.Add(new TrackTile(grid.CalculatePosition(8, 7), new Size(1, 1), Track.GetTrack("2a")));
        RegisteredTiles.Add(new TrackTile(grid.CalculatePosition(3, 9), new Size(6, 1), Track.GetTrack("4a")));
        RegisteredTiles.Add(new TrackTile(grid.CalculatePosition(10, 9), new Size(1, 1), Track.GetTrack("4a")));
        RegisteredTiles.Add(new TrackTile(grid.CalculatePosition(11, 11), new Size(1, 1), Track.GetTrack("6a")));

        RegisteredTiles.Add(new TrackTile(grid.CalculatePosition(3, 6), new Size(1, 1), Track.GetTrack("2a1a")) { Drawing = DrawingDirection.Start_Bottom | DrawingDirection.Start_Left | DrawingDirection.End_Top | DrawingDirection.End_Right });
        RegisteredTiles.Add(new TrackTile(grid.CalculatePosition(5, 4), new Size(1, 1), Track.GetTrack("1a3a")) { Drawing = DrawingDirection.Start_Bottom | DrawingDirection.Start_Left | DrawingDirection.End_Top | DrawingDirection.End_Right });
        RegisteredTiles.Add(new TrackTile(grid.CalculatePosition(6, 6), new Size(1, 1), Track.GetTrack("1a2a")) { Drawing = DrawingDirection.Start_Top | DrawingDirection.Start_Left | DrawingDirection.End_Bottom | DrawingDirection.End_Right });
        RegisteredTiles.Add(new TrackTile(grid.CalculatePosition(8, 8), new Size(1, 1), Track.GetTrack("2a4a")) { Drawing = DrawingDirection.Start_Top | DrawingDirection.Start_Left | DrawingDirection.End_Bottom | DrawingDirection.End_Right });
        RegisteredTiles.Add(new TrackTile(grid.CalculatePosition(10, 10), new Size(1, 1), Track.GetTrack("6a")) { Drawing = DrawingDirection.Start_Top | DrawingDirection.Start_Left | DrawingDirection.End_Bottom | DrawingDirection.End_Right });

        RegisteredTiles.Add(new SignalTile(grid.CalculatePosition(7, 3), Signal.GetSignal("P", TriangleDirection.Left, Track.GetTrack("3"))));
        RegisteredTiles.Add(new SignalTile(grid.CalculatePosition(7, 5), Signal.GetSignal("O", TriangleDirection.Left, Track.GetTrack("1"))));
        RegisteredTiles.Add(new SignalTile(grid.CalculatePosition(9, 7), Signal.GetSignal("N", TriangleDirection.Left, Track.GetTrack("2"))));
        RegisteredTiles.Add(new SignalTile(grid.CalculatePosition(11, 9), Signal.GetSignal("M", TriangleDirection.Left, Track.GetTrack("4"))));
        RegisteredTiles.Add(new SignalTile(grid.CalculatePosition(12, 11), Signal.GetSignal("L", TriangleDirection.Left, Track.GetTrack("6"))));

        RegisteredTiles.Add(new TrackTile(grid.CalculatePosition(8, 3), new Size(11, 1), Track.GetTrack("3")));
        RegisteredTiles.Add(new TrackTile(grid.CalculatePosition(8, 5), new Size(11, 1), Track.GetTrack("1")));
        RegisteredTiles.Add(new TrackTile(grid.CalculatePosition(10, 7), new Size(8, 1), Track.GetTrack("2")));
        RegisteredTiles.Add(new TrackTile(grid.CalculatePosition(12, 9), new Size(5, 1), Track.GetTrack("4")));
        RegisteredTiles.Add(new TrackTile(grid.CalculatePosition(13, 11), new Size(3, 1), Track.GetTrack("6")));

        RegisteredTiles.Add(new JunctionTile(grid.CalculatePosition(2, 7), Junction.GetJunction("15", JunctionDirection.JunctionL_Right, Track.GetTrack("2a"), Track.GetTrack("2a1a"))));
        RegisteredTiles.Add(new DoubleJunctionTile(grid.CalculatePosition(4, 5), Junction.GetJunction("14ab", JunctionDirection.JunctionL_Left, Track.GetTrack("1a"), Track.GetTrack("1a3a")), Junction.GetJunction("14cd", Track.GetTrack("1a"), Track.GetTrack("2a1a"))));
        RegisteredTiles.Add(new JunctionTile(grid.CalculatePosition(6, 3), Junction.GetJunction("13", JunctionDirection.JunctionL_Left, Track.GetTrack("3a"), Track.GetTrack("1a3a"))));
        RegisteredTiles.Add(new JunctionTile(grid.CalculatePosition(5, 5), Junction.GetJunction("12", JunctionDirection.JunctionR_Right, Track.GetTrack("1a"), Track.GetTrack("1a2a"))));
        RegisteredTiles.Add(new DoubleJunctionTile(grid.CalculatePosition(7, 7), Junction.GetJunction("11ab", JunctionDirection.JunctionR_Left, Track.GetTrack("2a"), Track.GetTrack("1a2a")), Junction.GetJunction("11cd", Track.GetTrack("2a"), Track.GetTrack("2a4a"))));
        RegisteredTiles.Add(new DoubleJunctionTile(grid.CalculatePosition(9, 9), Junction.GetJunction("10ab", JunctionDirection.JunctionR_Left, Track.GetTrack("4a"), Track.GetTrack("2a4a")), Junction.GetJunction("10cd", Track.GetTrack("4a"), Track.GetTrack("4a6a"))));

        RegisteredTiles.Add(new SignalTile(grid.CalculatePosition(16, 11), Signal.GetSignal("H", TriangleDirection.Right, Track.GetTrack("6"))));
        RegisteredTiles.Add(new SignalTile(grid.CalculatePosition(17, 9), Signal.GetSignal("G", TriangleDirection.Right, Track.GetTrack("4"))));
        RegisteredTiles.Add(new SignalTile(grid.CalculatePosition(18, 7), Signal.GetSignal("F", TriangleDirection.Right, Track.GetTrack("2"))));
        RegisteredTiles.Add(new SignalTile(grid.CalculatePosition(19, 5), Signal.GetSignal("E", TriangleDirection.Right, Track.GetTrack("1"))));
        RegisteredTiles.Add(new SignalTile(grid.CalculatePosition(19, 3), Signal.GetSignal("D", TriangleDirection.Right, Track.GetTrack("3"))));

        RegisteredTiles.Add(new TrackTile(grid.CalculatePosition(17, 11), new Size(1, 1), Track.GetTrack("6b")));
        RegisteredTiles.Add(new TrackTile(grid.CalculatePosition(18, 9), new Size(1, 1), Track.GetTrack("4b")));
        RegisteredTiles.Add(new TrackTile(grid.CalculatePosition(20, 9), new Size(1, 1), Track.GetTrack("4b")));
        RegisteredTiles.Add(new TrackTile(grid.CalculatePosition(19, 7), new Size(3, 1), Track.GetTrack("2b")));
        RegisteredTiles.Add(new TrackTile(grid.CalculatePosition(23, 7), new Size(1, 1), Track.GetTrack("2b")));
        RegisteredTiles.Add(new TrackTile(grid.CalculatePosition(25, 7), new Size(2, 1), Track.GetTrack("2b")));
        RegisteredTiles.Add(new TrackTile(grid.CalculatePosition(20, 5), new Size(2, 1), Track.GetTrack("1b")));
        RegisteredTiles.Add(new TrackTile(grid.CalculatePosition(23, 5), new Size(1, 1), Track.GetTrack("1b")));
        RegisteredTiles.Add(new TrackTile(grid.CalculatePosition(25, 5), new Size(2, 1), Track.GetTrack("1b")));
        RegisteredTiles.Add(new TrackTile(grid.CalculatePosition(20, 3), new Size(6, 1), Track.GetTrack("3b")));

        RegisteredTiles.Add(new TrackTile(grid.CalculatePosition(18, 10), new Size(1, 1), Track.GetTrack("6b")) { Drawing = DrawingDirection.Start_Bottom | DrawingDirection.Start_Left | DrawingDirection.End_Top | DrawingDirection.End_Right });
        RegisteredTiles.Add(new TrackTile(grid.CalculatePosition(21, 8), new Size(1, 1), Track.GetTrack("2b4b")) { Drawing = DrawingDirection.Start_Bottom | DrawingDirection.Start_Left | DrawingDirection.End_Top | DrawingDirection.End_Right });
        RegisteredTiles.Add(new TrackTile(grid.CalculatePosition(25, 4), new Size(1, 1), Track.GetTrack("1b3b")) { Drawing = DrawingDirection.Start_Bottom | DrawingDirection.Start_Left | DrawingDirection.End_Top | DrawingDirection.End_Right });

        RegisteredTiles.Add(new JunctionTile(grid.CalculatePosition(19, 9), Junction.GetJunction("4", JunctionDirection.JunctionL_Left, Track.GetTrack("4b"), Track.GetTrack("6b"))));
        RegisteredTiles.Add(new JunctionTile(grid.CalculatePosition(22, 5), Junction.GetJunction("5", JunctionDirection.JunctionR_Right, Track.GetTrack("1b"), Track.GetTrack("3b1b"))));
        RegisteredTiles.Add(new JunctionTile(grid.CalculatePosition(24, 7), Junction.GetJunction("6", JunctionDirection.JunctionR_Left, Track.GetTrack("2b"), Track.GetTrack("1b2b"))));
        RegisteredTiles.Add(new JunctionTile(grid.CalculatePosition(26, 3), Junction.GetJunction("1", JunctionDirection.JunctionL_Left, Track.GetTrack("3b"), Track.GetTrack("1b3b"))));
        RegisteredTiles.Add(new DoubleJunctionTile(grid.CalculatePosition(22, 7), Junction.GetJunction("3ab", JunctionDirection.JunctionL_Left, Track.GetTrack("2b"), Track.GetTrack("2b4b")), Junction.GetJunction("3cd", Track.GetTrack("2b"), Track.GetTrack("2b1b"))));
        RegisteredTiles.Add(new DoubleJunctionTile(grid.CalculatePosition(24, 5), Junction.GetJunction("2ab", JunctionDirection.JunctionL_Left, Track.GetTrack("1b"), Track.GetTrack("1b2b")), Junction.GetJunction("2cd", Track.GetTrack("1b"), Track.GetTrack("1b3b"))));

        RegisteredTiles.Add(new CrossTrackTile(grid.CalculatePosition(23, 6), CrossTrack.GetCross("K1", Track.GetTrack("2b1b"), Track.GetTrack("1b2b"))));

        RegisteredTiles.Add(new SignalTile(grid.CalculatePosition(27, 3), Signal.GetSignal("C", TriangleDirection.Left, Track.GetTrack("1b"))));
        RegisteredTiles.Add(new SignalTile(grid.CalculatePosition(27, 5), Signal.GetSignal("B", TriangleDirection.Left, Track.GetTrack("1b"))));
        RegisteredTiles.Add(new SignalTile(grid.CalculatePosition(27, 7), Signal.GetSignal("A", TriangleDirection.Left, Track.GetTrack("2b"))));

        RegisteredTiles.Add(new TrackTile(grid.CalculatePosition(28, 3), new Size(2, 1), Track.GetTrack("outC")));
        RegisteredTiles.Add(new TrackTile(grid.CalculatePosition(31, 3), new Size(2, 1), Track.GetTrack("it102")));
        RegisteredTiles.Add(new TrackTile(grid.CalculatePosition(31, 2), new Size(2, 1), Track.GetTrack("it103")));
        RegisteredTiles.Add(new TrackTile(grid.CalculatePosition(31, 1), new Size(2, 1), Track.GetTrack("it104")));

        RegisteredTiles.Add(new TrackTile(grid.CalculatePosition(28, 5), new Size(2, 1), Track.GetTrack("outB")));
        RegisteredTiles.Add(new TrackTile(grid.CalculatePosition(28, 7), new Size(2, 1), Track.GetTrack("outA")));

        RegisteredTiles.Add(new InfoTile(grid.CalculatePosition(0, 13), new Size(15, 5)));

        RegisteredTiles.Add(new TrackCurveTile(grid.CalculatePosition(11, 11), Track.GetTrack("6a"), CurveDirection.FromRightTurnRight45));
        RegisteredTiles.Add(new TrackCurveTile(grid.CalculatePosition(17, 11), Track.GetTrack("6b"), CurveDirection.FromLeftTurnLeft45));
    }

    public void RegisterElements()
    {
        RegisterTiles();

        for (int i = 0; i < grid.Capacity; i++)
        {
            if (i == grid.CalculatePosition(1, 0))
            {
                grid.AddTile(new ColorCheckTile(i, new Size(3, 2)));
            }
            else if (i == grid.CalculatePosition(0, 18))
            {
                grid.AddTile(new CommandTile(i, new Size(9, 1), this.Parent));
            }
            else
            {
                grid.AddTile(new Tile(i));
            }
        }

        foreach (var tile in RegisteredTiles)
        {
            grid.AddTile(tile);
        }
    }

    protected override void OnSizeChanged(EventArgs e)
    {
        base.OnSizeChanged(e);
        calculateScale();
    }

    private void calculateScale()
    {
        scale = ((float)Width / designSize.Width, (float)Height / designSize.Height);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
#if DEBUG
        watch.Restart();
#endif
        base.OnPaint(e);
        calculateScale();

        e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
        e.Graphics.SmoothingMode = SmoothingMode.None;
        e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;

        using (SolidBrush b = new SolidBrush(Colors.Black))
        {
            e.Graphics.FillRectangle(b, 0, 0, Width, Height);
        }

        DrawPulpit(e.Graphics);
    }

    protected void DrawPulpit(Graphics g)
    {
        var defaultTransform = g.Transform;
        var prevClipRegion = g.Clip;
        foreach (var tile in grid.GetTiles())
        {
            Point p = grid.CalculateGraphicTilePosition(tile.Position);
            g.ScaleTransform(scale.horizontal, scale.vertical);
            g.TranslateTransform(p.X, p.Y);
            g.Clip = new Region(new Rectangle(p.X == 0 ? -1 : 0, p.Y == 0 ? -1 : 0, tile.Size.Width, tile.Size.Height));
            tile.PaintTile(g);
            g.Clip = prevClipRegion;
            g.ResetTransform();
        }
        g.ResetTransform();
        g.Transform = defaultTransform;
    }

    protected override void OnMouseClick(MouseEventArgs e)
    {
        void ShowContextMenu(ContextMenuStrip menu)
        {
            /* if debugmode
                 * add debug items
                 * */
            menu.Show(this, e.Location);
        }

        base.OnMouseClick(e);

        Point p = new Point((int)(e.X / scale.horizontal), (int)(e.Y / scale.vertical));
        var tile = grid.GetTileFromPoint(p);
        if (e.Button == MouseButtons.Right)
        {
            if (tile.IsOccupied)
            {
                if (tile.ParentTile is not null and IHasMenuStrip pMenuStrip)
                {
                    ShowContextMenu(pMenuStrip.GetMenuStrip());
                }
            }
            else
            {
                if (tile is IHasMenuStrip menuStrip)
                {
                    ShowContextMenu(menuStrip.GetMenuStrip());
                    return;
                }
            }
        }

        if (e.Button is MouseButtons.Left or MouseButtons.Middle)
        {
            if (tile.IsOccupied)
            {
                if (tile.ParentTile is not null and IMouseEvent pMouseEvent)
                {
                    pMouseEvent.OnMouseClick(e);
                }
            }
            else
            {
                if (tile is IMouseEvent mouseEvent)
                {
                    mouseEvent.OnMouseClick(e);
                }
            }
        }
    }
}
