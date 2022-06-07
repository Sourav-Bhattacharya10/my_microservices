using System;
using System.Threading.Tasks;
using MongoDB.Driver;

using employee_management.Persistence.Models.Interfaces;

namespace employee_management.Persistence.Models;

public class MongoDbContext : IMongoDbContext, IDisposable
{
    public MongoDbContext(MongoDbContextOptions options)
    {
        
    }

    public void Dispose()
    {
        // Dispose of unmanaged resources.
        Dispose();
        // Suppress finalization.
        GC.SuppressFinalize(this);
    }
}