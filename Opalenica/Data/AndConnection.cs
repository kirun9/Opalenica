namespace Opalenica;

using System.Diagnostics;

[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public class AndConnection : Connection
{
    public Data Input2 { get; internal set; }

    public static AndConnection GetConnection(Data input1, Data input2, Data output)
    {
        if (!input1.Direction.HasFlag(DataDirection.Input)) throw new ArgumentException("Input1 data must have set Input direction flag");
        if (!input2.Direction.HasFlag(DataDirection.Input)) throw new ArgumentException("Input2 data must have set Input direction flag");
        if (!output.Direction.HasFlag(DataDirection.Output)) throw new ArgumentException("Output data must have set Output direction flag");
        if (input1.Name == output.Name || input2.Name == output.Name || input1.Name == input2.Name) throw new ArgumentException("Cannot get/create connection between the same data");
        string name = $"{input1.Name}&{input2.Name}->{output.Name}";
        if (Connections.FirstOrDefault(e => e?.Name == name, null) is not null and AndConnection aconn) return aconn;
        var conn = new AndConnection()
        {
            Input = input1,
            Input2 = input2,
            Output = output,
            Name = name
        };
        conn.Input.DataChanged += conn.UpdateOutput;
        conn.Input2.DataChanged += conn.UpdateOutput;
        Connections.Add(conn);
        return conn;
    }

    public static AndConnection GetConnection(string input1, string input2, string output)
    {
        Data? i1, i2, o;
        if ((i1 = Data.DataList.FirstOrDefault(e => e?.Name == input1, null)) is null) throw new ArgumentOutOfRangeException(nameof(input1), input1, "Data with provided name was not found");
        if ((i2 = Data.DataList.FirstOrDefault(e => e?.Name == input2, null)) is null) throw new ArgumentOutOfRangeException(nameof(input2), input2, "Data with provided name was not found");
        if ((o = Data.DataList.FirstOrDefault(e => e?.Name == output, null)) is null) throw new ArgumentOutOfRangeException(nameof(output), output, "Data with provided name was not found");
        return GetConnection(i1, i2, o);
    }

    public override void UpdateOutput(object? _, EventArgs __)
    {
        Output.Value = Input.Value && Input2.Value;
    }

    public override string GetDebuggerDisplay()
    {
        return $"{Input.Name} ({Input.Value}) & {Input2.Name} ({Input2.Value}) -> {Output.Name} ({Output.Value})";
    }
}
