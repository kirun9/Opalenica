namespace Opalenica.Tiles;

using System.Drawing;
using Opalenica;

public class JunctionTile : Tile
{
    public Junction Junction { get; set; }

    public override bool IsSelected => Junction.IsSelected;

    public JunctionTile(int pos, Junction junction) : base(pos)
    {
        Junction = junction;
    }

    public JunctionTile(int position, Size sizeOnGrid, Junction junction) : base(position, sizeOnGrid)
    {
        Junction = junction;
    }

    public JunctionTile(Grid parent, int position, Size sizeOnGrid, Junction junction) : base(parent, position, sizeOnGrid)
    {
        Junction = junction;
    }

    protected override void Paint(Graphics g)
    {
        if (Junction is not null)
        {
            using Pen A = Junction.A.GetPenWithColor(Parent.Pulse);
            using Pen B = Junction.A.GetPenWithColor(Parent.Pulse);
            using Pen C = Junction.A.GetPenWithColor(Parent.Pulse);

            using Pen JPen = Junction.GetPenWithColor(Parent.Pulse);

            switch (Junction.DrawDirection)
            {
                case JunctionDirection.JunctionL_Right:
                    g.DrawLine(A, 0, Height / 2, Width / 2, Height / 2);
                    if (Junction.Direction is JunctionSet.AB)
                        g.DrawLine(JPen, Width / 2, Height / 2, Width, Height / 2);
                    else if (Junction.Direction is JunctionSet.AC)
                        g.DrawLine(JPen, Width / 2, Height / 2, Width, 0);
                    break;
                case JunctionDirection.JunctionR_Right:
                    g.DrawLine(A, 0, Height / 2, Width / 2, Height / 2);
                    if (Junction.Direction is JunctionSet.AB)
                        g.DrawLine(JPen, Width / 2, Height / 2, Width, Height / 2);
                    else if (Junction.Direction is JunctionSet.AC)
                        g.DrawLine(JPen, Width / 2, Height / 2, Width, Height);
                    break;
                case JunctionDirection.JunctionR_Left:
                    g.DrawLine(A, Width / 2, Height / 2, Width, Height / 2);
                    if (Junction.Direction is JunctionSet.AB)
                        g.DrawLine(JPen, 0, Height / 2, Width / 2, Height / 2);
                    else if (Junction.Direction is JunctionSet.AC)
                        g.DrawLine(JPen, 0, 0, Width / 2, Height / 2);
                    break;
                case JunctionDirection.JunctionL_Left:
                    g.DrawLine(A, Width / 2, Height / 2, Width, Height / 2);
                    if (Junction.Direction is JunctionSet.AB)
                        g.DrawLine(JPen, Width / 2, Height / 2, 0, Height / 2);
                    else if (Junction.Direction is JunctionSet.AC)
                        g.DrawLine(JPen, Width / 2, Height / 2, 0, Height);
                    break;
                case JunctionDirection.JunctionL_Down:
                    g.DrawLine(A, Width / 2, Height / 2, Width / 2, 0);
                    if (Junction.Direction is JunctionSet.AB)
                        g.DrawLine(JPen, Width / 2, Height / 2, Width / 2, Height);
                    else if (Junction.Direction is JunctionSet.AC)
                        g.DrawLine(JPen, Width / 2, Height / 2, Width, Height);
                    break;
                case JunctionDirection.JunctionR_Down:
                    g.DrawLine(A, Width / 2, Height / 2, Width / 2, 0);
                    if (Junction.Direction is JunctionSet.AB)
                        g.DrawLine(JPen, Width / 2, Height / 2, Width / 2, Height);
                    else if (Junction.Direction is JunctionSet.AC)
                        g.DrawLine(JPen, Width / 2, Height / 2, 0, Height);
                    break;
                case JunctionDirection.JunctionL_Up:
                    g.DrawLine(A, Width / 2, Height, Width / 2, Height / 2);
                    if (Junction.Direction is JunctionSet.AB)
                        g.DrawLine(JPen, Width / 2, Height / 2, Width / 2, 0);
                    else if (Junction.Direction is JunctionSet.AC)
                        g.DrawLine(JPen, Width / 2, Height / 2, 0, 0);
                    break;
                case JunctionDirection.JunctionR_Up:
                    g.DrawLine(A, Width / 2, Height, Width / 2, Height / 2);
                    if (Junction.Direction is JunctionSet.AB)
                        g.DrawLine(JPen, Width / 2, Height / 2, Width / 2, 0);
                    else if (Junction.Direction is JunctionSet.AC)
                        g.DrawLine(JPen, Width / 2, Height / 2, Width, 0);
                    break;
            }
        }
    }
}