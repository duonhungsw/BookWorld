using System.ComponentModel.DataAnnotations;

namespace Book.Common.Entities;

public class BaseEntity
{
    [Key]
    public Guid Id { get; set; } = new Guid();
}
