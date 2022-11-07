namespace Opalenica.Forms;

using CustomUIDesign;

using System.Windows.Forms;

public class Tab
{
    public string Name { get; set; }
    public bool Selected { get; set; }
    public Control Control { get; set; }
    public ButtonWithoutPadding Button { get; set; }

    public Tab(string name, Control control)
    {
        Name = name;
        Control = control;
    }
}