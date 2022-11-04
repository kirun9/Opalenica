using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Opalenica.Tiles;

public class Kostka : Tile {

    private String folderPath = "../../../KostkiPNG/Tile_";

    private Image backgroundImage;

    //Kostka Data:
    KostkaTypes type;

    //Only position - blank tile
    public Kostka(Int32 position) : base(position) {

    }

    //Position + 
    public Kostka(Int32 position, String name) : base(position) {
        backgroundImage = Image.FromFile(folderPath + name + ".png");
    }


    protected override void Paint(Graphics g) {
        g.DrawImage(backgroundImage, 0, 0, Width, Height);
    }

}


