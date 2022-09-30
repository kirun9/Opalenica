namespace Opalenica;

using System.Diagnostics;
using System.Runtime.CompilerServices;

[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public class Connection
{
    internal static List<Connection> Connections { get; } = new List<Connection>();

    public string Name { get; internal set; }

    public Data Input { get; internal set; }
    public Data Output { get; internal set; }

    public Connection[] Outputs { get; internal set; } // TODO

    public static Connection GetConnection(Data input, Data output)
    {
        if (input.Direction.HasFlag(DataDirection.Input)) throw new ArgumentException($"Input data must have set Input direction flag");
        if (output.Direction.HasFlag(DataDirection.Output)) throw new ArgumentException($"Output data must have set Output direction flag");
        if (input.Name == output.Name) throw new ArgumentException("Cannot get/create connection between the same data");
        string name = $"{input.Name}->{output.Name}";
        var conn = Connections.FirstOrDefault(e => e?.Name == name, null);
        if (conn is not null) return conn;
        conn = new Connection()
        {
            Input = input,
            Output = output,
            Name = name
        };
        conn.Input.DataChanged += conn.UpdateOutput;
        Connections.Add(conn);
        return conn;
    }

    public static Connection GetConnection(string input, string output)
    {
        Data? i, o;
        if ((i = Data.DataList.FirstOrDefault(e => e?.Name == input, null)) is null) throw new ArgumentOutOfRangeException(nameof(input), input, "Data with provided name was not found");
        if ((o = Data.DataList.FirstOrDefault(e => e?.Name == output, null)) is null) throw new ArgumentOutOfRangeException(nameof(output), output, "Data with provided name was not found");
        return GetConnection(i, o);
    }

    public virtual void UpdateOutput(object? _, EventArgs __)
    {
        Output.Value = Input.Value;
    }

    public virtual string GetDebuggerDisplay()
    {
        return $"{Input.Name} ({Input.Value}) -> {Output.Name} ({Output.Value})";
    }
}

/*[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public class Connection2
{
    internal static int lastInternalID = 0;
    internal static List<Connection2> RegisteredConnections = new List<Connection2>();

    public string Name { get; internal set; }
    internal int internalID { get; private set; }
    public Data AssociatedData { get; internal set; }
    public Connection2 Input { get; internal set; }
    public Connection2[] Output { get; internal set; }

    public static Connection2 GetConnection(Connection2 input, Connection2[] output)
    {
        if (output.Select(e => e.internalID).Contains(input.internalID)) throw new ArgumentException("Cannot create connection beetwen the same connections");
        int internalID = ++lastInternalID;
        string name = $"{internalID}{input.Name}->{string.Join(", ", output.Select(e => e.Name))}";

    }

    private string GetDebuggerDisplay()
    {
        return $"{internalID}";
    }
}*/