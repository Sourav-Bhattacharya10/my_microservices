using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson.Serialization.IdGenerators;

using employee_management.Domain;
using employee_management.Domain.Common;
using employee_management.Persistence.Models;
using employee_management.Persistence.Models.Interfaces;
using employee_management.Persistence.Configurations.Entities;
using employee_management.Persistence.Repositories;
using employee_management.Persistence.Repositories.Interfaces;

namespace employee_management.Persistence;

public static class PersistenceServicesRegistration
{
    public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Use this when specifying in appSettings.json
        // services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));

        var connectionString = configuration.GetValue<string>("AzureCosmosDBUri");
        var database = configuration.GetValue<string>("AzureCosmosDBDatabase");

        // Map Bson documents
        BsonClassMap.RegisterClassMap<BaseDomainEntity>(cm =>
        {
            cm.SetIsRootClass(true);

            cm.MapIdMember(c => c.Id).SetSerializer(new StringSerializer(BsonType.ObjectId)).SetIdGenerator(StringObjectIdGenerator.Instance); //.SetElementName("_id");

            cm.MapProperty(c => c.CreatedBy).SetElementName("createdBy");
            cm.MapProperty(c => c.LastModifiedDate).SetElementName("lastModifiedDate");
            cm.MapProperty(c => c.LastModifiedBy).SetElementName("lastModifiedBy");
        });

        BsonClassMap.RegisterClassMap<Employee>(cm =>
        {
            cm.MapProperty(c => c.Name).SetElementName("name");
            cm.MapProperty(c => c.Email).SetElementName("email");
            cm.MapProperty(c => c.Password).SetElementName("password");
            cm.MapProperty(c => c.DateOfJoining).SetElementName("dateOfJoining");
            cm.MapProperty(c => c.ProfileImage).SetElementName("profileImage");
        });

        // services.AddSingleton<MongoDbContextOptions>();
        services.AddSingleton<EmployeeManagementDbContext>(sp => new EmployeeManagementDbContext(new MongoDbContextOptions(connectionString, database)));

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();

        return services;
    }
}