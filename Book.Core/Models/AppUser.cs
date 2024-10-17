using Book.Common.Entities;
using System.ComponentModel.DataAnnotations;

namespace Book.Core.Models;

public class AppUser : BaseEntity
{
    [Required]
    public  string FirstName { get; set; }
    [Required]

    public  string LastName { get; set; }
    public  string UserName { get; set; }
    public string? PhoneNumber { get; set; }
    [Required]
    public  string Email { get; set; }
    [Required]
    public  string Password { get; set; }
    public string? PictureUrl { get; set; }
    public bool IsDeleted { get; set; }
    [Required]
    public  Role Role { get; set; }

}
