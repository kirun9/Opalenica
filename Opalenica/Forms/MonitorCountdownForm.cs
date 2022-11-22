namespace Opalenica.Forms;

using CustomUIDesign;

using System.Drawing.Drawing2D;

public partial class MonitorCountdownForm : ResizableForm
{
    public MonitorCountdownForm()
    {
        InitializeComponent();

        Title.SetString(true, this);
        AcceptButton.SetString(true, true);
        CancelButton.SetString(true, true);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        using Pen pen = new Pen(Colors.White, 3);
        pen.Alignment = PenAlignment.Inset;
        e.Graphics.DrawRectangle(pen, ClientRectangle);
    }
}
