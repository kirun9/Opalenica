namespace Opalenica.Tiles;
public class CrossTrack : Element {
    private static List<CrossTrack> RegisteredCrosses = new List<CrossTrack>();

    public Track TrackA { get; set; }
    public Track TrackB { get; set; }
    public CrossMainTrackDirection Direction { get; set; }
    public string Name { get; set; } = "CrossTrackElement";

    public static CrossTrack GetCross(string name, Track trackA, Track trackB, CrossMainTrackDirection direction = CrossMainTrackDirection.TopLeft_BottomRight) {
        var cross = RegisteredCrosses.FirstOrDefault(e => e?.Name == name, null);
        if (cross is not null) return cross;
        cross = new CrossTrack();
        cross.Name = name;
        cross.TrackA = trackA;
        cross.TrackB = trackB;
        cross.Direction = direction;
        RegisteredCrosses.Add(cross);
        return cross;
    }
}