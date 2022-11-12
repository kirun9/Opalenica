namespace Opalenica.Tiles;

using CommandProcessor;

public class InfoTile : Tile
{
    private static List<InfoMessage> InfoLines = new List<InfoMessage>();
    private new Font Font;

    public InfoTile(int pos) : base(pos)
    {
        Initialize();
    }

    public InfoTile(int position, Size sizeOnGrid) : base(position, sizeOnGrid)
    {
        Initialize();
    }

    public InfoTile(Grid parent, int position, Size sizeOnGrid) : base(parent, position, sizeOnGrid)
    {
        Initialize();
    }

    private void Initialize()
    {
        /*InfoLines.Add((1, "Sample Error", Colors.Red, Colors.White));
        InfoLines.Add((2, "Sample Information", Colors.Yellow, Colors.Yellow));
        InfoLines.Add((3, "Sample Help info", Colors.White, Colors.White));*/
        Font = new Font(base.Font.FontFamily, 12F, FontStyle.Bold, base.Font.Unit);
    }

    protected override void Paint(Graphics g)
    {
        using Pen p = new Pen(Colors.White, 2);
        p.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
        g.DrawRectangle(p, 0, 0, Width, Height);

        float prevHeight = 5;
        foreach (var line in InfoLines)
        {
            g.DrawString(line.Message, Font, new SolidBrush(line.GetColor(Parent.Pulse)), 5, prevHeight);
            var size = g.MeasureString(line.Message, Font);
            prevHeight += size.Height + 2;
        }
    }

    public static int AddInfo(string message, MessageSeverity severity, params string[] tags)
    {
        var id = InfoLines.Count == 0 ? 0 : InfoLines.Last().Id;

        var m = new InfoMessage() { Id = id + 1, Message = message, Severity = severity, Tags = tags };

        // TODO - nie wiem co XD Ale to brakuje czegoś

        InfoLines.Add(m);
        return id + 1;
    }

    public static void RemoveInfo(int id)
    {
        InfoLines.RemoveAll(x => x.Id == id);
    }

    private static void SelectMessage(int id)
    {
        InfoLines.ForEach(e => e.Selected = e.Id == id);
    }

    private static InfoMessage GetMessage(int id)
    {
        if (InfoLines.Count is 0) return null;
        if (id is 0) return null;
        return InfoLines.FirstOrDefault(x => x.Id == id, null);
    }

    public static InfoMessage GetMessageByTag(params string[] tags)
    {
        return InfoLines.Where(x => tags.All(x.Tags.Contains)).FirstOrDefault();
    }

    public static int CountMessagesByTag(params string[] tags)
    {
        return InfoLines.Where(x => tags.All(x.Tags.Contains)).Count();
    }

    public static IEnumerable<InfoMessage> GetMessagesByTag(params string[] tags)
    {
        return InfoLines.Where(x => tags.All(x.Tags.Contains));
    }

    public static int GetMessagesCount()
    {
        return InfoLines.Count;
    }

    public static bool ConfirmMessage(CommandContext context)
    {
        var message = GetMessage(context.GetArgAs<int>(0));
        if (message is null) return CommandProcessor.BreakChainCommand();
        if (message.Severity is MessageSeverity.Error)
        {
            SelectMessage(message.Id);
            return true;
        }

        return true;
    }
}

public sealed class InfoMessage
{
    internal List<InfoMessage> Messages { get; set; } = new List<InfoMessage>();

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

public enum MessageSeverity
{
    Help,
    Warning,
    Error,
}