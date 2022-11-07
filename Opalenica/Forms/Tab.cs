namespace Opalenica.Forms;

using CustomUIDesign;

using Opalenica.Forms.Settings;

using System.Windows.Forms;

public class Tab
{
    public string Name { get; set; }
    public bool Selected { get; set; }
    public Control Control { get; set; }
    public TabButton Button { get; set; }

    public Tab(string name, Control control)
    {
        Name = name;
        Control = control;
    }
}