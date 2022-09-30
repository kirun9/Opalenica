namespace Opalenica;

using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;

internal class Pulpit : Control
{
    private readonly Size designSize = new Size(1366, 768);
    private (float horizontal, float vertical) scale = (1, 1);
    private List<PulpitElement> pulpit = new List<PulpitElement>();
    public static List<Data> Data = new List<Data>();

#if DEBUG
    private Stopwatch watch;
#endif

    public Pulpit() : base()
    {
#if DEBUG
        watch = new Stopwatch();
        watch.Stop();
#endif
        this.DoubleBuffered = true;
        RegisterElements();
    }

    protected override void OnSizeChanged(EventArgs e)
    {
        base.OnSizeChanged(e);
        calculateScale();
    }

    private void calculateScale()
    {
        scale = ((float) Width / designSize.Width, (float) Height / designSize.Height);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
#if DEBUG
        watch.Restart();
#endif
        base.OnPaint(e);
        calculateScale();

        using Bitmap bitmap = new Bitmap(designSize.Width, designSize.Height);
        using Graphics g = Graphics.FromImage(bitmap);
        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
        g.SmoothingMode = SmoothingMode.None;
        g.PixelOffsetMode = PixelOffsetMode.Half;

        using (SolidBrush b = new SolidBrush(Colors.Black))
        {
            g.FillRectangle(b, 0, 0, bitmap.Width, bitmap.Height);
            b.Color = Color.FromArgb(255, 0, 0);
            g.FillRectangle(b, 10, 10, 30, 50);
            b.Color = Color.FromArgb(0, 255, 0);
            g.FillRectangle(b, 40, 10, 30, 50);
            b.Color = Color.FromArgb(0, 0, 255);
            g.FillRectangle(b, 70, 10, 30, 50);
        }
        DrawPulpit(g);
        DrawDebugOverlay(g);

        e.Graphics.DrawImage(bitmap, 0, 0, Width, Height);

#if DEBUG
        watch.Stop();
        using Brush textBrush = new SolidBrush(Colors.White);
        using Font f = new Font(Font.FontFamily, 8f, FontStyle.Bold);
        string s = $"DEBUG MODE\n\nDraw Time {watch.Elapsed:s\\.fff} s\n" +
            $"Scale: {scale.horizontal} x {scale.vertical}\n" +
            $"Design resolution: {designSize.Width} x {designSize.Height}\n" +
            $"Display: {OpalenicaForm.actualScreen.DeviceName} - {Width} x {Height}\n" +
            $"Displaying in window: {Parent switch { Form form => !(form.WindowState == FormWindowState.Maximized), _ => "unknown" }}";
        var sizef = e.Graphics.MeasureString(s, f);
        e.Graphics.FillRectangle(Brushes.DimGray, 5, Height - (sizef.Height + 15), sizef.Width + 10, sizef.Height + 10);
        e.Graphics.DrawString(s, f, textBrush, 10, Height - (sizef.Height + 10));
#endif
    }

    protected void DrawDebugOverlay(Graphics g)
    {
        using Pen pen = new Pen(Color.Pink);
        for (int x = 5; x < Size.Width; x += 30)
        {
            for (int y = 10; y < Size.Height; y += 20)
            {
                g.DrawRectangle(pen, x, y, 30, 20);
            }
        }
    }

    /**
     *  Przyjąłem 10 pixeli w górę, przy 3 pixelach w bok dla skosów (coś około 73 stopni)
     *  później pewnie zmienię ten skos
     *  zobaczę jak będzie to wyglądać w ostatecznej wersji
     *  :)
     */
    protected void RegisterElements()
    {
        pulpit.Clear();

        /*pulpit.AddElement(new Semafor() { Name = "R", Location = new Location(145, 200), Type = SemaforType.Pociagowy, Direction = TriangleDirection.Right });
        pulpit.AddElement(new Semafor() { Name = "S", Location = new Location(145, 300), Type = SemaforType.Pociagowy, Direction = TriangleDirection.Right });

        pulpit.AddElement(new Semafor() { Name = "P", Location = new Location(295, 100), Type = SemaforType.PociagowyManewrowy, Direction = TriangleDirection.Left });
        pulpit.AddElement(new Semafor() { Name = "O", Location = new Location(295, 200), Type = SemaforType.PociagowyManewrowy, Direction = TriangleDirection.Left });
        pulpit.AddElement(new Semafor() { Name = "N", Location = new Location(325, 300), Type = SemaforType.PociagowyManewrowy, Direction = TriangleDirection.Left });
        pulpit.AddElement(new Semafor() { Name = "M", Location = new Location(355, 400), Type = SemaforType.PociagowyManewrowy, Direction = TriangleDirection.Left });
        pulpit.AddElement(new Semafor() { Name = "L", Location = new Location(385, 500), Type = SemaforType.PociagowyManewrowy, Direction = TriangleDirection.Left });

        pulpit.AddElement(new Semafor() { Name = "D", Location = new Location(965, 100), Type = SemaforType.PociagowyManewrowy, Direction = TriangleDirection.Right });
        pulpit.AddElement(new Semafor() { Name = "E", Location = new Location(915, 200), Type = SemaforType.PociagowyManewrowy, Direction = TriangleDirection.Right });
        pulpit.AddElement(new Semafor() { Name = "F", Location = new Location(915, 300), Type = SemaforType.PociagowyManewrowy, Direction = TriangleDirection.Right });
        pulpit.AddElement(new Semafor() { Name = "G", Location = new Location(845, 400), Type = SemaforType.PociagowyManewrowy, Direction = TriangleDirection.Right });
        pulpit.AddElement(new Semafor() { Name = "H", Location = new Location(815, 500), Type = SemaforType.PociagowyManewrowy, Direction = TriangleDirection.Right });

        pulpit.AddElement(new Semafor() { Name = "A", Location = new Location(1065, 100), Type = SemaforType.Pociagowy, Direction = TriangleDirection.Left });
        pulpit.AddElement(new Semafor() { Name = "B", Location = new Location(1035, 200), Type = SemaforType.Pociagowy, Direction = TriangleDirection.Left });
        pulpit.AddElement(new Semafor() { Name = "C", Location = new Location(1035, 300), Type = SemaforType.Pociagowy, Direction = TriangleDirection.Left });

        /*pulpit.AddElement(new Track() { Name = "outR"     , Location = new Location(30 , 200, 130, 200) });
        pulpit.AddElement(new Track() { Name = "R-14ab"   , Location = new Location(160, 200, 230, 200) });
        pulpit.AddElement(new Track() { Name = "outS"     , Location = new Location(30 , 300, 130, 300) });
        pulpit.AddElement(new Track() { Name = "S-15"     , Location = new Location(160, 300, 200, 300) });
        pulpit.AddElement(new Track() { Name = "15-14ab"  , Location = new Location(200, 300, 230, 200) });
        pulpit.AddElement(new Track() { Name = "14cd-13"  , Location = new Location(230, 200, 260, 100) });
        pulpit.AddElement(new Track() { Name = "13-P"     , Location = new Location(260, 100, 280, 100) });
        pulpit.AddElement(new Track() { Name = "13-End"   , Location = new Location(260, 100, 200, 100) });
        pulpit.AddElement(new Track() { Name = "14cd-12"  , Location = new Location(230, 200, 260, 200) });
        pulpit.AddElement(new Track() { Name = "12-O"     , Location = new Location(260, 200, 280, 200) });
        pulpit.AddElement(new Track() { Name = "12-11ab"  , Location = new Location(260, 200, 290, 300) });
        pulpit.AddElement(new Track() { Name = "15-11ab"  , Location = new Location(200, 300, 290, 300) });
        pulpit.AddElement(new Track() { Name = "11cd-N"   , Location = new Location(290, 300, 310, 300) });
        pulpit.AddElement(new Track() { Name = "11cd-10ab", Location = new Location(290, 300, 320, 400) });
        pulpit.AddElement(new Track() { Name = "10cd-M"   , Location = new Location(320, 400, 340, 400) });
        pulpit.AddElement(new Track() { Name = "10ab-End" , Location = new Location(320, 400, 200, 400) });
        pulpit.AddElement(new Track() { Name = "10cd-L"   , Location = new Location(320, 400, 350, 500) });
        pulpit.AddElement(new Track() { Name = "10cd-L"   , Location = new Location(350, 500, 370, 500) });

        pulpit.AddElement(new Track() { Name = "Tr3"      , Location = new Location(310, 100, 950, 100) });
        pulpit.AddElement(new Track() { Name = "Tr1"      , Location = new Location(310, 200, 900, 200) });
        pulpit.AddElement(new Track() { Name = "Tr2"      , Location = new Location(340, 300, 900, 300) });
        pulpit.AddElement(new Track() { Name = "Tr4"      , Location = new Location(370, 400, 830, 400) });
        pulpit.AddElement(new Track() { Name = "Tr6"      , Location = new Location(400, 500, 800, 500) });

        pulpit.AddElement(new Track() { Name = "H-4"      , Location = new Location(830, 500, 850, 500) });
        pulpit.AddElement(new Track() { Name = "H-4"      , Location = new Location(850, 500, 880, 400) });
        pulpit.AddElement(new Track() { Name = "G-4"      , Location = new Location(860, 400, 880, 400) });
        pulpit.AddElement(new Track() { Name = "4-3ab"    , Location = new Location(880, 400, 920, 400) });
        pulpit.AddElement(new Track() { Name = "4-3ab"    , Location = new Location(920, 400, 950, 300) });
        pulpit.AddElement(new Track() { Name = "F-3ab"    , Location = new Location(930, 300, 950, 300) });
        pulpit.AddElement(new Track() { Name = "3cd-2ab"  , Location = new Location(950, 300, 980, 200) });
        pulpit.AddElement(new Track() { Name = "E-7"      , Location = new Location(930, 200, 950, 200) });
        pulpit.AddElement(new Track() { Name = "7-2ab"    , Location = new Location(950, 200, 980, 200) });
        pulpit.AddElement(new Track() { Name = "7-6"      , Location = new Location(950, 200, 980, 300) });
        pulpit.AddElement(new Track() { Name = "3cd-6"    , Location = new Location(950, 300, 980, 300) });
        pulpit.AddElement(new Track() { Name = "2cd-1"    , Location = new Location(980, 200, 1010, 100) });
        pulpit.AddElement(new Track() { Name = "D-1"      , Location = new Location(980, 100, 1010, 100) });
        pulpit.AddElement(new Track() { Name = "2cd-B"    , Location = new Location(980, 200, 1020, 200) });
        pulpit.AddElement(new Track() { Name = "6-C"      , Location = new Location(980, 300, 1020, 300) });
        pulpit.AddElement(new Track() { Name = "1-A"      , Location = new Location(1010, 100, 1050, 100) });

        pulpit.AddElement(new Track() { Name = "outB"     , Location = new Location(1050, 200, 1150, 200) });
        pulpit.AddElement(new Track() { Name = "outC"     , Location = new Location(1050, 300, 1150, 300) });

        pulpit.AddElement(new Track() { Name = "outA"     , Location = new Location(1080, 100, 1095 , 100) });
        pulpit.AddElement(new Track() { Name = "it10"     , Location = new Location(1100, 100, 1180, 100) });
        pulpit.AddElement(new Track() { Name = "it20"     , Location = new Location(1100, 70 , 1180, 70) });
        pulpit.AddElement(new Track() { Name = "it30"     , Location = new Location(1100, 40 , 1180, 40) });*/
    }

    protected void DrawPulpit(Graphics g)
    {
#if DEBUG
        RegisterElements();
#endif
        using Pen pen = new Pen(Colors.White, 3);
        using SolidBrush brush = new SolidBrush(Colors.White);

        foreach (var element in pulpit)
        {
            if (element.Location.IsEmpty())
                continue;

            /*if (element is Semafor semafor)
            {
                brush.Color = GetColor(semafor);
                pen.Color = GetColor(semafor);
                if (semafor.Type == SemaforType.Pociagowy)
                    g.FillTriangle(brush, semafor.Location, semafor.Direction);
                else if (semafor.Type == SemaforType.Manewrowy)
                    g.DrawOpenTriangle(pen, semafor.Location, semafor.Direction);
                else if (semafor.Type == SemaforType.PociagowyManewrowy)
                {
                    RectangleF rect = semafor.Direction switch
                    {
                        TriangleDirection.Left => new RectangleF(semafor.Location.X, semafor.Location.Y, semafor.Location.Size.Width / 2, semafor.Location.Size.Height),
                        TriangleDirection.Up => new RectangleF(semafor.Location.X, semafor.Location.Y, semafor.Location.Size.Width, semafor.Location.Size.Height / 2),
                        TriangleDirection.Right => new RectangleF(semafor.Location.X + semafor.Location.Size.Width / 2, semafor.Location.Y, semafor.Location.Size.Width / 2, semafor.Location.Size.Height),
                        TriangleDirection.Down => new RectangleF(semafor.Location.X, semafor.Location.Y + semafor.Location.Size.Height / 2, semafor.Location.Size.Width, semafor.Location.Size.Height / 2),
                        _ => throw new ArgumentException("Invalid direction")
                    };
                    g.FillTriangle(brush, rect, semafor.Direction);
                    rect = semafor.Direction switch
                    {
                        TriangleDirection.Left => new RectangleF(rect.X + rect.Width, rect.Y, rect.Width, rect.Height),
                        TriangleDirection.Up => new RectangleF(rect.X, rect.Y + rect.Height, rect.Width, rect.Height),
                        TriangleDirection.Right => new RectangleF(rect.X - rect.Width, rect.Y, rect.Width, rect.Height),
                        TriangleDirection.Down => new RectangleF(rect.X, rect.Y - rect.Height, rect.Width, rect.Height),
                        _ => throw new ArgumentException("Invalid direction")
                    };
                    g.DrawOpenTriangle(pen, rect, semafor.Direction);
                }
            }*/
            /*if (element is Track track)
            {
                pen.Color = GetColor(track);
                g.DrawLine(pen, track.Location.TopLeft, track.Location.BottomRight);
            }*/
        }
    }

    private Color GetColor(PulpitElement element)
    {
        return element switch
        {
            /*Track track => (int) track switch
            {
                -2 => Colors.Red,
                -1 => Colors.Blue,
                _ => track.ActualColor
            },*/
            /*Semafor sem => (int) sem switch
            {
                -1 => Colors.Blue,
                _ => sem.ActualColor
            },
            _ => Colors.Blue*/
        };
    }

    /*private bool CheckTrack(Track track)
    {
        return track == Track.it102;
    }*/

    /*private bool CheckSem(Semafor sem)
    {
        return sem == Semafor.A;
    }*/
}
