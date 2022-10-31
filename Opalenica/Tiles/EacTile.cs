namespace Opalenica.Tiles;

using Opalenica.Interfaces;
using Opalenica.Tiles.Interfaces;

using System.Drawing;
using System.Windows.Forms;

public class EacTile : Tile, IMouseEvent, IHasMenuStrip
{
    public BlokadaEac Blokada { get; set; }

    public ArrowDirection DrawDirection { get; set; }

    public override bool IsSelected => Blokada.IsSelected;

    public EacTile(int pos, BlokadaEac blokada) : base(pos)
    {
        Blokada = blokada;
    }

    public EacTile(int position, Size sizeOnGrid, BlokadaEac blokada) : base(position, sizeOnGrid)
    {
        Blokada = blokada;
    }

    public EacTile(Grid parent, int position, Size sizeOnGrid, BlokadaEac blokada) : base(parent, position, sizeOnGrid)
    {
        Blokada = blokada;
    }

    protected override void Paint(Graphics g)
    {
        using SolidBrush brushA = new SolidBrush(Blokada.ColorA);
        using SolidBrush brushB = new SolidBrush(Blokada.ColorA);

        SizeF partSize = new SizeF(Width / 3 * 0.9f, Height * 0.80f);
        Point middle1 = new Point(Width / 3, 0);
        Point middle2 = new Point(Width / 3 * 2, 0);
        float gapLeft = partSize.Width * 0.05f;
        float gapTop = Height * 0.1f;

        RectangleF part1 = new RectangleF(gapLeft, gapTop, partSize.Width, partSize.Height);
        RectangleF part2 = new RectangleF(middle1.X + gapLeft, gapTop, partSize.Width, partSize.Height);
        RectangleF part3 = new RectangleF(middle2.X + gapLeft, gapTop, partSize.Width, partSize.Height);

        switch (Blokada.Kierunek)
        {
            case BlokadaKierunek.Neutralny:
            case BlokadaKierunek.Nieznany:
                using (Pen pen = new Pen(Blokada.ColorA, 1))
                {
                    g.DrawRectangle(pen, part1.X, part1.Y, part1.Width, part1.Height);
                    g.DrawRectangle(pen, part2.X, part2.Y, part2.Width, part2.Height);
                    g.DrawRectangle(pen, part3.X, part3.Y, part3.Width, part3.Height);
                }
                break;
            case BlokadaKierunek.Przyjazd:

                break;
            case BlokadaKierunek.Wyjazd:

                break;
        }
    }

    public ContextMenuStrip GetMenuStrip()
    {
        ContextMenuStrip strip = new ContextMenuStrip();
        ToolStripMenuItem menuItem = new ToolStripMenuItem("test");
        strip.Items.Add(menuItem);
        return strip;
    }

    void IMouseEvent.OnMouseClick(MouseEventArgs e)
    {
        throw new NotImplementedException();
    }
}
