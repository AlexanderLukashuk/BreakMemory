using BreakMemory.Application.Services;
using BreakMemory.Domain.Models.Database;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

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
        BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));

        services.Configure<MongoDBSettings>(configuration.GetSection("MongoDBSettings"));
        var mongoDBSettings = configuration.GetSection("MongoDBSettings").Get<MongoDBSettings>();
        Console.WriteLine($"ConnectionString: {mongoDBSettings.ConnectionString}");
        Console.WriteLine($"DatabaseName: {mongoDBSettings.DatabaseName}");
        Console.WriteLine($"CollectionName: {mongoDBSettings.CollectionName}");
    }

    private static void AddServices(IServiceCollection services)
    {
        services.AddSingleton<WordService>();
    }
}