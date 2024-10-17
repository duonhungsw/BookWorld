using Book.Common.Entities;

namespace Book.Core.Models;

public class Role : BaseEntity
{
    public required string RoleName { get; set; }
}
