using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Opalenica.Tiles;

public class Kostka : Tile {

    private String folderPath = "../../../KostkiPNG/";

    private Image backgroundImage;
    int buttonPosition;

    //If it's straight
    private Image[] straightLamp = new Image[4];
    //If it's junction add angle
    private Image[] angleLamp = new Image[4];

    //Helping RotateFlipType
    RotateFlipType rotateFlipType;
    //Kostka Data:
    public KostkaTypes type;
    public void setType(KostkaTypes typ, int mirrorHorizontal, int mirrorVertical, int rotate, bool hasButton, int buttonPos) {
        if (hasButton) {
            buttonPosition = buttonPos;
        }

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
                (straightLamp[0] = Image.FromFile(folderPath + "Straight_Black")).RotateFlip(rotateFlipType);
                (straightLamp[1] = Image.FromFile(folderPath + "Straight_Yellow")).RotateFlip(rotateFlipType);
                (straightLamp[2] = Image.FromFile(folderPath + "Straight_White")).RotateFlip(rotateFlipType);
                (straightLamp[3] = Image.FromFile(folderPath + "Straight_Red")).RotateFlip(rotateFlipType);
                break;
            case KostkaTypes.Rozjazd:
                //Straight
                (straightLamp[0] = Image.FromFile(folderPath + "Straight_Black")).RotateFlip(rotateFlipType);
                (straightLamp[1] = Image.FromFile(folderPath + "Straight_Yellow")).RotateFlip(rotateFlipType);
                (straightLamp[2] = Image.FromFile(folderPath + "Straight_White")).RotateFlip(rotateFlipType);
                (straightLamp[3] = Image.FromFile(folderPath + "Straight_Red")).RotateFlip(rotateFlipType);
                //Angle
                (angleLamp[0] = Image.FromFile(folderPath + "Angle_Black")).RotateFlip(rotateFlipType);
                (angleLamp[1] = Image.FromFile(folderPath + "Angle_Yellow")).RotateFlip(rotateFlipType);
                (angleLamp[2] = Image.FromFile(folderPath + "Angle_White")).RotateFlip(rotateFlipType);
                (angleLamp[3] = Image.FromFile(folderPath + "Angle_Red")).RotateFlip(rotateFlipType);
                break;
            case KostkaTypes.Skos:
                (angleLamp[0] = Image.FromFile(folderPath + "Angle_Black")).RotateFlip(rotateFlipType);
                (angleLamp[1] = Image.FromFile(folderPath + "Angle_Yellow")).RotateFlip(rotateFlipType);
                (angleLamp[2] = Image.FromFile(folderPath + "Angle_White")).RotateFlip(rotateFlipType);
                (angleLamp[3] = Image.FromFile(folderPath + "Angle_Red")).RotateFlip(rotateFlipType);
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
    }

}


