namespace Opalenica.Tiles;

using System.Drawing;

public class DebugMoveTile : Tile
{
    public DebugMoveTile(int position, Size sizeOnGrid) : base(position, sizeOnGrid)
    { }

    public DebugMoveTile(Grid parent, int position, Size sizeOnGrid) : base(parent, position, sizeOnGrid)
    {}

    public DebugMoveTile(int pos) : base(pos)
    { }

    protected override void Paint(Graphics g)
    {

    }

    internal Rectangle GetRectangle()
    {
        var pos = Parent.CalculateGraphicTilePosition(this.Position);
        return new Rectangle(pos.X, pos.Y, Width, Height);
    }
}
