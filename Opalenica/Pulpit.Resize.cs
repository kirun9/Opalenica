namespace Opalenica;

partial class Pulpit
{
    //TODO: Przemieszczenie z odniesieniem do obecnego monitora
    
    private Rectangle movableRectangle;
    /*#region Move Window ...
    private bool _mouseLeftDown = false;
    private Point _lastMouseLocation;

    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseDown(e);
        if (e.Button == MouseButtons.Left && Program.DebugMode)
        {
            System.Diagnostics.Debug.WriteLine(movableRectangle);
            System.Diagnostics.Debug.WriteLine(e.Location);
            if (movableRectangle.Contains(e.Location))
            {
                _mouseLeftDown = true;
                _lastMouseLocation = e.Location;
            }
        }
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
        base.OnMouseUp(e);
        if (e.Button == MouseButtons.Left)
        {
            _mouseLeftDown = false;
        }
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);
        if (_mouseLeftDown && Parent is Form form)
        {
            form.SetDesktopLocation(this.Location.X - _lastMouseLocation.X + e.X, this.Location.Y - _lastMouseLocation.Y + e.Y);
        }
    }

    protected override void OnMouseCaptureChanged(EventArgs e)
    {
        base.OnMouseCaptureChanged(e);
        _mouseLeftDown = false;
    }
    #endregion*/
}
