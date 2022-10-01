namespace Opalenica.Tiles;

using System.Text.RegularExpressions;

using Timer = System.Windows.Forms.Timer;

public class Grid
{
    private const string SizeRegex = @"^([1-9][0-9]*)x([1-9][0-9]*)$";
    private Timer timer = new Timer();
    public bool Pulse { get; set; }
    public Size GridDimensions { get; private set; }
    public Size TileSize { get; set; }
    public bool DebugMode => Program.DebugMode;
    public Padding Padding { get; set; }
    public int Capacity => tileArray.Length;

    private Tile[] tileArray { get; set; }

    public Tile this[int x, int y]
    {
        get { return this[CalculatePosition(x, y)]; }
        set { this[CalculatePosition(x, y)] = value; }
    }

    public Tile this[int pos]
    {
        get { return tileArray[pos]; }
        set { tileArray[pos] = value; }
    }

    public Tile this[Tile tile]
    {
        get { return this[tile.Position]; }
        set { this[tile.Position] = value; }
    }

    public Grid(string size, string tileSize)
    {
        timer = new Timer();
        timer.Interval = 500; // 1Hz, wypełnienie 50/50%
        timer.Tick += (_, _) => { Pulse = !Pulse; };
        timer.Enabled = true;


        if (!Regex.IsMatch(size, SizeRegex)) throw new ArgumentException("", nameof(size));
        if (!Regex.IsMatch(tileSize, SizeRegex)) throw new ArgumentException("", nameof(tileSize));

        string[] dimensions = size.Split('x');
        GridDimensions = new Size(int.Parse(dimensions[0]), int.Parse(dimensions[1]));

        string[] tSize = tileSize.Split('x');
        TileSize = new Size(int.Parse(tSize[0]), int.Parse(tSize[1]));

        tileArray = new Tile[GridDimensions.Width * GridDimensions.Height];
    }

    public Grid(int x, int y, int width, int height)
    {
        if (x < 1) throw new ArgumentException("Value must be greater than 0", nameof(x));
        if (y < 1) throw new ArgumentException("Value must be greater than 0", nameof(y));
        if (width < 1) throw new ArgumentException("Value must be greater than 0", nameof(width));
        if (height < 1) throw new ArgumentException("Value must be greater than 0", nameof(height));
        GridDimensions = new Size(x, y);
        TileSize = new Size(width, height);
    }

    public void AddTile(Tile tile)
    {
        tile.Parent ??= this;
        if (tile.Position == 33 /*|| (tile.X <= 9 && tile.Y == 18)*/)
        {
            Tile t = new Tile(CalculatePosition(tile.X, tile.Y)) { IsOccupied = true };
            t.Parent = this;
            tileArray[t.Position] = t;
            t.TileAdded(EventArgs.Empty);
        }
        if (tileArray[tile.Position]?.IsOccupied ?? false) return;
        for (int x = 0; x < tile.SizeOnGrid.Width; x++)
        {
            for (int y = 0; y < tile.SizeOnGrid.Height; y++)
            {
                if (x == 0 && y == 0)
                {
                    tileArray[tile.Position] = tile;
                    continue;
                }
                Tile t = new Tile(CalculatePosition(tile.X + x, tile.Y + y)) { IsOccupied = true };
                t.Parent = this;
                tileArray[t.Position] = t;
                t.TileAdded(EventArgs.Empty);
            }
        }
        tile.TileAdded(EventArgs.Empty);
    }

    public void RemoveTile(int x, int y)
    {
        RemoveTile(CalculatePosition(x, y));
    }

    public void RemoveTile(int position)
    {
        RemoveTile(this[position]);
    }

    public void RemoveTile(Tile tile)
    {
        if (tile.Parent is null || tile.Parent != this || tile != this[tile]) return;
        if (this[tile]?.IsOccupied ?? false) return;
        for (int x = 0; x < tile.SizeOnGrid.Width; x++)
        {
            for (int y = 0; y < tile.SizeOnGrid.Height; y++)
            {
                this[tile.X + x, tile.Y + y].TileRemoved(EventArgs.Empty);
                this[tile.X + x, tile.Y + y] = null;
            }
        }
    }

    public IEnumerable<Tile> GetTiles()
    {
        foreach (var tile in tileArray)
            yield return tile;
    }

    public Point CalculateGraphicTilePosition(int pos)
    {
        return new Point(CalculateX(pos) * TileSize.Width + Padding.Left,
                         CalculateY(pos) * TileSize.Height + Padding.Top);
    }

    public int CalculatePosition(int x, int y)
    {
        return x + y * GridDimensions.Width;
    }

    public int CalculateX(int pos)
    {
        return pos % GridDimensions.Width;
    }

    public int CalculateY(int pos)
    {
        return (pos - pos % GridDimensions.Width) / GridDimensions.Width;
    }

    public Size CalculateTileSize(Size tileSize)
    {
        return new Size(tileSize.Width * TileSize.Width, tileSize.Height * TileSize.Height);
    }
}
