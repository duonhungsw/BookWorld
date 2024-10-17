using Book.Common.Entities;
using Book.Core.Interfaces;
using Book.Data.Context;

namespace Book.Data.Repositories;

public static class RepositoryFactory
{
    public static IGenericRepository<T> CreateRepository<T>(AppDbContext context) where T : BaseEntity
    {
        return new GenericRepository<T>(context);
    }
}
