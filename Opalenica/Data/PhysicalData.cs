namespace Opalenica;

using System.Text.RegularExpressions;

public class PhysicalData : Data
{
    internal static string DataRegex = @"[0-9a-fA-F][0-9a-mA-M]";
    private PhysicalData() { }

    public static PhysicalData GetData(string position, DataDirection direction = DataDirection.None)
    {
        if (!Regex.IsMatch(position, DataRegex)) throw new ArgumentException(DataRegex);
        var data = DataList.FirstOrDefault(e => e?.Name == position && e?.GetType() == typeof(PhysicalData), null);
        if (data is not null and PhysicalData pdata) return pdata;
        PhysicalData p = new PhysicalData();
        p.Name = position;
        p.Direction = direction;
        p.DisplayName = "PLC " + position;
        DataList.Add(p);
        return p;
    }

    public static byte GetRow(char pos) => pos switch {
        >= '0' and <= '9' => (byte) (pos - '0'),
        >= 'a' and <= 'm' => (byte) (pos - 'a' + 10),
        >= 'A' and <= 'M' => (byte) (pos - 'A' + 10),
        _ => throw new ArgumentOutOfRangeException(nameof(pos), "position must be in [0-9,a-m,A-M] range"),
    };

    public static byte GetColumn(char pos) => pos switch {
        >= '0' and <= '9' => (byte) (pos - '0'),
        >= 'a' and <= 'f' => (byte) (pos - 'a' + 10),
        >= 'A' and <= 'F' => (byte) (pos - 'A' + 10),
        _ => throw new ArgumentOutOfRangeException(nameof(pos), "position must be in [0-9,a-f,A-F] range")
    };
}