using Book.Core.Interfaces;
using Book.Core.Models;
using Book.Data.Context;

namespace Book.Data.Repositories;

public interface IRoleRepository : IGenericRepository<Role>
{
    bool? GetRoleByName(string roleName);
}
public class RoleRepository : GenericRepository<Role>, IRoleRepository
{
    public RoleRepository(AppDbContext context) : base(context)
    {
    }
    public bool? GetRoleByName(string roleName)
    {
        try
        {
            return _context.Roles
                .Any(x => x.RoleName.Equals(roleName));
        }
        catch (TaskCanceledException ex)
        {
            Console.WriteLine("Task was canceled: " + ex.Message);
            return null;
        }
    }

}
