namespace Opalenica.Tiles;

using CommandProcessor;

using Opalenica.Render;

using System.Drawing;
using System.Windows.Forms;

public class ColorCheckTile : Tile
{
    public static bool DisplayAllColors = false;

    public ColorCheckTile(Int32 pos) : base(pos)
    {
    }

    public ColorCheckTile(Int32 position, Size sizeOnGrid) : base(position, sizeOnGrid)
    {
    }

    public ColorCheckTile(Grid parent, Int32 position, Size sizeOnGrid) : base(parent, position, sizeOnGrid)
    {
    }

    protected override void Paint(Graphics g)
    {
        if (DisplayAllColors)
        {
            using SolidBrush brush = new SolidBrush(Colors.Azure);
            g.FillRectangle(brush, new Rectangle(Size.Width / 6 * 0, Size.Height / 2 * 0, Size.Width / 6, Size.Height / 2));
            brush.Color = Colors.Blue;
            g.FillRectangle(brush, new Rectangle(Size.Width / 6 * 1, Size.Height / 2 * 0, Size.Width / 6, Size.Height / 2));
            brush.Color = Colors.Cyan;
            g.FillRectangle(brush, new Rectangle(Size.Width / 6 * 2, Size.Height / 2 * 0, Size.Width / 6, Size.Height / 2));
            brush.Color = Colors.DarkRed;
            g.FillRectangle(brush, new Rectangle(Size.Width / 6 * 3, Size.Height / 2 * 0, Size.Width / 6, Size.Height / 2));
            brush.Color = Colors.Gray;
            g.FillRectangle(brush, new Rectangle(Size.Width / 6 * 4, Size.Height / 2 * 0, Size.Width / 6, Size.Height / 2));
            brush.Color = Colors.Green;
            g.FillRectangle(brush, new Rectangle(Size.Width / 6 * 5, Size.Height / 2 * 0, Size.Width / 6, Size.Height / 2));
            brush.Color = Colors.LightCyan;
            g.FillRectangle(brush, new Rectangle(Size.Width / 6 * 0, Size.Height / 2 * 1, Size.Width / 6, Size.Height / 2));
            brush.Color = Colors.Orange;
            g.FillRectangle(brush, new Rectangle(Size.Width / 6 * 1, Size.Height / 2 * 1, Size.Width / 6, Size.Height / 2));
            brush.Color = Colors.Pink;
            g.FillRectangle(brush, new Rectangle(Size.Width / 6 * 2, Size.Height / 2 * 1, Size.Width / 6, Size.Height / 2));
            brush.Color = Colors.Red;
            g.FillRectangle(brush, new Rectangle(Size.Width / 6 * 3, Size.Height / 2 * 1, Size.Width / 6, Size.Height / 2));
            brush.Color = Colors.White;
            g.FillRectangle(brush, new Rectangle(Size.Width / 6 * 4, Size.Height / 2 * 1, Size.Width / 6, Size.Height / 2));
            brush.Color = Colors.Yellow;
            g.FillRectangle(brush, new Rectangle(Size.Width / 6 * 5, Size.Height / 2 * 1, Size.Width / 6, Size.Height / 2));
        }
        else
        {
            using SolidBrush brush = new SolidBrush(Colors.Red);
            g.FillRectangle(brush, new Rectangle(0, 0, Size.Width / 3, Size.Height / 2));
            brush.Color = Colors.Green;
            g.FillRectangle(brush, new Rectangle(Size.Width / 3, 0, Size.Width / 3, Size.Height / 2));
            brush.Color = Colors.Blue;
            g.FillRectangle(brush, new Rectangle(Size.Width / 3 * 2, 0, Size.Width / 3, Size.Height / 2));
            brush.Color = Colors.Gray;
            g.FillRectangle(brush, new Rectangle(0, Size.Height / 2, Size.Width / 3, Size.Height / 2));
            brush.Color = Colors.White;
            g.FillTriangle(brush, new Rectangle(0, Size.Height / 2, Size.Width / 3, Size.Height / 2), TriangleDirection.Right);
            brush.Color = Parent.Pulse ? Colors.White : Colors.Gray;
            g.FillRectangle(brush, new Rectangle(Size.Width / 3, Size.Height / 2, Size.Width / 3, Size.Height / 2));
        }
    }

    [RegisterCommand("displayallcolors", false)]
    public static bool DisplayAllColorsCommand(string[] args)
    {
        if (!Program.DebugMode) return true;
        if (args.Length == 0)
        {
            DisplayAllColors = !DisplayAllColors;
            return true;
        }
        else
        {
            if (Boolean.TryParse(args[0], out bool value))
            {
                DisplayAllColors = value;
                return true;
            }
        }
        return false;
    }
}