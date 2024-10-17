using Book.Common.Entities;
using Book.Core.Interfaces;
using Book.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Book.Data.Repositories;

public  class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    protected readonly AppDbContext _context;

    public GenericRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Create(T entity)
    {
        _context.Set<T>().Add(entity);
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    public bool Exist(int id)
    {
        return _context.Set<T>().Any(x => x.Id.Equals(id));
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }
    public async Task<IEnumerable<T>> GetAllAsync(Func<IQueryable<T>, IQueryable<T>>? includeQuery = null)
    {
        IQueryable<T> query = _context.Set<T>();

        if (includeQuery != null)
        {
            query = includeQuery(query);
        }

        return await query.ToListAsync();
    }


    public Task<T?> GetByIdAsync(Guid id)
    {
        return _context.Set<T>().FirstOrDefaultAsync(x => x.Id.Equals(id));
    }

    public void Update(T entity)
    {
        _context.Set<T>().Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
    }
    public  bool CheckIfExists<T>(Func<T, bool> predicate) where T : class
    {
        return  _context.Set<T>().Any(predicate);
    }
}

