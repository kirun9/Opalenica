namespace Opalenica.Tiles;

using System.Drawing;
using Opalenica;

public class DoubleJunctionTile : Tile
{
    public Junction JunctionAB { get; set; }
    public Junction JunctionCD { get; set; }

    public DoubleJunctionTile(int pos, Junction junctionAB, Junction junctionCD) : base(pos)
    {
        JunctionAB = junctionAB;
        JunctionCD = junctionCD;
    }

    public DoubleJunctionTile(int position, Size sizeOnGrid, Junction junctionAB, Junction junctionCD) : base(position, sizeOnGrid)
    {
        JunctionAB = junctionAB;
        JunctionCD = junctionCD;
    }

    public DoubleJunctionTile(Grid parent, int position, Size sizeOnGrid, Junction junctionAB, Junction junctionCD) : base(parent, position, sizeOnGrid)
    {
        JunctionAB = junctionAB;
        JunctionCD = junctionCD;
    }

    protected override void Paint(Graphics g)
    {
        if (JunctionAB is not null)
        {
            using Pen B = JunctionAB.A.GetPenWithColor(Parent.Pulse);
            using Pen C = JunctionAB.A.GetPenWithColor(Parent.Pulse);

            using Pen JPen = JunctionAB.GetPenWithColor(Parent.Pulse);

            switch (JunctionAB.DrawDirection)
            {
                case JunctionDirection.JunctionL_Right:
                    if (JunctionAB.Direction is JunctionSet.AB)
                        g.DrawLine(JPen, Width / 2, Height / 2, Width, Height / 2);
                    else if (JunctionAB.Direction is JunctionSet.AC)
                        g.DrawLine(JPen, Width / 2, Height / 2, Width, 0);
                    if (JunctionCD.Direction is JunctionSet.AB)
                        g.DrawLine(JPen, Width / 2, Height / 2, 0, Height / 2);
                    else if (JunctionCD.Direction is JunctionSet.AC)
                        g.DrawLine(JPen, Width / 2, Height / 2, 0, Height);
                    break;
                case JunctionDirection.JunctionR_Right:
                    if (JunctionAB.Direction is JunctionSet.AB)
                        g.DrawLine(JPen, Width / 2, Height / 2, Width, Height / 2);
                    else if (JunctionAB.Direction is JunctionSet.AC)
                        g.DrawLine(JPen, Width / 2, Height / 2, Width, Height);
                    if (JunctionCD.Direction is JunctionSet.AB)
                        g.DrawLine(JPen, Width / 2, Height / 2, 0, Height / 2);
                    else if (JunctionCD.Direction is JunctionSet.AC)
                        g.DrawLine(JPen, Width / 2, Height / 2, 0, 0);
                    break;
                case JunctionDirection.JunctionL_Left:
                    if (JunctionAB.Direction is JunctionSet.AB)
                        g.DrawLine(JPen, Width / 2, Height / 2, 0, Height / 2);
                    else if (JunctionAB.Direction is JunctionSet.AC)
                        g.DrawLine(JPen, Width / 2, Height / 2, 0, Height);
                    if (JunctionCD.Direction is JunctionSet.AB)
                        g.DrawLine(JPen, Width / 2, Height / 2, Width, Height / 2);
                    else if (JunctionCD.Direction is JunctionSet.AC)
                        g.DrawLine(JPen, Width / 2, Height / 2, Width, 0);
                    break;
                case JunctionDirection.JunctionR_Left:
                    if (JunctionAB.Direction is JunctionSet.AB)
                        g.DrawLine(JPen, 0, Height / 2, Width / 2, Height / 2);
                    else if (JunctionAB.Direction is JunctionSet.AC)
                        g.DrawLine(JPen, 0, 0, Width / 2, Height / 2);
                    if (JunctionCD.Direction is JunctionSet.AB)
                        g.DrawLine(JPen, Width / 2, Height / 2, Width, Height / 2);
                    else if (JunctionCD.Direction is JunctionSet.AC)
                        g.DrawLine(JPen, Width / 2, Height / 2, Width, Height);
                    break;
                case JunctionDirection.JunctionL_Down:
                    if (JunctionAB.Direction is JunctionSet.AB)
                        g.DrawLine(JPen, Width / 2, Height / 2, Width / 2, Height);
                    else if (JunctionAB.Direction is JunctionSet.AC)
                        g.DrawLine(JPen, Width / 2, Height / 2, Width, Height);
                    if (JunctionCD.Direction is JunctionSet.AB)
                        g.DrawLine(JPen, Width / 2, Height / 2, Width / 2, 0);
                    else if (JunctionCD.Direction is JunctionSet.AC)
                        g.DrawLine(JPen, Width / 2, Height / 2, 0, 0);
                    break;
                case JunctionDirection.JunctionR_Down:
                    if (JunctionAB.Direction is JunctionSet.AB)
                        g.DrawLine(JPen, Width / 2, Height / 2, Width / 2, Height);
                    else if (JunctionAB.Direction is JunctionSet.AC)
                        g.DrawLine(JPen, Width / 2, Height / 2, 0, Height);
                    if (JunctionCD.Direction is JunctionSet.AB)
                        g.DrawLine(JPen, Width / 2, Height / 2, Width / 2, 0);
                    else if (JunctionCD.Direction is JunctionSet.AC)
                        g.DrawLine(JPen, Width / 2, Height / 2, Width, 0);
                    break;
                case JunctionDirection.JunctionL_Up:
                    if (JunctionAB.Direction is JunctionSet.AB)
                        g.DrawLine(JPen, Width / 2, Height / 2, Width / 2, 0);
                    else if (JunctionAB.Direction is JunctionSet.AC)
                        g.DrawLine(JPen, Width / 2, Height / 2, 0, 0);
                    if (JunctionCD.Direction is JunctionSet.AB)
                        g.DrawLine(JPen, Width / 2, Height / 2, Width / 2, Height);
                    else if (JunctionCD.Direction is JunctionSet.AC)
                        g.DrawLine(JPen, Width / 2, Height / 2, Width, Height);
                    break;
                case JunctionDirection.JunctionR_Up:
                    if (JunctionAB.Direction is JunctionSet.AB)
                        g.DrawLine(JPen, Width / 2, Height / 2, Width / 2, 0);
                    else if (JunctionAB.Direction is JunctionSet.AC)
                        g.DrawLine(JPen, Width / 2, Height / 2, Width, 0);
                    if (JunctionCD.Direction is JunctionSet.AB)
                        g.DrawLine(JPen, Width / 2, Height / 2, Width / 2, Height);
                    else if (JunctionCD.Direction is JunctionSet.AC)
                        g.DrawLine(JPen, Width / 2, Height / 2, 0, Height);
                    break;
            }
        }
    }
}