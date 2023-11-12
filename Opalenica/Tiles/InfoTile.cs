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

        Command command = new Command("confirm", ConfirmMessage);
        CommandProcessor.RegisterCommand(command);
    }

    protected override void Paint(Graphics g)
    {
        using Pen p = new Pen(Colors.White, 2);
        p.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
        g.DrawRectangle(p, 0, 0, Width, Height);

        float prevHeight = 5;
        foreach (var line in InfoLines)
        {
            g.DrawString($"[{line.Id}] {line.Message}", Font, new SolidBrush(line.GetColor(Parent.Pulse)), 5, prevHeight);
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
        return InfoLines.FirstOrDefault(x => x.Id == id, InfoMessage.None);
    }

    public static InfoMessage GetMessageByTag(params string[] tags)
    {
        return InfoLines.Where(x => tags.All(x.Tags.Contains)).FirstOrDefault(InfoMessage.None);
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

    public static InfoMessage GetSelectedMessage()
    {
        return InfoLines.Where(e => e.Selected).FirstOrDefault(InfoMessage.None);
    }

    public static bool ConfirmMessage(CommandContext context)
    {
        if (context.Args.Length == 0)
        {
            var message = GetSelectedMessage();
            if (message == InfoMessage.None) return CommandProcessor.BreakChainCommand();
            RemoveInfo(message.Id);
            return true;
        }
        else
        {
            var message = GetMessage(context.GetArg<int>(0));
            if (message == InfoMessage.None) return CommandProcessor.BreakChainCommand();
            if (message.Severity is MessageSeverity.Error)
            {
                SelectMessage(message.Id);
                return true;
            }
            else
            {
                RemoveInfo(message.Id);
                return true;
            }
        }
    }
}