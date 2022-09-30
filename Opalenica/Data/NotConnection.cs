namespace Opalenica;

using System.Diagnostics;

[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public class NotConnection : Connection
{
    public static new NotConnection GetConnection(Data input, Data output)
    {
        if (input.Direction.HasFlag(DataDirection.Input)) throw new ArgumentException($"Input data must have set Input direction flag");
        if (output.Direction.HasFlag(DataDirection.Output)) throw new ArgumentException($"Output data must have set Output direction flag");
        if (input.Name == output.Name) throw new ArgumentException("Cannot get/create connection between the same data");
        string name = $"{input.Name}!->{output.Name}";
        if (Connections.FirstOrDefault(e => e?.Name == name, null) is not null and NotConnection nconn) return nconn;
        var conn = new NotConnection()
        {
            Input = input,
            Output = output,
            Name = name
        };
        conn.Input.DataChanged += conn.UpdateOutput;
        Connections.Add(conn);
        return conn;
    }

    public static new NotConnection GetConnection(string input, string output)
    {
        Data? i, o;
        if ((i = Data.DataList.FirstOrDefault(e => e.Name == input, null)) is null) throw new ArgumentOutOfRangeException(nameof(input), input, "Data with provided name was not found");
        if ((o = Data.DataList.FirstOrDefault(e => e.Name == output, null)) is null) throw new ArgumentOutOfRangeException(nameof(output), output, "Data with provided name was not found");
        return GetConnection(i, o);
    }

    public override void UpdateOutput(object? _, EventArgs __)
    {
        Output.Value = !Input.Value;
    }

    public override string GetDebuggerDisplay()
    {
        return $"{Input.Name} ({Input.Value}) ! -> {Output.Name} ({Output.Value})";
    }
}
