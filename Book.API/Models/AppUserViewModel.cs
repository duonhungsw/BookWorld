namespace Book.API.Models
{
    public class AppUserViewModel
    {
        public Guid Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string UserName { get; set; }
        public string? PhoneNumber { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public string? PictureUrl { get; set; }
        public bool IsDeleted { get; set; }
        public required RoleViewModel RoleViewModel { get; set; }
    }
}
