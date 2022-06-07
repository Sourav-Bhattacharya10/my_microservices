using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

using employee_management.Domain;
using employee_management.Persistence.Configurations.Entities;
using employee_management.Persistence.Models.Interfaces;

namespace employee_management.Persistence;

public static class PersistenceDatabaseSeeder
{
    public static void SeedDatabase(this IServiceProvider serviceCollection)  
    {  
        var dbContext = (EmployeeManagementDbContext)serviceCollection.GetService(typeof(EmployeeManagementDbContext))!;  
        Seed(dbContext);  
    }  

    private static void Seed(EmployeeManagementDbContext dbContext)  
    {  
        List<IEntitySeederConfiguration> _seederConfigurations = new List<IEntitySeederConfiguration>
        {
            new EmployeeSeederConfiguration()
        };

        foreach(var seeder in _seederConfigurations)
        {
            var currentCollection = dbContext.Collection<Employee>();

            if(seeder != null && currentCollection.CountDocuments(new BsonDocument()) == 0)
            {
                seeder.Seed(currentCollection);
            }
        }
    }  
}