namespace Opalenica.Forms.Settings;

using CustomUIDesign;

using System;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

using static System.ComponentModel.Design.ObjectSelectorEditor;

public class TabButton : ButtonWithoutPadding
{
    private bool selected;
    public bool Selected
    {
        get => selected;
        set
        {
            selected = value;
            ChangeBackColor();
        }
    }

    public TabButton(string name)
    {
        Text = name;

        AutoSize = true;
        AutoSizeMode = AutoSizeMode.GrowAndShrink;
        FlatAppearance.BorderSize = 0;
        FlatAppearance.MouseDownBackColor = ControlPaint.Light(BackColor);
        FlatAppearance.MouseOverBackColor = ControlPaint.Light(BackColor);
        FlatStyle = FlatStyle.Flat;
        Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
        ForeColor = Color.White;
        Location = new Point(3, 3);
        MaximumSize = new Size(0, 20);
        Size = new Size(57, 20);
        TabIndex = 6;
        TextAlign = ContentAlignment.MiddleLeft;
        UseVisualStyleBackColor = true;
    }

    public void ChangeBackColor()
    {
        BackColor = selected ? ControlPaint.Dark(Colors.Blue) : Colors.Black;
        FlatAppearance.MouseDownBackColor = ControlPaint.Light(BackColor);
        FlatAppearance.MouseOverBackColor = ControlPaint.Light(BackColor);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        Graphics g = e.Graphics;
        using Pen p = new Pen(Selected ? Colors.White : Colors.Gray, 2);
        p.Alignment = PenAlignment.Inset;
        g.DrawRectangle(p, 0, 0, Width, Height);
        /*g.DrawLine(p, 0, 0, 0, Height);
        g.DrawLine(p, 0, 0, Width, 0);
        g.DrawLine(p, Width, 0, Width, Height);*/
    }

    protected override void OnMouseHover(EventArgs e)
    {
        base.OnMouseHover(e);
        ForeColor = selected ? Colors.White : Colors.Black;
    }

    protected override void OnMouseEnter(EventArgs e)
    {
        base.OnMouseEnter(e);
        ForeColor = selected ? Colors.White : Colors.Black;
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        base.OnMouseLeave(e);
        ForeColor = Colors.White;
    }
}
