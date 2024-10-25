namespace BreakMemory.Domain.Models.Database;

public class MongoDBSettings
{
    public string ConnectionString { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;

    public string CollectionName { get; set; } = null!;
}