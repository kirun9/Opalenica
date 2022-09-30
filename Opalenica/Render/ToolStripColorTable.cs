namespace Opalenica.Render;

public class ToolStripColorTable : ProfessionalColorTable
{
    private Color _backgroundColor;
    private Color _borderColor;

    public ToolStripColorTable(Color backgroundColor, Color borderColor)
    {
        _backgroundColor = backgroundColor;
        _borderColor = borderColor;
    }

    public override Color ToolStripDropDownBackground => _backgroundColor;
    public override Color MenuBorder => _borderColor;
}