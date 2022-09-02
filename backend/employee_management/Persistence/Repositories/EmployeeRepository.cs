using System;
using System.Threading.Tasks;
using MongoDB.Driver;

using employee_management.Domain;
using employee_management.Persistence.Repositories.Interfaces;

namespace employee_management.Persistence.Repositories;

public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
{
    private readonly EmployeeManagementDbContext _dbContext;

    public EmployeeRepository(EmployeeManagementDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public override async Task<Employee> UpdateAsync(string id, Employee entity)
    {
        var filter = Builders<Employee>.Filter.Eq("_id", id);
        var update = Builders<Employee>.Update.Set(p => p.Name, entity.Name)
                                              .Set(p => p.Email, entity.Email)
                                              .Set(p => p.DateOfJoining, entity.DateOfJoining)
                                              .Set(p => p.ProfileImage, entity.ProfileImage);

        var updateResult = await _dbContext.Collection<Employee>().UpdateOneAsync(filter, update);
        // After updating the record in database, assigning the id for simlpy returning the API response
        entity.Id = id;

        if(!updateResult.IsAcknowledged)
        {
            throw new Exception("Unable to update the document");
        }

        return entity;
    }

    public async Task<DeleteResult> DeleteAsync(string id)
    {
        var filter = Builders<Employee>.Filter.Eq("_id", id);

        var deleteResult = await _dbContext.Collection<Employee>().DeleteOneAsync(filter);

        if(!deleteResult.IsAcknowledged)
        {
            throw new Exception("Unable to delete the document");
        }

        return deleteResult;
    }
}