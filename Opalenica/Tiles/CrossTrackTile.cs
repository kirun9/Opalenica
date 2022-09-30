namespace Opalenica.Tiles;

public class CrossTrackTile : Tile
{
    private CrossTrack Cross { get; set; }

    public CrossTrackTile(int pos, CrossTrack cross) : base(pos)
    {
        Cross = cross;
    }

    public CrossTrackTile(int position, Size sizeOnGrid, CrossTrack cross) : base(position, sizeOnGrid)
    {
        Cross = cross;
    }

    public CrossTrackTile(Grid parent, int position, Size sizeOnGrid, CrossTrack cross) : base(parent, position, sizeOnGrid)
    {
        Cross = cross;
    }

    protected override void Paint(Graphics g)
    {
        // checking priotytetes on colors
        Pen penA, penB;
        bool aPriority = false;
        if (Cross.TrackA.Data is TrackData.PrzebiegPociagowy or TrackData.PrzebiegManewrowy or TrackData.OchronaPrzebiegu)
        {
            aPriority = true;
            penA = Cross.TrackA.GetPenWithColor(Parent.Pulse);
            penB = Cross.TrackB.GetPenWithColor(Parent.Pulse, TrackData.StanPodstawowy);
        }
        else if (Cross.TrackB.Data is TrackData.PrzebiegPociagowy or TrackData.PrzebiegManewrowy or TrackData.OchronaPrzebiegu)
        {
            penA = Cross.TrackA.GetPenWithColor(Parent.Pulse, TrackData.StanPodstawowy);
            penB = Cross.TrackB.GetPenWithColor(Parent.Pulse);
        }
        else
        {
            aPriority = true;
            penA = Cross.TrackA.GetPenWithColor(Parent.Pulse);
            penB = Cross.TrackB.GetPenWithColor(Parent.Pulse);
        }

        switch (Cross.Direction)
        {
            case CrossMainTrackDirection.TopLeft_BottomRight:
                if (aPriority)
                    g.DrawLine(penB, 0, Height, Width, 0);
                g.DrawLine(penA, 0, 0, Width, Height);
                if (!aPriority)
                    g.DrawLine(penB, 0, Height, Width, 0);
                break;
            case CrossMainTrackDirection.TopRight_BottomLeft:
            default:
                if (aPriority)
                    g.DrawLine(penB, 0, 0, Width, Height);
                g.DrawLine(penA, 0, Height, Width, 0);
                if (!aPriority)
                    g.DrawLine(penB, 0, 0, Width, Height);
                break;
        }
    }
}