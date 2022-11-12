namespace Opalenica.Serialization;

using System.Text.Json.Serialization;

public class SerialOptions
{
    public string PortName { get; set; }
    public int BaudRate { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
    public int ErrorMessageId { get; set; } = -1;
}
