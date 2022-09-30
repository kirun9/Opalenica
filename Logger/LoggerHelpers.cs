namespace Pulpit.Logger;
using Microsoft.Extensions.DependencyInjection;

public static class LoggerHelpers
{

    public static IServiceCollection RegisterLogger(this IServiceCollection services)
    {
        services.AddSingleton<ILogger, Logger>();
        return services;
    }
}