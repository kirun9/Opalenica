namespace Opalenica;

public class DataChangedEventArgs : EventArgs
{
    public bool PrevValue { get; private set; }
    public bool Value => Data.Value;
    public Data Data { get; set; }
    public bool DataChanged => PrevValue != Value;

    public DataChangedEventArgs(Data data, bool prevValue)
    {
        Data = data;
        PrevValue = prevValue;
    }
}
