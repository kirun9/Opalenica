namespace Opalenica.Forms.Settings;

using System.ComponentModel;
using System.Drawing.Drawing2D;

public partial class RoundControlLED : Control
{
    [Browsable(true)]
    [Category("Behavior")]
    [Description("The array of colors of the LED when it is on.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public Color[] LEDColors { get; set; } = new Color[] { Colors.Red };

    [Browsable(true)]
    [Category("Behavior")]
    [Description("Index of the color of the LED when it is on.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [DefaultValue(0)]
    public int LEDIndex { get; set; }

    protected override void OnPaint(PaintEventArgs e)
    {
        using GraphicsPath path = new GraphicsPath();
        path.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
        Region = new Region(path);

        // if (LedIndex is lower than LedColor count then draw circle with path gradient that is darker on edges and lighter in center
        int ledIndex = LEDIndex;
        if (LEDIndex >= LEDColors.Length)
        {
            ledIndex = LEDColors.Length - 1;
        }
        using PathGradientBrush brush = new PathGradientBrush(path);
        brush.CenterColor = LEDColors[ledIndex];
        brush.SurroundColors = new Color[] { ControlPaint.Dark(LEDColors[ledIndex], 1f) };
        e.Graphics.FillEllipse(brush, 0, 0, ClientSize.Width, ClientSize.Height);

        base.OnPaint(e);
    }
}
