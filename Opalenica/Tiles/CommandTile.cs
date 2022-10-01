namespace Opalenica.Tiles;

using System;
using System.Diagnostics;
using System.Drawing;

using CommandProcessor;

public class CommandTile : Tile, IDisposable
{
    private Control _control;
    private TextBox CommandBox;
    private List<string> prevCommands = new List<string>(new string[] { "" });
    private int prevCommandPos = 0;

    public CommandTile(int pos, Control control) : base(pos)
    {
        _control = control;
        InitializeControl();
    }

    public CommandTile(int position, Size sizeOnGrid, Control control) : base(position, sizeOnGrid)
    {
        _control = control;
        InitializeControl();
    }

    public CommandTile(Grid parent, int position, Size sizeOnGrid, Control control) : base(parent, position, sizeOnGrid)
    {
        _control = control;
        InitializeControl();
    }

    private void InitializeControl()
    {
        CommandBox = new TextBox();
        CommandBox.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
        CommandBox.BackColor = Colors.Black;
        CommandBox.BorderStyle = BorderStyle.None;
        CommandBox.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
        CommandBox.ForeColor = Colors.White;
        CommandBox.Name = "CommandBox";
        CommandBox.TabIndex = 0;
        CommandBox.TextAlign = HorizontalAlignment.Left;
        CommandBox.KeyDown += new KeyEventHandler(CommandBox_KeyDown);
    }

    private void CommandBox_KeyDown(object? sender, KeyEventArgs e)
    {
        switch (e.KeyData)
        {
            case Keys.Enter:
            {
                CommandProcessor.ExecuteCommand(CommandBox.Text);
                if (prevCommands.Count > 1 && prevCommands[1] == CommandBox.Text)
                {
                    CommandBox.Text = "";
                }
                prevCommands.AddCommand(CommandBox.Text);
                prevCommandPos = 0;
                CommandBox.Text = "";
                _control?.Invalidate(true);
                e.Handled = e.SuppressKeyPress = true;
                break;
            }
            case Keys.Up:
            {
                if (prevCommandPos < prevCommands.Count) prevCommandPos++;
                if (prevCommands.Count <= prevCommandPos) break;
                CommandBox.Text = prevCommands[prevCommandPos];
                e.Handled = e.SuppressKeyPress = true;
                break;
            }
            case Keys.Down:
            {
                if (prevCommandPos > 0) prevCommandPos--;
                if (prevCommands.Count <= prevCommandPos) break;
                CommandBox.Text = prevCommands[prevCommandPos];
                e.Handled = e.SuppressKeyPress = true;
                break;
            }
        }
    }

    protected override void Paint(Graphics g)
    {
        using (Pen p = new Pen(Colors.White, 2))
        {
            p.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
            g.DrawRectangle(p, 0, 0, Width, Height);
        }
    }

    private Size CalculateSize()
    {
        return new Size(this.Size.Width - 8, 27);
    }

    private Point CalculatePos()
    {
        Point p = new Point();
        var preferedPos = this.Parent.CalculateGraphicTilePosition(this.Position);
        p.X = preferedPos.X + 4;
        p.Y = preferedPos.Y + ((this.Size.Height - CommandBox.Size.Height) / 2);
        return p;
    }

    protected override void OnTileAdded(EventArgs args)
    {
        base.OnTileAdded(args);
        CommandBox.Size = CalculateSize();
        _control.Controls.Add(CommandBox);
        CommandBox.Location = CalculatePos();
        CommandBox.BringToFront();
    }

    protected override void OnTileRemoved(EventArgs args)
    {
        base.OnTileRemoved(args);
        _control.Controls.Remove(CommandBox);
        _control.Invalidate(true);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (CommandBox is not null)
            {
                CommandBox.Dispose();
                CommandBox = null;
            }
            prevCommands = null;
        }
    }
}
