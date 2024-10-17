using Book.Common.Entities;
using Book.Core.Interfaces;
using Book.Data.Context;

namespace Book.Data.Repositories;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();

    private static UnitOfWork _instance;
    private static readonly object _lock = new object();

    public static UnitOfWork GetInstance(AppDbContext context)
    {
        if (_instance == null)
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new UnitOfWork(context);
                }
            }
        }
        return _instance;
    }
    public async Task<bool> Complete()
    {
        return await context.SaveChangesAsync() > 0;
    }

    public void Dispose()
    {
        context.Dispose();
    }
    public IGenericRepository<T> Repository<T>() where T : BaseEntity
    {
        if (!_repositories.ContainsKey(typeof(T)))
        {
            _repositories[typeof(T)] = RepositoryFactory.CreateRepository<T>(context);
        }
        return (IGenericRepository<T>)_repositories[typeof(T)];
    }
}
