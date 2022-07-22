using System.Threading.Tasks;
using System.Collections.Generic;
using MongoDB.Driver;
using MongoDB.Bson;

using employee_management.Domain.Common;
using employee_management.Persistence;
using employee_management.Persistence.Repositories.Interfaces;

namespace employee_management.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseDomainEntity
{
    private readonly EmployeeManagementDbContext _dbContext;

    public GenericRepository(EmployeeManagementDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<T?> GetAsync(string id)
    {
        return await _dbContext.Collection<T>().Find(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _dbContext.Collection<T>().Find(new BsonDocument()).ToListAsync();
    }

    public async Task<T> AddAsync(T entity)
    {
        await _dbContext.Collection<T>().InsertOneAsync(entity);

        return entity;
    }

    // public T Update(T entity)
    // {
    //     _dbContext.Entry(entity).State = EntityState.Modified;

    //     return entity;
    // }

    // public T Delete(T entity)
    // {
    //     _dbContext.Set<T>().Remove(entity);

    //     return entity;
    // }

    // public async Task<bool> ExistsAsync(int id)
    // {
    //     var entity = await GetAsync(id);

    //     return entity != null;
    // }
}