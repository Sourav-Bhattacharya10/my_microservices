using System;
using System.Threading.Tasks;
using MongoDB.Driver;

using employee_management.Domain;

namespace employee_management.Persistence.Configurations.Entities;

public class EmployeeSeederConfiguration : IEntitySeederConfiguration
{
    public string CollectionName { get; set; } = "employees";
    public EmployeeSeederConfiguration()
    {
        
    }

    public void Seed(IMongoCollection<Employee> collection)
    {
        List<Employee> empList = new List<Employee>{
            new Employee{Name = "Sourav", Email = "sourav.bhattacharya3@gmail.com", Password = "202cb962ac59075b964b07152d234b70", DateOfJoining = new DateTime(2016,11,14).ToUniversalTime(), ProfileImage = "https://deviacstorageaccount.blob.core.windows.net/blobcontainer/Goku.png", CreatedBy = "Sourav", LastModifiedDate = DateTime.Now.ToUniversalTime(), LastModifiedBy = "Sourav"},
            new Employee{Name = "Priya", Email = "priyad301294@gmail.com", Password = "202cb962ac59075b964b07152d234b70", DateOfJoining = new DateTime(2016,11,14).ToUniversalTime(), ProfileImage = "https://deviacstorageaccount.blob.core.windows.net/blobcontainer/NarutoJonin.png", CreatedBy = "Sourav", LastModifiedDate = DateTime.Now.ToUniversalTime(), LastModifiedBy = "Sourav"},
        };

        collection.InsertMany(empList);
    }
}