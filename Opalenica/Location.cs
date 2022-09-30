namespace Opalenica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal struct Location
{
    private bool empty = false;

    public static readonly Location Empty = new Location() { empty = true };

    public Point TopLeft { get; set; }
    public Point BottomRight { get; set; }

    public int X => TopLeft.X;
    public int Y => TopLeft.Y;

    public Size Size => new Size(BottomRight.X, BottomRight.Y);

    public Location(Point topLeft, Point bottomRight)
    {
        TopLeft = topLeft;
        BottomRight = bottomRight;
    }

    public Location(int topLeftX, int topLeftY, int bottomRightX, int bottomRightY)
    {
        TopLeft = new Point(topLeftX, topLeftY);
        BottomRight = new Point(bottomRightX, bottomRightY);
    }

    public Location(Point middle)
    {
        TopLeft = new Point(middle.X - 10, middle.Y - 10);
        BottomRight = new Point(20, 20);
    }

    public Location(int x, int y)
    {
        TopLeft = new Point(x - 10, y - 10);
        BottomRight = new Point(20, 20);
    }

    public bool IsEmpty() => empty;

    public static implicit operator Rectangle(Location val) => new Rectangle(val.TopLeft, (Size) val.BottomRight);
}
