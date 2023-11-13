namespace Opalenica.Serialization;

public class Pulpit
{
    public string Name { get; set; } = "PulpitSettings";
    public SerialOptions SerialOptions { get; set; } = new SerialOptions();

    public GeneralOptions General { get; set; } = new GeneralOptions();
}