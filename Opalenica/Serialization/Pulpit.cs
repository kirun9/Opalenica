namespace Opalenica.Serialization;

public class Pulpit
{
    public string Name { get; set; } = "PulpitSettings";
    public SerialOptions SerialOptions { get; set; }

    public string CurrentMonitor { get; set; }
    public bool FullScreenOnStart { get; set; }
    public bool ShowResolutionWarning { get; set; } = true;
}
