using employee_management.Persistence.Models.Interfaces;

namespace employee_management.Persistence.Models;

public class MongoDbContextOptions : IMongoDbContextOptions
{
    public string MongoUri { get; set; } = default!;
    public string Database { get; set; } = default!;

    public MongoDbContextOptions(string mongoUri, string database)
    {
        MongoUri = mongoUri;
        Database = database;
    }
}