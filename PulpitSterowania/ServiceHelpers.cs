namespace PulpitSterowania;
using Microsoft.Extensions.DependencyInjection;

using Pulpit.Module;

internal static class ServiceHelpers
{
    public static IServiceCollection RegisterMarkedClassesAsServices(this IServiceCollection collection)
    {
        foreach (var type in typeof(Program).Assembly.GetTypes())
        {
            var foundAttributes = type.GetCustomAttributes(typeof(ServiceAttribute), false);
            if (foundAttributes.Length > 0)
            {
                ServiceAttribute attribute = (ServiceAttribute)foundAttributes[0];
                _ = attribute.ServiceType switch
                {
                    ServiceType.Singleton when attribute.BaseInterface is not null => collection.AddSingleton(attribute.BaseInterface, type),
                    ServiceType.Scoped    when attribute.BaseInterface is not null => collection.AddScoped(attribute.BaseInterface, type),
                    ServiceType.Transient when attribute.BaseInterface is not null => collection.AddTransient(attribute.BaseInterface, type),
                    ServiceType.Singleton when attribute.BaseInterface is null     => collection.AddSingleton(type),
                    ServiceType.Scoped    when attribute.BaseInterface is null     => collection.AddScoped(type),
                    ServiceType.Transient when attribute.BaseInterface is null     => collection.AddTransient(type),
                    _ => throw new InvalidOperationException()
                };
            }
        }
        return collection;
    }

    public static T? GetClass<T>(this IServiceProvider provider)
    {
        return provider.GetService<T>();
    }

    public static IEnumerable<T> GetClasses<T>(this IServiceProvider provider)
    {
        return provider.GetServices<T>();
    }

    public static object? GetClass(this IServiceProvider provider, Type type)
    {
        return provider.GetService(type);
    }

    public static IEnumerable<object?> GetClasses(this IServiceProvider provider, Type type)
    {
        return provider.GetServices(type);
    }

    public static bool Find<T>(this IServiceCollection collection)
    {
        foreach (var service in collection)
        {
            if (service.ServiceType == typeof(T))
            {
                return true;
            }
        }
        return false;
    }

    public static bool Find(this IServiceCollection collection, Type type)
    {
        foreach (var service in collection)
        {
            if (service.ServiceType == type)
            {
                return true;
            }
        }
        return false;
    }
}