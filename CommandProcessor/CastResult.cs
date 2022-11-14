namespace CommandProcessor;

public class CastResult<T>
{
    public bool IsSuccess { get; }
    //public Exception Exception { get; }
    public T Value { get; }

    public CastResult(T value, bool success)
    {
        this.Value = value;
        IsSuccess = success;
    }

    public static implicit operator T(CastResult<T> val) => val.Value;
}