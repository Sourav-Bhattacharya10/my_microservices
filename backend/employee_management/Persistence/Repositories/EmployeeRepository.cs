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
}