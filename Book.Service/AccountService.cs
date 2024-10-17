using Book.Common.Entities;
using Book.Common.Extensions;
using Book.Core.Interfaces;
using Book.Core.Models;
using Book.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Book.Service;

public interface IAccountService
{
    Task<AppUser?> GetByIdAsync(Guid id);
    Task<IEnumerable<AppUser>> GetAllAsync();

    void Delete(AppUser entity);
    void Update(AppUser entity);
    void Create(AppUser entity);
    bool Exist(int id);
    bool IsRoleNameExists(string userName);
}
public class AccountService(IUnitOfWork unitOfWork, IRoleRepository roleRepository,
                            IAppUserRepository appUserRepository) : IAccountService
{
    public void Create(AppUser entity)
    {
        var roleExist =  IsRoleNameExists(entity.Role.RoleName.ToLower());
        if (roleExist == false)
        {
            unitOfWork.Repository<Role>().Create(new Role { RoleName = BaseRole.Employee.ToString() });
        }
        entity.Id = Guid.NewGuid();
        entity.Role = new Role { RoleName = BaseRole.Employee.ToString()};
        byte[] salt;
        string hashPassword = PasswordHasher.HashPasswordPBKDF2(entity.Password, out salt);

        entity.Password = hashPassword;

        unitOfWork.Repository<AppUser>().Create(entity);
    }
    public  void Delete(AppUser entity) =>  unitOfWork.Repository<AppUser>().Delete(entity);
    public bool Exist(int id) => unitOfWork.Repository<AppUser>().Exist(id);
    public Task<IEnumerable<AppUser>> GetAllAsync() => unitOfWork.Repository<AppUser>()
                                                    .GetAllAsync(query => query.Include(x => x.Role));
    public async Task<AppUser?> GetByIdAsync(Guid id) => await unitOfWork.Repository<AppUser>().GetByIdAsync(id);
    public bool IsRoleNameExists(string userName) 
        =>  roleRepository.CheckIfExists<Role>(x => x.RoleName == userName);
    public void Update(AppUser entity) => unitOfWork.Repository<AppUser>().Update(entity);
 
}
