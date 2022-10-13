namespace Opalenica.Tiles;

using Opalenica.Tiles.Interfaces;

using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

public class TrackCurveTile : TrackTile
{
    //public Track Track { get; set; }
    private CurveDirection direction;

    //public override bool IsSelected => Track.IsSelected;

    public CurveDirection Direction
    {
        get
        {
            return direction;
        }
        set
        {
            var v = value;
            if (!Enum.IsDefined(typeof(CurveDirection), v))
                throw new ArgumentException($"{Enum.GetName(typeof(CurveDirection), v)} is not defined in enum {nameof(CurveDirection)}", nameof(Direction));
            direction = v;
        }
    }

    public TrackCurveTile(int pos, Track track, CurveDirection direction = CurveDirection.FromLeftTurnLeft45) : base(pos, track)
    {
        Direction = direction;
    }

    public TrackCurveTile(int position, Size sizeOnGrid, Track track, CurveDirection direction = CurveDirection.FromLeftTurnLeft45) : base(position, sizeOnGrid, track)
    {
        Direction = direction;
    }

    public TrackCurveTile(Grid parent, int position, Size sizeOnGrid, Track track, CurveDirection direction = CurveDirection.FromLeftTurnLeft45) : base(parent, position, sizeOnGrid, track)
    {
        Direction = direction;
    }

    protected override void Paint(Graphics g)
    {
        Point Left() => new Point(0, Height / 2);
        Point Right() => new Point(Width, Height / 2);
        Point Top() => new Point(Width / 2, 0);
        Point Bottom() => new Point(Width / 2, Height);
        Point Center() => new Point(Width / 2, Height / 2);
        Point TopRight() => new Point(Width, 0);
        Point TopLeft() => new Point(0, 0);
        Point BottomRight() => new Point(Width, Height);
        Point BottomLeft() => new Point(0, Height);

        using Pen pen = Track.GetPenWithColor(Pulse);

        (Point p1, Point p3) ps;

        ps = direction switch
        {
            CurveDirection.FromLeftTurnLeft45   => (Left()  , TopRight()   ),
            CurveDirection.FromLeftTurnLeft90   => (Left()  , Top()        ),
            CurveDirection.FromLeftTurnRight45  => (Left()  , BottomRight()),
            CurveDirection.FromLeftTurnRight90  => (Left()  , Bottom()     ),
            CurveDirection.FromTopTurnLeft45    => (Top()   , BottomRight()),
            CurveDirection.FromTopTurnLeft90    => (Top()   , Right()      ),
            CurveDirection.FromTopTurnRight45   => (Top()   , BottomLeft() ),
            CurveDirection.FromTopTurnRight90   => (Top()   , Left()       ),
            CurveDirection.FromRightTurnLeft45  => (Right() , BottomLeft() ),
            CurveDirection.FromRightTurnLeft90  => (Right() , Bottom()     ),
            CurveDirection.FromRightTurnRight45 => (Right() , TopLeft()    ),
            CurveDirection.FromRightTurnRight90 => (Right() , Top()        ),
            CurveDirection.FromDownTurnLeft45   => (Bottom(), TopRight()   ),
            CurveDirection.FromDownTurnLeft90   => (Bottom(), Right()      ),
            CurveDirection.FromDownTurnRight45  => (Bottom(), TopLeft()    ),
            CurveDirection.FromDownTurnRight90  => (Bottom(), Left()       ),
            _                                   => (Center(), Center()     )
        };

        g.DrawLine(pen, ps.p1, Center());
        g.DrawLine(pen, Center(), ps.p3);
    }

    /*void IMouseEvent.OnMouseClick(MouseEventArgs e)
    {
        if (IsSelected)
        {
            Track.Unselect();
        }
        else
        {
            Track.Select();
        }
    }*/
}

[Flags]
public enum CurveDirection
{
    FromLeftTurnLeft45,
    FromLeftTurnLeft90,
    FromLeftTurnRight45,
    FromLeftTurnRight90,

    FromTopTurnLeft45,
    FromTopTurnLeft90,
    FromTopTurnRight45,
    FromTopTurnRight90,

    FromRightTurnLeft45,
    FromRightTurnLeft90,
    FromRightTurnRight45,
    FromRightTurnRight90,

    FromDownTurnLeft45,
    FromDownTurnLeft90,
    FromDownTurnRight45,
    FromDownTurnRight90,
}