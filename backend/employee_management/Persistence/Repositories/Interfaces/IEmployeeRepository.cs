using MongoDB.Driver;

using employee_management.Domain;

namespace employee_management.Persistence.Repositories.Interfaces;

public interface IEmployeeRepository : IGenericRepository<Employee>
{
    Task<DeleteResult> DeleteAsync(string id);
}