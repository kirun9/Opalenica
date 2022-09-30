namespace PulpitSterowania;

using Microsoft.Extensions.DependencyInjection;

using Pulpit.Logger;

internal static class Program
{
    public static IServiceProvider ServiceProvider { get; private set; }
    private static ServiceCollection ServiceCollection = new ServiceCollection();

    public static IServiceProvider Init()
    {
        var serviceProvider = ServiceCollection.BuildServiceProvider();
        ServiceProvider = serviceProvider;
        return serviceProvider;
    }

    internal static IServiceProvider AppendService(object service)
    {
        ServiceCollection.AddSingleton(service);
        ServiceProvider = ServiceCollection.BuildServiceProvider();
        return ServiceProvider;
    }

    public static T? GetClass<T>()
    {
        if (ServiceCollection.Find<T>())
            return ServiceProvider.GetClass<T>();
        throw new InvalidOperationException("Service not registered");
    }

    public static object? GetClass(Type type)
    {
        if (ServiceCollection.Find(type))
            return ServiceProvider.GetClass(type);
        throw new InvalidOperationException("Service not registered");
    }

    public static IEnumerable<T> GetClasses<T>()
    {
        if (ServiceCollection.Find<T>())
            return ServiceProvider.GetClasses<T>();
        throw new InvalidOperationException("Service not registered");
    }

    public static IEnumerable<object?> GetClasses(Type type)
    {
        if (ServiceCollection.Find(type))
            return ServiceProvider.GetClasses(type);
        throw new InvalidOperationException("Service not registered");
    }

    public static T CreateInstance<T>(params object[] parameters) => ActivatorUtilities.CreateInstance<T>(ServiceProvider, parameters);

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        ServiceProvider = ServiceCollection.RegisterLogger()
            .RegisterMarkedClassesAsServices()
            .BuildServiceProvider();



        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Application.Run(new Form1());
    }
}