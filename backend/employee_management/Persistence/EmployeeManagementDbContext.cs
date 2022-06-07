using System.Threading.Tasks;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

using employee_management.Domain;
using employee_management.Persistence.Models;
using employee_management.Persistence.Configurations.Entities;

namespace employee_management.Persistence;

public class EmployeeManagementDbContext : MongoDbContext
{
    public readonly IMongoDatabase Database = default!;

    

    // public EmployeeManagementDbContext(IOptions<MongoDbSettings> settings)
    // {
    //     var client = new MongoClient(settings.Value.ConnectionString);
    //     if (client != null)
    //         _database = client.GetDatabase(settings.Value.Database);
    // }

    public EmployeeManagementDbContext(MongoDbContextOptions options) : base(options)
    {
        var client = new MongoClient(options.MongoUri);
        if (client != null)
        {
            Database = client.GetDatabase(options.Database);
        }
    }

    public IMongoCollection<T> Collection<T>()
    {
        var collectionExists = Database.GetCollection<T>($"{typeof(T).Name.ToLower()}s");

        if(collectionExists == null)
        {
            Database.CreateCollection($"{nameof(T).ToLower()}s");
            collectionExists = Database.GetCollection<T>($"{typeof(T).Name.ToLower()}s");
        }
        
        return collectionExists;
    }
}