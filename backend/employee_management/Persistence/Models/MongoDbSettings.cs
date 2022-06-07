namespace employee_management.Persistence.Models;

public class MongoDbSettings
{
    public string ConnectionString { get; set; } = default!;
    public string Database { get; set; } = default!;
    public string Collection { get; set; } = default!;
}