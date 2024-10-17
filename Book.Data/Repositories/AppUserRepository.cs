using Book.Core.Interfaces;
using Book.Core.Models;
using Book.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Book.Data.Repositories;

public interface IAppUserRepository : IGenericRepository<AppUser>
{
    Task<AppUser?> GetRoleByName(string roleName);
}
public class AppUserRepository : GenericRepository<AppUser>, IAppUserRepository
{
    public AppUserRepository(AppDbContext context) : base(context)
    {
    }
    public async Task<AppUser?> GetRoleByName(string roleName)
    {
        return await _context.AppUsers
            .FirstOrDefaultAsync(u => u.Role.RoleName == roleName);
    }

}

