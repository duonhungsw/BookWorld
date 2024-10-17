using Book.API.Models;
using Book.Core.Models;

namespace Book.API.Infrastructure.Extensions
{
    public static class EntityExtension
    {
        public static void UpdateAppUser(this AppUser appUser, AppUserViewModel appUserVM)
        {
            appUser.FirstName = appUserVM.FirstName;
            appUser.LastName = appUserVM.LastName;
            appUser.UserName = appUserVM.UserName;
            appUser.PhoneNumber = appUserVM.PhoneNumber;
            appUser.Email = appUserVM.Email;
            appUser.Password = appUserVM.Password;
            appUser.PictureUrl = appUserVM.PictureUrl;
            appUser.IsDeleted = appUserVM.IsDeleted;
        }
    }
}
