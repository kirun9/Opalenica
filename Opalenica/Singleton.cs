namespace Opalenica;

public class Singleton<T> : object where T : class, new()
{
    private static Lazy<T> _instance;

    public static T Instance
    {
        get
        {
            _instance ??= new Lazy<T>();
            return _instance.Value;
        }
        set
        {
            _instance = new Lazy<T>(value);
        }
    }

    static Singleton()
    {
        _instance = new Lazy<T>();
    }

    public Singleton()
    {
    }
}