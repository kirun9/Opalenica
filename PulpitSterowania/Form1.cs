namespace PulpitSterowania;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void Form1_Load(Object sender, EventArgs e)
    {
        var renderer = new MyToolStripProfessionalRenderer(Color.Black, Color.White, Color.White, 3);
        contextMenuStrip1.RenderMode = ToolStripRenderMode.ManagerRenderMode;
        contextMenuStrip1.Renderer = renderer;
    }
}

class MyToolStripProfessionalRenderer : ToolStripProfessionalRenderer
{
    public MyToolStripProfessionalRenderer(Color primaryColor, Color textColor, Color borderColor, Int32 arrowThickness)
        : base(new ColorTable(primaryColor, textColor, borderColor))
    {
        PrimaryColor = primaryColor;
        TextColor = textColor;
        BorderColor = borderColor;
        this.arrowThickness = arrowThickness;
    }

    public Color PrimaryColor { get; set; }
    public Color TextColor { get; set; }
    public Color BorderColor { get; set; }
    public int arrowThickness { get; set; }

    protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
    {
        base.OnRenderItemText(e);
        e.Item.ForeColor = e.Item.Selected ? Color.White : TextColor;
    }

    protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
    {
        base.OnRenderToolStripBorder(e);
        using Pen p = new Pen(BorderColor, arrowThickness * 2);
        e.Graphics.DrawRectangle(p, 0, 0, e.ToolStrip.Width, e.ToolStrip.Height);
    }
}

class ColorTable : ProfessionalColorTable
{

    public ColorTable(Color primaryColor, Color textColor, Color boirderColor)
    {
        PrimaryColor = primaryColor;
        TextColor = textColor;
        BorderColor = boirderColor;
    }

    public Color PrimaryColor { get; set; }
    public Color TextColor { get; set; }
    public Color BorderColor { get; set; }

    public override Color MenuBorder => BorderColor;
    public override Color ToolStripDropDownBackground => PrimaryColor;
}
