using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Opalenica.Tiles;

public class Kostka : Tile {

    private Image backgroundTile = Image.FromFile("../../../KostkiPNG/Blank.png");

    //Kostka Data:
    bool isWithControl, isFlipped;
    int rotation, startState;
    KostkaTypes type;

    //Only position - blank tile
    public Kostka(Int32 position) : base(position) {

    }

    //Tile with something on it
    public Kostka(Int32 position, KostkaTypes type, bool isWithControl, bool isFlipped, int rotation, int startState = 0) : base(position) {
        //Check if rotation is one of four
        if (rotation is >= 0 or <= 3) throw new ArgumentException("Value must be greater than 0 and less than 3", nameof(rotation));
        this.isWithControl = isWithControl;
        this.isFlipped = isFlipped;
        this.rotation = rotation;
        this.startState = startState;
        this.type = type;
    }

    protected override void Paint(Graphics g) {
        g.DrawImage(backgroundTile, 0, 0, Width, Height);
    }

}


