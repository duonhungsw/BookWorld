using Book.Common.Entities;
using Microsoft.EntityFrameworkCore;

namespace Book.Core.Interfaces;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<T?> GetByIdAsync(Guid id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> GetAllAsync(Func<IQueryable<T>, IQueryable<T>>? includeQuery = null);
     void Delete(T entity);
    void Update(T entity);
    void Create(T entity);
    bool Exist(int id);
    bool CheckIfExists<T>(Func<T, bool> predicate) where T : class;
}


