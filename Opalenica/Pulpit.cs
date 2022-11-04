namespace Opalenica;

using Opalenica.Interfaces;
using Opalenica.Tiles;
using Opalenica.Tiles.Interfaces;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

internal class Pulpit : Control {
    private readonly Size designSize = new Size(1366, 768);
    public static (float Horizontal, float Vertical) Scale { get; private set; } = (1, 1);
    private bool DesignerMode { get; } = false;

    private static int sizeX = 46;
    private static int sizeY = 22;
    private Grid grid { get; set; } = new Grid($"{sizeX}x{sizeY}", "38x38");

    [Category("Appearance")]
    [Browsable(true)]
    public new Padding Padding { get; set; } = new Padding(1, 74, 1, 74);

    public List<Tile> RegisteredTiles = new List<Tile>();

    private bool blockLeftClick = false;

#if DEBUG
    private Stopwatch watch;
#endif

    public Pulpit() : base() {
#if DEBUG
        watch = new Stopwatch();
        watch.Start();
#endif
        DesignerMode = LicenseManager.UsageMode == LicenseUsageMode.Designtime;
        grid.Padding = Padding;
        this.DoubleBuffered = true;
        RegisterElements();
        //tileSize = new Size((designSize.Width - Padding.Vertical) / 38, (designSize.Height - Padding.Horizontal) / 38);
    }

    public Pulpit(Control parent, String text) : base(parent, text) {
        Parent = parent;
        Text = text;

#if DEBUG
        watch = new Stopwatch();
        watch.Start();
#endif
        DesignerMode = LicenseManager.UsageMode == LicenseUsageMode.Designtime;
        grid.Padding = Padding;
        this.DoubleBuffered = true;
        RegisterElements();
    }

    public void RegisterTiles() {
        for (int i = 1; i < 1013; i++) {
            RegisteredTiles.Add(new Kostka(i-1, i.ToString()));
        }
    }

    public void RegisterElements() {
        RegisterTiles();

        foreach (var tile in RegisteredTiles) {
            grid.AddTile(tile);
        }
    }

    protected override void OnSizeChanged(EventArgs e) {
        base.OnSizeChanged(e);
        calculateScale();
    }

    private void calculateScale() {
        Scale = ((float) Width / designSize.Width, (float) Height / designSize.Height);
    }

    private void DesignerPaint(Graphics g) {
        Point center = new Point(Width / 2, Height / 2);
        string s = $"Dimensions: {Width}x{Height}\nScale: {Scale.Horizontal}x{Scale.Vertical}";
        g.FillRectangle(Brushes.Black, 0, 0, Width, Height);
        using Pen pen = new Pen(Colors.White, 5);
        pen.Alignment = PenAlignment.Inset;
        g.DrawRectangle(pen, 0, 0, Width, Height);

        using var cap = new AdjustableArrowCap(5, 5);
        pen.Alignment = PenAlignment.Center;
        pen.CustomEndCap = cap;
        pen.CustomStartCap = cap;

        g.DrawLine(pen, Width * 0.05f, Height * 0.05f, Width * 0.95f, Height * 0.95f);
        g.DrawLine(pen, Width * 0.05f, Height * 0.95f, Width * 0.95f, Height * 0.05f);

        SizeF size = g.MeasureString(s, Font);
        g.FillRectangle(Brushes.Black, center.X - size.Width / 2, center.Y - size.Height / 2, size.Width, size.Height);
        g.DrawString(s, Font, Brushes.White, center.X - size.Width / 2, center.Y - size.Height / 2);
    }

    protected override void OnPaint(PaintEventArgs e) {
#if DEBUG
        watch.Restart();
#endif
        base.OnPaint(e);

        if (DesignerMode || DesignMode) {
            DesignerPaint(e.Graphics);
            return;
        }
        calculateScale();

        e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor; //TODO: TEST OTHERS
        e.Graphics.SmoothingMode = SmoothingMode.None;
        e.Graphics.PixelOffsetMode = PixelOffsetMode.Half; // DO NOT CHANGE!!!!!!

        //if (DrawBackground)
        using (SolidBrush b = new SolidBrush(Colors.DarkGray)) {
            e.Graphics.FillRectangle(b, 0, 0, Width, Height);
        }

        DrawPulpit(e.Graphics);
    }

    protected void DrawPulpit(Graphics g) {
        var defaultTransform = g.Transform;
        var prevClipRegion = g.Clip;
        foreach (var tile in grid.GetTiles()) {
            Point p = grid.CalculateGraphicTilePosition(tile.Position);
            g.ScaleTransform(Scale.Horizontal, Scale.Vertical);
            g.TranslateTransform(p.X, p.Y);
            g.Clip = new Region(new Rectangle(0, 0, tile.Size.Width, tile.Size.Height));
            tile.PaintTile(g);
            g.Clip = prevClipRegion;
            g.ResetTransform();
        }
        g.ResetTransform();
        g.Transform = defaultTransform;
    }

    //protected override void OnMouseClick(MouseEventArgs e) {
    //    void ShowContextMenu(ContextMenuStrip menu) {
    //        /* if debugmode
    //             * add debug items
    //             * */
    //        blockLeftClick = true;
    //        menu.Show(this, e.Location);
    //    }

    //    base.OnMouseClick(e);

    //    Point p = new Point((int) (e.X / Scale.Horizontal), (int) (e.Y / Scale.Vertical));
    //    var tile = grid.GetTileFromPoint(p);

    //    if (e.Button is MouseButtons.Left or MouseButtons.Middle) {
    //        if (blockLeftClick) {
    //            blockLeftClick = false;
    //            return;
    //        }
    //        if ((tile.IsOccupied ? tile.ParentTile ?? tile : tile) is IMouseEvent pMouseEvent) {
    //            pMouseEvent.OnMouseClick(e);
    //        }
    //    }

    //    if (e.Button == MouseButtons.Right) {
    //        if ((tile.IsOccupied ? tile.ParentTile ?? tile : tile) is IHasMenuStrip pMenuStrip) {
    //            ShowContextMenu(pMenuStrip.GetMenuStrip());
    //            return;
    //        }
    //    }

    //}
}
