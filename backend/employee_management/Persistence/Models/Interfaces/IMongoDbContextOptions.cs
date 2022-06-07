namespace employee_management.Persistence.Models.Interfaces;

public interface IMongoDbContextOptions
{
    string MongoUri { get; set; }
    string Database { get; set; }
}