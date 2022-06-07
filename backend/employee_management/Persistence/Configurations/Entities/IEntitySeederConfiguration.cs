using System.Threading.Tasks;
using MongoDB.Driver;

using employee_management.Domain;

namespace employee_management.Persistence.Configurations.Entities;

public interface IEntitySeederConfiguration
{
    string CollectionName {get; set;}
    void Seed(IMongoCollection<Employee> collection);
}