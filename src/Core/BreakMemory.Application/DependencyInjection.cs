using BreakMemory.Application.Services;
using BreakMemory.Domain.Models.Database;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BreakMemory.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        AddDatabase(services, configuration);
        AddServices(services);
        return services;
    }

    private static void AddDatabase(IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<MongoDBSettings>(configuration.GetSection("BreakMemory"));
    }

    private static void AddServices(IServiceCollection services)
    {
        services.AddSingleton<WordService>();
    }
}