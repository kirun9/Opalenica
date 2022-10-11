namespace Opalenica.Tiles;

using System.Drawing;

public class Tile
{
    protected static int _elementID { get; private set; } = 0;
    private int _position;

    public event EventHandler OnTileAdd;
    public event EventHandler OnTileRemove;

    public Grid Parent { get; internal set; }

    public virtual bool IsSelected { get; internal set; }

    public bool Pulse => Parent?.Pulse ?? false;

    public int Position
    {
        get => _position;
        set
        {
            if (Parent != null)
            {
                Parent.RemoveTile(this);
            }
            _position = value;
            if (Parent != null)
            {
                Parent.AddTile(this);
            }
        }
    }

    public int X => Parent.CalculateX(Position);
    public int Y => Parent.CalculateY(Position);

    /// <summary>
    /// Returns <code>Width</code> in pixels;
    /// </summary>
    public int Width => Size.Width;
    /// <summary>
    /// Returns <code>Height</code> in pixels;
    /// </summary>
    public int Height => Size.Height;

    /// <summary>
    /// Size of elements counted in tiles
    /// </summary>
    public Size SizeOnGrid { get; set; } = new Size(1, 1);
    /// <summary>
    /// Returns size of element in pixels
    /// </summary>
    public Size Size => Parent.CalculateTileSize(SizeOnGrid);
    public bool IsOccupied { get; internal set; }

    public Font Font { get; set; } = SystemFonts.DefaultFont;

    private Tile()
    {
        _elementID++;
    }

    public Tile(Grid parent, int position, Size sizeOnGrid) : base()
    {
        Parent = parent;
        Position = position;
        SizeOnGrid = sizeOnGrid;
    }

    public Tile(int pos) : base()
    {
        Position = pos;
    }

    public Tile(int position, Size sizeOnGrid) : base()
    {
        Position = position;
        SizeOnGrid = sizeOnGrid;
    }

    public void SetPosition(int x, int y)
    {
        Position = Parent.CalculatePosition(x, y);
    }

    internal void PaintTile(Graphics g)
    {
        PrePaint(g);
        Paint(g);
    }

    private void PrePaint(Graphics g)
    {
        if (IsSelected)
        {
            using Pen p = new Pen(Colors.Azure, 1);
            p.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
            g.DrawRectangle(p, new Rectangle(1, 1, Width - 2, Height - 2));
        }
    }

    protected virtual void Paint(Graphics g)
    {
        if (Parent.DebugMode && !IsOccupied)
        {
            using Font font = new Font(Font.FontFamily, 6, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);
            g.DrawRectangle(Pens.Red, 0, 0, Size.Width, Size.Height);
            string s = $"{X}x{Y}";
            var size = g.MeasureString(s, font);
            g.DrawRectangle(Pens.Red, 0, 0, Size.Width, Size.Height);
            PointF center = new PointF(0 + Size.Width / 2 - size.Width / 2, 0 + Size.Height / 2 - size.Height / 2);
            g.DrawString(s, font, Brushes.White, center);
        }
    }

    internal void TileAdded(EventArgs args)
    {
        OnTileAdded(args);
    }


    internal void TileRemoved(EventArgs args)
    {
        OnTileRemoved(args);
    }

    protected virtual void OnTileAdded(EventArgs args)
    {
        OnTileAdd?.Invoke(this, args);
    }

    protected virtual void OnTileRemoved(EventArgs args)
    {
        OnTileRemove?.Invoke(this, args);
    }
}
