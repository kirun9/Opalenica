namespace Opalenica;

public class Data
{
    public event EventHandler<DataChangedEventArgs> DataChanged;

    internal static List<Data> DataList { get; } = new List<Data>();

    private bool _value;
    public bool Value
    {
        get => _value;
        set
        {
            var prevVal = _value;
            _value = value;
            DataChanged?.Invoke(this, new DataChangedEventArgs(this, prevVal));
        }
    }

    public string Name { get; internal set; }
    public DataDirection Direction { get; internal set; }
    public string DisplayName { get; set; }

    public static implicit operator bool(Data data) => data.Value;
}