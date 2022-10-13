namespace Opalenica.Interfaces;

public interface IHasOwnData<T> where T : Enum
{
    public Color GetColor(T data, bool pulse = false);
}
