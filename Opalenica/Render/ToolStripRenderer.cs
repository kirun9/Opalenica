namespace Opalenica.Render;

public class ToolStripRenderer : ToolStripProfessionalRenderer {
    private Color _backgroundColor;
    private Color _foreColor;
    private Color _borderColor;
    private int _borderSize;

    public ToolStripRenderer(Color backgroundColor, Color foreColor, Color borderColor, Int32 borderSize) {
        _backgroundColor = backgroundColor;
        _foreColor = foreColor;
        _borderColor = borderColor;
        _borderSize = borderSize;
    }

    protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e) {
        base.OnRenderItemText(e);
        e.Item.ForeColor = _foreColor;
    }

    protected override void OnRenderItemBackground(ToolStripItemRenderEventArgs e) {
        base.OnRenderItemBackground(e);
        e.Item.BackColor = _backgroundColor;
    }

    protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e) {
        base.OnRenderToolStripBorder(e);
        using Pen p = new Pen(_borderColor, _borderSize);
        e.Graphics.DrawRectangle(p, 0, 0, e.ToolStrip.Width, e.ToolStrip.Height);
    }
}
