using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Opalenica.Tiles;

public class Kostka : Tile {

    private readonly String folderPath = "../../../KostkiPNG/";

    private Image backgroundImage;
    public Rectangle buttonPosition = new Rectangle(0, 0, 10, 10);
    public bool hasButton = false;
    private int plusPosition;

    //If it's straight
    private Image[] straightLamp = new Image[4];
    //If it's junction add angle
    private Image[] angleLamp = new Image[4];

    //Helping RotateFlipType
    RotateFlipType rotateFlipType;
    //Kostka Data:
    private KostkaTypes type; //Type of given Kostka
    private int junctionPosition; //0 - plus, 1 - minus

    public void setType(KostkaTypes typ, int mirrorHorizontal, int mirrorVertical, int rotate, int buttonPos, int plusPos = 0) {
        if (buttonPos != 0) {
            hasButton = true;
            switch (buttonPos) {
                case 1:
                    buttonPosition.Location = new Point(X + 5, Y + 5);
                    break;
                case 2:
                    buttonPosition.Location = new Point(X + 29, Y + 5);
                    break;
                case 3:
                    buttonPosition.Location = new Point(X + 5, Y + 29);
                    break;
                case 4:
                    buttonPosition.Location = new Point(X + 29, Y + 29);
                    break;
            }
        }
        plusPosition = plusPos;
        junctionPosition = plusPosition;

        if(mirrorHorizontal == 0 && mirrorVertical == 0) {
            if(rotate == 0) {
                rotateFlipType = RotateFlipType.RotateNoneFlipNone;
            }
            else {
                rotateFlipType = RotateFlipType.Rotate90FlipNone;
            }
        }
        else if(mirrorHorizontal == 0 && mirrorVertical == 1){
            if (rotate == 0) {
                rotateFlipType = RotateFlipType.RotateNoneFlipY;
            }
            else {
                rotateFlipType = RotateFlipType.Rotate90FlipY;
            }
        }
        else if (mirrorHorizontal == 1 && mirrorVertical == 0) {
            if (rotate == 0) {
                rotateFlipType = RotateFlipType.RotateNoneFlipX;
            }
            else {
                rotateFlipType = RotateFlipType.Rotate90FlipX;
            }
        }
        else if (mirrorHorizontal == 1 && mirrorVertical == 1) {
            if (rotate == 0) {
                rotateFlipType = RotateFlipType.RotateNoneFlipY;
                rotateFlipType = RotateFlipType.RotateNoneFlipX;
            }
            else {
                rotateFlipType = RotateFlipType.Rotate90FlipY;
                rotateFlipType = RotateFlipType.RotateNoneFlipX;
            }
        }


        this.type = typ;
        switch (type) {
            case KostkaTypes.Prosty:
                (straightLamp[0] = Image.FromFile(folderPath + "Straight_Black.png")).RotateFlip(rotateFlipType);
                (straightLamp[1] = Image.FromFile(folderPath + "Straight_Yellow.png")).RotateFlip(rotateFlipType);
                (straightLamp[2] = Image.FromFile(folderPath + "Straight_White.png")).RotateFlip(rotateFlipType);
                (straightLamp[3] = Image.FromFile(folderPath + "Straight_Red.png")).RotateFlip(rotateFlipType);
                break;
            case KostkaTypes.Rozjazd:
                //Straight
                (straightLamp[0] = Image.FromFile(folderPath + "Straight_Black.png")).RotateFlip(rotateFlipType);
                (straightLamp[1] = Image.FromFile(folderPath + "Straight_Yellow.png")).RotateFlip(rotateFlipType);
                (straightLamp[2] = Image.FromFile(folderPath + "Straight_White.png")).RotateFlip(rotateFlipType);
                (straightLamp[3] = Image.FromFile(folderPath + "Straight_Red.png")).RotateFlip(rotateFlipType);
                //Angle
                (angleLamp[0] = Image.FromFile(folderPath + "Angle_Black.png")).RotateFlip(rotateFlipType);
                (angleLamp[1] = Image.FromFile(folderPath + "Angle_Yellow.png")).RotateFlip(rotateFlipType);
                (angleLamp[2] = Image.FromFile(folderPath + "Angle_White.png")).RotateFlip(rotateFlipType);
                (angleLamp[3] = Image.FromFile(folderPath + "Angle_Red.png")).RotateFlip(rotateFlipType);
                break;
            case KostkaTypes.Skos:
                (angleLamp[0] = Image.FromFile(folderPath + "Angle_Black.png")).RotateFlip(rotateFlipType);
                (angleLamp[1] = Image.FromFile(folderPath + "Angle_Yellow.png")).RotateFlip(rotateFlipType);
                (angleLamp[2] = Image.FromFile(folderPath + "Angle_White.png")).RotateFlip(rotateFlipType);
                (angleLamp[3] = Image.FromFile(folderPath + "Angle_Red.png")).RotateFlip(rotateFlipType);
                break;
        }

    }

    //Only position - blank tile
    public Kostka(Int32 position) : base(position) {

    }

    //Position + backgr img
    public Kostka(Int32 position, String name) : base(position) {
        backgroundImage = Image.FromFile(folderPath + "Tile_" + name + ".png");
    }


    protected override void Paint(Graphics g) {
        g.DrawImage(backgroundImage, 0, 0, Width, Height);

        //Junction type - ROZJAZD:
        if(type == KostkaTypes.Rozjazd) {
            if (junctionPosition == 0) {
                g.DrawImage(straightLamp[1], 0, 0, Width, Height);
                g.DrawImage(angleLamp[0], 0, 0, Width, Height);
            }
            else if (junctionPosition == 1) {
                g.DrawImage(straightLamp[0], 0, 0, Width, Height);
                g.DrawImage(angleLamp[1], 0, 0, Width, Height);
            }
        }
        
        
    }

}


