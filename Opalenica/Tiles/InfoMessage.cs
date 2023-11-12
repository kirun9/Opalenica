namespace Opalenica.Tiles;

public sealed class InfoMessage
{
    internal List<InfoMessage> Messages { get; set; } = new List<InfoMessage>();

    public static readonly InfoMessage None = new InfoMessage() { Id = -1, Selected = false, Tags = new []{ "None" }, Severity = MessageSeverity.Help };

    public int Id { get; set; }
    public string Message { get; set; }
    public MessageSeverity Severity { get; internal set; }
    public bool Selected { get; internal set; }
    public string[] Tags { get; set; }

    internal Color GetColor(bool pulse)
    {
        return Severity switch
        {
            MessageSeverity.Error when !pulse => Colors.Red,
            MessageSeverity.Error when pulse => Colors.White,
            MessageSeverity.Warning => Colors.Yellow,
            MessageSeverity.Help => Colors.White,
            _ => Colors.White
        };
    }
}
