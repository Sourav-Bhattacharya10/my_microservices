using System.Threading.Tasks;
using System.Collections.Generic;

namespace employee_management.Persistence.Repositories.Interfaces;

public interface IGenericRepository<T> where T : class
{
    Task<T?> GetAsync(string id);
    Task<List<T>> GetAllAsync();
    Task<T> AddAsync(T entity);
    // T Update(T entity);
    // T Delete(T entity);
    // Task<bool> ExistsAsync(int id);
}