namespace Opalenica.Lang;

using System.Resources;

public class LocalizedStrings
{
    ResourceManager rm = new ResourceManager("Opalenica.Strings", typeof(Program).Assembly);

    public string AcceptButton { get; set; }
    public string Title { get => rm.GetString("Title"); }
}
